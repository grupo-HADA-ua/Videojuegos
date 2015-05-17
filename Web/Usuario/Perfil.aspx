<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Usuario.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Perfil del usuario</h1>
        <% var c = getUsuarioActual(); %>
        Nombre: <%= c.Nombre %>
        Email: <%= c.Email %>
        Dirección: <%= c.Direccion %>

    <h2>
        Carrito
    </h2>
    <table class="table table-bordered table-hover">
        <tr>
            <th>Nombre</th>
            <th>Precio</th>
        </tr>
        <% var total = 0.0; %>
        <% foreach (var p in ObtenerCarrito().Productos) %>
        <% { %>
        <tr>
            <td><%= p.Nombre %></td>
            <td><%= p.Precio %></td>
            <% total += p.Precio; %>
        </tr>
        <% } %>
    </table>
    Precio total: <%= total %>
</asp:Content>
