using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Models
{
    public class CreateUserDTO
    {
        public string email { get; set; }

        public string pass { get; set; }
    }
}
