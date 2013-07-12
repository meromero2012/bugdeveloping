using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Canje_de_Ptos
{
    public partial class CanjePuntos : BaseForm
    {
        DataTable productosQuePuedeCanjearDt;

        public CanjePuntos():
               base()
        {
            InitializeComponent();
        }

        private void setProductosComboBox(DataTable dt)
        {
            productosComboBox.DataSource = dt;
            productosComboBox.ValueMember = "PRODUCTO_ID";
            productosComboBox.DisplayMember = "PRODUCTO_DETALLE";
        }

        private void resetFormPorPuntosInsuficientes()
        {
            puntosTextBox.Text = "";
            puntosTextBox.Enabled = false;
            dniTextBox.Text = "";
            dniTextBox.Enabled = true;
            buscarDniButton.Enabled = true;
        }

        private void buscarDniButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            String dni = dniTextBox.Text;

            if (!dni.Equals(""))
            {
                String estaEnBBDD = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDNI(dni);

                if (!estaEnBBDD.Equals("0"))
                {
                    dniTextBox.Enabled = false;
                    buscarDniButton.Enabled = false;

                    String puntosDisponibles = FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.getPuntosDisponibles(dni, DateTime.Now);
                    productosQuePuedeCanjearDt = FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.getProductosDisponibles(puntosDisponibles);

                    puntosTextBox.Text = puntosDisponibles;
                    puntosTextBox.Enabled = true;

                    if (productosQuePuedeCanjearDt.Rows.Count != 0)
                    {
                        setProductosComboBox(productosQuePuedeCanjearDt);
                        productosComboBox.Enabled = true;
                        canjearButton.Enabled = true;
                    }
                    else
                    {
                        errorLabel.Text = "No posee puntos suficientes para realizar el canje.";
                        resetFormPorPuntosInsuficientes();
                    }

                }
                else
                    errorLabel.Text = "No se ha encontrado el dni ingresado.";

            }
        }

        private void canjearButton_Click(object sender, EventArgs e)
        {
            String productoSeleccionado = productosComboBox.SelectedValue.ToString();
            FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.updateProducto(productoSeleccionado);
            FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.insertCanje(dniTextBox.Text, productosComboBox.SelectedValue.ToString());
        }

        private void CanjePuntos_Load(object sender, EventArgs e)
        {

        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
