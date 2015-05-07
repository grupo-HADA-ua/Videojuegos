<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web.Administrador.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Productos</h2>    
    <h3>Videojuegos</h3>
    <table class="table">
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Edad Minima</th>
            <th>Editar</th>
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
            <td><a  href="EditarVideojuego.aspx?id=<%: v.Id %>">Editar</a></td>
        </tr>
    <%} %>
    </table>
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
        <asp:Button Text="Crear Videojuego" OnClick="CrearVideojuego" CssClass="btn btn-default" runat="server" />        
    </div>
    <h3>Consolas</h3>
    <table class="table">
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Stock</th>
        </tr>
        <% var consolas = ObtenerConsolas(); %>
        <% foreach (var c in consolas)
            { %>
        <tr>
            <td><%= c.Id %></td>
            <td><%= c.Nombre %></td>
            <td><%= c.Precio %></td>
            <td><%= c.CantidadStock %></td>
        </tr>
        <% } %>
    </table>
    <h3>Perifericos</h3>
    <table class="table">
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Stock</th>
        </tr>
        <% var perifericos = ObtenerPerifericos(); %>
        <% foreach (var p in perifericos)
            { %>
        <tr>
            <td><%= p.Id %></td>
            <td><%= p.Nombre %></td>
            <td><%= p.Precio %></td>
            <td><%= p.CantidadStock %></td>
        </tr>
        <% } %>
    </table>
</asp:Content>
