<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="EditarPeriferico.aspx.cs" Inherits="Web.Administrador.EditarPeriferico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <div class="form-group">
            <label for="Nombre">Nombre</label>
            <asp:TextBox ID="Nombre" CssClass="form-control" type="text" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Se requiere un nombre" 
                ControlToValidate="Nombre" CssClass="alert alert-danger" runat="server" />
        </div>

        <div class="form-group">
            <label for="Precio">Precio</label>
            <asp:TextBox ID="Precio" CssClass="form-control"  runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Se requiere un precio" 
                ControlToValidate="Precio" CssClass="alert alert-danger" runat="server" />
        </div>

        <div class="form-group">
            <label for="Stock">Stock</label>
            <asp:TextBox ID="Stock" CssClass="form-control" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Se requiere un Stock" CssClass="alert alert-danger" ControlToValidate="Stock" runat="server" />
        </div>

        <div class="form-group">
            <label for="Descripcion">Descripcion</label>
            <asp:TextBox ID="Descripcion" type="textarea" CssClass="form-control" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Se requiere una descripción"
                 ControlToValidate="Descripcion" CssClass="alert alert-danger" runat="server" />
        </div>
        <asp:Button Text="Actualizar" OnClick="Actualizar" CssClass="btn btn-default" runat="server" />        
    </div>
</asp:Content>
