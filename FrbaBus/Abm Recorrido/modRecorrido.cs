using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class modRecorrido : BaseForm
    {
        public string codigoRecorrido = "";

        public modRecorrido():
               base()
        {
            InitializeComponent();
        }

        private void loadComboBox()
        {
            DataTable DtCiudadesDestino;
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

        private void modRecorrido_Load_1(object sender, EventArgs e)
        {
            label_CodigoRecorrido.Text = codigoRecorrido;

            /* Cargo los combo box*/
            loadComboBox();

            /* Cargo la informacion correspondiente al codigo de recorrido*/
            loadRecorridoData();
    
        }


        private void loadRecorridoData()
        {

            DataTable Dt = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerCamposDeRecorrido(label_CodigoRecorrido.Text);

            comboBox_TipoServicio.Text = Dt.Rows[0].ItemArray[1].ToString();
            textBox_PrecioKG.Text = Dt.Rows[0].ItemArray[4].ToString();
            textBox_PrecioPasaje.Text = Dt.Rows[0].ItemArray[5].ToString();
            comboBox_CiudadOrigen.Text= Dt.Rows[0].ItemArray[2].ToString();
            comboBox_CiudadDestino.Text = Dt.Rows[0].ItemArray[3].ToString();

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            loadRecorridoData();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            /* Verifico si falta algun campo */
            /* Si no falta ningun campo guardo*/

            if (!fieldsHaveMissingValues()) saveChangesToDB();
            
        }

        private bool fieldsHaveMissingValues()
        {
            bool hasMissingValue = false;
            string errorMesaje = "Los siguientes campos son obligatorios y estan sin cargar:";

            if(comboBox_TipoServicio.Text == "") {
                errorMesaje += " Tipo Servicio ";
                hasMissingValue = true;
            }
            if (comboBox_CiudadOrigen.Text == "")
            {
                errorMesaje += " Ciudad Origen ";
                hasMissingValue = true;
            }
            if (comboBox_CiudadDestino.Text == "")
            {
                errorMesaje += " Ciudad Destino ";
                hasMissingValue = true;
            }
            if (textBox_PrecioKG.Text == "")
            {
                errorMesaje += " Precio KG ";
                hasMissingValue = true;
            }
            if (textBox_PrecioPasaje.Text == "")
            {
                errorMesaje += " Precio Base ";
                hasMissingValue = true;
            }

            if (hasMissingValue){
                MessageBox.Show(errorMesaje, "Modificacion de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
           
            return hasMissingValue;
        }

        private void saveChangesToDB()
        {
            DataTable resultadoModificarRecorrido;
            string codigoRecorrido = label_CodigoRecorrido.Text;
            string tipoServicio = comboBox_TipoServicio.SelectedValue.ToString();
            string ciudadOrigen = comboBox_CiudadOrigen.SelectedValue.ToString();
            string ciudadDestino = comboBox_CiudadDestino.SelectedValue.ToString();
            string precioKG = textBox_PrecioKG.Text;
            string precioPasaje = textBox_PrecioPasaje.Text;

            resultadoModificarRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.modificarRecorrido(codigoRecorrido, tipoServicio, ciudadOrigen, ciudadDestino, precioKG, precioPasaje);
            string resultado = resultadoModificarRecorrido.Rows[0].ItemArray[0].ToString();

            string mensaje = "";
            if (resultado == "recorridoSimilarExistente") mensaje = "El recorrido: " + resultadoModificarRecorrido.Rows[0].ItemArray[1].ToString() + " es similar y se encuentra Activo";
            if (resultado == "recorridoModificado")
            {
                mensaje = "El recorrido se modifico exitosamente";
            }
            MessageBox.Show(mensaje, "Modificacion de Recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox_TipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
