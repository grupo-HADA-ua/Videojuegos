<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div>

    <% var clientes = ObtenerClientes();
       foreach (var c in clientes)
       {
           %>
           <p>
           <%
           string html = c.Nombre;
           Response.Write(html);
           %>
           </p>
           <%
       }
         %>
   </div>
</asp:Content>
