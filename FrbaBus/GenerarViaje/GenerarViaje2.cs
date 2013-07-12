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
    public partial class GenerarViaje2 : Form
    {
        public GenerarViaje2()
        {
            InitializeComponent();
        }


        ConnectorClass cc;
        DataTable dt;
        string tipoServicio;

        private void buttonSeleccionarRecorrido_Click(object sender, EventArgs e)
        {
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

        private void CargarComboBoxMicro()
        {
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT MICRO_PATENTE FROM BUGDEVELOPING.MICRO");
            comboBoxMicro.DataSource = dt;
            comboBoxMicro.DisplayMember = "MICRO_PATENTE";
            comboBoxMicro.ValueMember = "MICRO_PATENTE";
        }

        private void GenerarViaje2_Load(object sender, EventArgs e)
        {
            CargarComboBoxMicro();
        }

        private void dateTimePicker_fechaSalida_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker_fechaSalida.Format = DateTimePickerFormat.Time;
            this.dateTimePicker_fechaSalida.Width = 100;
            this.dateTimePicker_fechaSalida.ShowUpDown = true;
        }

        private void dateTimePicker_fechaLlegadaEstimada_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker_fechaLlegadaEstimada.Format = DateTimePickerFormat.Time;
            this.dateTimePicker_fechaLlegadaEstimada.Width = 100;
            this.dateTimePicker_fechaLlegadaEstimada.ShowUpDown = true;
        }

        private void ReestablecerFechas()
        {
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
            textBox_numeroRecorrido.Text = "";
            textBox_numeroRecorrido.Enabled = false;
            textBox_numeroRecorrido.BackColor = System.Drawing.SystemColors.InactiveCaption;
            comboBoxMicro.Text = "";
            this.ReestablecerFechas();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            DateTime fechaSalida = dateTimePicker_fechaSalida.Value;
            DateTime fechaLlegadaEstimada = dateTimePicker_fechaLlegadaEstimada.Value;
            string micro = comboBoxMicro.SelectedValue.ToString();
            string mensaje2 = "Los siguientes campos son obligatorios y estan sin cargar:";
            bool faltanDatos = false;

            if (textBox_numeroRecorrido.Text == "")
            {
                mensaje2 += " Numero de Recorrido ";
            }

            if (comboBoxMicro.Text == "")
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
            {
                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarMicro(tipoServicio, micro))
                {
                    MessageBox.Show("El tipo de servicio que brinda el micro seleccionado no corresponde con el tipo de servicio que debe brindar el recorrido", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxMicro.Text = "";
                }


                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarFecha(fechaSalida, fechaLlegadaEstimada))
                {
                    MessageBox.Show("Alguna de las fechas seleccionadas es menor a la actual o la Fecha de Llegada Estimada supera las 24 hs de la de Salida", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePicker_fechaSalida.Value = DateTime.Now;
                    dateTimePicker_fechaSalida.ShowUpDown = false;
                    dateTimePicker_fechaLlegadaEstimada.Value = DateTime.Now;
                    dateTimePicker_fechaLlegadaEstimada.ShowUpDown = false;
                }

                if (!FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarMicroDisponible(fechaSalida, micro))
                {
                    MessageBox.Show("El micro no esta disponible porque esta realizando otro viaje", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxMicro.Text = "";
                }

                else
                {
                    string codigoRecorrido = textBox_numeroRecorrido.Text.ToString();
                    cc = ConnectorClass.Instance;
                    dt = cc.executeQuery("INSERT INTO BUGDEVELOPING.VIAJE (VIAJE_MICRO_PATENTE, VIAJE_CODIGO_RECORRIDO, VIAJE_FECHA_SALIDA, VIAJE_FECHA_ESTIMADA_LLEGADA) values ('" + micro + "','" + codigoRecorrido + "', '" + fechaSalida + "', '" + fechaLlegadaEstimada + "')");
                    MessageBox.Show("Se genero el viaje de manera correcta", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                }
            }
          }
     }
}

