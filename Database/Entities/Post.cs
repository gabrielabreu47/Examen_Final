using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Post
    {
        public int ID_Post { get; set; }
        public int ID_User { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string TimeDate { get; set; }
        public int Visible { get; set; }
    }
}
