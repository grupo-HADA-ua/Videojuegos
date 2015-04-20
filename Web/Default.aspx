<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <nav class="navbar navbar-default navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button class="navbar-toggle collapsed" aria-controls="navbar"
                aria-expanded="false" data-target="#navbar"
                data-toggle="collapse" type="button"></button>
            <a class="navbar-brand" href="~/Default.aspx" runat="server"><%= Resources.Cadenas.NombreTienda %></a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a href="#">Catálogo</a>
                </li>
                <li>
                    <a href="#">Noticias</a>
                </li>
            </ul>
        </div>
    </div>
   </nav>

   <div class="container">
    <div class="jumbotron">
       
    </div>    
   </div>
</asp:Content>
