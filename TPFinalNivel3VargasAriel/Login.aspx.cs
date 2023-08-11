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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnLog_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            Users user;
            try
            {
                user = new Users(txtEmail.Text, txtPassword.Text, false);
                if (usuarios.Login(user))
                {
                    Session.Add("usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o contraseña incorrectos, en caso de no tener usuario crear");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}