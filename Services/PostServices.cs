using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using Services.EtitiesRepository;

namespace Services
{
    public class PostServices
    {
        Post post = new Post();
        PostRepository postRepository = new PostRepository();

        public bool Add(string Title, string Caption, string TimeDate, int ID_User, int Visible = 1)
        {
            post.Title = Title;
            post.Caption = Caption;
            post.TimeDate = TimeDate;
            post.ID_User = ID_User;
            post.Visible = Visible;
            return postRepository.Add(post);
        }
        public bool Edit(string Title, string Caption, string TimeDate, int ID_User, int ID_Post, int Visible = 1)
        {
            post.Title = Title;
            post.Caption = Caption;
            post.TimeDate = TimeDate;
            post.ID_User = ID_User;
            post.Visible = Visible;
            post.ID_Post = ID_Post;
            return postRepository.Edit(post);
        }

        public bool EditVisiblity(int ID, int State)
        {
            return postRepository.EditVisibility(ID, State);
        }
        public bool Delete(int id)
        {
            return postRepository.Delete(id);
        }
        public DataTable Get(string query)
        {
            return postRepository.GetSpecific(query);
        }
    }
}
