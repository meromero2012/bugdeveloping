using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.Abm_Recorrido
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
        public bool esModificacion = false;

        private void ListadoRecorridos_Load(object sender, EventArgs e)
        {
            //carga del dataGridView lista de recorridos
            this.bFiltrar_Click(sender, e);
            //carga del comboboxTipoServicio
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT TIPO_SERVICIO_CODIGO, TIPO_SERVICIO_NOMBRE FROM BUGDEVELOPING.TIPO_SERVICIO");
            comboBoxTipoServicio.DataSource = dt;
            comboBoxTipoServicio.DisplayMember = "TIPO_SERVICIO_NOMBRE";
            comboBoxTipoServicio.ValueMember = "TIPO_SERVICIO_CODIGO";
            comboBoxTipoServicio.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxCiudadOrigen.Text = "";
            textBoxCiudadDestino.Text = "";
            comboBoxTipoServicio.Text = "";
            bFiltrar_Click(sender, e);
        }

        private void bFiltrar_Click(object sender, EventArgs e)
        {
            cc = ConnectorClass.Instance;
            string seleccion = "SELECT RECORRIDO_CODIGO AS 'NRO', CO.CIUDAD_NOMBRE AS 'CIUDAD ORIGEN', CD.CIUDAD_NOMBRE AS 'CIUDAD DESTINO', TIPO_SERVICIO_NOMBRE AS 'TIPO SERVICIO'";
            string origen = "FROM BUGDEVELOPING.RECORRIDO JOIN BUGDEVELOPING.TIPO_SERVICIO ON (RECORRIDO_TIPO_SERVICIO = TIPO_SERVICIO_CODIGO) JOIN BUGDEVELOPING.CIUDAD CD ON (RECORRIDO_ID_CIUDAD_DESTINO = CD.CIUDAD_ID) JOIN BUGDEVELOPING.CIUDAD CO ON (RECORRIDO_ID_CIUDAD_ORIGEN = CO.CIUDAD_ID)";
            string condicion = " where RECORRIDO_ACTIVO = 1 ";

            if (textBoxCiudadOrigen.Text != "")
            { condicion += " and CO.CIUDAD_NOMBRE like " + "'%" + textBoxCiudadOrigen.Text + "%'"; }

            if (textBoxCiudadDestino.Text != "")
            { condicion += "and CD.CIUDAD_NOMBRE like " + "'%" + textBoxCiudadDestino.Text + "%'"; }

            if (comboBoxTipoServicio.Text != "")
            { condicion += "and TIPO_SERVICIO_NOMBRE = '" + comboBoxTipoServicio.Text + "'"; }

            dataGridView_Recorridos.DataSource = cc.executeQuery(seleccion + origen + condicion);
            dataGridView_Recorridos.Enabled = true;
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_Recorridos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numeroRecorrido = dataGridView_Recorridos.CurrentRow.Cells[0].Value.ToString();
            if (esModificacion)
            {
                modRecorrido formModificacion = new modRecorrido();
                formModificacion.codigoRecorrido = numeroRecorrido;
                formModificacion.ShowDialog();                   
            }
            else
            {
                BajaRecorrido formBaja = new BajaRecorrido();
                formBaja.codigoRecorrido = numeroRecorrido;
                formBaja.ShowDialog();                   
            }
        
        }
    }
}
