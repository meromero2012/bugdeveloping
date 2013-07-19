using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.AuthentificationSystem;

namespace FrbaBus.Login
{
    public partial class Operacion : BaseForm
    {
        public Operacion():
               base()
        {
            InitializeComponent();
        }

        private void Operacion_Load(object sender, EventArgs e)
        {

        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void continuarButton_Click(object sender, EventArgs e)
        {
            if (clienteRadioButton.Checked)
            {
                AccountManagment.LogUser("clienteUser", "w23e");
                this.Hide();

                Program.MenuPrincipal = new FrbaBus.MenuPrincipal.MenuPrincipal();
                Program.MenuPrincipal.ShowDialog(this);
            }
            else
            {
                (new Login()).Show();
                this.Hide();
            }
        }
    }
}
