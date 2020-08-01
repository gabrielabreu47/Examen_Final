using Database.Entities;
using Services.EtitiesRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices
    {
        User user = new User();
        UserRepository userRepository = new UserRepository();

        public bool Add(string Name, string Lastname, string Mail, string Username, string Password, string Profilepic)
        {
            user.Name = Name;
            user.LastName = Lastname;
            user.Mail = Mail;
            user.Username = Username;
            user.Password = Password;
            user.ProfilePicture = Profilepic;
            return userRepository.Add(user);

        }
        public DataTable Get(string query)
        {
            return userRepository.GetSpecific(query);
        }
        public int ID_User_Logged()
        {
            return UserLogged.Instance.user.ID_User;
        }
    }
}
