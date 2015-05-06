<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Administrador.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <div class="form-group">
                <label for="Usuario">Usuario</label>
                <asp:TextBox ID="Usuario" CssClass="form-control" type="text" placeholder="introduce tu usuario como administrador" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Introduce tu usuario" 
                    ControlToValidate="Usuario" Display="Dynamic"
                    runat="server" />
            </div>
            
            <div class="form-group">
                <label for="Password">Contraseña</label>
                <asp:TextBox ID="Password" CssClass="form-control" type="password" placeholder="introducte tu contraseña" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Introduce la contraseña!" 
                    ControlToValidate="Password" Display="Dynamic"
                    runat="server" />
                <asp:CustomValidator ErrorMessage="Datos incorrectos" 
                    OnServerValidate="ComprobarDatos" Display="Dynamic"
                    ControlToValidate="Password" runat="server" />
            </div>
            <asp:Button Text="Entrar" CssClass="btn btn-default" OnClick="Logear" runat="server" />
        </div>    
</asp:Content>
