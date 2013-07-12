using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.CancelarViaje
{
    class FuncionesCancelarViaje
    {
        public static String getNroVoucher(String nroVoucher)
        {
            String query = "select COMPRA_NUMERO_VOUCHER from BUGDEVELOPING.COMPRA where (COMPRA_NUMERO_VOUCHER = '" + nroVoucher + "') group by COMPRA_NUMERO_VOUCHER";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
                return dt.Rows[0].ItemArray[0].ToString();
            return "";
        }

        public static DataTable getViajes(String nroVoucher)
        {
            String query = "select COMPRA_CODIGO_PASAJE_ENCOMIENDA, 'DNI: ' + CAST(PASAJE_ENCOMIENDA_VIAJERO AS varchar) + ' - ' + 'Fecha: ' + CAST(DAY(VIAJE_FECHA_SALIDA) AS varchar) + '/' + Cast(MONTH(VIAJE_FECHA_SALIDA) as varchar) as 'DATOS_VIAJE' from BUGDEVELOPING.COMPRA join BUGDEVELOPING.PASAJE_ENCOMIENDA on (BUGDEVELOPING.COMPRA.COMPRA_CODIGO_PASAJE_ENCOMIENDA = BUGDEVELOPING.PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO)join BUGDEVELOPING.VIAJE on( BUGDEVELOPING.PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO_VIAJE = BUGDEVELOPING.VIAJE.VIAJE_CODIGO) where (COMPRA_NUMERO_VOUCHER = '" + nroVoucher + "' AND VIAJE_FECHA_LLEGADA IS NULL AND PASAJE_ENCOMIENDA_CODIGO not in (select CANCELACION_CODIGO_PASAJE_ENCOMIENDA from BUGDEVELOPING.CANCELACION))";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static Boolean esPasaje(String codigoPasajeEncomienda)
        {
            String query = "select PASAJE_CODIGO from BUGDEVELOPING.PASAJE where (PASAJE_CODIGO = '" + codigoPasajeEncomienda + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
                return true;
            return false;
        }

        public static void actualizarPasaje(String codigoPasajeEncomienda)
        {
            String query = "update BUGDEVELOPING.PASAJE set PASAJE_MICRO_PATENTE = NULL, PASAJE_PISO_BUTACA = NULL, PASAJE_NUMERO_BUTACA = NULL where (PASAJE_CODIGO = '" + codigoPasajeEncomienda + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
        }

        public static void actualizarEncomienda(String codigoPasajeEncomienda)
        {
            String query = "update BUGDEVELOPING.ENCOMIENDA set ENCOMIENDA_KG_UTILIZADOS = 0 where (ENCOMIENDA_CODIGO = '" + codigoPasajeEncomienda + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
        }

        public static void actualizarCancelacion(String codigoPasajeEncomienda, String motivoCancelacion)
        {
            String query = "insert into BUGDEVELOPING.CANCELACION(CANCELACION_CODIGO_PASAJE_ENCOMIENDA, CANCELACION_FECHA_DEVOLUCION, CANCELACION_MOTIVO) values ('" + codigoPasajeEncomienda + "', cast('" + (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day).ToString() + "' as datetime), '" + motivoCancelacion + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
        }
    }
}
