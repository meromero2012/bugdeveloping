using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;
using FrbaBus.Canje_de_Ptos;



namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    public partial class ConsultaPuntos : BaseForm
    {
        public ConsultaPuntos()
            :base()
        {
            InitializeComponent();
        }

        ConnectorClass conn;

        private void FormFiltrarRol_Load(object sender, EventArgs e)
        {

        }

        //Busca en la BBDD el dni, si lo encuentra devuelve el calculo de puntos acumulados,
        //caso contrario devuelve un error.
        private void bFiltrar_Click(object sender, EventArgs e)
        {
            conn = ConnectorClass.Instance;
            cantidadLabel.Text = FuncionesCanjePuntos.getPuntosDisponibles(txtbDNI.Text);   
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
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
