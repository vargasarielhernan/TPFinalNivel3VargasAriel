<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3VargasAriel.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox CssClass="form-control" ID="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" ID="Nombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtDescripcion" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txturlImagen" class="form-label">Url Imagen</label>
                <asp:TextBox CssClass="form-control" ID="txturlImagen" runat="server" />
            </div>
             <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                 <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlMarca">
                     <asp:ListItem Text="text1" />
                     <asp:ListItem Text="text2" />
                 </asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>
