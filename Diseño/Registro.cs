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
    public partial class Registro : Form
    {
        UserServices userServices = new UserServices();
        public Registro()
        {
            InitializeComponent();
        }
        private string ProfilePicture { get; set; }
        private void setProfilePic()
        {
            DialogResult dr = Photo.ShowDialog();
            if(dr == DialogResult.OK)
            {
                ProfilePicture = Photo.FileName;
                pictureBox1.ImageLocation = ProfilePicture;
            }
        }
        private void Save()
        {
            if(userServices.Add(txtNombre.Text, txtApellido.Text, txtMail.Text, txtUsuario.Text, txtContra.Text, pictureBox1.ImageLocation))
            {
                MessageBox.Show("Usuario agregado correctamente");
            }
            else
            {
                MessageBox.Show("El usuario no pudo ser agregado");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setProfilePic();
        }
        bool existe;
        private void Existe()
        {
            DataTable dt = new DataTable();
            dt = userServices.Get("SELECT * FROM USERS WHERE USERNAME = '"+txtUsuario.Text+"'");
            if(dt == null)
            {
                existe = false;
            }
            else if( dt.Rows.Count == 0)
            {
                existe = false;
            }
            else
            {
                existe= true;
            }
        }
        private void btnNC_Click(object sender, EventArgs e)
        {
            if (txtContra.Text != "" | txtConContra.Text != "")
            {
                if (txtContra.Text != txtConContra.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
                else
                {
                    if (txtNombre.Text != "" | txtApellido.Text != "" | txtUsuario.Text != "")
                    {
                        Existe();
                        if (!existe)
                        {
                            Save();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario no esta disponible");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe llenar todos los campos");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }
    }
}
