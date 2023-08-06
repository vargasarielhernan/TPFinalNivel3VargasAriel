using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ListaCategoria
    {
        public List<Categoria> ListarSP()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos AccesoDB = new AccesoDatos();
            try
            {
                AccesoDB.Setquery("select Id, Descripcion from CATEGORIAS");
                AccesoDB.Runread();
                while (AccesoDB.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)AccesoDB.Lector["Id"];
                    aux.Descripcion = (string)AccesoDB.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoDB.Closeconnection();

            }
        }
    }
}
