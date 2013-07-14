using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;       


namespace FrbaBus.Abm_Recorrido
{
    class FuncionesRecorridos
    {

        public static DataTable InsertarNuevoRecorrido(string tipoServicio, string ciudadOrigen, string ciudadDestino, string precioKG, string precioPasaje)
        {
            DataTable DtRes;
            ConnectorClass conexion = ConnectorClass.Instance;

            string query = "EXEC BUGDEVELOPING.Alta_Recorrido" + " " +
                tipoServicio + "," +
                ciudadOrigen + "," +
                ciudadDestino + "," +
                precioKG + "," +
                precioPasaje;

            DtRes = conexion.executeQuery(query);

            return DtRes;
        }

        public static DataTable obtenerTipoServicios()
        {
            DataTable Dt;
            String query = "SELECT * FROM BUGDEVELOPING.TIPO_SERVICIO";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        public static void DarDeBajaARecorrido(string codigoRecorrido)
        {
            DataTable Dt;
            string query = "UPDATE BUGDEVELOPING.RECORRIDO SET RECORRIDO_ACTIVO = 0 WHERE RECORRIDO_CODIGO ='"+codigoRecorrido+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
        }

        public static DataTable ViajesDeRecorridoApartirDeFecha(string codigoRecorrido, DateTime fechaComienzo)
        {
            string comienzo = "'" + fechaComienzo.ToString("yyyyMMdd HH:mm:ss") + "'";
            comienzo = "20101010 00:00:00";
           
            DataTable Dt;
            String select = "SELECT *";
            String from = "FROM BUGDEVELOPING.COMPRA ";
            String join1 = "left join BUGDEVELOPING.PASAJE_ENCOMIENDA on (COMPRA.COMPRA_CODIGO_PASAJE_ENCOMIENDA = PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO) ";						  
            String join2 = "left join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE.VIAJE_CODIGO) ";						   
            String join3 = "left join BUGDEVELOPING.RECORRIDO on (VIAJE_CODIGO_RECORRIDO = RECORRIDO_CODIGO) ";
            String where = "WHERE RECORRIDO_CODIGO = '" + codigoRecorrido + "' and COMPRA_FECHA >='" + comienzo + "' and PASAJE_ENCOMIENDA_CODIGO not in (SELECT CANCELACION_CODIGO_PASAJE_ENCOMIENDA from BUGDEVELOPING.CANCELACION)";
            String query = select + from + join1 + join2+ join3 + where;

            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }


        public static DataTable obtenerTablaCiudades()
        {
            DataTable Dt;
            String query = "SELECT * FROM BUGDEVELOPING.CIUDAD";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        public static DataTable modificarRecorrido(object codigoRecorrido, string tipoServicio, string ciudadOrigen, string ciudadDestino, string precioKG, string precioPasaje)
        {
            DataTable DtRes;
            ConnectorClass conexion = ConnectorClass.Instance;

            string query = "EXEC BUGDEVELOPING.Modificar_Recorrido" + " '" +
                codigoRecorrido + "'," +
                tipoServicio + "," +
                ciudadOrigen + "," +
                ciudadDestino + "," +
                precioKG + "," +
                precioPasaje;

            DtRes = conexion.executeQuery(query);

            return DtRes;
        }

        public static DataTable obtenerRecorridosModificables()
        {
            DataTable Dt;
            String query = "SELECT * FROM BUGDEVELOPING.V_RECORRIDO_CODIGO_MODIFICABLE";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        public static DataTable obtenerCamposDeRecorrido(object codigoDeRecorrido)
        {
            String query = "SELECT * FROM BUGDEVELOPING.V_RECORRIDO WHERE BUGDEVELOPING.V_RECORRIDO.RECORRIDO_CODIGO ='" + codigoDeRecorrido+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            return conexion.executeQuery(query);
        }


    }
}