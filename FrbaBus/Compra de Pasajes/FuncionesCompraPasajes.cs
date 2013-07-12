using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.Compra_de_Pasajes
{
    class FuncionesCompraPasajes
    {
        public static DataTable getCiudades()
        {
            String query = "select CIUDAD_ID, CIUDAD_NOMBRE from BUGDEVELOPING.CIUDAD order by CIUDAD_ID";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static DataTable getViajeLibre(String fecha,String origen, String destino)
        {
            String query = "select top 1 VIAJE_CODIGO, RECORRIDO_CODIGO, VIAJE_MICRO_PATENTE, (select count(*) from BUGDEVELOPING.BUTACA where BUTACA_MICRO_PATENTE = VIAJE_MICRO_PATENTE and BUTACA_PISO <> 0 and BUTACA_NUMERO not in (select p.PASAJE_NUMERO_BUTACA from BUGDEVELOPING.PASAJE_ENCOMIENDA pe join BUGDEVELOPING.PASAJE p on (pe.PASAJE_ENCOMIENDA_CODIGO = p.PASAJE_CODIGO) where pe.PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)) as 'BUTACAS_DISPONIBLES', MICRO_CANTIDAD_KGS - (select SUM(ENCOMIENDA_KG_UTILIZADOS) from BUGDEVELOPING.ENCOMIENDA where ENCOMIENDA_CODIGO in (select PASAJE_ENCOMIENDA_CODIGO from BUGDEVELOPING.PASAJE_ENCOMIENDA where PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE_CODIGO)) as 'KGS_DISPONIBLES' from BUGDEVELOPING.VIAJE join BUGDEVELOPING.RECORRIDO on (VIAJE_CODIGO_RECORRIDO = RECORRIDO_CODIGO) join BUGDEVELOPING.MICRO on (VIAJE_MICRO_PATENTE = MICRO_PATENTE) where cast(VIAJE_FECHA_SALIDA as date) = '" + fecha + "' and RECORRIDO_ID_CIUDAD_ORIGEN = '" + origen + "' and RECORRIDO_ID_CIUDAD_DESTINO = '" + destino + "' and VIAJE_FECHA_LLEGADA is null and RECORRIDO_ACTIVO = 1 and MICRO_PATENTE not in (select MICRO_FUERA_SERVICIO_PATENTE from BUGDEVELOPING.MICRO_FUERA_SERVICIO where VIAJE_FECHA_SALIDA not between MICRO_FUERA_SERVICIO_FECHA_INICIO and MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION) order by BUTACAS_DISPONIBLES desc, KGS_DISPONIBLES desc";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static String getTipoServicio(String Recorrido)
        {
            String query = "select TIPO_SERVICIO_NOMBRE from BUGDEVELOPING.RECORRIDO join BUGDEVELOPING.TIPO_SERVICIO on (RECORRIDO_CODIGO = " + Recorrido + "and TIPO_SERVICIO_CODIGO = RECORRIDO_TIPO_SERVICIO)";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
                return dt.Rows[0].ItemArray[0].ToString();
            return "";
        }

        public static String getDNI(String dni)
        {
            String query = "select COUNT(CLIENTE_DNI) from BUGDEVELOPING.CLIENTE where CLIENTE_DNI = '" + dni + "'";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static String getDNINoDiscapacitado(String dni)
        {
            String query = "select COUNT(CLIENTE_DNI) from BUGDEVELOPING.CLIENTE where CLIENTE_DNI = '" + dni + "' and CLIENTE_DNI not in (select C.CLIENTE_DNI from BUGDEVELOPING.CLIENTE C where CLIENTE_DISCAPACIDAD = 'Si')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static DataTable getDatosPersonales(String dni)
        {
            String query = "select YEAR(CLIENTE_FECHA_NACIMIENTO), MONTH(CLIENTE_FECHA_NACIMIENTO), DAY(CLIENTE_FECHA_NACIMIENTO), CLIENTE_NOMBRE, CLIENTE_APELLIDO, isnull(CLIENTE_SEXO, ''), isnull(CLIENTE_DISCAPACIDAD, ''), CLIENTE_DIRECCION, CLIENTE_TELEFONO, isnull(CLIENTE_MAIL, '') from BUGDEVELOPING.CLIENTE where CLIENTE_DNI = '" + dni + "'";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static DataTable getPisoButacas(String patente)
        {
            String query = "SELECT BUTACA_PISO FROM BUGDEVELOPING.BUTACA WHERE BUTACA_PISO <> 0 and BUTACA_MICRO_PATENTE = '" + patente + "' GROUP BY BUTACA_PISO ORDER BY BUTACA_PISO ASC";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static DataTable getButacasLibres(String patente, String piso, String viaje)
        {
            String query = "select BUTACA_NUMERO, 'Nro.: ' + CAST(BUTACA_NUMERO as nvarchar(255)) + ' - ' + BUTACA_TIPO as 'BUTACA_DESCRIPCION' from BUGDEVELOPING.BUTACA where BUTACA_MICRO_PATENTE = '" + patente + "' and BUTACA_PISO = " + piso + " and BUTACA_NUMERO not in (select p.PASAJE_NUMERO_BUTACA from BUGDEVELOPING.PASAJE_ENCOMIENDA pe join BUGDEVELOPING.PASAJE p on (pe.PASAJE_ENCOMIENDA_CODIGO = p.PASAJE_CODIGO) where p.PASAJE_PISO_BUTACA = " + piso + " and pe.PASAJE_ENCOMIENDA_CODIGO_VIAJE = " + viaje + ")";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt;
        }

        public static String getPrecioPasajeStandar(String recorrido)
        {
            String query = "select ROUND(RECORRIDO_PRECIO_BASE_PASAJE + RECORRIDO_PRECIO_BASE_PASAJE * TIPO_SERVICIO_PORCENTAJE_ADICIONAL, 2) from BUGDEVELOPING.RECORRIDO join BUGDEVELOPING.TIPO_SERVICIO on (RECORRIDO_TIPO_SERVICIO = TIPO_SERVICIO_CODIGO) where RECORRIDO_CODIGO = " + recorrido;
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static String getPasajeEncomiendaNumero()
        {
            String query = "select MAX(PASAJE_ENCOMIENDA_CODIGO) + 1 from BUGDEVELOPING.PASAJE_ENCOMIENDA";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static void updateCliente(String dni, String fecha, String nombre, String apellido, String sexo, String discapacidad, String direccion, String telefono, String mail)
        {
            String query = "update BUGDEVELOPING.CLIENTE set CLIENTE_FECHA_NACIMIENTO = CAST('" + fecha + "' as datetime ), CLIENTE_NOMBRE = '" + nombre + "', CLIENTE_APELLIDO = '" + apellido + "', CLIENTE_SEXO = '" + sexo + "', CLIENTE_DISCAPACIDAD = '" + sexo + "', CLIENTE_DIRECCION = '" + direccion + "', CLIENTE_TELEFONO = '" + telefono + "', CLIENTE_MAIL = '" + mail + "' where CLIENTE_DNI = '" + dni + "'";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertCliente(String dni, String fecha, String nombre, String apellido, String sexo, String discapacidad, String direccion, String telefono, String mail)
        {
            String query = "insert into BUGDEVELOPING.CLIENTE (CLIENTE_DNI, CLIENTE_FECHA_NACIMIENTO, CLIENTE_NOMBRE, CLIENTE_APELLIDO, CLIENTE_SEXO, CLIENTE_DISCAPACIDAD, CLIENTE_DIRECCION, CLIENTE_TELEFONO, CLIENTE_MAIL) values  ('" + dni + "', cast('" + fecha + "' as datetime), '" + nombre + "', '" + apellido + "', '" + sexo + "', '" + sexo + "', '" + direccion + "', '" + telefono + "', '" + mail + "'";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertPasajeEncomienda(String nro, String dni, String precio, String viaje)
        {
            String query = "insert into BUGDEVELOPING.PASAJE_ENCOMIENDA (PASAJE_ENCOMIENDA_CODIGO, PASAJE_ENCOMIENDA_VIAJERO, PASAJE_ENCOMIENDA_PRECIO, PASAJE_ENCOMIENDA_CODIGO_VIAJE) values  ('" + nro + "', '" + dni + "', '" + precio + "', '" + viaje + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertPasaje(String nro, String patente, String butacaNro, String butacaPiso)
        {
            String query = "insert into BUGDEVELOPING.PASAJE (PASAJE_CODIGO, PASAJE_MICRO_PATENTE, PASAJE_NUMERO_BUTACA, PASAJE_PISO_BUTACA) values  ('" + nro + "', '" + patente + "', '" + butacaNro + "', '" + butacaPiso + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static string getPrecioBaseEncomienda(String recorrido)
        {
            String query = "select RECORRIDO_PRECIO_BASE_KG from BUGDEVELOPING.RECORRIDO where RECORRIDO_CODIGO = " + recorrido;
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        public static void insertEncomienda(String nro, String kgs)
        {
            String query = "insert into BUGDEVELOPING.ENCOMIENDA (ENCOMIENDA_CODIGO, ENCOMIENDA_KG_UTILIZADOS) values  ('" + nro + "', '" + kgs + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertCompraEfectivo(String pasajeEncomiendaNro, String fecha, String dni, String compraNro)
        {
            String query = "insert into BUGDEVELOPING.COMPRA (COMPRA_CODIGO_PASAJE_ENCOMIENDA, COMPRA_FECHA, COMPRA_COMPRADOR, COMPRA_MODALIDAD_PAGO, COMPRA_NUMERO_VOUCHER) values  ('" + pasajeEncomiendaNro + "', cast('" + fecha + "' as datetime), '" + dni + "', 'Efectivo', '" + compraNro + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static void insertCompraTarjeta(String pasajeEncomiendaNro, String fecha, String dni, String compraNro, String tarjetaNro, String cuotas)
        {
            String query = "insert into BUGDEVELOPING.COMPRA (COMPRA_CODIGO_PASAJE_ENCOMIENDA, COMPRA_FECHA, COMPRA_COMPRADOR, COMPRA_MODALIDAD_PAGO, COMPRA_NUMERO_TARJETA, COMPRA_NUMERO_CUOTAS, COMPRA_NUMERO_VOUCHER) values  ('" + pasajeEncomiendaNro + "', cast('" + fecha + "' as datetime), '" + dni + "', 'Tarjeta', '" + tarjetaNro + "', '" + cuotas + "', '" + compraNro + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static String getNroCompra()
        {
            String query = "select MAX(COMPRA_NUMERO_VOUCHER) + 1 from BUGDEVELOPING.COMPRA";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        }
    }
}