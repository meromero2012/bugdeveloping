using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroBaja : BaseForm
    {
        public bool mainloadFinished = false;
        public MicroBaja()
            :base()
        {
            InitializeComponent();
        }

        private void MicroBaja_Load(object sender, EventArgs e)
        {
            DataTable DtPatentes;
            DtPatentes = obtenerPatentes();
            comboBox_Patente.DataSource = DtPatentes;
            comboBox_Patente.DisplayMember = "MICRO_PATENTE";
            comboBox_Patente.ValueMember = "MICRO_PATENTE";

            mainloadFinished = true;
        }

        public static DataTable obtenerPatentes()
        {
            DataTable patentes;

            String query = "SELECT MICRO_PATENTE FROM BUGDEVELOPING.MICRO";
            ConnectorClass conexion = ConnectorClass.Instance;
            patentes = conexion.executeQuery(query);

            return patentes;
        }

        private void comboBox_Patente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mainloadFinished) return;
            
            textBox_FechaBaja.Text = obtenerFechaBajaDeMicro(comboBox_Patente.SelectedValue);
            textBox_FechaBaja.Enabled = false;
            textBox_FechaBaja.BackColor = Color.White;
            DateTime fechaBaja = Convert.ToDateTime(textBox_FechaBaja.Text);
            var result = DateTime.Compare(fechaBaja, DateTime.Today);
            if(result < 0)
            {
                dateTimePicker_FechaBajaNuevaC.Visible = false;
                dateTimePicker_FechaBajaNuevaF.Visible = false;
                label_Finaliza.Visible = false;
                label9_Comienzo.Visible = false;
                button_Confirmar.Visible = false;

                button_DarDeBaja.Visible = true;
                label_FechaBaja.Visible = true;

            }
            else
            {
                dateTimePicker_FechaBajaNuevaC.Visible = true;
                dateTimePicker_FechaBajaNuevaF.Visible = true;
                label_Finaliza.Visible = true;
                label9_Comienzo.Visible = true;
                button_Confirmar.Visible = true;

                button_DarDeBaja.Visible = false;

                dateTimePicker_FechaBajaNuevaC.MinDate = DateTime.Today;
                dateTimePicker_FechaBajaNuevaC.MaxDate = Convert.ToDateTime(textBox_FechaBaja.Text);
                dateTimePicker_FechaBajaNuevaF.MinDate = DateTime.Today;
                dateTimePicker_FechaBajaNuevaF.MaxDate = Convert.ToDateTime(textBox_FechaBaja.Text);

            }
            
            
        }

         public static string obtenerFechaBajaDeMicro(object micro)
        {
            DataTable patentes;
            string date;
            String query = "SELECT MICRO_FECHA_BAJA FROM BUGDEVELOPING.MICRO WHERE MICRO_PATENTE = '"+micro+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            patentes = conexion.executeQuery(query);
            date = patentes.Rows[0].ItemArray[0].ToString();
            return date;
        }

         private void label9_FechaDeBajaNuevo_Click(object sender, EventArgs e)
         {

         }

         private void dateTimePicker_FechaBajaNuevaC_ValueChanged(object sender, EventArgs e)
         {
         }

         private void button_Confirmar_Click(object sender, EventArgs e)
         {
             DateTime fechaComienzo =  dateTimePicker_FechaBajaNuevaC.Value;
             DateTime fechaFinalizacion = dateTimePicker_FechaBajaNuevaF.Value;
             var comparacionFechas = DateTime.Compare(fechaComienzo, fechaFinalizacion);
             if(comparacionFechas > 0)
             {
                 MessageBox.Show("Fecha comienzo menor");
             }  

         }

         private void cancelarButton_Click(object sender, EventArgs e)
         {
             this.Close();
         }
    }
}
