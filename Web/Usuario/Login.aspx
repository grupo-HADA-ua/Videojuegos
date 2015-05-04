<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Usuario.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
        <div>
            <div class="form-group">
                <label for="Email">Email</label>
                <asp:TextBox ID="Email" CssClass="form-control" type="text" placeholder="introduce tu email" runat="server" />
            </div>
            
            <div class="form-group">
                <label for="Password">Contraseña</label>
                <asp:TextBox ID="Password" CssClass="form-control" type="password" placeholder="introducte tu contraseña" runat="server" />
            </div>
            
            <asp:CustomValidator ErrorMessage="Datos Incorrectos" 
                OnServerValidate="ComprobarDatos" Display="Dynamic"
                ControlToValidate="Password" runat="server" /><br />
            <asp:Button Text="Entrar" CssClass="btn btn-default" OnClick="Logear" runat="server" />
        </div>    
</asp:Content>
