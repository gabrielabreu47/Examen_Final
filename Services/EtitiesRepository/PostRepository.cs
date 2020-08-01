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
    class PostRepository : Repository, IRepository<Post>
    {
        public bool Add(Post item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO POST (TITLE, CAPTION, TIMEDATE, ID_USER, VISIBLE) "
                                               + "VALUES(@title, @caption, @timedate, @id_user, @visible)");
            command.Parameters.AddWithValue("@title", item.Title);
            command.Parameters.AddWithValue("@caption", item.Caption);
            command.Parameters.AddWithValue("@timedate", item.TimeDate);
            command.Parameters.AddWithValue("@id_user", item.ID_User);
            command.Parameters.AddWithValue("@visible", item.Visible);


            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE POST WHERE ID_POST = @ID");
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(Post item)
        {
            SqlCommand command = new SqlCommand("UPDATE POST SET TITLE = @title, CAPTION = @caption, TIMEDATE = @timedate, ID_USER = @id_user,"
                +" VISIBLE = @visible WHERE ID_POST = @ID");
            command.Parameters.AddWithValue("@title", item.Title);
            command.Parameters.AddWithValue("@caption", item.Caption);
            command.Parameters.AddWithValue("@timedate", item.TimeDate);
            command.Parameters.AddWithValue("@id_user", item.ID_User);
            command.Parameters.AddWithValue("@visible", item.Visible);
            command.Parameters.AddWithValue("@ID", item.ID_Post);
            return ExecuteDml(command);
        }

        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }
        public bool EditVisibility(int ID,int state)
        {
            SqlCommand command = new SqlCommand("UPDATE POST SET VISIBLE = @visible WHERE ID_POST = @ID");
            command.Parameters.AddWithValue("@visible", state);
            command.Parameters.AddWithValue("@ID", ID);
            return ExecuteDml(command);

        }
    }
}
