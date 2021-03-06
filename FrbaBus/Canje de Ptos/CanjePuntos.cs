﻿using System;
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

        /* Una vez consultada la base de datos se carga en el combobox de productos, aquellos productos
         * que puedan ser canjeados con los puntos del cliente */
        private void setProductosComboBox(DataTable dt)
        {
            productosComboBox.DataSource = dt;
            productosComboBox.ValueMember = "PRODUCTO_ID";
            productosComboBox.DisplayMember = "PRODUCTO_DETALLE";
        }

        private void resetFormPorPuntosInsuficientes()
        {
            puntosLabel.Text = "-";
            puntosLabel.Enabled = false;
            dniTextBox.Text = "";
            dniTextBox.Enabled = true;
            buscarDniButton.Enabled = true;
        }

        /* Verifica que el dni ingresado este registrado en la base de datos, de ser asi se cargan los puntos
         * disponibles y los productos que se pueden canjear */
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

                    String puntosDisponibles = FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.getPuntosDisponibles(dni);
                    productosQuePuedeCanjearDt = FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.getProductosDisponibles(puntosDisponibles);

                    puntosLabel.Text = puntosDisponibles;
                    puntosLabel.Enabled = true;

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

        /* Se realiza el canje y se actualiza el stock del producto, junto con el canje realizado */
        private void canjearButton_Click(object sender, EventArgs e)
        {
            String productoSeleccionado = productosComboBox.SelectedValue.ToString();
            FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.updateProducto(productoSeleccionado);
            FrbaBus.Canje_de_Ptos.FuncionesCanjePuntos.insertCanje(dniTextBox.Text, productosComboBox.SelectedValue.ToString());
            MessageBox.Show("Canje realizado exitosamente");
            volverButton_Click(sender, e);
        }

        private void CanjePuntos_Load(object sender, EventArgs e)
        {

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
