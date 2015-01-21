<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Mainsite.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sistema de aplicaciones informáticas White Cloud Technologies por WTC Consultores Ltda.
    </h2>
    <p style="text-align:center;">
        &copy; WTC Consultores Limitada - <%: DateTime.Now.Year %>, 
        Todos los derechos reservados. <br />

        La reproducción total o parcial de las aplicaciones, se encuentra penada por la ley 20.435<br />
        de acuerdo a los derechos de autor y propiedad intelectual. El uso indebido o inadecuado de las <br />
        aplicaciones contenidas en este sistema se encuentra sancionado y penado bajo la ley 20.435 <br />
        de derecho de propiedad intelectual de la Republica de Chile, publicada y promulgada el 4 de Mayo de 2010.
     </p>
     <p style="text-align:center;">
     Versión 2.0.77.45
     </p>
</asp:Content>
