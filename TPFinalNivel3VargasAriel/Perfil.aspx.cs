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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Users user = (Users)Session["usuario"];
                txtEmail.Text =user.Email;
                txtPass.Text = user.Password;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;

            }
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./images/");
                Usuarios usuario = new Usuarios();
                Users user = (Users)Session["usuario"];
                txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-"+user.Id+".jpg");
                user.UrlImagen = "perfil-" + user.Id + ".jpg";
                user.Nombre=txtNombre.Text;
                user.Apellido=txtApellido.Text;
                user.Password = txtPass.Text;
                user.Email=txtEmail.Text;

                usuario.ActualizarUser(user);

                Image img = (Image)Master.FindControl("ImagenAvatar");
                img.ImageUrl = "~/Images/" + user.UrlImagen;

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}