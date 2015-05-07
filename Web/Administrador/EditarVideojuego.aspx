<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="EditarVideojuego.aspx.cs" Inherits="Web.Administrador.EditarVideojuego" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <div class="form-group">
            <label for="Nombre">Nombre</label>
            <asp:TextBox ID="Nombre" CssClass="form-control" type="text" runat="server" />
        </div>

        <div class="form-group">
            <label for="Edad">Edad Minima</label>
            <asp:TextBox ID="Edad" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group">
            <label for="Precio">Precio</label>
            <asp:TextBox ID="Precio" CssClass="form-control"  runat="server" />
        </div>

        <div class="form-group">
            <label for="Stock">Stock</label>
            <asp:TextBox ID="Stock" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group">
            <label for="Descripcion">Descripcion</label>
            <asp:TextBox ID="Descripcion" type="textarea" CssClass="form-control" runat="server" />
        </div>
        <asp:Button Text="Actualizar" OnClick="Actualizar" CssClass="btn btn-default" runat="server" />        
    </div>
</asp:Content>
