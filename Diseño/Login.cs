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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text != "" | txtPassword.Text != "")
            {
                UserServices userServices = new UserServices();
                DataTable dt = new DataTable();
                dt = userServices.Get("SELECT * FROM USERS WHERE USERNAME = '" + txtUser.Text + "' AND PASSWORD = '" + txtPassword.Text + "'");
                if(dt.Rows.Count == 1)
                {
                    UserLogged.Instance.logIn(dt);
                    Principal principal = new Principal();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectas");
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnNC_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
        }
    }
}
