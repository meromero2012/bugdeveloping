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
        
        public MicroBaja():
               base()
        {
            InitializeComponent();
        }

        public string microPatente= "";

        private void MicroBaja_Load(object sender, EventArgs e)
        {
            label_Patente.Text = microPatente;

            /*Cargo las fechas del date picker*/

            loadDatePickers();
            
        }

        private void loadDatePickers()
        {
            /*Cargo los date pickers y limito las fechas */
            dateTimePicker_FechaBajaNuevaC.MinDate = DateTime.Today;
            dateTimePicker_FechaBajaNuevaC.MaxDate = DateTime.Today.AddYears(50);
            dateTimePicker_FechaBajaNuevaF.MinDate = DateTime.Today;
            dateTimePicker_FechaBajaNuevaF.MaxDate = DateTime.Today.AddYears(50);
        }

        private void button_Confirmar_Click(object sender, EventArgs e)
        {
                
            bool hasDateError = false;
            /*Chequeo que la fecha de comienzo sea menor a la de finalizacion*/
            hasDateError = checkDateInterval(dateTimePicker_FechaBajaNuevaC.Value, dateTimePicker_FechaBajaNuevaF.Value);
            /*Chequeo que el micro no se encuentre ya afuera de servicio en esa fecha*/
            if (!hasDateError)
            { 
               hasDateError = isMicroOutInDate(dateTimePicker_FechaBajaNuevaC.Value, dateTimePicker_FechaBajaNuevaF.Value);
            }

            if (!hasDateError)
            {
                /*Pasar los viajes a micros similares los que no los cancelo*/
                FrbaBus.Abm_Micro.FuncionesMicro.cancelarOMoverViajesDeMicroParaFecha(microPatente, dateTimePicker_FechaBajaNuevaC.Value, dateTimePicker_FechaBajaNuevaF.Value);
                /* Mandar a fuera de servicio al micro */
                FrbaBus.Abm_Micro.FuncionesMicro.mandarMicroFueraServicio(microPatente, dateTimePicker_FechaBajaNuevaC.Value, dateTimePicker_FechaBajaNuevaF.Value);
                
            }

         
        }

                  
        private bool checkDateInterval(DateTime fechaComienzo, DateTime fechaFinalizacion)
        {
            /*Me fijo que la fecha de inicio sea menor a la de reincorporacion*/
            bool dateHasError = false;
            var comparacionFechas = DateTime.Compare(fechaComienzo, fechaFinalizacion);
            if (comparacionFechas > 0)
            {
                dateHasError = true;
                MessageBox.Show("Fecha comienzo menor a la fecha de finalizacion");
            }
            return dateHasError;
        }

        private bool isMicroOutInDate(DateTime fechaComienzo, DateTime fechaFinalizacion)
        {
            /*Controlo que el micro no se encuentre previamente fuera de servicio en esas fechas*/
            bool dateHasError = false;
            dateHasError = FrbaBus.Abm_Micro.FuncionesMicro.microEstaFueraDeServicioDurante(microPatente, fechaComienzo, fechaFinalizacion);
            
            if(dateHasError) MessageBox.Show("El micro ya se encuentra fuera de servicio en esas fechas");
            
            return dateHasError;
        }

         private void button_Volver_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void button_baja_Click(object sender, EventArgs e)
         {
             /*Pasar los viajes a micros similares los que no los cancelo*/
             FrbaBus.Abm_Micro.FuncionesMicro.cancelarOMoverViajesDeMicroParaFecha(microPatente, DateTime.Today, DateTime.Today.AddYears(100));

             /*Guardo el micro en micros baja*/
             FrbaBus.Abm_Micro.FuncionesMicro.bajarMicroEnDB(microPatente, DateTime.Today);
             
             /*Imprimo por pantalla que el micro fue dado de baja y cierro*/
             MessageBox.Show("El micro fue dado de baja");
             Close();


         }
    }
}
