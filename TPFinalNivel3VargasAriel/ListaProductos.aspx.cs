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
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requiere Perfil de administrador");
                Response.Redirect("Error.aspx", false);
            }
            ListaArticulos lista = new ListaArticulos();
            Session.Add("listaProductos", lista.ListarSP());
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }
        protected void Filtro_text(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaProductos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvProductos.DataSource= listaFiltrada;
            dgvProductos.DataBind();
        }
        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = !chkAvanzado.Checked;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                ListaArticulos lista = new ListaArticulos();
                 String Criterio = ddlCriterio.SelectedItem.ToString();
                dgvProductos.DataSource = lista.filtrar(ddlCampo.SelectedItem.ToString(), Criterio, txtFiltroAvanzado.Text);
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id =dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?Id=" + id);
        }
    }
}