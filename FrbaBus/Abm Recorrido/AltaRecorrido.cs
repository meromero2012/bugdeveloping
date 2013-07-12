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
    public partial class AltaRecorrido : Form
    {
        public AltaRecorrido()
        {
            InitializeComponent();
        }

        private void AltaRecorrido_Load(object sender, EventArgs e)
        {
                DataTable DtCiudadesDestino;
            //Lleno los Combo Box de Ciudades
            DtCiudadesDestino = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTablaCiudades();
            comboBox_CiudadDestino.DataSource = DtCiudadesDestino;
            comboBox_CiudadDestino.DisplayMember = "CIUDAD_NOMBRE";
            comboBox_CiudadDestino.ValueMember = "CIUDAD_ID";
            comboBox_CiudadDestino.Enabled = true;

            DataTable DtCiudadesOrigen;
            DtCiudadesOrigen = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTablaCiudades();
            comboBox_CiudadOrigen.DataSource = DtCiudadesOrigen;
            comboBox_CiudadOrigen.DisplayMember = "CIUDAD_NOMBRE";
            comboBox_CiudadOrigen.ValueMember = "CIUDAD_ID";
            comboBox_CiudadOrigen.Enabled = true;
            //Lleno el Combo Box Tipo de servicio
            DataTable DtTipoServicios;
            DtTipoServicios = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTipoServicios();
            comboBox_TipoServicio.DataSource = DtTipoServicios;
            comboBox_TipoServicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBox_TipoServicio.ValueMember = "TIPO_SERVICIO_CODIGO";
            comboBox_TipoServicio.Enabled = true;

        }


        
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            object tipoServicio = comboBox_TipoServicio.SelectedValue;
            object ciudadOrigen = comboBox_CiudadOrigen.SelectedValue;
            object ciudadDestino = comboBox_CiudadDestino.SelectedValue;
            string precioKG = textBox_PrecioKG.Text;
            string precioPasaje = textBox_PrecioPasaje.Text;
            string mensaje2 = "Los siguientes campos son obligatorios y estan sin cargar:";
            bool faltanDatos = false;
/*
            if (codigoRecorrido == "")
            {
                mensaje2 += " Codigo Recorrido ";
                faltanDatos = true;
            }
*/
            if (precioKG == "")
            {
                mensaje2 += " Precio KG ";
                faltanDatos = true;
            }

            if (precioPasaje == "")
            {
                mensaje2 += " Precio Pasaje ";
                faltanDatos = true;
            }
          
            if (faltanDatos == true)
            {
                MessageBox.Show(mensaje2, "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataTable resultadoInsertarNuevoRecorrido;
                resultadoInsertarNuevoRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.InsertarNuevoRecorrido(tipoServicio, ciudadOrigen, ciudadDestino, precioKG, precioPasaje);

                string resultado = resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[0].ToString();
                string mensaje = "";
                if(resultado == "recorridoCodigoExistente")mensaje = "El codigo de Recorrido ya Existe";
                if(resultado == "recorridoSimilarExistenteYActivo") mensaje = "El recorrido: "+resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[1].ToString()+" es similar y se encuentra Activo";
                if(resultado == "recorridoSimilarExistenteYNoActivo") mensaje = "El recorrido: "+resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[0].ToString()+" es similar y no se encuentra Activo";
                if (resultado == "recorridoDadoDeAltaExitoso") mensaje = "El recorrido se dio de alta exitosamente codigo: " + resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[1].ToString();

                MessageBox.Show(mensaje, "Alta de Recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void textBox_CodigoRecorrido_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_CiudadOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }      
}
