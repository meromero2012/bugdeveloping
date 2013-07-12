using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Login;
using FrbaBus.AuthentificationSystem;

namespace FrbaBus.Login
{
    public partial class Login : BaseForm
    {

        public Login()
            :base()
        {
            InitializeComponent();
        }

        private void buttonINGRESAR_Click(object sender, EventArgs e)
        {
            String errorMessage= AccountManagment.LogUser(textBoxUSER.Text, textBoxPASSWORD.Text);
            if (errorMessage == null)
            {
                MessageBox.Show("Ingreso Exitoso");
                this.Hide();

                Program.MenuPrincipal= new FrbaBus.MenuPrincipal.MenuPrincipal();
                Program.MenuPrincipal.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBoxPASSWORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonINGRESAR.PerformClick();
                e.Handled = true;
            }
        }
    }
}
