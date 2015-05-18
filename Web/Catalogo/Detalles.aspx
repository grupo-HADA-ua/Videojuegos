<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="Web.Catalogo.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= _producto.Nombre %></h2>
    <div class="row">
        <div class="col-md-6">
            <img src="~/Imagenes/WatchDogs.jpg" alt="Imagen Videojuego" runat="server" />
        </div>
        <div class="col-md-6">
            <%= _producto.Descripcion %>
        </div>
    </div>

    <div class="row">
        <div class="col-md-1"><%= _producto.Precio %>€</div>
        <div class="col-md-1">
            <% if (Session["Cliente"] != null) %>
            <% { %>
            <a class="btn btn-default" href="Catalogo.aspx?id=<%: _producto.Id %>&clase=<%: ObtenerClase(_producto) %>">Añadir</a>
            <% } %>            
        </div>
    </div>
</asp:Content>
