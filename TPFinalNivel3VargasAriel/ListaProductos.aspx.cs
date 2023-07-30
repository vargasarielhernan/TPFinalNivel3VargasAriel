using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPFinalNivel3VargasAriel
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos lista = new ListaArticulos();
            dgvProductos.DataSource = lista.ListarSP();
            dgvProductos.DataBind();
        }
    }
}