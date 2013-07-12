using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;

namespace FrbaBus.Top_5
{
    public partial class ListadoEstadistico : BaseForm
    {
        public ListadoEstadistico()
            :base()
        {
            InitializeComponent();
        }

        ConnectorClass connection;
        DataTable dt;
        String top5Seleccion;
        String añoSeleccion;
        String semestreSeleccion;
        String mesMinimo;
        String mesMaximo;

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            CargarComboBoxAñoYSemestre();
        }

        private void CargarComboBoxAñoYSemestre() 
        {
            connection = ConnectorClass.Instance;
            dt = connection.executeQuery("select DISTINCT(YEAR(COMPRA_FECHA)) AS ANIO FROM BUGDEVELOPING.COMPRA");
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "ANIO";
            comboBox3.SelectedIndex=0;
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            if (semestreSeleccion == "1")
            {
                mesMinimo = "1";
                mesMaximo = "6";
            }
            if (semestreSeleccion == "2")
            {
                mesMinimo = "7";
                mesMaximo = "12";
            }

            if (top5Seleccion == "0")
            {
                String query = "select top 5 CD.CIUDAD_NOMBRE DESTINO, COUNT(*) CANT_PASAJES_COMPRADOS" +
                               " from BUGDEVELOPING.COMPRA" +
                               " join BUGDEVELOPING.PASAJE on (PASAJE_CODIGO = COMPRA_CODIGO_PASAJE_ENCOMIENDA AND YEAR(COMPRA_FECHA) = '" + añoSeleccion + "' AND (MONTH(COMPRA_FECHA) BETWEEN '" + mesMinimo + "' AND '" + mesMaximo + "'))" + 
                               " join BUGDEVELOPING.PASAJE_ENCOMIENDA on (PASAJE_CODIGO = PASAJE_ENCOMIENDA_CODIGO)" +
                               " join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)" +
                               " join BUGDEVELOPING.RECORRIDO on (VIAJE_CODIGO_RECORRIDO = RECORRIDO_CODIGO)" +
                               " join BUGDEVELOPING.CIUDAD CD on (RECORRIDO_ID_CIUDAD_DESTINO = CD.CIUDAD_ID)" +
                               " GROUP BY CD.CIUDAD_ID, CD.CIUDAD_NOMBRE" +
                               " ORDER BY COUNT(*) DESC";
                
                dataGridView1.DataSource = connection.executeQuery(query);
                dataGridView1.AutoResizeColumn(0);
                dataGridView1.AutoResizeColumn(1);
            }

            if (top5Seleccion == "1")
            {
                String query = "select top 5 CIUDAD_NOMBRE, " +
                               "(select COUNT(PASAJE_ENCOMIENDA_CODIGO)" +
                               " from BUGDEVELOPING.VIAJE join BUGDEVELOPING.RECORRIDO on (VIAJE_CODIGO_RECORRIDO = RECORRIDO_CODIGO AND YEAR(VIAJE_FECHA_LLEGADA) = '" + añoSeleccion + "' AND (MONTH(VIAJE_FECHA_LLEGADA) BETWEEN '" + mesMinimo + "' AND '" + mesMaximo + "'))" +
                               " join BUGDEVELOPING.PASAJE_ENCOMIENDA on (PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)" +
                               " where RECORRIDO_ID_CIUDAD_DESTINO = CIUDAD_ID and  PASAJE_ENCOMIENDA_CODIGO not in (select CANCELACION_CODIGO_PASAJE_ENCOMIENDA" +
                               " from BUGDEVELOPING.CANCELACION)) as 'VISITAS'" +
                               " from BUGDEVELOPING.CIUDAD" +
                               " order by VISITAS asc";
                
                dataGridView1.DataSource = connection.executeQuery(query);
                dataGridView1.AutoResizeColumn(0);
                dataGridView1.AutoResizeColumn(1);
            }

            if (top5Seleccion == "2")
            {
                String fechaActual = (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day).ToString();
                String query = "select top 5 CLIENTE_DNI, " +
                               "(select CAST(isnull(ROUND(SUM(isnull(PASAJE_ENCOMIENDA_PRECIO, 0))/5, 0, 1), 0) as decimal(12,0)) from BUGDEVELOPING.PASAJE_ENCOMIENDA" +
                               " join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)" +
                               " where CLIENTE_DNI = PASAJE_ENCOMIENDA_VIAJERO and YEAR(VIAJE_FECHA_LLEGADA) = " + añoSeleccion + " and (MONTH(VIAJE_FECHA_LLEGADA) BETWEEN " + mesMinimo + " and " + mesMaximo + ") and PASAJE_ENCOMIENDA_CODIGO not in (select CANCELACION_CODIGO_PASAJE_ENCOMIENDA" +
                               " from BUGDEVELOPING.CANCELACION) and DATEDIFF( DAY, VIAJE_FECHA_LLEGADA, CAST('"+ fechaActual + "' as datetime) )<365) as 'PUNTOS_VALIDOS'" +
                               " from BUGDEVELOPING.CLIENTE" +
                               " order by PUNTOS_VALIDOS desc";
                dataGridView1.DataSource = connection.executeQuery(query);
                dataGridView1.AutoResizeColumn(0);
                dataGridView1.AutoResizeColumn(1);
            }

            if (top5Seleccion == "3")
            {
                String query = "select top 5 CD.CIUDAD_NOMBRE DESTINO, COUNT(*) CANT_PASAJES_CANCELADOS" +
                                " from BUGDEVELOPING.CANCELACION" +
                                " join BUGDEVELOPING.PASAJE on (PASAJE_CODIGO = CANCELACION_CODIGO_PASAJE_ENCOMIENDA AND YEAR(CANCELACION_FECHA_DEVOLUCION) = '" + añoSeleccion + "' AND (MONTH(CANCELACION_FECHA_DEVOLUCION) BETWEEN '" + mesMinimo + "' AND '" + mesMaximo + "'))"  +
                                " join BUGDEVELOPING.PASAJE_ENCOMIENDA on (PASAJE_CODIGO = PASAJE_ENCOMIENDA_CODIGO)" +
                                " join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)" +
                                " join BUGDEVELOPING.RECORRIDO on (VIAJE_CODIGO_RECORRIDO = RECORRIDO_CODIGO)" +
                                " join BUGDEVELOPING.CIUDAD CD on (RECORRIDO_ID_CIUDAD_DESTINO = CD.CIUDAD_ID)" +
                                " GROUP BY CD.CIUDAD_ID, CD.CIUDAD_NOMBRE" +
                                " ORDER BY COUNT(*) DESC";

                dataGridView1.DataSource = connection.executeQuery(query);
                dataGridView1.AutoResizeColumn(0);
                dataGridView1.AutoResizeColumn(1);
            }

            if (top5Seleccion == "4")
            {
                String query = "select top 5 MICRO_FUERA_SERVICIO_PATENTE, SUM(DATEDIFF(DAY, MICRO_FUERA_SERVICIO_FECHA_INICIO, MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION)) CANT_DIAS" +
                               " from BUGDEVELOPING.MICRO_FUERA_SERVICIO" +
                               " where YEAR(MICRO_FUERA_SERVICIO_FECHA_INICIO) = '" + añoSeleccion + "' AND YEAR(MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION) = '" + añoSeleccion + "' AND (MONTH(MICRO_FUERA_SERVICIO_FECHA_INICIO) BETWEEN '" + mesMinimo + "' AND '" + mesMaximo + "') AND (MONTH(MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION) BETWEEN '" + mesMinimo + "' AND '" + mesMaximo + "')" +
                               " group by MICRO_FUERA_SERVICIO_PATENTE" +
                               " order by CANT_DIAS DESC";

                dataGridView1.DataSource = connection.executeQuery(query);
                dataGridView1.AutoResizeColumn(0);
                dataGridView1.AutoResizeColumn(1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           top5Seleccion = comboBox1.SelectedIndex.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            añoSeleccion = comboBox2.Text.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            semestreSeleccion = comboBox3.Text.ToString();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
