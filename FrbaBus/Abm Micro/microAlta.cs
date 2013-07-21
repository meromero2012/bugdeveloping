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
        public microAlta():
               base()
        {
            InitializeComponent();
            /*Seteo los handlers para limitar el ingreso de caracteres en los textBoxes*/
            textBox_KG.KeyPress += new KeyPressEventHandler(textBox_NumberKeyPress);
            textBox_NumeroMicro.KeyPress += new KeyPressEventHandler(textBox_NumberKeyPress);  
        }

        private void textBox_Patente_Validating(object sender, EventArgs e)
        {
            MessageBox.Show("validando");
        }

        private void microAlta_Load(object sender, EventArgs e)
        {
            /* Seteo invicible los checkedListBox de los asientos*/
            checkedListBox_Piso1.Visible = false;
            checkedListBox_Piso2.Visible = false;
            label_EsVentana_P1.Visible = false;
            label_EsVentana_P2.Visible = false;

            /* Cargo los combo Box*/
            loadComboBox();
        }

        public void loadComboBox()
        {
            DataTable DtMarcas;
            DtMarcas = FrbaBus.Abm_Micro.FuncionesMicro.obtenerMarcas();
            comboBox_Marca.DataSource = DtMarcas;
            comboBox_Marca.DisplayMember = "MARCA_NOMBRE";
            comboBox_Marca.ValueMember = "MARCA_CODIGO";

            DataTable DtTipoServicios;
            DtTipoServicios = FrbaBus.Abm_Micro.FuncionesMicro.obtenerTipoServicios();
            comboBox_Servicio.DataSource = DtTipoServicios;
            comboBox_Servicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBox_Servicio.ValueMember = "TIPO_SERVICIO_CODIGO";

            /*Agrego para que cada piso tenga como mucho 100 asientos por cada piso*/
            comboBox_Asientos_Piso1.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());
            comboBox_Asientos_Piso2.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());

        }

        private void comboBox_Asientos_Piso1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Cuando cambian la cantidad de asientos de un piso cargo devuelta la lista 
             *con la nueva cantidad para seleccionar si es ventana o pasillo
             */
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
            /*Cuando cambian la cantidad de asientos de un piso cargo devuelta la lista 
             *con la nueva cantidad para seleccionar si es ventana o pasillo
             */

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
            /* Verifico si falta algun campo o si esta mal formateado*/
            /* Si no falta ningun campo guardo*/
            if (fieldsAreValid()) saveChangesToDB();
        }

        private bool fieldsAreValid()
        {
            return (!fieldsHaveMissingValues()& !fieldsFormatError());
        }


        private bool fieldsFormatError()
        {
            bool formatHasError = false;
            formatHasError = validatePatente();
            return formatHasError;
        }

        private bool validatePatente()
        {
            /*Me fijo que la patente este formada por 7 caracteres, "LLL-DDD" L=Letra -= guion D= Digito*/
            bool formatHasError = false;
            if (textBox_Patente.Text.Length != 7) formatHasError = true;
            if(!formatHasError)
            {
                string letras = textBox_Patente.Text.Substring(0, 3);
                string numeros = textBox_Patente.Text.Substring(4, 3);
                string guion = textBox_Patente.Text.Substring(3, 1);

                formatHasError = !letras.All(Char.IsLetter) || !numeros.All(Char.IsDigit) || guion != "-";
            }

            if (formatHasError) 
            {
                MessageBox.Show("El formato de la patente debe ser tres caracteres seguidos por '-' y 3 numeros", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return formatHasError;
        }


        private bool fieldsHaveMissingValues()
        {
            /*Me fijo si falta llenar algun campo*/
            bool hasMissingValue = false;
            string errorMesaje = "Los siguientes campos son obligatorios y estan sin cargar:";
            string microPatente = textBox_Patente.Text;
            string codigoMarga = comboBox_Marca.SelectedValue.ToString();
            string modelo = textBox_Modelo.Text;
            string tipoServicio = comboBox_Servicio.SelectedValue.ToString();

            string numeroMicro = textBox_NumeroMicro.Text;

            string fechaAlta = dateTimePicker_Vida_Util.Value.ToUniversalTime().ToString();
            string fechaVidaUtil = dateTimePicker_Vida_Util.Value.ToUniversalTime().ToString();

            string KGEncomienda = textBox_KG.Text;

            if (modelo == "")
            {
                errorMesaje += " Modelo ";
                hasMissingValue = true;
            }

            if (numeroMicro == "")
            {
                errorMesaje += " Numero de Micro";
                hasMissingValue = true;
            }

            if (KGEncomienda == "")
            {
                errorMesaje += " Espacio Encomiendas(KG) ";
                hasMissingValue = true;
            }

            if (comboBox_Asientos_Piso1.Text == "" || comboBox_Asientos_Piso2.Text == "")
            {
                errorMesaje += " Se debe indicar la cantidad de asientos en los pisos ";
                hasMissingValue = true;
            }

            if (comboBox_Asientos_Piso1.SelectedIndex == 0 & comboBox_Asientos_Piso2.SelectedIndex == 0)
            {
                errorMesaje += " Al menos un piso debe tener asientos ";
                hasMissingValue = true;
            }

            if (hasMissingValue == true)
            {
                MessageBox.Show(errorMesaje, "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return hasMissingValue;
         }

        private void saveChangesToDB()
        {
            /*Guardo los cambios en la base de datos*/
            string microPatente = textBox_Patente.Text;
            string codigoMarga = comboBox_Marca.SelectedValue.ToString();
            string modelo = textBox_Modelo.Text;
            string tipoServicio = comboBox_Servicio.SelectedValue.ToString();
            string numeroMicro = textBox_NumeroMicro.Text;
            string fechaAlta = dateTimePicker_Vida_Util.Value.ToUniversalTime().ToString();
            string KGEncomienda = textBox_KG.Text;

            /*Guardo el micro*/
            if (guardarNuevoMicro(microPatente, numeroMicro, fechaAlta, codigoMarga, modelo, tipoServicio, KGEncomienda))
            {
                /*Si logro guardar el micro guardo las butacas correspondientes*/
                guardarButacasDeNuevoMicro(microPatente, checkedListBox_Piso1, checkedListBox_Piso2);
            }
        }



        public  Boolean guardarNuevoMicro(string microPatente, string numeroMicro, string fechaAlta, string codigoMarga, string modelo, string tipoServicio, string KGEncomienda)
        {
            bool exito = false;
            DataTable Dt;
            String query = "EXEC [BUGDEVELOPING].[MICRO_ALTA] '"
                    + microPatente +
                "'," + numeroMicro +
                ",'" + fechaAlta +
                "'," + codigoMarga +
                ",'" + modelo +
                "'," + tipoServicio +
                "," + KGEncomienda;

            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);

            if(Dt.Rows[0].ItemArray[0].ToString() == "PatenteExistente")
            {
            MessageBox.Show("La patente ya existe, porfavor, seleccione una nueva", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
            }
            else if (Dt.Rows[0].ItemArray[0].ToString() == "NumeroExistente")
            {
                MessageBox.Show("El numero de micro ya existe, porfavor, seleccione otro", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Dt.Rows[0].ItemArray[0].ToString() == "GuardadoExistoso")
            {
            MessageBox.Show("El micro fue dado de alta exitosamente", "Alta de micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            exito = true;
            }
            Close();
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

                    String query = "EXEC [BUGDEVELOPING].[BUTACA_ALTA] '" +
                    microPatente+
                    "', "+butacaPiso+
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

                    String query = "EXEC [BUGDEVELOPING].[BUTACA_ALTA] '" +
                    microPatente+
                    "', "+butacaPiso+
                    ", "+butacaNumero+
                    ", "+butacaTipoString;

                    Dt = conexion.executeQuery(query);
                }
            }

          }            
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_NumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
