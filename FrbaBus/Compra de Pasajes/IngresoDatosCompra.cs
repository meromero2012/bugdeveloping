using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.AuthentificationSystem;
using FrbaBus.ConnectorSQL;
using System.Configuration;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class IngresoDatosCompra : BaseForm
    {
        public static Boolean dniEncontradoBBDD;
        public Compra compra;

        private void cargarSexoCb()
        {
            sexoComboBox.Items.Add("Masculino");
            sexoComboBox.Items.Add("Femenino");
            sexoComboBox.SelectedIndex = 0;
        }

        public IngresoDatosCompra()
               :base()
        {
            InitializeComponent();
            cargarSexoCb();
            dniEncontradoBBDD = false;
        }

        public IngresoDatosCompra(Compra cmp):
               this()
        {
            compra = cmp;
        }

        public void setDatosPersonales(DataRow row)
        {
            int anio = Convert.ToInt16(row.ItemArray[0].ToString());
            int mes = Convert.ToInt16(row.ItemArray[1].ToString());
            int dia = Convert.ToInt16(row.ItemArray[2].ToString());
            nacimientoDateTimePicker.Value = new DateTime(anio, mes, dia);
            nombreTextBox.Text = row.ItemArray[3].ToString();
            apellidoTextBox.Text = row.ItemArray[4].ToString();
            String sexo = row.ItemArray[5].ToString();
            if (sexo.Equals('F'))
                sexoComboBox.SelectedIndex = 2;
            else if (sexo.Equals('M'))
                sexoComboBox.SelectedIndex = 1;
            String discapacidad = row.ItemArray[6].ToString();
            if (discapacidad.Equals("Si"))
                discapacidadCheckBox.AutoCheck = true;
            domicilioTextBox.Text = row.ItemArray[7].ToString();
            telefonoTextBox.Text = row.ItemArray[8].ToString();
            mailTextBox.Text = row.ItemArray[9].ToString();
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
            continuarButton.Enabled = estado;
        }

        /*Una vez cargado el dni lo busca en la base de datos, para autocompletar el formulario o dar la posibilidad de ingresar un cliente nuevo*/
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

                    setDatosPersonales(datosPersonalesDt.Rows[0]);
                }

                dniTextBox.Enabled = false;

                enableFormularioDatos(true);
            }
        }

        /*Habilita las opciones de pago despues de cargar los datos del cliente*/
        private void continuarButton_Click(object sender, EventArgs e)
        {
            enableFormularioDatos(false);
            if (AccountManagment.ActualUser.Role== RoleEnum.Administrator)
            {
                efectivoRadioButton.Enabled = true;
                efectivoRadioButton.Checked = true;
            }

            tarjetaRadioButton.Enabled = true;

            finalizarButton.Enabled = true;
        }
        
        /* Escribe la tabla compras con la informacion del listado cargado durante el ingreso de encomienda y pasajes, dependiendo si el pago se realiza en efectivo o tarjeta */
        private void insertCompra(String tipo)
        {
            string fechaCompra = ConfigurationManager.AppSettings["SystemYear"] + ConfigurationManager.AppSettings["SystemMonth"] + ConfigurationManager.AppSettings["SystemDay"];

            string nroCompra = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getNroCompra();

            foreach(Pasaje_Encomienda pe in compra.Compras){

                string nroPasaje_Encomienda = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getPasajeEncomiendaNumero();

                if (tipo.Equals("Efectivo"))
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCompraEfectivo(nroPasaje_Encomienda, fechaCompra, dniTextBox.Text, nroCompra);
                else
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCompraTarjeta(nroPasaje_Encomienda, fechaCompra, dniTextBox.Text, nroCompra, nroTarjetaTextBox.Text, cuotasTextBox.Text);

                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertPasajeEncomienda(nroPasaje_Encomienda, pe.dni_viajero, pe.precio, pe.codigo_viaje);
                
                if (pe.tipo.Equals("Pasaje"))
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertPasaje(nroPasaje_Encomienda, pe.micro_patente, pe.nro_butaca, pe.piso_butaca);
                else
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertEncomienda(nroPasaje_Encomienda, pe.kgs_utilizados);
            }
        }

        /* Verifica que la data este cargada segun corresponde y escribe la entidad cliente y compra segun la data del formulario. Una vez hecho esto cierra el formulario volviendo al menu de seleccion de viajes a comprar */
        private void finalizarButton_Click(object sender, EventArgs e)
        {
            string dni = dniTextBox.Text;
            string fechaNacimiento = ConnectorClass.ParseDateTime(nacimientoDateTimePicker.Value);
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
            
            if (dniEncontradoBBDD)
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.updateCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);
            else
                FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCliente(dni, fechaNacimiento, nombre, apellido, sexo, discapacidad, domicilio, telefono, mail);

            if (tarjetaRadioButton.Checked)
            {
                if (!nroTarjetaTextBox.Text.Equals("") && !codigoSeguridadtextBox.Text.Equals("") && !vtoTextBox.Text.Equals("") && !cuotasTextBox.Text.Equals(""))
                {
                    insertCompra("Tarjeta");
                    this.Close();
                    Program.MenuPrincipal.Show();
                }
            }
            else
            {
                insertCompra("Efectivo");
                this.Close();
                MessageBox.Show("Compra realizada");
                Program.MenuPrincipal.Show();
            }
        }
        
        private void IngresoDatosCompra_Load(object sender, EventArgs e)
        {
            nacimientoDateTimePicker.Value = new DateTime(Convert.ToInt32(ConfigurationManager.AppSettings["SystemYear"]),
                                          Convert.ToInt32(ConfigurationManager.AppSettings["SystemMonth"]),
                                          Convert.ToInt32(ConfigurationManager.AppSettings["SystemDay"]));
        }

        private void tarjetaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nroTarjetaTextBox.Enabled = tarjetaRadioButton.Checked;
            codigoSeguridadtextBox.Enabled = tarjetaRadioButton.Checked;
            vtoTextBox.Enabled = tarjetaRadioButton.Checked;
            cuotasTextBox.Enabled = tarjetaRadioButton.Checked;
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
