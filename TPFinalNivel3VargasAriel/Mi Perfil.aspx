<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mi Perfil.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Mi_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
        </div>
        <div class="mb-3">
            <label for="txtPass" class="form-label">Password</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" Type="Password" />
        </div>
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtApellido" class="form-label">Nombre</label>
            <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" />
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</asp:Content>
