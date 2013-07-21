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
    public partial class Micro_Modificacion : BaseForm
    {
        public bool mainLoadFinished = false;

        public Micro_Modificacion():
               base()
        {
            InitializeComponent();
        }

        public string microPatente = "";

        private void Micro_Modificacion_Load(object sender, EventArgs e)
        {
            /*Cargo los combo box*/
            loadComboBox();
            /*Cargo la info del micro*/
            loadMicroData();
        }

        private void loadMicroData()
        {
            /*Cargo la informacion del micro correspondiente*/
            textBox_Patente.Text = microPatente;
            DataTable micro = obtenerMicro(textBox_Patente.Text);

            comboBox_Marca.Text = micro.Rows[0].ItemArray[1].ToString();
            textBox_Modelo.Text = micro.Rows[0].ItemArray[3].ToString();
            textBox_NumeroMicro.Text = micro.Rows[0].ItemArray[2].ToString();
            textBox_KG.Text = micro.Rows[0].ItemArray[5].ToString();
        }

        private void loadComboBox()
        {
            DataTable DtMarcas = obtenerMarcas();
            comboBox_Marca.DataSource = DtMarcas;
            comboBox_Marca.DisplayMember = "MARCA_NOMBRE";
            comboBox_Marca.ValueMember = "MARCA_CODIGO";
        }

        public static DataTable obtenerPatentes()
        {
            DataTable patentes;

            String query = "SELECT MICRO_PATENTE FROM BUGDEVELOPING.MICRO";
            ConnectorClass conexion = ConnectorClass.Instance;
            patentes = conexion.executeQuery(query);

            return patentes;
        }

        public static DataTable obtenerMarcas()
        {
            DataTable Dt;
            String query = "SELECT * FROM  BUGDEVELOPING.MARCA";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        private DataTable obtenerMicro(Object patente)
        {
        DataTable micro;
        string seleccion = "SELECT MICRO_PATENTE as 'Patente',MARCA_NOMBRE as 'MARCA',  MICRO_NUMERO as 'Numero', MICRO_MODELO as 'Modelo',TIPO_SERVICIO_NOMBRE as 'Servicio',  MICRO_CANTIDAD_KGS as 'Capacidad(KG)'";
        string origen = "FROM BUGDEVELOPING.MICRO left join BUGDEVELOPING.MARCA on (Micro.MICRO_CODIGO_MARCA = MARCA_CODIGO) left join BUGDEVELOPING.TIPO_SERVICIO TS on (MICRO.MICRO_TIPO_SERVICIO = TS.TIPO_SERVICIO_CODIGO)";
        string condicion = " WHERE MICRO_PATENTE ='" + patente + "'";
        ConnectorClass conexion = ConnectorClass.Instance;
        micro = conexion.executeQuery(seleccion+origen+condicion);

        return micro;
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            loadMicroData();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (!fieldsHaveMissingValues()) saveChangesToDB();
        }

        private bool fieldsHaveMissingValues()
        {
            bool hasMissingValue = false;
            string errorMesaje = "Los siguientes campos son obligatorios y estan sin cargar:";

            if (comboBox_Marca.Text == "")
            {
                errorMesaje += " Marca ";
                hasMissingValue = true;
            }

            if (textBox_Modelo.Text == "")
            {
                errorMesaje += " Modelo ";
                hasMissingValue = true;
            }

            if (hasMissingValue)
            {
                MessageBox.Show(errorMesaje, "Modificacion de Recorridos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }               

            return hasMissingValue;
        }

        private void saveChangesToDB()
        {
            FuncionesMicro.modificarMicro(textBox_Patente.Text, comboBox_Marca.SelectedValue.ToString(), textBox_Modelo.Text);
            MessageBox.Show("El micro se modifico exitosamente", "Modificacion de Micro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void comboBox_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
