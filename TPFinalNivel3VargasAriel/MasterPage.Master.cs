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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenAvatar.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
            if (Page is Perfil || Page is Favoritos)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                lblUser.Text = ((Users)Session["usuario"]).Email;
                if (!string.IsNullOrEmpty(((Users)(Session["usuario"])).UrlImagen))
                    ImagenAvatar.ImageUrl = "~/Images/" + ((Users)(Session["usuario"])).UrlImagen;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}