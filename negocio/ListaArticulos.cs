using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

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
                    else
                        aux.ImagenUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
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
        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos accesoDB = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, M.Id as IdMarca, C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca= M.Id and A.IdCategoria=C.ID and ";
                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;

                    default:
                        break;
                }
                accesoDB.Setquery(consulta);
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
        }
        public void agregar(Articulos nuevo)
        {
            try
            {
                AccesoDatos accesoDB = new AccesoDatos();
                accesoDB.SetearProcedimiento("StoredAgregarArticulo");
                accesoDB.SetParametro("@Codigo", nuevo.Codigo);
                accesoDB.SetParametro("@Nombre", nuevo.Nombre);
                accesoDB.SetParametro("@Descripcion", nuevo.Descripcion);
                accesoDB.SetParametro("@imagen", nuevo.ImagenUrl);
                accesoDB.SetParametro("@Categoria", nuevo.Categoria.Id);
                accesoDB.SetParametro("@Precio", nuevo.Precio);
                accesoDB.SetParametro("@Marca", nuevo.Marca.Id);
                accesoDB.Runread();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void editar(Articulos nuevo)
        {
            try
            {
                AccesoDatos accesoDB = new AccesoDatos();
                accesoDB.SetearProcedimiento("StoredEditarArticulo");
                accesoDB.SetParametro("@Codigo", nuevo.Codigo);
                accesoDB.SetParametro("@Nombre", nuevo.Nombre);
                accesoDB.SetParametro("@Descripcion", nuevo.Descripcion);
                accesoDB.SetParametro("@imagen", nuevo.ImagenUrl);
                accesoDB.SetParametro("@Categoria", nuevo.Categoria.Id);
                accesoDB.SetParametro("@Precio", nuevo.Precio);
                accesoDB.SetParametro("@Marca", nuevo.Marca.Id);
                accesoDB.SetParametro("@Id", nuevo.Id);
                accesoDB.Runread();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.Setquery("delete from ARTICULOS where id = @id");
                accesoDatos.SetParametro("@id", id);
                accesoDatos.Exeaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulos> mapearFav(int id)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.Setquery("select A.Id, A.Nombre, A.Descripcion,A.ImagenUrl, A.Precio, U.Id, F.IdUser,F.IdArticulo from ARTICULOS A, USERS U,FAVORITOS F where F.IdUser=U.Id and A.Id=F.IdArticulo and U.Id=@Id");
                accesoDatos.SetParametro("@Id", id);
                accesoDatos.Runread();
                while (accesoDatos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    if (!(accesoDatos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];
                    else
                        aux.ImagenUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];

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
                accesoDatos.Closeconnection();
            }
        }
    }
}
