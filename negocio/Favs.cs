using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Favs
    {
        public void guardarFav(Favorito favorito)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {

                accesoDatos.Setquery("insert into FAVORITOS (IdUser, IdArticulo) VALUES (@IdUser,@IdArticulo)");
                accesoDatos.SetParametro("@IdUser", favorito.IdUser);
                accesoDatos.SetParametro("@IdArticulo", favorito.IdArticulo);
                accesoDatos.Runread();
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
        public void eliminarFav(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("delete from FAVORITOS where Id=@Id");
                accesoDatos.SetParametro("@Id", id);
                accesoDatos.Exeaction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }  
    }
}
