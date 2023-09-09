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
            if (negocio.Seguridad.sesionActiva(Session["usuario"]))
            {
                Users User = ((Users)Session["Usuario"]);
                int id = User.Id;
                ListaArticulos lista = new ListaArticulos();
                ProdFavs = lista.mapearFav(id);
                RepetidorFav.DataSource = ProdFavs;
                RepetidorFav.DataBind();

            }
        }
        protected void cambiarFav(object sender, EventArgs e)
        {
            if (negocio.Seguridad.sesionActiva(Session["usuario"]))
            {
                Users user = new Users();
                Favorito favorito = new Favorito();
                Favs favs = new Favs();
                int IdFav = int.Parse(((LinkButton)sender).CommandArgument);
                user = (Users)Session["usuario"];
                int IdUser = user.Id;
                favorito.IdUser = IdUser;
                favorito.IdArticulo = IdFav;
                if (favs.existeFav(favorito))
                {
                    favs.eliminarFav(favorito.Id);
                    rellenoCora();
                    Response.Redirect("Favoritos.aspx", false);
                }
                else
                {
                    favs.guardarFav(favorito);
                }
            }
        }

        public bool rellenoCora()
        {
            return false;
        }

    }
}