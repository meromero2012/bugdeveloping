﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;
using System.Windows.Forms;

namespace FrbaBus.GenerarViaje
{
    class FuncionesGenerarViaje
    {
        public static bool validarMicroTipoS(string tipoServicio, string micro)
        {
            /*valida que el micro sea del mismo tipo de servicio que el recorrido a realizar*/
            String query = "SELECT * FROM BUGDEVELOPING.MICRO WHERE '" + micro + "'= MICRO_PATENTE AND '" + tipoServicio + "' = MICRO_TIPO_SERVICIO";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count.Equals(0) == true)
                return false;
            else
                return true;
        }

        public static bool validarFecha(DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {
            /*valida que la fechas se correspondan y que la de llegada estimada no supere las 24 hs de la salida del micro*/
            DateTime fechaSalida24despues = fechaSalida.AddDays(1);
            if ((fechaSalida > DateTime.Now) & (fechaSalida < fechaLlegadaEstimada) & (fechaLlegadaEstimada <= fechaSalida24despues))
                return true;
            else
                return false;
        }

        public static bool validarMicroDisponible(DateTime fechaSalida, string micro)
        {
            /*valida que el micro este disponible, esto significa que no este realizando otro viaje en esa fecha y que no este dado de baja o fuera de servicio*/
            string fechaSalida24antes = fechaSalida.AddDays(-1).ToString();
            string fechaSalida24despues = fechaSalida.AddDays(1).ToString();
            String query = "SELECT * FROM BUGDEVELOPING.VIAJE WHERE '" + micro + "'= VIAJE_MICRO_PATENTE AND VIAJE_FECHA_SALIDA BETWEEN '" + fechaSalida24antes + "' AND '" + fechaSalida24despues + "' AND '" + micro + "' NOT IN (SELECT MICRO_FUERA_DE_SERVICIO_PATENTE FROM BUGDEVELOPING.MICRO_FUERA_SERVICIO WHERE ('" + fechaSalida + "' BETWEEN MICRO_FUERA_SERVICIO_FECHA_INICIO AND MICRO_FUERA_SERVICIO_FECHA_FIN) OR (MICRO_FUERA_SERVICIO_FECHA_INICIO >= '" + fechaSalida + "' AND MICRO_FUERA_SERVICIO_FECHA_FIN IS NULL)";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count.Equals(0) == true)
                return true;
            else
                return false;
        }

        public static void InsertarViaje(string codigoRecorrido, string micro, DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {
            /*genera el viaje*/
            ConnectorClass cc = ConnectorClass.Instance;
            String query = "INSERT INTO BUGDEVELOPING.VIAJE (VIAJE_MICRO_PATENTE, VIAJE_CODIGO_RECORRIDO, VIAJE_FECHA_SALIDA, VIAJE_FECHA_ESTIMADA_LLEGADA) values ('" + micro + "','" + codigoRecorrido + "', '" + fechaSalida + "', '" + fechaLlegadaEstimada + "')";
            DataTable dt = cc.executeQuery(query);
            MessageBox.Show("Se genero el viaje de manera correcta", "GenerarViaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    
    }
}