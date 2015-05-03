<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Web.Usuario.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div>
        Nombre de usuario: <asp:TextBox  ID="Nombre" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce nombre de usuario" 
                ControlToValidate="Nombre" Display="Dynamic"
                runat="server" /><br />

        Email: <asp:TextBox ID="Email" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce un email" 
                ControlToValidate="Email" Display="Dynamic"
                runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Introduce un email válido" 
                ValidationExpression="\S+@\S+\.\S+" Display="Dynamic"
                ControlToValidate="Email" runat="server" />
            <asp:CustomValidator ErrorMessage="El usuario ya existe" 
                OnServerValidate="ExisteUsuario" Display="Dynamic"
                ControlToValidate="Email" runat="server" />
            <br />

        Contraseña: <asp:TextBox ID="Password" type="password" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce una contraseña" 
                ControlToValidate="Password" Display="Dynamic"
                runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Introduce una contraseña válida" 
                ValidationExpression="^[a-zA-Z]\w{3,14}" Display="Dynamic"
                ControlToValidate="Password" runat="server" />
            <br />

        Repetir contraseña: <asp:TextBox ID="PasswordConfirmation" type="password" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Repite la contraseña" 
                ControlToValidate="PasswordConfirmation" Display="Dynamic"
                runat="server" />
            <asp:CustomValidator ErrorMessage="Las contraseñas introducidas no coinciden" 
                ControlToValidate="PasswordConfirmation" 
                OnServerValidate="MismoPassword" Display="Dynamic"
                runat="server" /><br />

        Dirección: <asp:TextBox ID="Direccion" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce tu dirección" 
                ControlToValidate="Direccion" Display="Dynamic"
                runat="server" /><br />

        <asp:Button Text="Registrarse" OnClick="Registrarse" runat="server" /><br />
        </div>
    </form>    
</asp:Content>
