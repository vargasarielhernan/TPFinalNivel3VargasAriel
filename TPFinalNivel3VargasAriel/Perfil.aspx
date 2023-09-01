<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator Cssclass="form-control is-invalid" ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" Type="Password" />
                <asp:RequiredFieldValidator ErrorMessage="Password requerida" Cssclass="form-control is-invalid" ControlToValidate="txtPass" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" />
            </div>
            <asp:Button Text="Guardar" ID="btnGuardarPerfil" Onclick="btnGuardarPerfil_Click" runat="server" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" Id="txtImagenPerfil" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imagenUrl" ImageUrl="https://i0.wp.com/casagres.com.ar/wp-content/uploads/2022/09/placeholder.png?ssl=1" runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
</asp:Content>
