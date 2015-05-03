<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Usuario.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
        <div>
            Email: <asp:TextBox ID="Email" type="text" placeholder="introduce tu email" runat="server" /><br />
            Password: <asp:TextBox ID="Password" type="password" placeholder="introducte tu contraseña" runat="server" />
            <asp:CustomValidator ErrorMessage="Datos Incorrectos" 
                OnServerValidate="ComprobarDatos" Display="Dynamic"
                ControlToValidate="Password" runat="server" /><br />
            <asp:Button Text="Entrar" OnClick="Logear" runat="server" />
        </div>    
</asp:Content>
