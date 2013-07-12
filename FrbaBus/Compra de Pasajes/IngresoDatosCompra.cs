using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.AuthentificationSystem;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class IngresoDatosCompra : BaseForm
    {
        public static Boolean dniEncontradoBBDD;
        public static DataTable pasajeEncomiendaNro;

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

        public IngresoDatosCompra(DataTable dt):
               this()
        {
            pasajeEncomiendaNro = dt;
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
            int cantidadElementos = pasajeEncomiendaNro.Rows.Count;

            string fechaCompra = (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day).ToString();

            string nroCompra = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getNroCompra();

            for (int i = 1; i <= cantidadElementos; i++)
            {
                if ( tipo.Equals("Efectivo") )
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCompraEfectivo(pasajeEncomiendaNro.Rows[i].ItemArray[0].ToString(), fechaCompra, dniTextBox.Text,nroCompra);
                else
                    FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.insertCompraTarjeta(pasajeEncomiendaNro.Rows[i].ItemArray[0].ToString(), fechaCompra, dniTextBox.Text, nroTarjetaTextBox.Text, cuotasTextBox.Text, nroCompra);
            }
        }

        /* Verifica que la data este cargada segun corresponde y escribe la entidad cliente y compra segun la data del formulario. Una vez hecho esto cierra el formulario volviendo al menu de seleccion de viajes a comprar */
        private void finalizarButton_Click(object sender, EventArgs e)
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
                }
            }
            else
            {
                insertCompra("Efectivo");
                this.Close();
                Program.MenuPrincipal.Show();
            }
        }
        
        private void IngresoDatosCompra_Load(object sender, EventArgs e)
        {

        }

        private void tarjetaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nroTarjetaTextBox.Enabled = tarjetaRadioButton.Checked;
            codigoSeguridadtextBox.Enabled = tarjetaRadioButton.Checked;
            vtoTextBox.Enabled = tarjetaRadioButton.Checked;
            cuotasTextBox.Enabled = tarjetaRadioButton.Checked;
        }
    }
}
