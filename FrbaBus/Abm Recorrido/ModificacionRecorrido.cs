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
    public partial class ModificacionRecorrido : Form
    {
        public ModificacionRecorrido()
        {
            InitializeComponent();
        }

        public bool mainLoadFinished = false;

        private void ModificacionRecorrido_Load(object sender, EventArgs e)
        {
            button_Guardar.Visible = false;
            DataTable DtRecorridosModificables;
            //Lleno los Combo Box de Ciudades
            DtRecorridosModificables = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerRecorridosModificables();
            comboBox_CodigoRecorrido.DataSource = DtRecorridosModificables;
            comboBox_CodigoRecorrido.DisplayMember = "RECORRIDO_CODIGO";
            comboBox_CodigoRecorrido.ValueMember = "RECORRIDO_CODIGO";

            textBox_PrecioKG.Enabled = false;
            textBox_PrecioPasaje.Enabled = false;
            comboBox_CiudadOrigen.Enabled = false;
            comboBox_CiudadDestino.Enabled = false;
            comboBox_TipoServicio.Enabled = false;
            comboBox_Activo.Enabled = false;

            DataTable Dt = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerCamposDeRecorrido(comboBox_CodigoRecorrido.SelectedValue);

            textBox_Servicio_Actual.Text = Dt.Rows[0].ItemArray[1].ToString();
            textBox_CiudadOrigen_Actual.Text = Dt.Rows[0].ItemArray[4].ToString();
            textBox_CiudadDestino_Actual.Text = Dt.Rows[0].ItemArray[5].ToString();
            textBox_PrecioKG_Actual.Text = Dt.Rows[0].ItemArray[2].ToString();
            textBox_PrecioPasaje_Actual.Text = Dt.Rows[0].ItemArray[3].ToString();
            textBox_Activo_Actual.Text = Dt.Rows[0].ItemArray[6].ToString();

            mainLoadFinished = true;
        }

        private void comboBox_CodigoRecorrido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mainLoadFinished) return;
            DataTable Dt = FrbaBus.Abm_Recorrido.FuncionesRecorridos.obtenerCamposDeRecorrido(comboBox_CodigoRecorrido.SelectedValue);

            textBox_Servicio_Actual.Text = Dt.Rows[0].ItemArray[1].ToString();
            textBox_CiudadOrigen_Actual.Text = Dt.Rows[0].ItemArray[4].ToString();
            textBox_CiudadDestino_Actual.Text = Dt.Rows[0].ItemArray[5].ToString();
            textBox_PrecioKG_Actual.Text = Dt.Rows[0].ItemArray[2].ToString();
            textBox_PrecioPasaje_Actual.Text = Dt.Rows[0].ItemArray[3].ToString();

            textBox_PrecioKG.Text = "";
            textBox_PrecioPasaje.Text = "";
            comboBox_CiudadOrigen.Text = "";
            comboBox_CiudadDestino.Text = "";
            comboBox_TipoServicio.Text = "";
            comboBox_Activo.Text = "";

            textBox_PrecioKG.Enabled = false;
            textBox_PrecioPasaje.Enabled = false;
            comboBox_CiudadOrigen.Enabled = false;
            comboBox_CiudadDestino.Enabled = false;
            comboBox_TipoServicio.Enabled = false;
            comboBox_Activo.Enabled = false;

            buttom_Editar.Visible = true;
            button_Guardar.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 
        private void comboBox_CiudadDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox_Servicio_Actual_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {

        }

        private void Editar_Click(object sender, EventArgs e)
        {
            buttom_Editar.Visible = false;
            button_Guardar.Visible = true;

            textBox_PrecioKG.Enabled = true;
            textBox_PrecioPasaje.Enabled = true;
            comboBox_CiudadOrigen.Enabled = true;
            comboBox_CiudadDestino.Enabled = true;
            comboBox_TipoServicio.Enabled = true;
            comboBox_Activo.Enabled = true;

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

            comboBox_Activo.Items.Add("True");
            comboBox_Activo.Items.Add("False");
        }



        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string codigoRecorrido = ""+comboBox_CodigoRecorrido.SelectedValue;
            object tipoServicio = comboBox_TipoServicio.SelectedValue;
            object ciudadOrigen = comboBox_CiudadOrigen.SelectedValue;
            object ciudadDestino = comboBox_CiudadDestino.SelectedValue;
            string precioKG = textBox_PrecioKG.Text.Replace(",", ".");
            string precioPasaje = textBox_PrecioPasaje.Text.Replace(",", ".");
            string activo = comboBox_Activo.SelectedItem.ToString();
            string mensaje2 = "Los siguientes campos son obligatorios y estan sin cargar:";
            bool faltanDatos = false;

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

            if (activo == "")
            {
                mensaje2 += " Pasaje Estado(Activo) ";
                faltanDatos = true;
            }

            bool valoresIguales = false;

            if (textBox_PrecioKG_Actual.Text == textBox_PrecioKG.Text &
                textBox_PrecioPasaje_Actual.Text == textBox_PrecioPasaje.Text &
                textBox_CiudadOrigen_Actual.Text == comboBox_CiudadOrigen.Text &
                textBox_CiudadDestino_Actual.Text == comboBox_CiudadDestino.Text &
                textBox_Servicio_Actual.Text == comboBox_TipoServicio.Text &
                textBox_Activo_Actual.Text == comboBox_Activo.Text)
            {
                valoresIguales = true;
            }

            if (valoresIguales)
            {
                MessageBox.Show("Error los valores nuevos iguales a los anteriores", "Modificacion de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (faltanDatos == true)
            {
                MessageBox.Show(mensaje2, "Modificacion de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(!faltanDatos & !valoresIguales)
            {
                DataTable resultadoModificarRecorrido;
                int activoValue;
                if (activo == "True") activoValue = 1;
                else activoValue = 0;
                resultadoModificarRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.modificarRecorrido(codigoRecorrido, tipoServicio, ciudadOrigen, ciudadDestino, precioKG, precioPasaje, activoValue);
                string resultado = resultadoModificarRecorrido.Rows[0].ItemArray[0].ToString();
                
                string mensaje = "";
                if (resultado == "recorridoSimilarExistenteYActivo") mensaje = "El recorrido: " + resultadoModificarRecorrido.Rows[0].ItemArray[1].ToString() + " es similar y se encuentra Activo";
                if (resultado == "recorridoSimilarExistenteYNoActivo") mensaje = "El recorrido: " + resultadoModificarRecorrido.Rows[0].ItemArray[0].ToString() + " es similar y no se encuentra Activo";
                if (resultado == "recorridoModificado"){
                    mensaje = "El recorrido se modifico exitosamente";

                    button_Guardar.Visible = false;
                    buttom_Editar.Visible = true;

                    textBox_PrecioKG_Actual.Text = textBox_PrecioKG.Text;
                    textBox_PrecioPasaje_Actual.Text = textBox_PrecioPasaje.Text;
                    textBox_CiudadOrigen_Actual.Text = comboBox_CiudadOrigen.Text;
                    textBox_CiudadDestino_Actual.Text =comboBox_CiudadDestino.Text;
                    textBox_Servicio_Actual.Text = comboBox_TipoServicio.Text;
                    textBox_Activo_Actual.Text = comboBox_Activo.Text;
 
                    textBox_PrecioKG.Text = "";
                    textBox_PrecioPasaje.Text = "";
                    comboBox_CiudadOrigen.Text = "";
                    comboBox_CiudadDestino.Text = "";
                    comboBox_TipoServicio.Text = "";
                    comboBox_Activo.Text = "";

                    textBox_PrecioKG.Enabled = false;
                    textBox_PrecioPasaje.Enabled = false;
                    comboBox_CiudadOrigen.Enabled = false;
                    comboBox_CiudadDestino.Enabled = false;
                    comboBox_TipoServicio.Enabled = false;
                    comboBox_Activo.Enabled = false;

                }
                MessageBox.Show(mensaje, "Modificacion de Recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void comboBox_Activo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_PrecioKG_Actual_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
