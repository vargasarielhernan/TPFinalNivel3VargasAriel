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
        public bool Login(Users user)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("select Id, admin from USERS where email=@email and pass=@pass");
                accesoDatos.SetParametro("@email", user.Email);
                accesoDatos.SetParametro("@pass", user.Password);
                accesoDatos.Runread();
                while (accesoDatos.Lector.Read())
                {
                    user.Id = (int)accesoDatos.Lector["Id"];
                    user.TipoUsuario = (bool)accesoDatos.Lector["admin"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
