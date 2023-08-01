using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using negocio;

namespace TPFinalNivel3VargasAriel
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos lista = new ListaArticulos();
            Session.Add("listaProductos", lista.ListarSP());
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }
        protected void Filtro_text(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaProductos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(Filtro.Text.ToUpper()));
            dgvProductos.DataSource= listaFiltrada;
            dgvProductos.DataBind();
        }
    }
}