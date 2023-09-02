using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3VargasAriel
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulos> ProdFavs { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Users User = ((Users)Session["Usuario"]);
                int id = User.Id;
                ListaArticulos lista = new ListaArticulos();
                ProdFavs = lista.mapearFav(id);
                Repetidor.DataSource = ProdFavs;
                Repetidor.DataBind();
            }
        }
    }
}