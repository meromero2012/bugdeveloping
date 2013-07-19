using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;
using System.Data;
using FrbaBus.Login;


namespace FrbaBus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static MenuPrincipal.MenuPrincipal MenuPrincipal;
        [STAThread]
        static void Main()
        {
            Application.Run(new FrbaBus.Login.Login());
        }

    }
}
