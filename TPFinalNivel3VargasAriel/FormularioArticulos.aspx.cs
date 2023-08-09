using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using Dominio;
using System.Collections;

namespace TPFinalNivel3VargasAriel
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    ListaCategoria negocio = new ListaCategoria();
                    List<Categoria> lista = negocio.ListarSP();
                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ListaMarca Marca = new ListaMarca();
                    List<Marca> listaM = Marca.ListarSP();
                    ddlMarca.DataSource = listaM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                if (Request.QueryString["id"]!=null && !IsPostBack)
                {
                    Articulos articulo = new Articulos();
                    AccesoDatos accesoDB = new AccesoDatos();
                    string id = Request.QueryString["id"].ToString();
                    string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, M.Id as IdMarca, C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca= M.Id and A.IdCategoria=C.ID and A.Id=" + id;
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

                        txtCodigo.Text= aux.Codigo;
                        txtNombre.Text = aux.Nombre;
                        txtDescripcion.Text = aux.Descripcion;
                        txtPrecio.Text = aux.Precio.ToString();
                        txturlImagen.Text= aux.ImagenUrl.ToString();
                        ddlCategoria.SelectedValue=aux.Categoria.Id.ToString();
                        ddlMarca.SelectedValue=aux.Marca.Id.ToString();
                        ImagenUrl.ImageUrl = txturlImagen.Text;
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
                
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos nuevo = new Articulos();
                ListaArticulos negocio = new ListaArticulos();
                
                nuevo.Codigo=txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txturlImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"].ToString());
                    negocio.editar(nuevo);
                }
                else
                    negocio.agregar(nuevo);
                Response.Redirect("ListaProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void txturlImagen_TextChanged(object sender, EventArgs e)
        {
            ImagenUrl.ImageUrl= txturlImagen.Text;  
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkEliminar.Checked)
                {
                    ListaArticulos articulos = new ListaArticulos();
                    articulos.Delete(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("ListaProductos.aspx", false);                
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}