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
        protected void agregarfav(Object sender, EventArgs e)
        {
            Favorito favorito = new Favorito();
            Favs favs = new Favs();
            Users user = new Users();
            int IdFav = int.Parse(((LinkButton)sender).CommandArgument);
            user = (Users)Session["usuario"];
            int IdUser = user.Id;
            favorito.IdUser = IdUser;
            favorito.IdArticulo = IdFav;
            favs.guardarFav(favorito);
        }
    }
}