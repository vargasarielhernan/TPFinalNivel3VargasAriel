<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator CssClass="form-control is-invalid" ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator CssClass="form-control is-invalid" ErrorMessage="Formato incorrecto" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />

            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" Type="Password" MaxLength="20" />
                <asp:RequiredFieldValidator Cssclass="form-control is-invalid" ErrorMessage="Password requerida" ControlToValidate="txtPass" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" />
            </div>
            <asp:Button Text="Guardar" ID="btnGuardarPerfil" OnClick="btnGuardarPerfil_Click" runat="server" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagenPerfil" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imagenUrl" runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
</asp:Content>
