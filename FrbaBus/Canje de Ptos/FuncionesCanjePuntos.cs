using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;
using System.Configuration;

namespace FrbaBus.Canje_de_Ptos
{
    public class FuncionesCanjePuntos
    {
        public static String getPuntosDisponibles(String dni)
        {
            String fecha = ConfigurationManager.AppSettings["SystemYear"] + ConfigurationManager.AppSettings["SystemMonth"] + ConfigurationManager.AppSettings["SystemDay"];
            String query = "select CAST(ROUND(SUM(PASAJE_ENCOMIENDA_PRECIO)/5,0,1) AS INT) - (SELECT isnull(SUM( isnull(PRODUCTO_PUNTOS_NECESARIOS, 0) ), 0) FROM BUGDEVELOPING.CANJE join BUGDEVELOPING.PRODUCTO on CANJE_PRODUCTO_ELEGIDO = PRODUCTO_ID WHERE CANJE_DNI = '" + dni + "' and datediff(DAY, cast(CANJE_FECHA as date), cast('" + fecha + "' as date)) < 365) FROM BUGDEVELOPING.PASAJE_ENCOMIENDA join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO) where PASAJE_ENCOMIENDA_VIAJERO = '" + dni + "' and datediff(DAY, cast(VIAJE_FECHA_SALIDA as date), cast('" + fecha + "' as date)) < 365 and PASAJE_ENCOMIENDA_CODIGO not in (select CANCELACION_CODIGO_PASAJE_ENCOMIENDA from BUGDEVELOPING.CANCELACION) group by PASAJE_ENCOMIENDA_VIAJERO";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count == 0) return "DNI invalido";
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static DataTable getProductosDisponibles(String puntos)
        {
            String query = "select PRODUCTO_ID, PRODUCTO_STOCK, 'Producto: ' + PRODUCTO_NOMBRE + ' - Puntos Necesarios: ' + cast(PRODUCTO_PUNTOS_NECESARIOS as nvarchar(255)) as 'PRODUCTO_DETALLE' from BUGDEVELOPING.PRODUCTO where PRODUCTO_STOCK > 0 and PRODUCTO_PUNTOS_NECESARIOS <= " + puntos;
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static void updateProducto(String codigoProducto)
        {
            String query = "update BUGDEVELOPING.PRODUCTO set PRODUCTO_STOCK -= 1 where PRODUCTO_ID = " + codigoProducto;
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertCanje(String dni, String producto)
        {
            String query = "insert into BUGDEVELOPING.CANJE (CANJE_DNI, CANJE_FECHA, CANJE_PRODUCTO_ELEGIDO) values ('" + dni + "', cast('" + (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day).ToString() + "' as datetime), '" + producto + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }
    }
}