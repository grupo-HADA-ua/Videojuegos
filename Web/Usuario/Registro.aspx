<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Web.Usuario.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="form-group">
            <label for="Nombre">Nombre de usuario</label>
            <asp:TextBox ID="Nombre" CssClass="form-control" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce nombre de usuario"
                ControlToValidate="Nombre" Display="Dynamic"
                runat="server" />
        </div>

        <div class="form-group">
            <label for="Email">Email</label>
            <asp:TextBox ID="Email" CssClass="form-control" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce un email"
                ControlToValidate="Email" Display="Dynamic"
                runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Introduce un email válido"
                ValidationExpression="\S+@\S+\.\S+" Display="Dynamic"
                ControlToValidate="Email" runat="server" />
            <asp:CustomValidator ErrorMessage="El usuario ya existe"
                OnServerValidate="ExisteUsuario" Display="Dynamic"
                ControlToValidate="Email" runat="server" />
        </div>

        <div class="form-group">
            <label for="Direccion">Dirección</label>
            <asp:TextBox ID="Direccion" CssClass="form-control" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce tu dirección"
                ControlToValidate="Direccion" Display="Dynamic"
                runat="server" />
        </div>

        <div class="form-group">
            <label for="Password">Contraseña</label>
            <asp:TextBox ID="Password" CssClass="form-control" type="password" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Introduce una contraseña"
                ControlToValidate="Password" Display="Dynamic"
                runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Introduce una contraseña válida"
                ValidationExpression="^[a-zA-Z]\w{3,14}" Display="Dynamic"
                ControlToValidate="Password" runat="server" />
        </div>

        <div class="form-group">
            <label for="PasswordConfirmation">Repite la contraseña</label>
            <asp:TextBox ID="PasswordConfirmation" CssClass="form-control" type="password" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Repite la contraseña"
                ControlToValidate="PasswordConfirmation" Display="Dynamic"
                runat="server" />
            <asp:CustomValidator ErrorMessage="Las contraseñas introducidas no coinciden"
                ControlToValidate="PasswordConfirmation"
                OnServerValidate="MismoPassword" Display="Dynamic"
                runat="server" />
        </div>        
        <asp:Button Text="Registrarse" CssClass="btn btn-default" OnClick="Registrarse" runat="server" /><br />
    </div>
</asp:Content>
