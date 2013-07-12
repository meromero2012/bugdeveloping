using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroMenu : BaseForm
    {
        public MicroMenu()
            :base()
        {
            InitializeComponent();
        }

        private void MicroMenu_Load(object sender, EventArgs e)
        {

        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            (new microAlta()).ShowDialog();
        }

        private void bajaButton_Click(object sender, EventArgs e)
        {
            (new MicroBaja()).ShowDialog();
        }

        private void modificacionButton_Click(object sender, EventArgs e)
        {
            (new Micro_Modificacion()).ShowDialog();
        }

        private void volverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
