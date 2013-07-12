using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.GenerarViaje
{
    public partial class ListadoRecorridos : BaseForm
    {
        public ListadoRecorridos():
               base()
        {
            InitializeComponent();
        }

        ConnectorClass cc;
        DataTable dt;
        public string numeroRecorrido;
        public string tipoServicio;
        

        private void ListadoRecorridos_Load(object sender, EventArgs e)
        {
            //carga del dataGridView lista de recorridos
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT RECORRIDO_CODIGO AS 'NRO', CO.CIUDAD_NOMBRE AS 'CIUDAD ORIGEN', CD.CIUDAD_NOMBRE AS 'CIUDAD DESTINO', TIPO_SERVICIO_NOMBRE AS 'TIPO SERVICIO'  FROM BUGDEVELOPING.RECORRIDO JOIN BUGDEVELOPING.TIPO_SERVICIO ON (RECORRIDO_TIPO_SERVICIO = TIPO_SERVICIO_CODIGO) JOIN BUGDEVELOPING.CIUDAD CD ON (RECORRIDO_ID_CIUDAD_DESTINO = CD.CIUDAD_ID) JOIN BUGDEVELOPING.CIUDAD CO ON (RECORRIDO_ID_CIUDAD_ORIGEN = CO.CIUDAD_ID) WHERE RECORRIDO_ACTIVO = 1");
            dataGridView_Recorridos.DataSource = dt;
            
            //carga del comboboxTipoServicio
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT TIPO_SERVICIO_CODIGO, TIPO_SERVICIO_NOMBRE FROM BUGDEVELOPING.TIPO_SERVICIO");
            comboBoxTipoServicio.DataSource = dt;
            comboBoxTipoServicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBoxTipoServicio.ValueMember = "TIPO_SERVICIO_CODIGO";
            comboBoxTipoServicio.Text = "";
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCiudadOrigen.Text = "";
            textBoxCiudadDestino.Text = "";
            comboBoxTipoServicio.Text = "";
        }

        private void buscarRecorrido_Click(object sender, EventArgs e)
        {
            cc = ConnectorClass.Instance;
            string seleccion = "SELECT RECORRIDO_CODIGO AS 'NRO', CO.CIUDAD_NOMBRE AS 'CIUDAD ORIGEN', CD.CIUDAD_NOMBRE AS 'CIUDAD DESTINO', TIPO_SERVICIO_NOMBRE AS 'TIPO SERVICIO'";
            string origen = "FROM BUGDEVELOPING.RECORRIDO JOIN BUGDEVELOPING.TIPO_SERVICIO ON (RECORRIDO_TIPO_SERVICIO = TIPO_SERVICIO_CODIGO) JOIN BUGDEVELOPING.CIUDAD CD ON (RECORRIDO_ID_CIUDAD_DESTINO = CD.CIUDAD_ID) JOIN BUGDEVELOPING.CIUDAD CO ON (RECORRIDO_ID_CIUDAD_ORIGEN = CO.CIUDAD_ID)";
            string condicion = " where 1=1";

            if (textBoxCiudadOrigen.Text != "")
            { condicion += " and CO.CIUDAD_NOMBRE like " + "'%" + textBoxCiudadOrigen.Text + "%'"; }

            if (textBoxCiudadDestino.Text != "")
            { condicion += "and CD.CIUDAD_NOMBRE like " + "'%" + textBoxCiudadDestino.Text + "%'"; }

            if (comboBoxTipoServicio.Text != "")
            { condicion += "and TIPO_SERVICIO_NOMBRE = '" + comboBoxTipoServicio.Text + "'"; }

            dataGridView_Recorridos.DataSource = cc.executeQuery(seleccion + origen + condicion);
            dataGridView_Recorridos.Enabled = true;
        }

        private void dataRecorridos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numeroRecorrido = dataGridView_Recorridos.CurrentRow.Cells[0].Value.ToString();
            tipoServicio = dataGridView_Recorridos.CurrentRow.Cells[3].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
