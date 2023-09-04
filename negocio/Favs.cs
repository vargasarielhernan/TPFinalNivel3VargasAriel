using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            finally { accesoDatos.Closeconnection(); }
        } 
        public bool existeFav(Favorito favorito)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("select F.IdArticulo, F.IdUser, F.Id from ARTICULOS A, USERS U, FAVORITOS F where U.Id=@User and U.Id=F.IdUser and A.Id=@Arti and A.Id=F.IdArticulo");
                accesoDatos.SetParametro("@User", favorito.IdUser);
                accesoDatos.SetParametro("@Arti", favorito.IdArticulo);
                accesoDatos.Runread();
                while (accesoDatos.Lector.Read())
                {
                    if(!((accesoDatos.Lector["Id"]) is DBNull))
                    {
                        favorito.Id= (int)accesoDatos.Lector["Id"];
                    }
                }
                if (favorito.Id != 0)
                    return true;
                return false;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { accesoDatos.Closeconnection(); }
        }
    }
}
