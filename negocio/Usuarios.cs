using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace negocio
{
    public class Usuarios
    {
        public void ActualizarUser(Users user)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("update USERS set urlImagenPerfil=@imagen where Id=@Id");
                accesoDatos.SetParametro("@imagen", user.UrlImagen);
                accesoDatos.SetParametro("@Id", user.Id);
                accesoDatos.Exeaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.Closeconnection();
            }
        }

        public bool Login(Users user)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("select Id, admin, Nombre, Apellido, urlImagenPerfil from USERS where email=@email and pass=@pass");
                accesoDatos.SetParametro("@email", user.Email);
                accesoDatos.SetParametro("@pass", user.Password);
                accesoDatos.Runread();
                while (accesoDatos.Lector.Read())
                {
                    user.Id = (int)accesoDatos.Lector["Id"];
                    user.TipoUsuario = (bool)accesoDatos.Lector["admin"];
                    if(!(accesoDatos.Lector["Nombre"] is DBNull))
                        user.Nombre = (string)accesoDatos.Lector["Nombre"];
                    if (!(accesoDatos.Lector["Apellido"] is DBNull))
                        user.Apellido = (string)accesoDatos.Lector["Apellido"];
                    if(!(accesoDatos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagen = (string)accesoDatos.Lector["urlImagenPerfil"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.Closeconnection();
            }
        }
        public int Registrarse(Users user)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearProcedimiento("SpRegistrarse");
                accesoDatos.SetParametro("@email", user.Email);
                accesoDatos.SetParametro("@pass", user.Password);
                return accesoDatos.ExeactionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.Closeconnection();
            }
        }
    }
}
