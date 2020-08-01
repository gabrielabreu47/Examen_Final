using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using System.Data;
namespace Services
{
    public sealed class UserLogged
    {
        public User user { get; set; } = null;

        public static UserLogged Instance { get; } = new UserLogged();

        public void logIn(DataTable dt)
        {
            User user = new User();
            user.ID_User = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            user.Name = dt.Rows[0].ItemArray[1].ToString();
            user.LastName = dt.Rows[0].ItemArray[2].ToString();
            user.ProfilePicture = dt.Rows[0].ItemArray[3].ToString();
            user.Mail = dt.Rows[0].ItemArray[4].ToString();
            user.Username = dt.Rows[0].ItemArray[5].ToString();
            user.Password = dt.Rows[0].ItemArray[6].ToString();
            this.user = user;
        }
        public void logOut()
        {
            User user = new User();
            user.ID_User = 0;
            user.Name = "";
            user.LastName = "";
            user.Mail = "";
            user.ProfilePicture = "";
            user.Username = "";
            user.Password = "";
            this.user = user;
        }
        private UserLogged()
        {
            
        }

    }
}
