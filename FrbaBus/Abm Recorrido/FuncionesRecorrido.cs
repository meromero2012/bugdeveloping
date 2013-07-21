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
            string query = "UPDATE BUGDEVELOPING.RECORRIDO SET RECORRIDO_ACTIVO = 0 WHERE RECORRIDO_CODIGO ='"+codigoRecorrido+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        }

        public static DataTable ViajesDeRecorridoApartirDeFecha(string codigoRecorrido, DateTime fechaComienzo)
        {
            string comienzo = "'" + fechaComienzo.ToString("yyyyMMdd HH:mm:ss") + "'";
           
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
            String query = "SELECT * FROM BUGDEVELOPING.V_RECORRIDO_ACTIVO";
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
        public static void CambiarRecorridosEnViajesDesdeFecha(string codigoRecorrido, string codigoRecorridoNuevo, DateTime fechaComienzo) 
        {
            string comienzo = "'" + fechaComienzo.ToString("yyyyMMdd HH:mm:ss") + "'";
            string query = "UPDATE BUGDEVELOPING.VIAJE SET VIAJE_CODIGO_RECORRIDO = '" + codigoRecorridoNuevo + "' WHERE VIAJE_CODIGO_RECORRIDO ='" + codigoRecorrido + "' and VIAJE_FECHA_SALIDA >= '"+comienzo+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
       }


        public static string generarCodigoRecorrido()
        {
            string nuevoCodigo = "";
            bool codigoUnico = false;
            while (!codigoUnico)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());

                DataTable Dt;
                String query = "SELECT * FROM BUGDEVELOPING.RECORRIDO WHERE RECORRIDO_CODIGO = '" + result + "'";
                ConnectorClass conexion = ConnectorClass.Instance;
                Dt = conexion.executeQuery(query);

                if (Dt.Rows.Count == 0)
                {
                    codigoUnico = true;
                    nuevoCodigo = String.Copy(result);
                }
            }

            return nuevoCodigo;

        }

        public static void DarDeBajaARecorridoDesdeFecha(string codigoRecorrido, DateTime fecha)   
        {
            DataTable viajesDeRecorrido = FrbaBus.Abm_Recorrido.FuncionesRecorridos.ViajesDeRecorridoApartirDeFecha(codigoRecorrido, DateTime.Today);
            //aca hago un for por cada uno y obtengo en nroDeViaje
            foreach (DataRow row in viajesDeRecorrido.Rows)
            {
                string codigoCompra = row.ItemArray[0].ToString();

                Boolean esPasaje = FrbaBus.CancelarViaje.FuncionesCancelarViaje.esPasaje(codigoCompra);

                if (esPasaje)
                    FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarPasaje(codigoCompra);
                else
                    FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarEncomienda(codigoCompra);

                FrbaBus.CancelarViaje.FuncionesCancelarViaje.actualizarCancelacion(codigoCompra, "Recorrido Dado de baja");
            }

        }
        
    }
}