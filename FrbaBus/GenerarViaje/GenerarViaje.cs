using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.GenerarViaje
{
    public partial class GenerarViaje : BaseForm
    {
        public GenerarViaje():
               base()
        {
            InitializeComponent();
        }

        string tipoServicio;

        private void buttonSeleccionarRecorrido_Click(object sender, EventArgs e)
        {
            /*al hacer click en seleccionar se abre la pantalla de Listado de Recorridos
             * y se asigna el numero de recorrido seleccionado al textBox de recorrido
             * asi como tambien el tipo de servicio se recorrido para realizar la validacion posterior */
            ListadoRecorridos formListadoDeRecorridos = new ListadoRecorridos();
            DialogResult result = formListadoDeRecorridos.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_numeroRecorrido.Enabled = true;
                textBox_numeroRecorrido.BackColor = System.Drawing.Color.White;
                textBox_numeroRecorrido.Text = formListadoDeRecorridos.numeroRecorrido;
                tipoServicio = formListadoDeRecorridos.tipoServicio;
            }
        }


        private void buttonSeleccionarMicro_Click(object sender, EventArgs e)
        {
            ListadoMicro formListadoDeMicros = new ListadoMicro();
            DialogResult result = formListadoDeMicros.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_numeroPatenteMicro.Enabled = true;
                textBox_numeroPatenteMicro.BackColor = System.Drawing.Color.White;
                textBox_numeroPatenteMicro.Text = formListadoDeMicros.numeroPatenteMicro;
                tipoServicio = formListadoDeMicros.tipoServicio;
            }
        }


        private void dateTimePicker_fechaSalida_ValueChanged(object sender, EventArgs e)
        {
            /*agrega al dateTimePicker para poder seleccionar la hora*/
            this.dateTimePicker_fechaSalida.Format = DateTimePickerFormat.Time;
            this.dateTimePicker_fechaSalida.Width = 100;
            this.dateTimePicker_fechaSalida.ShowUpDown = true;
        }

        private void dateTimePicker_fechaLlegadaEstimada_ValueChanged(object sender, EventArgs e)
        {
            /*agrega al dateTimePicker para poder seleccionar la hora*/
            this.dateTimePicker_fechaLlegadaEstimada.Format = DateTimePickerFormat.Time;
            this.dateTimePicker_fechaLlegadaEstimada.Width = 100;
            this.dateTimePicker_fechaLlegadaEstimada.ShowUpDown = true;
        }

        private void ReestablecerFechas()
        {
            /*vuelve al estado inicial las fechas, tanto de salida como de llegada estimada*/
            dateTimePicker_fechaSalida.Value = DateTime.Now;
            dateTimePicker_fechaSalida.Format = DateTimePickerFormat.Long;
            dateTimePicker_fechaSalida.Width = 200;
            dateTimePicker_fechaSalida.ShowUpDown = false;
            dateTimePicker_fechaLlegadaEstimada.Value = DateTime.Now;
            dateTimePicker_fechaLlegadaEstimada.ShowUpDown = false;
            dateTimePicker_fechaLlegadaEstimada.Format = DateTimePickerFormat.Long;
            dateTimePicker_fechaLlegadaEstimada.Width = 200;
        }

        private void Limpiar()
        {
            /*vuelve la pantalla completa al estadio inicial*/
            
            textBox_numeroRecorrido.Text = "";
            textBox_numeroRecorrido.Enabled = false;
            textBox_numeroRecorrido.BackColor = System.Drawing.SystemColors.InactiveCaption;
            textBox_numeroPatenteMicro.Text = "";
            textBox_numeroPatenteMicro.Enabled = false;
            textBox_numeroPatenteMicro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            ReestablecerFechas();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            /*asigna las variables correspondientes, realiza las validaciones y genera el viaje*/
            DateTime fechaSalida = dateTimePicker_fechaSalida.Value;
            DateTime fechaLlegadaEstimada = dateTimePicker_fechaLlegadaEstimada.Value;
            string micro = textBox_numeroPatenteMicro.Text.ToString();
            string codigoRecorrido = textBox_numeroRecorrido.Text.ToString();
            string mensaje2 = "Los siguientes campos son obligatorios y estan sin cargar:";
            bool faltanDatos = false;
            bool huboError = false;

            if (textBox_numeroRecorrido.Text == "")
            {
                mensaje2 += " Numero de Recorrido ";
            }

            if (textBox_numeroPatenteMicro.Text == "")
            {
                mensaje2 += " Micro ";
                faltanDatos = true;
            }

            if (faltanDatos == true)
            {
                MessageBox.Show(mensaje2, "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                faltanDatos = false;
            }

            else
                
                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarMicroTipoS(tipoServicio, micro))
                {
                    MessageBox.Show("El tipo de servicio que brinda el micro seleccionado no corresponde con el tipo de servicio que debe brindar el recorrido", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_numeroPatenteMicro.Text = "";
                    textBox_numeroPatenteMicro.Enabled = false;
                    textBox_numeroPatenteMicro.BackColor = System.Drawing.SystemColors.InactiveCaption;
                    huboError = true;
                }


                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarFecha(fechaSalida, fechaLlegadaEstimada))
                {
                    MessageBox.Show("Alguna de las fechas seleccionadas es menor a la actual o la Fecha de Llegada Estimada supera las 24 hs de la de Salida", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReestablecerFechas();
                    huboError = true;
                }

                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarMicroDisponible(fechaSalida, micro))
                {
                    MessageBox.Show("El micro no esta disponible porque esta realizando otro viaje", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_numeroPatenteMicro.Text = "";
                    textBox_numeroPatenteMicro.Enabled = false;
                    textBox_numeroPatenteMicro.BackColor = System.Drawing.SystemColors.InactiveCaption;
                    ReestablecerFechas();
                    huboError = true;
                }

                if (huboError == false)
                {
                    FrbaBus.GenerarViaje.FuncionesGenerarViaje.InsertarViaje(codigoRecorrido, micro, fechaSalida, fechaLlegadaEstimada);
                    Limpiar();
                }
          }

        private void GenerarViaje_Load(object sender, EventArgs e)
        {

        }
     }
}

