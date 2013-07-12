using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;
using System.Security.Cryptography;

namespace FrbaBus.Login
{
    class FuncionesLogin
    {
        public static String  getUsuario(String username) {
    
            
            //String query = "EXECUTE BUGDEVELOPING.getUserId "+username;
            String query = "select USUARIO_ID from BUGDEVELOPING.USUARIO where (USUARIO_USERNAME = '" + username + "')"; 
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0].ItemArray[0].ToString();
                
            }
            else {
                return null;
            }
        }

        public static Boolean checkPassword(String userId, String passwordAVerificar) {

            String hashAVerificarCadena = null;
            byte[] hashAVerificar = encriptar(passwordAVerificar);
            int LongitudHashAEVarificar = hashAVerificar.Length;
            
            for (int i = 0; i < LongitudHashAEVarificar - 1; i++)
                hashAVerificarCadena = hashAVerificarCadena + hashAVerificar[i].ToString("x2");
            
            if(hashAVerificarCadena == getPassword(userId)){
                 return true; 
           }else{
                return false;
            }
        
        }


        public static String getPassword(String userId) {
            String passwordObtenida;
            String query = "SELECT USUARIO_PASSWORD from BUGDEVELOPING.USUARIO where (USUARIO_ID = '"+userId+"')";
	
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
            {
                passwordObtenida = dt.Rows[0].ItemArray[0].ToString();
                return passwordObtenida;
            }
            else
            {
                return null;
            }
        
        }


        public static byte[] encriptar(String passwordAEncriptar){
            //Se invoca a la clase que realiza la encriptacion a SHA256
            SHA256 shaM = new SHA256Managed();
            //Se convierte el input en un array de bytes
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(passwordAEncriptar);
            //Calculo el hash de mi texto plano
            return (shaM.ComputeHash(bytes));
        
        
        }


        public static String HashAGuardarEnDB(String passwordAGuardar) {

            byte[] encriptado = encriptar(passwordAGuardar);
            String passwordEncriptadaString = null;
            for (int i = 0; i < encriptado.Length - 1; i++)
            {
                passwordEncriptadaString = passwordEncriptadaString + encriptado[i].ToString("x2");
            }
            return passwordEncriptadaString;

        
        }


        public static void grabarUsuarioEnDB(String nombreDeUsuario, String hashAGuardar, long  IdRol) {

            String query = "insert into BUGDEVELOPING.USUARIO (USUARIO_USERNAME,USUARIO_PASSWORD,USUARIO_INTENTOS,USUARIO_ROL)values('"+ nombreDeUsuario+"','"+hashAGuardar+"',3,"+IdRol+")";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        
        }

        public static String getCantidadDeIntentos(String userId) {
            String query = "SELECT USUARIO_INTENTOS from BUGDEVELOPING.USUARIO where (USUARIO_ID = '" + userId + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            return dt.Rows[0].ItemArray[0].ToString();
        
        }

        public static void decrementarIntentos(String userId) {
            String query = "UPDATE BUGDEVELOPING.USUARIO SET USUARIO_INTENTOS = USUARIO_INTENTOS -1 WHERE (USUARIO_ID = '" + userId + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
        
        }

        public static void resetearContador(String userId) {
            String query = "UPDATE BUGDEVELOPING.USUARIO SET USUARIO_INTENTOS = 3 WHERE (USUARIO_ID = '" + userId + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            conexion.executeQuery(query);
            
        }



        public static int? getRol(String username)
        {


            
            String query = "select USARIO_ROL from BUGDEVELOPING.USUARIO where (USUARIO_USERNAME = '" + username + "')";
            ConnectorClass conexion = ConnectorClass.Instance;
            DataTable dt = conexion.executeQuery(query);
            if (dt.Rows.Count != 0)
            {
                return Convert.ToInt32(dt.Rows[0].Field<decimal>("USARIO_ROL"));

            }
            else
            {
                return null;
            }
        }

    }
}
