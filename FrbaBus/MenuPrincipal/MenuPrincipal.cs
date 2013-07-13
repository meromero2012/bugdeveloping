using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.AuthentificationSystem;
using FrbaBus.Compra_de_Pasajes;
using FrbaBus.CancelarViaje;
using FrbaBus.Canje_de_Ptos;
using FrbaBus.Top_5;
using FrbaBus.Consulta_Puntos_Adquiridos;
using FrbaBus.Registrar_LLegada_Micro;
using FrbaBus.Abm_Recorrido;
using FrbaBus.Abm_Micro;
using FrbaBus.Abm_Permisos;

namespace FrbaBus.MenuPrincipal
{
    public partial class MenuPrincipal : BaseForm
    {
        public MenuPrincipal():
               base()
        {
            InitializeComponent();
        }

        /* Se habilitan los diferentes menues segun el rol del usuario logueado */
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control button in this.tableLayoutPanel1.Controls)
            {
                Permission actualPermission = AccountManagment.ActualUser.Permissions.FirstOrDefault(i=>"permission" + i.Id==button.Name);
                if (actualPermission != null)
                {
                    button.Enabled = true;
                    button.Text = actualPermission.Name;
                }
                else button.Enabled = false;
            }
            this.salirButton.Enabled = true;
        }

        private void permission1_Click(object sender, EventArgs e)
        {
            OpenWindow<MicroMenu>();
        }

        private void permission5_Click(object sender, EventArgs e)
        {
            OpenWindow<IngresoDatosViaje>();
        }

        private void permission3_Click(object sender, EventArgs e)
        {
            OpenWindow<CancelarViaje.CancelarViaje>();
        }

        private void permission4_Click(object sender, EventArgs e)
        {
            OpenWindow<CanjePuntos>();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void permission8_Click(object sender, EventArgs e)
        {
            OpenWindow<ListadoEstadistico>();
        }

        private void permission9_Click(object sender, EventArgs e)
        {
            OpenWindow<ConsultaPuntos>();
        }

        private void permission7_Click(object sender, EventArgs e)
        {
            OpenWindow<RegistrarLlegada>();
        }

        /* Esta funcion evita realizar repeticiones de codigo, centralizando el codigo de apertura
         * de ventanas nuevas en un solo metodo*/
        private void OpenWindow<T>()
            where T : BaseForm, new()
        {
            T form = new T();
            form.Show();
            this.Hide();
        }

        private void permission6_Click(object sender, EventArgs e)
        {
            OpenWindow<GenerarViaje.GenerarViaje>();
        }

        private void permission2_Click(object sender, EventArgs e)
        {
            OpenWindow<RecorridoMenu>();
        }

        private void permission10_Click(object sender, EventArgs e)
        {
            OpenWindow<RolMenu>();
        }
    }
}
