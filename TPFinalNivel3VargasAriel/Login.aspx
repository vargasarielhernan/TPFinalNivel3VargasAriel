<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email address</label>
            <asp:TextBox runat="server" type="email" class="form-control" ID="txtEmail" aria-describedby="emailHelp" />
            <asp:RequiredFieldValidator Cssclass="form-control is-invalid" ErrorMessage="Debe completar todos los campos" ControlToValidate="txtEmail" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtPassword" class="form-label">Password</label>
            <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassword" />
            <asp:RequiredFieldValidator Cssclass="form-control is-invalid" ErrorMessage="Debe completar todos los campos" ControlToValidate="txtPassword" runat="server" />
        </div>
        <%if (!txtlabelError.EnableViewState)
            { %>
        <label id="txtlabelError" for="txtError" runat="server" class="form-control is-invalid">Email o contraseña incorrectos</label>
        <%} %>
        <div>
            <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnLog" runat="server" OnClick="btnLog_Click" />

        </div>
    </form>
</asp:Content>
