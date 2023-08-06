<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3VargasAriel.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
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
            </div>
            <div>
                <div class="mb-3">
                    <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnagregar" OnClick="btnagregar_Click" runat="server" />
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
</asp:Content>
