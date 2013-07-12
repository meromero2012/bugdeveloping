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

        public Micro_Modificacion()
            :base()
        {
            InitializeComponent();
        }

        private void Micro_Modificacion_Load(object sender, EventArgs e)
        {
            DataTable DtPatentes;
            DtPatentes = obtenerPatentes();
            comboBox_Patente.DataSource = DtPatentes;
            comboBox_Patente.DisplayMember = "MICRO_PATENTE";
            comboBox_Patente.ValueMember = "MICRO_PATENTE";


            mainLoadFinished = true;

            DataTable DtMarcas = obtenerMarcas();
            comboBox_MarcaNuevo.DataSource = DtMarcas;
            comboBox_MarcaNuevo.DisplayMember = "MARCA_NOMBRE";
            comboBox_MarcaNuevo.ValueMember = "MARCA_CODIGO";

            comboBox_NumeroMicro_Nuevo.Items.AddRange(Enumerable.Range(0, 100).Cast<object>().ToArray());

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
            if (!mainLoadFinished) return;
            DataTable micro = obtenerMicro(comboBox_Patente.SelectedValue);

            textBox_Marca.Text = micro.Rows[0].ItemArray[3].ToString();
            textBox_Modelo.Text = micro.Rows[0].ItemArray[4].ToString();
            String modelo = micro.Rows[0].ItemArray[1].ToString();
            textBox_NumeroDeMicro.Text = micro.Rows[0].ItemArray[1].ToString();
            textBox_KG.Text = micro.Rows[0].ItemArray[6].ToString();
            textBox_FechaBaja.Text = micro.Rows[0].ItemArray[2].ToString();

            /*textBox_Marca.BackColor = Color.White;
            textBox_Modelo.BackColor = Color.White;
            textBox_NumeroDeMicro.BackColor = Color.White;
            textBox_KG.BackColor = Color.White;
            textBox_FechaBaja.BackColor = Color.White;*/
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
        String query = "SELECT * FROM BUGDEVELOPING.MICRO WHERE MICRO_PATENTE ='"+patente+"'";
        ConnectorClass conexion = ConnectorClass.Instance;
        micro = conexion.executeQuery(query);

        return micro;
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            comboBox_MarcaNuevo.Visible = true;
            textBox_ModeloNuevo.Visible = true;
            comboBox_NumeroMicro_Nuevo.Visible = true;
            dateTimePicker_FechaBajaNueva.Visible = true;
            comboBox_EspacioEncomiendasNuevo.Visible = true;

            label13_MarcaNuevo.Visible = true;
            label11_ModeloNuevo.Visible = true;
            label2_NumeroDeMicro.Visible = true;
            label10_EspacioEncomiendasNuevo.Visible = true;
            label9_FechaDeBajaNuevo.Visible = true;

            textBox_ModeloNuevo.Text = textBox_Modelo.Text;

            //TODO string a int
            comboBox_EspacioEncomiendasNuevo.Items.AddRange(Enumerable.Range(100, 5000).Cast<object>().ToArray());

        }

        private void comboBox_NumeroMicro_Nuevo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
