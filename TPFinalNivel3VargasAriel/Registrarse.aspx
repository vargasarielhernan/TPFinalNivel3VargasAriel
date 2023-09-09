<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPFinalNivel3VargasAriel.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-6">
                <form>
                    <h1>Ingrese sus datos para registrarse</h1>
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email address</label>
                        <asp:TextBox runat="server" type="email" class="form-control" ID="txtEmail" aria-describedby="emailHelp" />
                    </div>
                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassword" />
                    </div>
                    <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click" />
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" runat="server" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
