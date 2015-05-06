<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Web.Administrador.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Clientes</h2>
    <table class="table">
        <tr>
            <th>Id
            </th>
            <th>Nombre
            </th>
            <th>Email
            </th>
            <th>Dirección
            </th>
        </tr>
        <% var clientes = ObtenerClientes(); %>
        <% foreach (var c in clientes)
            { %>
        <tr>
            <td><%= c.Id %></td>
            <td><%= c.Nombre %></td>
            <td><%= c.Email %></td>
            <td><%= c.Direccion %></td>
        </tr>

        <%} %>
    </table>
</asp:Content>
