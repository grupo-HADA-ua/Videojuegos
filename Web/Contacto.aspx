<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Web.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Esto es el contacto</h2>
    <p>&nbsp;</p>
    <p>Direccion:&nbsp;&nbsp;&nbsp;&nbsp; C/Carrer Chile CV-84 (frente Corte Ingles)</p>
    <center>
    <iframe width="400" height="300" scrolling="no" marginheight="3" 
            marginwidth="3" 
            src="https://maps.google.es/maps?f=d&amp;source=s_d&amp;saddr=38.256885,-0.717964&amp;daddr=&amp;hl=es&amp;geocode=&amp;sll=38.256704,-0.718102&amp;sspn=0.002553,0.003449&amp;t=h&amp;mra=mift&amp;mrsp=0&amp;sz=18&amp;ie=UTF8&amp;ll=38.256704,-0.718102&amp;spn=0.002553,0.003449&amp;output=embed" 
            align="middle"></iframe>
    </center>
        <br />
        <br />
    <p>E-mail: otrogami@otrogami.com</p>
    <p>Facebook: Otrogami</p>
    <p>Telf.: 966666666</p>
    <p>Grupo formado por:</p>
        <b>
            Alejandro Oliver Ruiz<br />
            Almudena Marin Peñalver
            <br />
            Joaquin Aguirre Torres
            <br />
            Javier Revilla
            <br />
            Manuel Luis Pascual Luna
            <br />
        </b>
    <p>Tu e-mail:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="252px" ValidationGroup="contacto"></asp:TextBox>
    </p>
    <p>Comentario:</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="93px" MaxLength="160" 
            Width="433px" ValidationGroup="contacto"></asp:TextBox>
    </p>
    <p>
        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ControlToValidate="TextBox1" 
            ErrorMessage="Formato de email incorrecto" ForeColor="Red" Display="Dynamic" ValidationGroup="contacto"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox2" 
            ErrorMessage="El campo de mensaje no puede estar vacio" Display="Dynamic" 
            ForeColor="Red" VlidationGroup="contacto"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Enviar" onclick="Button1_Click" ValidationGroup="contacto" />
    </p>
</asp:Content>
