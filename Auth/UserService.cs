using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.DbModels;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Auth.Models;
using System.Threading.Tasks;

namespace Auth.Logic
{
    public class UserService
    {
        private IConfiguration Config { get; set; }
        private AuthDBContext _repo { get; set; }

        public UserService(IConfiguration config, AuthDBContext repo)
        {
            _repo = repo;
            Config = config;
        }

        public LogInfo Authenticate(string email, string password)
        {
            Users user = _repo.Users.Where(x => x.Email == email && x.Pass == password).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Config.GetValue<string>("JWT:key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LogInfo() { token = tokenHandler.WriteToken(token), user = email };
        }

        public async Task<int> CreateUser(CreateUserDTO user)
        {
            var userdb = new Users()
            {
                Email = user.email,
                Pass = user.pass
            };

            _repo.Users.Add(userdb);

            int result = await _repo.SaveChangesAsync();

            return userdb.Id;
        }
    }
}
