using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
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
    }
}
