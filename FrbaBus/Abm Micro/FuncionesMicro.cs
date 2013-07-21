using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.Abm_Micro
{
    class FuncionesMicro
    {
        public static DataTable obtenerMarcas()
        {
            DataTable Dt;
            String query = "SELECT * FROM  BUGDEVELOPING.MARCA";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        public static DataTable CompraDeViajesDeMicroApartirDeFecha(string microPatente, DateTime fechaComienzo)
        {
            string comienzo = fechaComienzo.ToString("yyyyMMdd HH:mm:ss");

            DataTable Dt;
            string select = "SELECT *";
            string from = "FROM BUGDEVELOPING.COMPRA ";
            string join1 = "left join BUGDEVELOPING.PASAJE_ENCOMIENDA on (COMPRA.COMPRA_CODIGO_PASAJE_ENCOMIENDA = PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO)";
            string join2 = "left join BUGDEVELOPING.VIAJE on (PASAJE_ENCOMIENDA.PASAJE_ENCOMIENDA_CODIGO_VIAJE = VIAJE.VIAJE_CODIGO)";
            string where = "WHERE VIAJE_MICRO_PATENTE = '" + microPatente + "' and COMPRA_FECHA >='" + comienzo + "' and PASAJE_ENCOMIENDA_CODIGO not in (SELECT CANCELACION_CODIGO_PASAJE_ENCOMIENDA from BUGDEVELOPING.CANCELACION)";
            String query = select + from + join1 + join2 + where;

            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;

        }


        public static void bajarMicroEnDB(string microPatene, DateTime fechaBaja)
        {
            string fecha = fechaBaja.ToString("yyyyMMdd HH:mm:ss");

            DataTable Dt;
            String query = "UPDATE BUGDEVELOPING.MICRO SET MICRO_FECHA_BAJA ='" + fecha + "' WHERE MICRO_PATENTE ='" + microPatene+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);

        }

        public static DataTable obtenerViajesDeMicroEnFecha(string microPatente, DateTime fechaComienzo,DateTime fechaFin)
        {
            string comienzo = "'" + fechaComienzo.ToString("yyyyMMdd HH:mm:ss") + "'";
            string fin = "'" + fechaFin.ToString("yyyyMMdd HH:mm:ss") + "'";
            
            DataTable Dt;
            string select = "SELECT * " ;
            string from = "FROM  BUGDEVELOPING.VIAJE ";
            string whereCondition1 = "WHERE VIAJE_MICRO_PATENTE = '" + microPatente + "'";
            /*Que la fecha de comienzo se encuentre durante un viaje programado*/
            string whereCondition2a = " and " + "((" + comienzo + " between VIAJE_FECHA_SALIDA and VIAJE_FECHA_ESTIMADA_LLEGADA)";
            /*Que la fecha de fin se encuentre durante un viaje programado*/
            string whereContition2b = " or (" + fin + "between VIAJE_FECHA_SALIDA and VIAJE_FECHA_ESTIMADA_LLEGADA)";
            /*Que la fecha de comienzo y fin son mas amplias que los viajes programados*/
            string whereContition2c = " or ("+comienzo+" < VIAJE_FECHA_SALIDA and "+fin+" > VIAJE_FECHA_ESTIMADA_LLEGADA))";
            string query = select + from + whereCondition1 + whereCondition2a + whereContition2b+whereContition2c;
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

        public static DataTable obtenerMicrosSimilaresA(string microPatente)
        {
            DataTable Dt;
            String query = "EXEC [BUGDEVELOPING].[MicrosSimilaresA] '"+microPatente+"'";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }

            public static void mandarMicroFueraServicio(string microPatente, DateTime fechaComienzo, DateTime fechaFin)
        {
            string comienzo = "'" + fechaComienzo.ToString("yyyyMMdd HH:mm:ss") + "'";
            string fin = "'" + fechaFin.ToString("yyyyMMdd HH:mm:ss") + "'";

            DataTable Dt;
            String query = "INSERT INTO BUGDEVELOPING.MICRO_FUERA_SERVICIO (MICRO_FUERA_SERVICIO_PATENTE, MICRO_FUERA_SERVICIO_FECHA_INICIO, MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION) VALUES('" + microPatente + "'," + comienzo + "," + fin + ")";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
        }


        public static void cancelarOMoverViajesDeMicroParaFecha(string microPatente, DateTime comienzo, DateTime fin)
        {
            //Obtengo todos los viajes del micro en esas fechas
            DataTable viajesDeMicroEnFecha = FrbaBus.Abm_Micro.FuncionesMicro.obtenerViajesDeMicroEnFecha(microPatente, comienzo, fin);

            if(viajesDeMicroEnFecha.Rows.Count >0)
            {
                //Si tiene viajes trato de asignarselo a otro micro
                //TODO obtengo micros similares para pasarles el viaje
                DataTable microsSimilares = FrbaBus.Abm_Micro.FuncionesMicro.obtenerMicrosSimilaresA(microPatente);
                //Hago un for each para asignar
                foreach(DataRow rowMicro in microsSimilares.Rows)
                {
                     List<int>indicesABorrar = new List<int>();
                     /*Por cada micro similar trato de asignarle los viajes*/
                     foreach(DataRow rowViaje in viajesDeMicroEnFecha.Rows)
                     {
                         DateTime fechaSalida = Convert.ToDateTime(rowViaje.ItemArray[3].ToString());
                         string patenteMicroSimilar = rowMicro.ItemArray[0].ToString();
                         /*Si el micro puede realizar el viaje se lo asigno y agrego el indice para despues borrarlo de la tabla de viajes a asignar*/
                         if (FrbaBus.GenerarViaje.FuncionesGenerarViaje.validarMicroDisponible(fechaSalida, patenteMicroSimilar))
                         {
                             string codigoViaje = rowViaje.ItemArray[0].ToString();
                             FrbaBus.Abm_Micro.FuncionesMicro.updatearViajeConMicro(codigoViaje, patenteMicroSimilar);
                             indicesABorrar.Add(viajesDeMicroEnFecha.Rows.IndexOf(rowViaje));
                         }
                     }
                    /*Saco los viajes que ya asigne*/
                     foreach (int indice in indicesABorrar) viajesDeMicroEnFecha.Rows[indice].Delete();

                     viajesDeMicroEnFecha.AcceptChanges();
                }
                /*Pido a la base de datos la informacion de los viajes que no pude asignar, pero esta vez
                *Con la informacion de los pasajes para cancelarlos*/
                         DataTable pasajesDeViajesDeMicro = FrbaBus.Abm_Micro.FuncionesMicro.CompraDeViajesDeMicroApartirDeFecha(microPatente, DateTime.Today);
                         //aca hago un for por cada uno y obtengo en nroDeViaje
                         foreach (DataRow row in pasajesDeViajesDeMicro.Rows)
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

        public static void updatearViajeConMicro(string codigoViaje, string microPatente)
        {
            DataTable Dt;
            String query = "UPDATE BUGDEVELOPING.VIAJE SET VIAJE_MICRO_PATENTE ='"+ microPatente+ "'WHERE VIAJE_CODIGO ="+codigoViaje;
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
        }

        public static bool microEstaFueraDeServicioDurante(string patante,DateTime fechaComienzo, DateTime fechaFin)
        {
            bool estaFueraDeServicio = false;
            DataTable Dt;
            string comienzo = "'"+fechaComienzo.ToString("yyyyMMdd HH:mm:ss")+"'";
            string fin = "'"+fechaFin.ToString("yyyyMMdd HH:mm:ss")+"'";

            /*Chequeo que el micro no este fuera de servicio en esas fechas*/
            string select = "SELECT *";
            string from = "FROM BUGDEVELOPING.MICRO_FUERA_SERVICIO ";
            String whereCondition1 = "WHERE MICRO_FUERA_SERVICIO_PATENTE = '"+patante+"'";
            string whereCondition2a = "and" + "((" + comienzo + " between MICRO_FUERA_SERVICIO_FECHA_INICIO and MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION)";
            string whereContition2b = "or" + "(" + fin + "between MICRO_FUERA_SERVICIO_FECHA_INICIO and MICRO_FUERA_SERVICIO_FECHA_REINCORPORACION))";

            String query = select+from+whereCondition1+whereCondition2a+whereContition2b;
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);

            if (Dt.Rows.Count > 0) estaFueraDeServicio = true;

            return estaFueraDeServicio;
        }

        public static DataTable modificarMicro(string patente, string marca, string modelo)
        {
            DataTable Dt;
            String query = "UPDATE BUGDEVELOPING.MICRO SET MICRO_CODIGO_MARCA ="+marca+",MICRO_MODELO ='"+modelo+"' WHERE MICRO_PATENTE ='" + patente+"';";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }


        public static DataTable obtenerTipoServicios()
        {
            DataTable Dt;
            String query = "SELECT * FROM BUGDEVELOPING.TIPO_SERVICIO";
            ConnectorClass conexion = ConnectorClass.Instance;
            Dt = conexion.executeQuery(query);
            return Dt;
        }
    }
}

