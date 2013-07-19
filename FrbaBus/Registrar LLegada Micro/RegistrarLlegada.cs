using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.Registrar_LLegada_Micro
{
    public partial class RegistrarLlegada : BaseForm
    {
        public RegistrarLlegada()
               :base()
        {
            InitializeComponent();
        }
        
        ConnectorClass cc;
        DataTable dt;
        string origen;
        string arribo;

        DateTime fechaActual = new DateTime(Convert.ToInt32(ConfigurationManager.AppSettings["SystemYear"]), Convert.ToInt32(ConfigurationManager.AppSettings["SystemMonth"]), Convert.ToInt32(ConfigurationManager.AppSettings["SystemDay"]));

        private void CargarComboBoxMicro()
        {
            /*carga el comboBox con los micros que estan asignados a un viaje y todavia no se registro su llegada*/
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT DISTINCT VIAJE_MICRO_PATENTE FROM BUGDEVELOPING.VIAJE WHERE VIAJE_FECHA_LLEGADA IS NULL");
            comboBox_Micro.DataSource = dt;
            comboBox_Micro.DisplayMember = "VIAJE_MICRO_PATENTE";
            comboBox_Micro.ValueMember = "VIAJE_MICRO_PATENTE";
        }

        private void CargarComboBoxCiudades(ComboBox comboBox)
        {
            /*carga de ciudades*/
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT CIUDAD_ID, CIUDAD_NOMBRE FROM BUGDEVELOPING.CIUDAD");
            comboBox.DataSource = dt;
            comboBox.DisplayMember = "CIUDAD_NOMBRE";
            comboBox.ValueMember = "CIUDAD_ID";
        }

        private void RegistrarLlegada2_Load(object sender, EventArgs e)
        {
            CargarComboBoxCiudades(comboBox_Arribo);
            CargarComboBoxCiudades(comboBox_Origen);
            CargarComboBoxMicro();
            ReestablecerFecha();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.RegistrarLlegada2_Load(sender, e);
            ReestablecerFecha();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /*permite al date time picker seleccionar la hora*/
            this.dateTimePicker_fechaLlegada.Format = DateTimePickerFormat.Time;
            this.dateTimePicker_fechaLlegada.Width = 100;
            this.dateTimePicker_fechaLlegada.ShowUpDown = true;
        }

        private void ReestablecerFecha() 
        {
            /*vuelve las fechas al estado inicial*/
            dateTimePicker_fechaLlegada.Value = fechaActual;
            dateTimePicker_fechaLlegada.ShowUpDown = false;
            dateTimePicker_fechaLlegada.Format = DateTimePickerFormat.Long;
            dateTimePicker_fechaLlegada.Width = 200;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            origen = comboBox_Origen.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            arribo = comboBox_Arribo.SelectedValue.ToString();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            /*realiza las validaciones correspondientes y luego registra la llegada del micro*/
            string micro = comboBox_Micro.SelectedValue.ToString();
            bool huboError = false;
            DateTime fechaLlegada = dateTimePicker_fechaLlegada.Value;

            if (!(FrbaBus.Registrar_LLegada_Micro.FuncionesRegistrarLlegada.validarFecha(fechaLlegada, micro)))
            {
                MessageBox.Show("La fecha de llegada seleccionada sobrepasa las 24 hs desde la fecha de salida del micro", "Registrar Llegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReestablecerFecha();
                huboError = true;
            }

            if (!(FrbaBus.Registrar_LLegada_Micro.FuncionesRegistrarLlegada.validarTerminalDeArribo(micro, origen, arribo)))
            {
                MessageBox.Show("La ciudad de donde proviene o a donde llegó el micro es incorrecta", "Registrar Llegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarComboBoxCiudades(comboBox_Arribo);
                CargarComboBoxCiudades(comboBox_Origen);
                huboError = true;
            }

            if (huboError == false)
            {
                MessageBox.Show("Se registro la llegada del micro de manera correcta", "Registrar Llegada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrbaBus.Registrar_LLegada_Micro.FuncionesRegistrarLlegada.RegistrarLlegada(micro, fechaLlegada);
                buttonLimpiar_Click(sender, e);
            }
        }
    }
}