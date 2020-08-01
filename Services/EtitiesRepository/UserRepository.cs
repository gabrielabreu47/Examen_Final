using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using Database.Entities;

namespace Services.EtitiesRepository
{
    class UserRepository : Repository, IRepository<Database.Entities.User>
    {
        public bool Add(User item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO USERS (NAME, LASTNAME, PROFILE_PICTURE, EMAIL, USERNAME, PASSWORD) "
                                               + "VALUES(@name, @lastname, @profilepic, @email, @username, @pass)");
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@lastname", item.LastName);
            command.Parameters.AddWithValue("@profilepic", item.ProfilePicture);
            command.Parameters.AddWithValue("@email", item.Mail);
            command.Parameters.AddWithValue("@username", item.Username);
            command.Parameters.AddWithValue("@pass", item.Password);

            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE USERS WHERE ID_USER = @ID");
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(User item)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }
    }
}
