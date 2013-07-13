using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
    /* Setea un standar de ventana para todos los menues */
    public class BaseForm : Form
    {
        public BaseForm()
            :base()
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.Text = this.Name;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
