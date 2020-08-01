using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class User
    {
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
