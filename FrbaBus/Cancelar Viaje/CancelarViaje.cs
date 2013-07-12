using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.CancelarViaje
{
    public partial class CancelarViaje : BaseForm
    {
        public static String nroVoucherIngresado;
        public DataTable viajesDt;
        public int totalViajesSeleccionados;

        public CancelarViaje():
               base()
        {
            InitializeComponent();
        }

        /*Busca todos los pasajes/encomiendas correspondientes a un numero de voucher. Los lista con detalle dni + fecha de salida*/
        private void buscarButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
 
            if (nvoucherTextBox.Text.Equals(""))
                errorLabel.Text = "Ingrese un número de voucher valido.";
            else
            {
                nroVoucherIngresado = FrbaBus.CancelarViaje.FuncionesCancelarViaje.getNroVoucher(nvoucherTextBox.Text);

                if (nroVoucherIngresado.Equals(""))
                    errorLabel.Text = "Ingrese un número de voucher valido.";
                else
                {
                    viajesDt = FrbaBus.CancelarViaje.FuncionesCancelarViaje.getViajes(nroVoucherIngresado);

                    if (viajesDt.Rows.Count != 0)
                    {
                        viajesCheckedListBox.DataSource = viajesDt;
                        viajesCheckedListBox.DisplayMember = "DATOS_VIAJE";
                        viajesCheckedListBox.ValueMember = "COMPRA_CODIGO_PASAJE_ENCOMIENDA";
                    }
                    else
                        errorLabel.Text = "No se puede operar sobre este número de voucher.";
                }
            }
        }

        private void CancelarViaje_Load(object sender, EventArgs e)
        {

        }

        /*Agrega un registro por cada pasaje/encomienda seleccionado en el listado liberando los kgs y butacas correspondientes*/
        private void cancelacionButton_Click(object sender, EventArgs e)
        {
            errorViajeLabel.Text = "";

            totalViajesSeleccionados = Convert.ToInt16(viajesCheckedListBox.CheckedItems.Count.ToString());

            if (totalViajesSeleccionados > 0)
            {
                foreach (DataRowView indexChecked in viajesCheckedListBox.CheckedItems)
                {
                    String nroViaje = indexChecked["COMPRA_CODIGO_PASAJE_ENCOMIENDA"].ToString();
                    Boolean esPasaje = FrbaBus.CancelarViaje.FuncionesCancelarViaje.esPasaje(nroViaje);

                    if (esPasaje)
                        FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarPasaje(nroViaje);
                    else
                        FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarEncomienda(nroViaje);

                    FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarCancelacion(nroViaje, motivoTextBox.Text);
                }

                nvoucherTextBox.Text = "";
                viajesCheckedListBox.DataSource = null;
                viajesCheckedListBox.DisplayMember = null;
                viajesCheckedListBox.ValueMember = null;

                MessageBox.Show("Cancelaciones realizadas");
            }
            else
                errorViajeLabel.Text = "Debe seleccionar al menos un viaje.";
        }

        private void menuPrincipalButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
