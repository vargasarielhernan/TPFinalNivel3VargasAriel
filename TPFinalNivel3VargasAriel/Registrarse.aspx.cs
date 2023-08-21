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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try 
            { 
                Usuarios usuarios = new Usuarios();
                Users user= new Users();
                EmailService emailService = new EmailService();
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                user.Id = usuarios.Registrarse(user);

                emailService.armarCorreo(user.Email, "Bienvenido a Maxitienda", "Hola te damos la bienvenida a Maxitienda. ¿Que esperas para gastar todo tu sueldo en nuestros productos?");
                emailService.enviarEmail();

                Response.Redirect("Default.aspx", false);
            } 
            catch (Exception ex) 
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}