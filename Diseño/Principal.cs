using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
namespace Diseño
{
    public partial class Principal : Form
    {
        DataTable dt;
        bool Min = true;
        bool visible = false;
        public Principal()
        {
            InitializeComponent();
        }
        private void GetPosts(int state)
        {
            UserServices userServices = new UserServices();
            string query = "SELECT P.ID_POST, U.NAME, U.LASTNAME, U.PROFILE_PICTURE, P.TITLE, P.CAPTION, P.TIMEDATE FROM POST P" +
                " INNER JOIN USERS U ON P.ID_USER = U.ID_USER" +
                " WHERE P.ID_USER = " + userServices.ID_User_Logged().ToString() + " AND P.VISIBLE = "+ state;
            PostServices postServices = new PostServices();
            
            dt = postServices.Get(query);

        }
        private void ajustar(Control control)
        {
            control.Size = new System.Drawing.Size(flowLayoutPanel1.Size.Width, 182);
        }
        private void LoadPosts(int index)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls.Clear();
            }
            ViewPost[] Post = new ViewPost[index];
            for(int i = 0; i<Post.Length; i++)
            {
                ViewPost post = new ViewPost();
                post.Title = dt.Rows[i][4].ToString();
                post.Caption = dt.Rows[i][5].ToString();
                post.TimeDate = dt.Rows[i][6].ToString();
                post.Route = dt.Rows[i][3].ToString();
                post.Nombre = dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString();
                post.ID_Post = Convert.ToInt32(dt.Rows[i][0].ToString());
                post.Visible = visible;
                ajustar(post);
                post.refresh += refresh;
                Post[i] = post;
                flowLayoutPanel1.Controls.Add(Post[i]);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            GetPosts(1);
            LoadPosts(dt.Rows.Count);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.Editar = false;
            if(post.ShowDialog() == DialogResult.Yes)
            {
                dt = new DataTable();
                GetPosts(1);
                LoadPosts(dt.Rows.Count);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UserLogged.Instance.logOut();
            Login login = new Login();
            login.Show();
            this.Hide();
        }



        private void refresh(object sender, EventArgs e)
        {
            visible = false;
            dt = new DataTable();
            GetPosts(1);
            LoadPosts(dt.Rows.Count);
            btnVisible.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Min)
            {
                this.WindowState = FormWindowState.Maximized;
                Min = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Min = true;
            }
            if (flowLayoutPanel1.Controls.Count > 0) {
                for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    ajustar(flowLayoutPanel1.Controls[i]);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            if (!visible)
            {
                visible = true;
                dt = new DataTable();
                GetPosts(0);
                LoadPosts(dt.Rows.Count);
                btnVisible.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {

                visible = false;
                dt = new DataTable();
                GetPosts(1);
                LoadPosts(dt.Rows.Count);
                btnVisible.BorderStyle = BorderStyle.None;
            }
        }
    }
}
