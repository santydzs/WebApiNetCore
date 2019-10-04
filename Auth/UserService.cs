using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.DbModels;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Auth.Logic
{
    public class UserService
    {
        private IConfiguration Config { get; set; }

        public UserService(IConfiguration config)
        {
            Config = config;
        }

        public LogInfo Authenticate(string email, string password)
        {
            AuthDBContext db = new AuthDBContext();
            Users user = db.Users.Where(x => x.Email == email && x.Pass == password).FirstOrDefault();

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
    }
}
