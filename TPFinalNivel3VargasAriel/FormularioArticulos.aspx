<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3VargasAriel.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <div class="container-fluid">
        <h1>Detalles</h1>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo</label>
                    <asp:TextBox CssClass="form-control" ID="txtCodigo" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Categoria</label>
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlMarca">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlCategoria">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox CssClass="form-control" ID="txtPrecio" runat="server" />
                    <asp:RegularExpressionValidator CssClass="form-control is-invalid" ErrorMessage="Solo se admiten numeros" ValidationExpression="^[0-9]+(.[0-9]+)?$" ControlToValidate="txtPrecio" runat="server" />
                </div>
                <div>
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnagregar" OnClick="btnagregar_Click" runat="server" />
                        <asp:Button Text="Cancelar" CssClass="btn btn-outline-red" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtDescripcion" runat="server" />
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txturlImagen" class="form-label">Url Imagen</label>
                            <asp:TextBox AutoPostBack="true" CssClass="form-control" ID="txturlImagen" runat="server" OnTextChanged="txturlImagen_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=740" runat="server" ID="ImagenUrl" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%if (negocio.Seguridad.esAdmin(Session["usuario"]))
            {
                if (Request.QueryString["id"] != null && !IsPostBack)
                {%>
        <div class="row">
            <div class="col-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Eliminar" CssClass="btn btn-outline-red" OnClick="btnEliminar_Click" ID="btnEliminar" runat="server" />
                        <%if (ConfirmaEliminacion)
                            { %>
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkEliminar" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnEliminarConfirmado" OnClick="btnEliminarConfirmado_Click" CssClass="btn btn-danger" runat="server" />
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%}
            }%>
    </div>
</asp:Content>
