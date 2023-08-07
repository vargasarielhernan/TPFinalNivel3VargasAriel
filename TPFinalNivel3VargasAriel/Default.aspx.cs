using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPFinalNivel3VargasAriel
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulos> Productos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos lista = new ListaArticulos();
            Productos = lista.ListarSP();
            Repetidor.DataSource = Productos;
            Repetidor.DataBind();

        }
    }
}