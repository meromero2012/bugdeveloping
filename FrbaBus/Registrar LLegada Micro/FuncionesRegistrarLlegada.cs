using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.Registrar_LLegada_Micro
{
    class FuncionesRegistrarLlegada
    {
        public static bool validarFecha(DateTime fechaLlegada, string micro)
        {
            /*valida que la fecha de llegada sea posterior y no supere las 24 hs de la fecha de salida*/
            ConnectorClass cc = ConnectorClass.Instance;
            DataTable dt = cc.executeQuery("SELECT VIAJE_FECHA_SALIDA FROM BUGDEVELOPING.VIAJE WHERE VIAJE_FECHA_LLEGADA IS NULL AND '" + micro + "' = VIAJE_MICRO_PATENTE");
            string fechaSalidaString = dt.Rows[0][0].ToString();
            DateTime fechaSalida = Convert.ToDateTime(fechaSalidaString);
            DateTime fechaSalida24despues = fechaSalida.AddDays(1);
            if ((fechaSalida < fechaLlegada) & (fechaLlegada <= fechaSalida24despues))
                return true;
            else
                return false;
        }

        public static bool validarTerminalDeArribo(string micro, string origen, string arribo)
        {
            /*valida que la terminal de arribo sea a la que verdaderamente debe llegar el micro*/
            ConnectorClass cc = ConnectorClass.Instance;
            DataTable dt = cc.executeQuery("SELECT VIAJE_CODIGO_RECORRIDO FROM BUGDEVELOPING.VIAJE WHERE VIAJE_FECHA_LLEGADA IS NULL AND '" + micro + "' = VIAJE_MICRO_PATENTE");
            string recorrido = dt.Rows[0][0].ToString();
            dt = cc.executeQuery("SELECT RECORRIDO_ID_CIUDAD_ORIGEN, RECORRIDO_ID_CIUDAD_DESTINO FROM BUGDEVELOPING.RECORRIDO WHERE '" + recorrido + "' = RECORRIDO_CODIGO");
            if ((dt.Rows[0][0].ToString().Equals(origen)) & (dt.Rows[0][1].ToString().Equals(arribo)))
                return true;
            else
                return false;
        }

        public static void RegistrarLlegada(string micro, DateTime fechaLlegada)
        {
            /*registra la llegada*/
            ConnectorClass cc = ConnectorClass.Instance;
            cc.executeQuery("UPDATE BUGDEVELOPING.VIAJE SET VIAJE_FECHA_LLEGADA = '" + fechaLlegada + "' WHERE VIAJE_FECHA_LLEGADA IS NULL AND VIAJE_MICRO_PATENTE = '" + micro + "'");
        }
    }
}
