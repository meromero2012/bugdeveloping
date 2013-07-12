using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.AuthentificationSystem
{
    public class UserInformation
    {
        public String Username { get; set; }
        public String UserId { get; set; }
        public RoleEnum Role { get; set; }
        public List<Permission> Permissions { get; set; }
        public UserInformation() { Permissions = new List<Permission>(); }
    }
}
