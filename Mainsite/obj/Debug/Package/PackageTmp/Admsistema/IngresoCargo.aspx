<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoCargo.aspx.cs" Inherits="Mainsite.Admsistema.IngresoCargo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/workarea.css" rel="stylesheet" type="text/css" />

   
</head>
<body>
<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
</asp:ToolkitScriptManager>
<asp:TabContainer ID="Tabcontainer1" runat="server" ActiveTabIndex="0" Font-Names="Century Gothic" Font-Size="Small" style="height:80%;">
 <asp:TabPanel runat="server" HeaderText="Cargos" ID="Tabpanel1" Font-Names="Century Gothic" Font-Size="X-Small">
 <ContentTemplate>
   <table style="border-style: none; border-color: inherit; border-width: 10px; width:100%;">
   
   <tr>
    <td>Cargo</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_nombre" ValidationGroup="UserGroup" style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txt_nombre" CssClass="failureNotification" 
            Font-Size="X-Small"  ErrorMessage="Ingrese Cargo"  
            ValidationGroup="ValidacionIngresoCargo"/></td>
  </tr>
  <tr>
    <td>Descripción</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_apellido" ValidationGroup="UserGroup" style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
   <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ControlToValidate="txt_apellido" CssClass="failureNotification" 
           Font-Size="X-Small"  ErrorMessage="Ingrese Descripción"  
           ValidationGroup="ValidacionIngresoCargo"/></td>
 </tr>
  
 
  
  <tr>
  <td></td>
  <td></td>
<td> <asp:Button ID="AceptaCargo" runat="server" Text="Aceptar"  Width="100px" 
        OnClick="AceptarCargo" ValidationGroup="ValidacionIngresoCargo" /></td>

  </tr>


   </table>
 
 </ContentTemplate>
 </asp:TabPanel>
</asp:TabContainer>



    </form>
</body>
</html>
