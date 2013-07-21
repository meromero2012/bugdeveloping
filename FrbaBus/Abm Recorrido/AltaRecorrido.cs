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
    public partial class AltaRecorrido : BaseForm
    {
        public AltaRecorrido():
               base()
        {
            InitializeComponent();
            /*Seteo los handlers para limitar el ingreso de caracteres en los textBoxes*/
            textBox_PrecioKG.KeyPress += new KeyPressEventHandler(textBox_Precios_KeyPress);
            textBox_PrecioPasaje.KeyPress += new KeyPressEventHandler(textBox_Precios_KeyPress);

        }

        private void AltaRecorrido_Load(object sender, EventArgs e)
        {
            /* Cargo los combo box*/
            loadComboBox();
        }

        private void loadComboBox()
        {
            DataTable DtCiudadesDestino;
            //Lleno los Combo Box de Ciudades
            DtCiudadesDestino = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTablaCiudades();
            comboBox_CiudadDestino.DataSource = DtCiudadesDestino;
            comboBox_CiudadDestino.DisplayMember = "CIUDAD_NOMBRE";
            comboBox_CiudadDestino.ValueMember = "CIUDAD_ID";
            
            DataTable DtCiudadesOrigen;
            DtCiudadesOrigen = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTablaCiudades();
            comboBox_CiudadOrigen.DataSource = DtCiudadesOrigen;
            comboBox_CiudadOrigen.DisplayMember = "CIUDAD_NOMBRE";
            comboBox_CiudadOrigen.ValueMember = "CIUDAD_ID";
            
            //Lleno el Combo Box Tipo de servicio
            DataTable DtTipoServicios;
            DtTipoServicios = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerTipoServicios();
            comboBox_TipoServicio.DataSource = DtTipoServicios;
            comboBox_TipoServicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBox_TipoServicio.ValueMember = "TIPO_SERVICIO_CODIGO";
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            /* Verifico si falta algun campo */
            /* Si no falta ningun campo guardo*/

            if (fieldsAreValid()) saveChangesToDB();
        }

        private bool fieldsAreValid()
        {
            return (checkImportes() & checkCiudades() & !fieldsHaveMissingValues());        
        }


        private bool checkImportes()
        {
            bool preciosValidos = true;
            int precioBase = 0;
            int precioKG = 0;
            bool couldParsePasaje = int.TryParse(textBox_PrecioPasaje.Text, out precioBase);
            bool couldParseKG = int.TryParse(textBox_PrecioKG.Text, out precioKG);

            if(!couldParseKG || !couldParsePasaje)
            {
                MessageBox.Show("Los precios no son validos, porfavor, ingrese un numero valido", "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                preciosValidos = false;
                return preciosValidos;
            }

            preciosValidos = (precioBase > 0 & precioKG > 0);

            if(!preciosValidos)
            {
                MessageBox.Show("Los precios no son validos, porfavor, ingrese valores superiores a 0", "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return preciosValidos;
        }

        private bool checkCiudades()
        {
            bool ciudadesDistintas = false;

            ciudadesDistintas = (comboBox_CiudadDestino.Text != comboBox_CiudadOrigen.Text);

            if (!ciudadesDistintas)
            {
                MessageBox.Show("Las ciudades deben ser distintas", "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return ciudadesDistintas;
        }

        private bool fieldsHaveMissingValues()
        {
            bool hasMissingValue = false;
            string errorMesaje = "Los siguientes campos son obligatorios y estan sin cargar:";

            string tipoServicio = comboBox_TipoServicio.Text;
            string ciudadOrigen = comboBox_CiudadOrigen.Text;
            string ciudadDestino = comboBox_CiudadDestino.Text;
            string precioKG = textBox_PrecioKG.Text;
            string precioPasaje = textBox_PrecioPasaje.Text;
          
            if(tipoServicio =="")
            {
                errorMesaje += " Tipo Servicio ";
                hasMissingValue = true;
            }

            if (ciudadOrigen == "")
            {
                errorMesaje += " Ciudad Origen ";
                hasMissingValue = true;
            }
            if (tipoServicio == "")
            {
                errorMesaje += " Ciudad Destino ";
                hasMissingValue = true;
            }

            if (precioKG == "")
            {
                errorMesaje += " Precio KG ";
                hasMissingValue = true;
            }

            if (precioPasaje == "")
            {
                errorMesaje += " Precio Pasaje ";
                hasMissingValue = true;
            }

            if (hasMissingValue == true)
            {
                MessageBox.Show(errorMesaje, "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return hasMissingValue;
        }
        
        private void saveChangesToDB()
        {
                string tipoServicio = comboBox_TipoServicio.SelectedValue.ToString();
                string ciudadOrigen = comboBox_CiudadOrigen.SelectedValue.ToString();
                string ciudadDestino = comboBox_CiudadDestino.SelectedValue.ToString();
                string precioKG = textBox_PrecioKG.Text;
                string precioPasaje = textBox_PrecioPasaje.Text;
                DataTable resultadoInsertarNuevoRecorrido;
                string codigoRandom = FrbaBus.Abm_Recorrido.FuncionesRecorridos.generarCodigoRecorrido();

                resultadoInsertarNuevoRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.InsertarNuevoRecorrido(codigoRandom,tipoServicio, ciudadOrigen, ciudadDestino, precioKG, precioPasaje);

                string resultado = resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[0].ToString();
                string mensaje = "";
                if (resultado == "recorridoSimilarExistente") mensaje = "El codigo de Recorrido ya Existe y es:" + resultadoInsertarNuevoRecorrido.Rows[0].ItemArray[1].ToString();
                if (resultado == "recorridoDadoDeAltaExitoso") mensaje = "El recorrido se dio de alta exitosamente codigo: " + codigoRandom;

                MessageBox.Show(mensaje, "Alta de Recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_PrecioKG_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Precios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox_PrecioPasaje_TextChanged(object sender, EventArgs e)
        {

        }


    }      
}
