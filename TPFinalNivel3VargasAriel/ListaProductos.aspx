﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TPFinalNivel3VargasAriel.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <div class="container-fluid">
        <h1>Lista de Productos</h1>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClas="form-control" OnTextChanged="Filtro_text" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" CssClass="form-check-input" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
                    </div>
                </div>

                <%if (chkAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Codigo" />
                                <asp:ListItem Text="Descripcion" />
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Categoria" />
                                <asp:ListItem Text="Precio" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                            <% if (ddlCampo.SelectedItem.ToString() == "Precio")
                                {%>
                            <asp:RegularExpressionValidator ErrorMessage="Solo se admiten numeros" ValidationExpression="^[0-9]+$" ControlToValidate="txtFiltroAvanzado" runat="server" />
                            <%} %>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
                <%} %>
                <div class="row">
                    <div class="col-4">
                        <div class="mb-3">
                            <asp:GridView ID="dgvProductos" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" CssClass="table" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                                    <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Acciones" />
                                    <asp:BoundField HeaderText="ImagenUrl" DataField="ImagenUrl" />
                                </Columns>
                            </asp:GridView>
                            <%if (negocio.Seguridad.esAdmin(Session["usuario"]))
                                { %>
                            <a class="btn btn-dark" href="FormularioArticulos.aspx">Agregar</a> <%} %>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
