using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ListaMarca
    {
        public List<Marca> ListarSP()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos accesoDB = new AccesoDatos();
            try
            {
                accesoDB.Setquery("select Id, Descripcion from MARCAS");
                accesoDB.Runread();
                while (accesoDB.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];

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
                accesoDB.Closeconnection();
            }
        }
    }
}
