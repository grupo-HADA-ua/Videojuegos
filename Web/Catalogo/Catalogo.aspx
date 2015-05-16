<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Web.Catalogo.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/catalogo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="catalogo">
        <h2>Catálogo</h2>
        <% var productos = ObtenerProductos(); %>
    <% foreach (var p in productos)
        {%>
        <article class="producto">
            <p><%= p.Nombre %></p>
            <div>
                <a href="#">
                    <img src="../Imagenes/WatchDogs.jpg" alt="Imagen Videojuego"/>
                </a>
            </div>
            <footer>
                <span><%= p.Precio %> €</span> |
                <a href="#">Ver Detalles</a> |
                <% var tipo = Tipo(p); %>
                <a href="">Añadir</a>
                <asp:Button Text="Comprar" runat="server" />
            </footer>
        </article>
    <%
        }%>
    </section>
</asp:Content>
