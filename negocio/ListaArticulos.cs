using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace negocio
{
    public class ListaArticulos
    {
        public List<Articulos> ListarSP()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos accesoDB = new AccesoDatos();
            try
            {
                accesoDB.SetearProcedimiento("StoredListar");
                accesoDB.Runread();
                while (accesoDB.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Codigo = (string)accesoDB.Lector["Codigo"];
                    aux.Nombre = (string)accesoDB.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];
                    if (!(accesoDB.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)accesoDB.Lector["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)accesoDB.Lector["Marca"];
                    aux.Marca.Id = (int)accesoDB.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)accesoDB.Lector["Categoria"];
                    aux.Categoria.Id = (int)accesoDB.Lector["IdCategoria"];
                    aux.Precio = (decimal)accesoDB.Lector["Precio"];

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
