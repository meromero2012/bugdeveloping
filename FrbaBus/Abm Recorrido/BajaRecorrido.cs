using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.Abm_Recorrido
{
    public partial class BajaRecorrido : Form
    {
        public BajaRecorrido()
        {
            InitializeComponent();
        }

        public string codigoRecorrido = "";

        private void BajaRecorrido_Load(object sender, EventArgs e)
        {
            loadRecorridoData();
        }

        private void loadRecorridoData()
        {
            label_CodigoRecorrido.Text = codigoRecorrido;

            DataTable Dt = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerCamposDeRecorrido(label_CodigoRecorrido.Text);

            textBox_TipoServicio.Text = Dt.Rows[0].ItemArray[1].ToString();
            textBox_PrecioKG.Text = Dt.Rows[0].ItemArray[4].ToString();
            textBox_PrecioPasaje.Text = Dt.Rows[0].ItemArray[5].ToString();
            textBox_CiudadOrigen.Text = Dt.Rows[0].ItemArray[2].ToString();
            textBox_CiudadDestino.Text = Dt.Rows[0].ItemArray[3].ToString();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable viajesDeRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.ViajesDeRecorridoApartirDeFecha(codigoRecorrido, DateTime.Today);
            //aca hago un for por cada uno y obtengo en nroDeViaje
            foreach (DataRow row in viajesDeRecorrido.Rows)
            {
                string codigoCompra = row.ItemArray[0].ToString();

                Boolean esPasaje = FrbaBus.CancelarViaje.FuncionesCancelarViaje.esPasaje(codigoCompra);

                if (esPasaje)
                    FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarPasaje(codigoCompra);
                else
                    FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarEncomienda(codigoCompra);

                FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarCancelacion(codigoCompra, "Recorrido Dado de baja");
            }
            MessageBox.Show("El recorrido fue dado de baja", "Baja de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrbaBus.Abm_Recorrido.FuncionesRecorridos.DarDeBajaARecorrido(codigoRecorrido);
            Close();
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
