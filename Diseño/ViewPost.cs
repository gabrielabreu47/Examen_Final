using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Diseño
{
    public partial class ViewPost : UserControl
    {
        PostServices postServices = new PostServices();
        private string route;
        private string nombre;
        private string title;
        private string caption;
        private string timeDate;
        public int ID_Post { get; set; }
        public bool Visible { get; set; }



        [Category("Post Prop")]
        public string Route
        {
            get { return route; }
            set { route = value;pbProfilePic.ImageLocation = value; }
        }

        [Category("Post Prop")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; lbName.Text = value; }
        }

        [Category("Post Prop")]
        public string Title
        {
            get { return title; }
            set { title = value;lbTitle.Text = value; }
        }

        [Category("Post Prop")]
        public string Caption
        {
            get { return caption; }
            set { caption = value;lbCaption.Text = value; }
        }


        public string TimeDate
        {
            get { return timeDate; }
            set { timeDate = value; lbDateTime.Text = value; }
        }


        public ViewPost()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ID_Post = ID_Post;
            options.visible = Visible;
            DialogResult dr = options.ShowDialog();
            if(dr == DialogResult.Yes)
            {
                Post post = new Post();
                post.Editar = true;
                post.PostEdit = postServices.Get("SELECT * FROM POST WHERE ID_POST = " + ID_Post);
                post.ShowDialog();
            }
            else if(dr == DialogResult.No)
            {
                if (postServices.EditVisiblity(ID_Post, 0))
                {
                    MessageBox.Show("El post fue ocultado");
                }
                else
                {
                    MessageBox.Show("La accion no pudo realizarse correctamente");
                }
            }
            else if(dr == DialogResult.OK)
            {
                if (postServices.Delete(ID_Post))
                {
                    MessageBox.Show("Publicacion eliminada correctamente");
                }
                else
                {
                    MessageBox.Show("La accion no pudo realizarse correctamente");
                }
            }
            else if(dr == DialogResult.Retry)
            {
                if (postServices.EditVisiblity(ID_Post, 1))
                {
                    MessageBox.Show("El post ya puede ser visualizado");
                }
                else
                {
                    MessageBox.Show("La accion no pudo realizarse correctamente");
                }
            }
            options.Close();
            options.Dispose();
            OnRefresh(e);

        }

        public event EventHandler refresh;
        protected virtual void OnRefresh(EventArgs e)
        {
            var handler = refresh;
            if (handler != null)
                handler(this, e);

        }

    }
}
