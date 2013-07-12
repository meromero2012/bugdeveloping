using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.ConnectorSQL;
using System.Data;

namespace FrbaBus.AuthentificationSystem
{
    public static class AccountManagment
    {
        public static UserInformation ActualUser { get; internal set; }

        public static String LogUser(String userName, String password)
        {
            String userId = FrbaBus.Login.FuncionesLogin.getUsuario(userName);

            if (userId == null)
            {
                return "usuario invalido.";
            }
            else
            {
                Boolean passwordCorrecto = FrbaBus.Login.FuncionesLogin.checkPassword(userId, password);
                if (!passwordCorrecto)
                {
                    String cantidad = FrbaBus.Login.FuncionesLogin.getCantidadDeIntentos(userId);


                    if (cantidad.Equals("0"))
                    {
                        return "El usuario ha alcanzado el maximo de entradas incorrectas. Usuario Inhabilitado";

                    }
                    else
                    {
                        FrbaBus.Login.FuncionesLogin.decrementarIntentos(userId);
                        cantidad = FrbaBus.Login.FuncionesLogin.getCantidadDeIntentos(userId);
                        return "Contraseña Erronea. Tiene " + cantidad + " intentos restantes";
                    }
                }
                else
                {
                    FrbaBus.Login.FuncionesLogin.resetearContador(userId);
                    int? rolId = FrbaBus.Login.FuncionesLogin.getRol(userName);
                    if (!rolId.HasValue) return "Error en el sistema. Usuario sin rol";
                    ActualUser = new UserInformation()
                    {
                        UserId=userId,
                        Role = (RoleEnum)rolId.Value,
                        Username=userName
                    };

                    ConnectorClass conn = ConnectorClass.Instance;

                    String query = "SELECT F.FUNCIONALIDAD_ID,F.FUNCIONALIDAD_NOMBRE  FROM BUGDEVELOPING.FUNCIONALIDAD F JOIN BUGDEVELOPING.FUNROL FR  ON FR.FUNROL_FUNCIONALIDAD_ID = F.FUNCIONALIDAD_ID WHERE FR.FUNROL_ROL_ID = " + rolId;

                    DataTable table = conn.executeQuery(query);
                    foreach (DataRow row in table.Rows)
                    {
                        ActualUser.Permissions.Add(new Permission()
                        {
                            Id=row.Field<decimal>(0).ToString(),
                            Name=row.Field<String>(1)
                        });
                    }
                    return null;
                }
            }
        }


    }
}
