using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
namespace Diseño
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }
        PostServices postServices = new PostServices();
        public int ID_Post { get; set; }
        public bool visible { get; set; }

        private void Options_Load(object sender, EventArgs e)
        {
            if (visible)
            {
                btnHide.Text = "Mostrar";
                btnHide.DialogResult = DialogResult.Retry;
            }
            else
            {
                btnHide.Text = "Ocultar publicacion";
                btnHide.DialogResult = DialogResult.No;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            
            this.Hide();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
