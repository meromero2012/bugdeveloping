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
    public partial class ListadoMicro : BaseForm
    {
        public ListadoMicro():
               base()
        {
            InitializeComponent();
        }

        ConnectorClass cc;
        DataTable dt;
        public string numeroPatenteMicro;
        public string tipoServicio;

        private void ListadoMicro_Load(object sender, EventArgs e)
        {
            //carga del dataGridView lista de micros
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT MICRO_PATENTE AS 'PATENTE', MARCA_NOMBRE AS 'MARCA' , MICRO_CANTIDAD_KGS AS 'CANT KGS', MICRO_TIPO_SERVICIO AS 'TIPO SERVICIO' FROM BUGDEVELOPING.MICRO JOIN BUGDEVELOPING.MARCA ON (MICRO_CODIGO_MARCA = MARCA_CODIGO)");
            dataGridView_Micros.DataSource = dt;

            //carga del comboboxTipoServicio
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT TIPO_SERVICIO_CODIGO, TIPO_SERVICIO_NOMBRE FROM BUGDEVELOPING.TIPO_SERVICIO");
            comboBoxTipoServicio.DataSource = dt;
            comboBoxTipoServicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBoxTipoServicio.ValueMember = "TIPO_SERVICIO_CODIGO";
            comboBoxTipoServicio.Text = "";

            //carga del comboboxMarcaDelMicro
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT MARCA_CODIGO, MARCA_NOMBRE FROM BUGDEVELOPING.MARCA");
            comboBoxMarcaMicro.DataSource = dt;
            comboBoxMarcaMicro.DisplayMember = "MARCA_NOMBRE";
            comboBoxMarcaMicro.ValueMember = "MARCA_CODIGO";
            comboBoxMarcaMicro.Text = "";
        }

        private void buscarMicro_Click(object sender, EventArgs e)
        {
            cc = ConnectorClass.Instance;
            string seleccion = "SELECT MICRO_PATENTE AS 'PATENTE', MARCA_NOMBRE AS 'MARCA' , MICRO_CANTIDAD_KGS AS 'CANT KGS', MICRO_TIPO_SERVICIO AS 'TIPO SERVICIO'";
            string origen = " FROM BUGDEVELOPING.MICRO JOIN BUGDEVELOPING.MARCA ON (MICRO_CODIGO_MARCA = MARCA_CODIGO)";
            string condicion = " where 1=1";

            if (textBoxCantKGS.Text != "")
            { condicion += " and MICRO_CANTIDAD_KGS >= '" + textBoxCantKGS.Text + "'"; }

            if (comboBoxMarcaMicro.Text != "")
            { condicion += "and MARCA_NOMBRE = '" + comboBoxMarcaMicro.Text + "'"; }

            if (comboBoxTipoServicio.Text != "")
            { condicion += "and MICRO_TIPO_SERVICIO = '" + comboBoxTipoServicio.Text + "'"; }

            dataGridView_Micros.DataSource = cc.executeQuery(seleccion + origen + condicion);
            dataGridView_Micros.Enabled = true;

        }

        private void dataGridView_Micros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numeroPatenteMicro = dataGridView_Micros.CurrentRow.Cells[0].Value.ToString();
            tipoServicio = dataGridView_Micros.CurrentRow.Cells[3].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCantKGS.Text = "";
            comboBoxMarcaMicro.Text = "";
            comboBoxTipoServicio.Text = "";
        }
    }


}
