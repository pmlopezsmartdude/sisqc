<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admusr.aspx.cs" Inherits="Mainsite.MainApp.admusr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="mainadmusr">
<asp:Table runat="server">
<asp:TableRow style="vertical-align:top; height:480px;" >
<asp:TableCell Width="15%" Height="480px">
    <iframe id="menuadmusr" runat="server" src="menuadmusr.aspx" style="display:block; width:100%; height:100%; border:none; margin:0; padding:0;" ></iframe>
</asp:TableCell>
<asp:TableCell Width="100%" Height="480px">
<asp:Table runat="server" ID="wrk" Width="100%">
<asp:TableRow style="vertical-align:top; height:20px;">
<asp:TableCell Width="100%" Height="20px">
    <iframe id="cabeceraareadetrabajo" runat="server" style="display:block; width:100%; height:100%; border:none; margin:0; padding:0;"></iframe>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow style="vertical-align:top; height:460px;">
<asp:TableCell Width="100%" Height="460px">
<iframe id="workingarea" name="workingarea" src="areadetrabajo.aspx" runat="server" style="display:block; width:100%; height:459px; border:none; margin:0; padding:0;" ></iframe>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</div>
</asp:Content>
