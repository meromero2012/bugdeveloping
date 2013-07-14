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
    public partial class ListadoMicros : BaseForm
    {
        public ListadoMicros():
               base()
        {
            InitializeComponent();
        }

        ConnectorClass cc;
        public string numeroMicro;
        public string tipoServicio;
        public bool esModificacion = false;

        private void ListadoMicros_Load(object sender, EventArgs e)
        {
            
            /*Cargo los combobox*/
            loadComboBox();

            /*Llamo a este metodo para que se muestren todos los micros*/
            button_Limpiar_Click(sender, e);

        }

        private void loadComboBox()
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
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Patente.Text = "";
            comboBox_Marca.Text = "";
            textBox_Modelo.Text = "";
            comboBox_Servicio.Text = "";
            textBox_NumeroMicro.Text = "";
            bFiltrar_Click(sender,e);
        }

        private void bFiltrar_Click(object sender, EventArgs e)
        {
            cc = ConnectorClass.Instance;
            string seleccion = "SELECT MICRO_PATENTE as 'Patente',MARCA_NOMBRE as 'MARCA',  MICRO_NUMERO as 'Numero', MICRO_MODELO as 'Modelo',TIPO_SERVICIO_NOMBRE as 'Servicio',  MICRO_CANTIDAD_KGS as 'Capacidad(KG)'";
            string origen = "FROM BUGDEVELOPING.MICRO left join BUGDEVELOPING.MARCA on (Micro.MICRO_CODIGO_MARCA = MARCA_CODIGO) left join BUGDEVELOPING.TIPO_SERVICIO TS on (MICRO.MICRO_TIPO_SERVICIO = TS.TIPO_SERVICIO_CODIGO)";
            string condicion = "Where MICRO_FECHA_BAJA is Null";


            if (textBox_Patente.Text != "")
            { condicion += " and MICRO_PATENTE like " + "'%" + textBox_Patente.Text + "%'"; }

            if (comboBox_Marca.Text != "")
            { condicion += "and  MARCA_NOMBRE like " + "'%" + comboBox_Marca.Text + "%'"; }

            if (textBox_NumeroMicro.Text != "")
            { condicion += " and MICRO_NUMERO like " + "'%" + textBox_NumeroMicro.Text + "%'"; }

            if (textBox_Modelo.Text != "")
            { condicion += " and MICRO_MODELO like " + "'%" + textBox_Modelo.Text + "%'"; }

            if (comboBox_Servicio.Text != "")
            { condicion += " and TIPO_SERVICIO_NOMBRE like " + "'%" + comboBox_Servicio.Text + "%'"; }

            dataGridView_Micros.DataSource = cc.executeQuery(seleccion + origen + condicion);
            dataGridView_Micros.Enabled = true;
        }

        private void dataGridView_Micros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (esModificacion)
            {
                Micro_Modificacion formModificacion = new Micro_Modificacion();
                formModificacion.microPatente = dataGridView_Micros.CurrentRow.Cells[0].Value.ToString();
                formModificacion.ShowDialog();
            }
            else
            {
                MicroBaja formBaja = new MicroBaja();
                formBaja.microPatente = dataGridView_Micros.CurrentRow.Cells[0].Value.ToString();
                formBaja.ShowDialog();
            }
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
