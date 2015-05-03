<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Usuario.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Perfil del usuario</h1>
        <% var c = getUsuarioActual(); %>
        Nombre: <%= c.Nombre %>
        Email: <%= c.Email %>
        Dirección: <%= c.Direccion %>
</asp:Content>
