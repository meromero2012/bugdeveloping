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
    public partial class microAlta : BaseForm
    {
        public microAlta()
            :base()
        {
            InitializeComponent();
        }

        private void textBox_Patente_TextChanged(object sender, EventArgs e)
        {
            comboBox_Marca.Enabled = false;
            textBox_Modelo.Enabled = false;
            comboBox_Servicio.Enabled = false;
            comboBox_NumeroDeMicro.Enabled = false;
            dateTimePicker_Vida_Util.Enabled = false;
            textBox_KG.Enabled = false;
            comboBox_Asientos_Piso1.Enabled = false;
            comboBox_Asientos_Piso2.Enabled = false;
            checkedListBox_Piso1.Visible = false;
            checkedListBox_Piso2.Visible = false;
            label_EsVentana_P1.Visible = false;
            label_EsVentana_P2.Visible = false;
        }
        private void textBox_Patente_Validating(object sender, EventArgs e)
        {
            MessageBox.Show("validando");
        }

        private void microAlta_Load(object sender, EventArgs e)
        {
            comboBox_Marca.Enabled = false;
            textBox_Modelo.Enabled = false;
            comboBox_Servicio.Enabled = false;
            comboBox_NumeroDeMicro.Enabled = false;
            dateTimePicker_Vida_Util.Enabled = false;
            textBox_KG.Enabled = false;
            comboBox_Asientos_Piso1.Enabled = false;
            comboBox_Asientos_Piso2.Enabled = false;
            checkedListBox_Piso1.Visible = false;
            checkedListBox_Piso2.Visible = false;
            label_EsVentana_P1.Visible = false;
            label_EsVentana_P2.Visible = false;

        }

        private void button_ValidarPatente_Click(object sender, EventArgs e)
        {
            if(textBox_Patente.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar una patente para ser validada");
                    textBox_Patente.Focus();
                return;
                }
            
             bool patenteValida =  validarPatente(textBox_Patente.Text);
            if(!patenteValida)
                {
                    MessageBox.Show("Debe ingresar una patente para ser validada");
                 
                }
            else
                {
                if(comboBox_Marca.Items.Count != 0)//Quiere decir que ya se habian cargado datos
                {
                    comboBox_Marca.Enabled = true;
                    textBox_Modelo.Enabled = true;
                    comboBox_Servicio.Enabled = true;
                    comboBox_NumeroDeMicro.Enabled = true;
                    dateTimePicker_Vida_Util.Enabled = true;
                    textBox_KG.Enabled = true;
                    comboBox_Asientos_Piso1.Enabled = true;
                    comboBox_Asientos_Piso2.Enabled = true;
                    checkedListBox_Piso1.Visible = true;
                    checkedListBox_Piso2.Visible = true;
                    label_EsVentana_P1.Visible = true;
                    label_EsVentana_P2.Visible = true;
                }
                else
                {
                    comboBox_Marca.Enabled = true;
                    textBox_Modelo.Enabled = true;
                    comboBox_Servicio.Enabled = true;
                    comboBox_NumeroDeMicro.Enabled = true;
                    dateTimePicker_Vida_Util.Enabled = true;
                    textBox_KG.Enabled = true;
                    comboBox_Asientos_Piso1.Enabled = true;
                    comboBox_Asientos_Piso2.Enabled = true;
                    checkedListBox_Piso1.Visible = false;
                    checkedListBox_Piso2.Visible = false;

                    comboBox_NumeroDeMicro.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());
                 

                    DataTable DtMarcas;
                    DtMarcas = obtenerMarcas();
                    comboBox_Marca.DataSource = DtMarcas;
                    comboBox_Marca.DisplayMember = "MARCA_NOMBRE";
                    comboBox_Marca.ValueMember = "MARCA_CODIGO";

                    DataTable DtTipoServicios;
                    DtTipoServicios = obtenerTipoServicios();
                    comboBox_Servicio.DataSource = DtTipoServicios;
                    comboBox_Servicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
                    comboBox_Servicio.ValueMember = "TIPO_SERVICIO_CODIGO";

                    comboBox_Asientos_Piso1.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());
                    comboBox_Asientos_Piso2.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());

                }
                }
        
        
        }

        public static bool validarPatente(string patente)
        {
            DataTable Dt;
            String query = "SELECT MICRO_PATENTE FROM  BUGDEVELOPING.MICRO WHERE MICRO_PATENTE = '"+patente+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            if (Dt.Rows.Count == 0) return true;
            else return false;
        }

        public static DataTable obtenerMarcas()
        {
            DataTable Dt;
            String query = "SELECT * FROM  BUGDEVELOPING.MARCA";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;    
        }

        public static DataTable obtenerTipoServicios()
        {
            DataTable Dt;
            String query = "SELECT * FROM BUGDEVELOPING.TIPO_SERVICIO";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        private void comboBox_Asientos_Piso1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int asientos = comboBox_Asientos_Piso1.SelectedIndex;
            if (asientos == 0) checkedListBox_Piso1.Visible = false;
            else
            {
                if (!checkedListBox_Piso1.Visible) checkedListBox_Piso1.Visible = true;                 
                string valueInComboBox = comboBox_Asientos_Piso1.SelectedItem.ToString();
                checkedListBox_Piso1.Items.Clear();
                checkedListBox_Piso1.Items.AddRange(Enumerable.Range(0,Convert.ToInt16(valueInComboBox) ).Cast<object>().ToArray());
                label_EsVentana_P1.Visible = true;
                
                
            }
        }

        private void comboBox_Asientos_Piso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int asientos = comboBox_Asientos_Piso2.SelectedIndex;
            if (asientos == 0) checkedListBox_Piso2.Visible = false;
            else
            {
                if(!checkedListBox_Piso2.Visible) checkedListBox_Piso2.Visible = true;
                    string valueInComboBox = comboBox_Asientos_Piso2.SelectedItem.ToString();
                    checkedListBox_Piso2.Items.Clear();    
                    checkedListBox_Piso2.Items.AddRange(Enumerable.Range(0, Convert.ToInt16(valueInComboBox)).Cast<object>().ToArray());
                    label_EsVentana_P2.Visible = true;    
                
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
          //TODO poner aca lo del archivo de configuracion
            string microPatente = textBox_Patente.Text;
            string codigoMarga = comboBox_Marca.SelectedValue.ToString(); 
            string modelo = textBox_Modelo.Text;
            string tipoServicio = comboBox_Servicio.SelectedValue.ToString();
          
            string numeroMicro = comboBox_NumeroDeMicro.SelectedItem.ToString();

            string fechaAlta = dateTimePicker_Vida_Util.Value.ToUniversalTime().ToString();
            string fechaVidaUtil = dateTimePicker_Vida_Util.Value.ToUniversalTime().ToString();

            string KGEncomienda = textBox_KG.Text;

            string mensaje2 = "Los siguientes campos son obligatorios y estan sin cargar o presentan errores:";
            bool faltanDatos = false;

            if (modelo == "")
            {
                mensaje2 += " Modelo ";
                faltanDatos = true;
            }

            if (numeroMicro == "")
            {
                mensaje2 += " Numero de Micro";
                faltanDatos = true;
            }

            if (KGEncomienda == "")
            {
                mensaje2 += " Espacio Encomiendas(KG) ";
                faltanDatos = true;
            }

            if (comboBox_Asientos_Piso1.SelectedIndex == 0 & comboBox_Asientos_Piso2.SelectedIndex == 0)
            {
                //TODO nose como hacer si no se selecciono nunca AAAA LPTM
                mensaje2 += " Al menos un piso debe tener asientos ";
                faltanDatos = true;
            }

            if (faltanDatos == true)
            {
                MessageBox.Show(mensaje2, "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            //Guardar micro

              if(guardarNuevoMicro(microPatente, numeroMicro, fechaAlta, codigoMarga, modelo, tipoServicio, KGEncomienda, fechaVidaUtil))
              {
                guardarButacasDeNuevoMicro(microPatente, checkedListBox_Piso1, checkedListBox_Piso2);
              }
              else                  
              {
                comboBox_Marca.Enabled = false;
                textBox_Modelo.Enabled = false;
                comboBox_Servicio.Enabled = false;
                comboBox_NumeroDeMicro.Enabled = false;
                dateTimePicker_Vida_Util.Enabled = false;
                textBox_KG.Enabled = false;
                comboBox_Asientos_Piso1.Enabled = false;
                comboBox_Asientos_Piso2.Enabled = false;
                checkedListBox_Piso1.Enabled = false;
                checkedListBox_Piso2.Enabled = false;
              }
           }
        
        }

        public  Boolean guardarNuevoMicro(string microPatente, string numeroMicro, string fechaAlta, string codigoMarga, string modelo, string tipoServicio, string KGEncomienda, string fechaVidaUtil)
        {
            //TODO CHECKEO DE INGRESAR COMAS DEL ORTO
            bool exito = false;
            DataTable Dt;
            String query = "EXEC [BUGDEVELOPING].[MICRO_ALTA] " 
                    + microPatente +
                "," + numeroMicro +
                ",'" + fechaAlta +
                "'," + codigoMarga +
                "," + modelo +
                "," + tipoServicio +
                "," + KGEncomienda +
                ",'" + fechaVidaUtil+"'";

            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);

            if(Dt.Rows[0].ItemArray[0].ToString() == "PatenteExistente")
            {
            MessageBox.Show("La patente acaba de ser tomada y ya existe, porfavor, seleccione una nueva", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
            }
            else if (Dt.Rows[0].ItemArray[0].ToString() == "GuardadoExistoso")
            {
            MessageBox.Show("El micro fue dado de alta exitosamente", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            exito = true;
            }
            return exito;
        }


        public void guardarButacasDeNuevoMicro(string microPatente, CheckedListBox checkedListBox_Piso1, CheckedListBox checkedListBox_Piso2)
        {

            DataTable Dt;
            ConnectorClass conexion = ConnectorClass.Instance;

            int butacaPiso=1;
            int butacaNumero=2;
            CheckState butacaTipo;
            //0 es butaca pasillo 1 ventana
            string butacaTipoString;

            int a = checkedListBox_Piso1.Items.Count;

            if(checkedListBox_Piso1.Visible)
            {
                for(int i = 0;i<checkedListBox_Piso1.Items.Count ;i++)
                {
                    butacaPiso = 1;
                    butacaNumero = i;
                    butacaTipo = checkedListBox_Piso1.GetItemCheckState(i);
                    if (butacaTipo == 0) butacaTipoString = "Pasillo";
                    else butacaTipoString = "Ventanilla";

                    String query = "EXEC [BUGDEVELOPING].[BUTACA_ALTA] " +
                    microPatente+
                    ", "+butacaPiso+
                    ", "+butacaNumero+
                    ", "+butacaTipoString;

                    Dt = conexion.executeQuery(query);
                }

            if(checkedListBox_Piso2.Visible)
            {
                for(int i = 0;i<checkedListBox_Piso2.Items.Count ;i++)
                {
                    butacaPiso = 2;
                    butacaNumero = i;
                    butacaTipo = checkedListBox_Piso2.GetItemCheckState(i);
                    if (butacaTipo == 0) butacaTipoString = "Pasillo";
                    else butacaTipoString = "Ventanilla";

                    String query = "EXEC [BUGDEVELOPING].[BUTACA_ALTA] " +
                    microPatente+
                    ", "+butacaPiso+
                    ", "+butacaNumero+
                    ", "+butacaTipoString;

                    Dt = conexion.executeQuery(query);
                }
            }

          }            
        }

        private void checkedListBox_Piso1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_Vida_Util_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
