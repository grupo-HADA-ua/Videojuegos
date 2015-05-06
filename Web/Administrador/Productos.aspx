<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web.Administrador.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Productos</h2>
    <table class="table">
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Edad Minima</th>
        </tr>
         <% var videojuegos = ObtenerVideojuegos(); %>
    <% foreach (var v in videojuegos)
        {%>
        <tr>
            <td><%= v.Id %></td>
            <td><%= v.Nombre %></td>
            <td><%= v.Precio %></td>
            <td><%= v.CantidadStock %></td>
            <td><%= v.EdadMinima %></td>
        </tr>
    <%} %>
    </table>
    <h3>Videojuegos</h3>
    <h3>Consolas</h3>
    <h3>Perifericos</h3>
</asp:Content>
