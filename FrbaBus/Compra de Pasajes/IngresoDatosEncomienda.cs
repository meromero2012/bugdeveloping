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
    public partial class IngresoDatosEncomienda : BaseForm
    {
        public static Boolean dniEncontradoBBDD;
        public Compra compra;
        
        public String codigoViaje;
        public String codigoRecorrido;
        public String microPatente;
        public String tipoServicio;
        public int pasajesCompra;
        public int kgsCompra;
        
        public IngresoDatosEncomienda():
               base()
        {
            InitializeComponent();
            cargarSexoCb();
        }

        private void cargarSexoCb()
        {
            sexoComboBox.Items.Add("Masculino");
            sexoComboBox.Items.Add("Femenino");
            sexoComboBox.SelectedIndex = 0;
        }

        public IngresoDatosEncomienda(String viaje, String recorrido, String patente, String servicio, int pasajes, int kgs, Compra cmp)
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
            discapacidadCheckBox.Enabled = estado;
            domicilioTextBox.Enabled = estado;
            telefonoTextBox.Enabled = estado;
            mailTextBox.Enabled = estado;
        }

        /*Una vez cargada la info del cliente, busca segun el piso seleccionado las butacas libres dando una descripcion de numero y ubicacion*/
        private void buscarDniButton_Click(object sender, EventArgs e)
        {
            String dni = dniTextBox.Text;

            if (!dni.Equals(""))
            {
                String estaEnBBDD = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDNI(dni);

                if (!estaEnBBDD.Equals("0"))
                {
                    dniEncontradoBBDD = true;

                    DataTable datosPersonalesDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getDatosPersonales(dni);

                    setDatosPersonales(datosPersonalesDt);
                }

                dniTextBox.Enabled = false;

                enableFormularioDatos(true);

                continuarButton.Enabled = true;
           }
        }

        /*Se calcula el precio final de la encomienda*/
        private String getPrecioEncomienda()
        {
            double precioEncomienda = Convert.ToDouble(FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPrecioBaseEncomienda(codigoRecorrido));
            precioEncomienda *= kgsCompra;

            return (precioEncomienda.ToString());
        }

        /*Carga la informacion referida a la cantidad de kgs y precio final de la encomienda*/
        private void continuarButton_Click(object sender, EventArgs e)
        {
            enableFormularioDatos(false);

            kgsLabel.Text = kgsCompra.ToString();
            kgsLabel.Enabled = true;

            precioLabel.Text = getPrecioEncomienda();
            precioLabel.Enabled = true;

            siguienteButton.Enabled = true;
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
            string encomiendaNro = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPasajeEncomiendaNumero();
            string precio = precioLabel.Text;

            if (dniEncontradoBBDD)
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.updateCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);
            else
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);

            cargarCompra("Encomienda",encomiendaNro,dni, precio, codigoViaje, "-1", "-1", "-1", kgsCompra.ToString());

            if (pasajesCompra > 0)
            {
                IngresoDatosPasaje frmPasaje = new IngresoDatosPasaje(codigoViaje, codigoRecorrido, microPatente, tipoServicio, pasajesCompra, kgsCompra, compra);
                frmPasaje.Show();
            }
            else
            {
                IngresoDatosCompra frmCompra = new IngresoDatosCompra(compra);
                frmCompra.Show();
            }

            this.Close();
        }

        private void IngresoDatosEncomienda_Load(object sender, EventArgs e)
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
