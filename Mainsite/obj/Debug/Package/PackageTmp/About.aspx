<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Mainsite.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sistema de aplicaciones informáticas White Cloud Technologies por WTC Consultores Ltda.
    </h2>
    <p>
        &copy; WTC Consultores Limitada - <%: DateTime.Now.Year %>
        Todos los derechos reservados.

        La reproducción total o parcial de las aplicaciones, se encuentra penada por la ley
        de acuerdo a los derechos de autor.
        El uso indebido o inadecuado de las aplicaciones contenidas en este sistema se encuentra
        sancionado y penado bajo la ley de derecho de propiedad intelectual de la Republica de Chile.
    </p>
</asp:Content>
