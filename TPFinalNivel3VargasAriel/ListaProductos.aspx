<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TPFinalNivel3VargasAriel.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <h1>Lista de Productos</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox ID="Filtro" AutoPostBack="true" CssClas="form-control" OnTextChanged="Filtro_text" runat="server" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvProductos" CssClass="table" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="ImagenUrl" DataField="ImagenUrl" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </Columns>

    </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
