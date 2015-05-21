<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Usuario.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Perfil del usuario</h1>
        <% var c = getUsuarioActual(); %>
        Email: <%= c.Email %>

    <h2>
        Carrito
    </h2>
    <table class="table table-bordered table-hover">
        <tr>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Eliminar</th>
        </tr>
        <% var total = 0.0; %>
        <% foreach (var p in ObtenerCarrito().Productos) %>
        <% { %>
        <tr>
            <td><%= p.Nombre %></td>
            <td><%= p.Precio %></td>
            <td><a href="Perfil.aspx?id=<%: p.Id %>&nombre=<%: p.Nombre %>">eliminar</a></td>
            <% total += p.Precio; %>
        </tr>
        <% } %>
    </table>
    Precio total: <%= total %>
    <asp:Button Text="Comprar" OnClick="Comprar" runat="server" />
</asp:Content>
