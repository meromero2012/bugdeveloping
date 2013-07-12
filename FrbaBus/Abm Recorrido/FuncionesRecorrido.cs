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

public static DataTable InsertarNuevoRecorrido(object tipoServicio, object ciudadOrigen, object ciudadDestino, string precioKG, string precioPasaje)
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

public static DataTable obtenerTablaCiudades()
{
    DataTable Dt;
    String query = "SELECT * FROM BUGDEVELOPING.CIUDAD";
    ConnectorClass conexion = ConnectorClass.Instance;
    Dt = conexion.executeQuery(query);
    return Dt;
}

public static DataTable modificarRecorrido(string codigoRecorrido, object tipoServicio, object ciudadOrigen, object ciudadDestino, string precioKG, string precioPasaje, int activo)
{
    DataTable DtRes;
    ConnectorClass conexion = ConnectorClass.Instance;

    string query = "EXEC BUGDEVELOPING.Modificar_Recorrido" + " " +
    codigoRecorrido + "," +
    tipoServicio + "," +
    ciudadOrigen + "," +
    ciudadDestino + "," +
    precioKG + "," +
    precioPasaje + "," +
    activo;
    ;

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