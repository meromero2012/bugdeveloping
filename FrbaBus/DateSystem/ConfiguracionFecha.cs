using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FrbaBus.DateSystem
{
    public partial class ConfiguracionFecha : BaseForm
    {
        public ConfiguracionFecha():
               base()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* En este metodo se setea en windows la fecha ingresada en el formulario*/
        private void siguienteButton_Click(object sender, EventArgs e)
        {
            MySystemDate.setSystemDate((short)Convert.ToInt32((anioTextBox.Text)), (short)Convert.ToInt32((mesTextBox.Text)), (short)Convert.ToInt32((diaTextBox.Text)));

            MessageBox.Show("Fecha Cambiada.");
            this.Hide();

            FrbaBus.Login.Login frmLogin = new FrbaBus.Login.Login();
            frmLogin.Show();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solamente valores numericos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // Evita que se puedan ingresar puntos para valores decimales
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') < 0)
                e.Handled = true;
        }
    }
}
