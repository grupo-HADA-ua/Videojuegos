<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Usuario.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="loginUsuario" action="" method="post" runat="server">
    <p>
        <asp:Label Text="Nombre usuario" runat="server" /><br />
        <asp:TextBox ID="usuario" type="text" placeholder="tu nombre usuario..." runat="server" />
    </p>
    <p>
        <asp:Label Text="Contraseña" runat="server" /><br />
        <asp:TextBox ID="password" type="password" runat="server" />
    </p>
    <p>
        <asp:Button OnClick="logear" Text="Entrar" runat="server" />
    </p>
    </form>
</asp:Content>
