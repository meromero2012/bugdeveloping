using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.Abm_Permisos
{
    class FuncionesRol
    {

        public static bool existeFunEnRol(int rolId, String codFun)
        {
            String query = "select * from BUGDEVELOPING.FUNROL where  ( FUNROL.FUNROL_FUNCIONALIDAD_ID = " + rolId + " ) AND ( FUNROL.FUNROL_ROL_ID = '"+codFun +"' )";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public static bool existeNombreRol(String nombreRol)
        {
            String query = "select * from BUGDEVELOPING.ROL where ( ROL.ROL_NOMBRE = '" + nombreRol + "' )";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public static void borrarRolXUsuario(int codRol)
        {
            String query = "UPDATE BUGDEVELOPING.USUARIO  SET USUARIO_ROL = NULL WHERE  ( USUARIO_ROL = " + codRol + ")";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
            
        }

        public static void modificarNombreYHabilitacion(int codRol, String rolNombre, String rolHabilitacion)
        {
            String query = "UPDATE BUGDEVELOPING.ROL SET ROL_NOMBRE = '" + rolNombre + "', ROL_TIPO = 1 , ROL_HABILITACION = '" + rolHabilitacion + "' WHERE (ROL.ROL_ID = " + codRol + " )";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);

        }

        public static void borrarFuncionalidades(int codRol)
        {
            String query = "DELETE FROM BUGDEVELOPING.FUNROL WHERE ( FUNROL.FUNROL_ROL_ID = " + codRol + " )";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);

        }

    }
}
