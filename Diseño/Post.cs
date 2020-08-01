using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Post : Form
    {
        public bool Editar { get; set; }
        public DataTable PostEdit { get; set; }

        PostServices postServices = new PostServices();
        UserServices userServices = new UserServices();
        public Post()
        {
            InitializeComponent();
        }

        #region Txt
        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            if(txtTitulo.Text == "Titulo")
            {
                txtTitulo.Text = "";
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if(txtTitulo.Text == "")
            {
                txtTitulo.Text = "Titulo";
            }
        }

        private void txtCuerpo_Enter(object sender, EventArgs e)
        {
            if (txtCuerpo.Text == "Cuerpo")
            {
                txtCuerpo.Text = "";
            }
        }

        private void txtCuerpo_Leave(object sender, EventArgs e)
        {
            if (txtCuerpo.Text == "")
            {
                txtCuerpo.Text = "Cuerpo";
            }
        }
        #endregion
        private void Save()
        {
            if(postServices.Add(txtTitulo.Text, txtCuerpo.Text, System.DateTime.UtcNow.ToShortDateString().ToString() + " " 
                + System.DateTime.Now.ToShortTimeString().ToString(), userServices.ID_User_Logged()))
            {
                MessageBox.Show("Publicacion guardada correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo guardar la publicacion");
            }
        }
        private void LoadData()
        {
            txtTitulo.Text = PostEdit.Rows[0][1].ToString();
            txtCuerpo.Text = PostEdit.Rows[0][2].ToString();
        }
        private void Edit()
        {
            if(postServices.Edit(txtTitulo.Text, txtCuerpo.Text, PostEdit.Rows[0][3].ToString(), Convert.ToInt32(PostEdit.Rows[0][4].ToString()), Convert.ToInt32(PostEdit.Rows[0][0].ToString())))
            {
                MessageBox.Show("Publicacion editada correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo editar la publicacion");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Editar)
            {
                Save();
            }
            else
            {
                Edit();
            }
        }

        private void Post_Load(object sender, EventArgs e)
        {
            if (Editar)
            {
                LoadData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
