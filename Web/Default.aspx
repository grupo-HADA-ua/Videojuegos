<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Contenido Destacado</h2>
    <div class="row destacado">
        <div class="col-md-6">
            <label>Watch Dogs</label>
            <label>19.99€</label>
            <a href="~/Catalogo/Detalles.aspx" runat="server">Ver</a>
            <img src="~/Imagenes/WatchDogs.jpg" alt="Imagen Videojuego" runat="server" />
        </div>
        <div class="col-md-6">
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut 
                labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut 
                aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum 
                dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui 
                officia deserunt mollit anim id est laborum.
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut 
                labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut 
                aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum 
                dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui 
                officia deserunt mollit anim id est laborum.
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <a href="~/Catalogo/Detalles.aspx" runat="server">
                <img src="~/Imagenes/WatchDogs.jpg" alt="Imagen Videojuego" runat="server" />
            </a>
            <label>Watch Dogs</label>
            <label>19.99€</label>
            <a href="~/Catalogo/Detalles.aspx" runat="server">Ver</a>
        </div>
        <div class="col-md-4">
            <a href="~/Catalogo/Detalles.aspx" runat="server">
                <img src="~/Imagenes/WatchDogs.jpg" alt="Imagen Videojuego" runat="server" />
            </a>
            <label>Watch Dogs</label>
            <label>19.99€</label>
            <a href="~/Catalogo/Detalles.aspx" runat="server">Ver</a>
        </div>
        <div class="col-md-4">
            <a href="~/Catalogo/Detalles.aspx" runat="server">
                <img src="~/Imagenes/WatchDogs.jpg" alt="Imagen Videojuego" runat="server" />
            </a>
            <label>Watch Dogs</label>
            <label>19.99€</label>
            <a href="~/Catalogo/Detalles.aspx" runat="server">Ver</a>
        </div>
    </div>
</asp:Content>
