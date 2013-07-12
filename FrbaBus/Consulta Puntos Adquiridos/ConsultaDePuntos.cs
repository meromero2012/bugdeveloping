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

        private void bFiltrar_Click(object sender, EventArgs e)
        {
            conn = ConnectorClass.Instance;
            cantidadLabel.Text = FuncionesCanjePuntos.getPuntosDisponibles(txtbDNI.Text,DateTime.Now);
           

          }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }

    }
}
