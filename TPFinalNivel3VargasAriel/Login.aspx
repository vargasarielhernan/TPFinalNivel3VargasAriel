<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email address</label>
            <asp:TextBox runat="server" type="email" class="form-control" Id="txtEmail" aria-describedby="emailHelp"/>
        </div>
        <div class="mb-3">
            <label for="txtPassword" class="form-label">Password</label>
            <asp:TextBox runat="server" type="password" class="form-control" Id="txtPassword"/>
        </div>
        <asp:Button Text="Aceptar" CssClass="btn btn-primary" Id="btnLog" runat="server" OnClick="btnLog_Click" />
    </form>
</asp:Content>
