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
    public partial class modRecorrido : BaseForm
    {
        public string codigoRecorrido = "";

        private string ciudadOrigenOriginal = "";
        private string ciudadDestinoOriginal = "";
        private string precioKGOriginal = "";
        private string precioPasajeOriginal = "";
        private string tipoServicioOriginal = "";


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
            tipoServicioOriginal = Dt.Rows[0].ItemArray[1].ToString();
            ciudadOrigenOriginal = Dt.Rows[0].ItemArray[2].ToString();
            ciudadDestinoOriginal = Dt.Rows[0].ItemArray[3].ToString();
            precioKGOriginal = Dt.Rows[0].ItemArray[4].ToString();
            precioPasajeOriginal = Dt.Rows[0].ItemArray[5].ToString();

            precioKGOriginal = precioKGOriginal.Replace(",",".");
            precioPasajeOriginal = precioPasajeOriginal.Replace(",", ".");

            comboBox_TipoServicio.Text = String.Copy(tipoServicioOriginal);
            textBox_PrecioKG.Text = String.Copy(precioKGOriginal);
            textBox_PrecioPasaje.Text = String.Copy(precioPasajeOriginal);
            comboBox_CiudadOrigen.Text = String.Copy(ciudadOrigenOriginal);
            comboBox_CiudadDestino.Text = String.Copy(ciudadDestinoOriginal);
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            loadRecorridoData();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            /* Verifico si falta algun campo */
            /* Si no falta ningun campo guardo*/

            if (fieldsAreValid())
            {
                if (cambiaronCiudadesOServicio()) darBajaYCrearNuevoRecorridoEnDB();
                else if (cambiaronPrecio()) cammbiarPrecioRecorridoEnDB();
                MessageBox.Show("Se guardaron los cambios exitosamente", "Modificacion de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void darBajaYCrearNuevoRecorridoEnDB()
        {
            /*Obtengo los valores del form*/
            string tipoServicio = comboBox_TipoServicio.SelectedValue.ToString();
            string ciudadOrigen = comboBox_CiudadOrigen.SelectedValue.ToString();
            string ciudadDestino = comboBox_CiudadDestino.SelectedValue.ToString();
            string precioKG = textBox_PrecioKG.Text;
            string precioPasaje = textBox_PrecioPasaje.Text;
            
            /*Doy de baja al recorrido y cancelo pasajes de los viajes futuros*/
            FrbaBus.Abm_Recorrido.FuncionesRecorridos.DarDeBajaARecorridoDesdeFecha(codigoRecorrido, DateTime.Today);

            /*Crear nuevo recorrido*/
            string codigoRandom = FrbaBus.Abm_Recorrido.FuncionesRecorridos.generarCodigoRecorrido();
            DataTable resultadoInsertarNuevoRecorrido;
            resultadoInsertarNuevoRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.InsertarNuevoRecorrido(codigoRandom,tipoServicio, ciudadOrigen, ciudadDestino, precioKG, precioPasaje);
            
            /*Le asigno al nuevo recorrido los viajes que tenia el otro*/
            FrbaBus.Abm_Recorrido.FuncionesRecorridos.CambiarRecorridosEnViajesDesdeFecha(codigoRecorrido, codigoRandom, DateTime.Today.AddYears(-3));   


        }

        private void cammbiarPrecioRecorridoEnDB()
        {
            string precioKGNuevo = textBox_PrecioKG.Text;
            string precioBaseNuevo = textBox_PrecioPasaje.Text;

            DataTable Dt;
            string query = "UPDATE BUGDEVELOPING.RECORRIDO SET RECORRIDO_PRECIO_BASE_KG = "+precioKGNuevo+ ", RECORRIDO_PRECIO_BASE_PASAJE = "+precioBaseNuevo+" WHERE RECORRIDO_CODIGO = '"+codigoRecorrido+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
        }
        
        private bool cambiaronCiudadesOServicio()
        {
            return (comboBox_CiudadDestino.Text != ciudadDestinoOriginal || 
                    comboBox_CiudadOrigen.Text  != ciudadOrigenOriginal ||
                    comboBox_TipoServicio.Text != tipoServicioOriginal);
        }

        private bool cambiaronPrecio()
        {
            return (textBox_PrecioKG.Text != precioKGOriginal ||
                    textBox_PrecioPasaje.Text != precioPasajeOriginal);
        }


        private bool fieldsAreValid()
        {
            return (checkImportes() & checkCiudades() & !fieldsHaveMissingValues());        
        }

        private bool checkImportes()
        {
            bool preciosValidos = true;
            float precioBase = 0;
            float precioKG = 0;

            bool couldParsePasaje = float.TryParse(textBox_PrecioPasaje.Text, out precioBase);
            bool couldParseKG = float.TryParse(textBox_PrecioKG.Text, out precioKG);

            if (!couldParseKG || !couldParsePasaje)
            {
                MessageBox.Show("Los precios no son validos, porfavor, ingrese un numero valido", "Alta de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                preciosValidos = false;
                return preciosValidos;
            }

            preciosValidos = (precioBase > 0 & precioKG > 0);

            if (!preciosValidos)
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

        private void button_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
