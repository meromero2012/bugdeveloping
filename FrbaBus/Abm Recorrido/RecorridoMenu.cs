using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoMenu : BaseForm
    {
        public RecorridoMenu()
            :base()
        {
            InitializeComponent();
        }

        private void RecorridoMenu_Load(object sender, EventArgs e)
        {
        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            (new AltaRecorrido()).ShowDialog();
        }

        private void bajaButton_Click(object sender, EventArgs e)
        {
            (new ListadoRecorridos()).ShowDialog();
        }

        private void modificacionButton_Click(object sender, EventArgs e)
        {
            ListadoRecorridos formListadoRecorridos = new ListadoRecorridos();
            formListadoRecorridos.esModificacion = true;
            formListadoRecorridos.ShowDialog();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
