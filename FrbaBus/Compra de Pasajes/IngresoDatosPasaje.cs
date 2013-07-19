using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class IngresoDatosPasaje : BaseForm
    {

        public static Boolean dniEncontradoBBDD;
        public static Boolean comproDiscapacitado;
        public static int pasajesSinCosto;
        public Compra compra;

        public static String codigoViaje;
        public static String codigoRecorrido;
        public static String microPatente;
        public static String tipoServicio;
        public static int pasajesCompra;
        public static int kgsCompra;

        private void cargarSexoCb()
        {
            sexoComboBox.Items.Add("Masculino");
            sexoComboBox.Items.Add("Femenino");
            sexoComboBox.SelectedIndex = 0;
        }

        /*Carga los datos de las butacas para los datos pasados en el formulario de viajes*/
        public void cargarPisoButacas()
        {
            pisoComboBox.DataSource = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPisoButacas(microPatente);
            pisoComboBox.ValueMember = "BUTACA_PISO";
            pisoComboBox.DisplayMember = "BUTACA_PISO";
        }

        public IngresoDatosPasaje():
               base()
        {
            InitializeComponent();
            cargarSexoCb();
            comproDiscapacitado = false;
            pasajesSinCosto = 2;
        }

        public IngresoDatosPasaje(String viaje, String recorrido, String patente, String servicio, int pasajes, int kgs, Compra cmp)
            :this()
        {
            codigoViaje = viaje;
            codigoRecorrido = recorrido;
            microPatente = patente;
            tipoServicio = servicio;
            pasajesCompra = pasajes;
            kgsCompra = kgs;
            compra = cmp;
        }

        public void setDatosPersonales(DataTable dt)
        {
            int anio = Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString());
            int mes = Convert.ToInt16(dt.Rows[0].ItemArray[1].ToString());
            int dia = Convert.ToInt16(dt.Rows[0].ItemArray[2].ToString());
            nacimientoDateTimePicker.Value = new DateTime(anio, mes, dia);
            nombreTextBox.Text = dt.Rows[0].ItemArray[3].ToString();
            apellidoTextBox.Text = dt.Rows[0].ItemArray[4].ToString();
            String sexo = dt.Rows[0].ItemArray[5].ToString();
            if (sexo.Equals('F'))
                sexoComboBox.SelectedIndex = 2;
            else if (sexo.Equals('M'))
                sexoComboBox.SelectedIndex = 1;
            String discapacidad = dt.Rows[0].ItemArray[6].ToString();
            if (discapacidad.Equals("Si"))
                discapacidadCheckBox.AutoCheck = true;
            domicilioTextBox.Text = dt.Rows[0].ItemArray[7].ToString();
            telefonoTextBox.Text = dt.Rows[0].ItemArray[8].ToString();
            mailTextBox.Text = dt.Rows[0].ItemArray[9].ToString();
        }

        public void enableFormularioDatos(Boolean estado)
        {
            nacimientoDateTimePicker.Enabled = estado;
            nombreTextBox.Enabled = estado;
            apellidoTextBox.Enabled = estado;
            sexoComboBox.Enabled = estado;
            if (!comproDiscapacitado)
                discapacidadCheckBox.Enabled = estado;
            domicilioTextBox.Enabled = estado;
            telefonoTextBox.Enabled = estado;
            mailTextBox.Enabled = estado;
        }

        /*Una vez cargado el dni lo busca en la base de datos, para autocompletar el formulario o dar la posibilidad de ingresar un cliente nuevo*/
        private void buscarDniButton_Click(object sender, EventArgs e)
        {
            String dni = dniTextBox.Text;

            if (!dni.Equals(""))
            {
                String estaEnBBDD = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDNI(dni);
                String noEsDNIDeDiscapacitado = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDNINoDiscapacitado(dni);

                if (noEsDNIDeDiscapacitado.Equals("1"))
                {
                    if (!estaEnBBDD.Equals("0"))
                    {
                        dniEncontradoBBDD = true;

                        DataTable datosPersonalesDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDatosPersonales(dni);

                        setDatosPersonales(datosPersonalesDt);
                    }

                    dniTextBox.Enabled = false;

                    enableFormularioDatos(true);

                    cargarPisoButacas();
                    pisoComboBox.Enabled = true;
                    buscarButacasButton.Enabled = true;
                }
            }
        }

        /*Una vez cargada la info del cliente, busca segun el piso seleccionado las butacas libres dando una descripcion de numero y ubicacion*/
        private void buscarButacasButton_Click(object sender, EventArgs e)
        {
            enableFormularioDatos(false);

            string piso = pisoComboBox.SelectedValue.ToString();
            
            DataTable butacasDisponiblesDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getButacasLibres(microPatente, piso, codigoViaje);
            
            nroComboBox.ValueMember = "BUTACA_NUMERO";
            nroComboBox.DisplayMember = "BUTACA_DESCRIPCION";
            nroComboBox.DataSource = butacasDisponiblesDt;
            
            nroComboBox.Enabled = true;

            getPrecioPasaje();

            precioLabel.Enabled = true;

            siguienteButton.Enabled = true;
        }

        /* Se calcula el precio del pasaje segun las restricciones del enunciado */
        private void getPrecioPasaje()
        {
            double precioStandar = Convert.ToDouble(FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPrecioPasajeStandar(codigoRecorrido));
            double precioFinal = precioStandar;

            if ( !comproDiscapacitado && discapacidadCheckBox.Checked )
            {
                precioFinal = 0;
                comproDiscapacitado = true;
                pasajesSinCosto -= 1;
            }
            else
            {
                if (comproDiscapacitado && pasajesSinCosto > 0)
                {
                    precioFinal = 0;
                    pasajesSinCosto -= 1;
                }
                else
                {
                    if (((sexoComboBox.SelectedIndex == 1) && ((DateTime.Now.Year - nacimientoDateTimePicker.Value.Year) > 60)) ||
                        ((sexoComboBox.SelectedIndex == 0) && ((DateTime.Now.Year - nacimientoDateTimePicker.Value.Year) > 65)))
                        precioFinal -= precioFinal * 0.5;
                }
            }

            precioLabel.Text = precioFinal.ToString();
        }

        private void resetForm()
        {
            dniEncontradoBBDD = false;
            dniTextBox.Enabled = true;
            dniTextBox.Text = "";
            buscarDniButton.Enabled = true;
            nacimientoDateTimePicker.Enabled = false;
            nombreTextBox.Enabled = false;
            nombreTextBox.Text = "";
            apellidoTextBox.Enabled = false;
            apellidoTextBox.Text = "";
            sexoComboBox.Enabled = false;
            discapacidadCheckBox.Enabled = false;
            discapacidadCheckBox.AutoCheck = false;
            domicilioTextBox.Enabled = false;
            domicilioTextBox.Text = "";
            telefonoTextBox.Enabled = false;
            telefonoTextBox.Text = "";
            mailTextBox.Enabled = false;
            mailTextBox.Text = "";
            pisoComboBox.Enabled = false;
            buscarButacasButton.Enabled = false;
            nroComboBox.Enabled = false;
            precioLabel.Enabled = false;
            precioLabel.Text = "-";
            siguienteButton.Enabled = false;
        }

        /*Agrega en un elemento de lista el codigo de pasaje comprado para despues poder registrar la compra*/
        private void cargarCompra(String pasje_encomienda, String codigo, String dni, String monto, String viaje, String patente, String nroButaca, String pisoButaca, String kgs)
        {
            compra.Compras.Add(new Pasaje_Encomienda()
            {
                tipo = pasje_encomienda,
                codigo_pasaje_encomienda = codigo,
                dni_viajero = dni,
                precio = monto,
                codigo_viaje = viaje,
                micro_patente = patente,
                nro_butaca = nroButaca,
                piso_butaca = pisoButaca,
                kgs_utilizados = kgs
            });
        }

        /*Si todo lo anterior se realizo con exito, se escriben las tablas de cliente, pasaje_encomienda y pasaje, permitiendo seguir con facturacion u otro pasaje si fuese necesario*/
        private void siguienteButton_Click(object sender, EventArgs e)
        {
            string dni = dniTextBox.Text;
            string fechaNacimiento = (nacimientoDateTimePicker.Value.Year * 10000 + nacimientoDateTimePicker.Value.Month * 100 + nacimientoDateTimePicker.Value.Day).ToString();
            string nombre = nombreTextBox.Text;
            string apellido = apellidoTextBox.Text;
            string sexo = "M";
            if (sexoComboBox.SelectedIndex == 1)
                sexo = "F";
            string discapacidad = "No";
            if (discapacidadCheckBox.Checked)
                discapacidad = "Si";
            string domicilio = domicilioTextBox.Text;
            string telefono = telefonoTextBox.Text;
            string mail = mailTextBox.Text;
            string pasajeNro = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPasajeEncomiendaNumero();
            string precio = precioLabel.Text;
            string butacaPiso = pisoComboBox.SelectedValue.ToString();
            string butacaNro = nroComboBox.SelectedIndex.ToString();

            if (dniEncontradoBBDD)
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.updateCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);
            else
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);

            cargarCompra("Pasaje", pasajeNro, dni, precio, codigoViaje, microPatente, butacaNro, butacaPiso, "-1");

            if (pasajesCompra > 1)
            {
                pasajesCompra -= 1;

                resetForm();
            }
            else
            {
                IngresoDatosCompra frmCompra = new IngresoDatosCompra(compra);
                frmCompra.Show();
                this.Close();
            }
        }

        private void IngresoDatosPasaje_Load(object sender, EventArgs e)
        {

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
