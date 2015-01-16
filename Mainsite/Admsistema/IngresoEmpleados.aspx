<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoEmpleados.aspx.cs" Inherits="Mainsite.Admsistema.IngresoEmpleados" %>
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
 <asp:TabPanel runat="server" HeaderText="Nuevo Empleado" ID="Tabpanel1" Font-Names="Century Gothic" Font-Size="X-Small">
 <ContentTemplate>
   <table style="border-style: none; border-color: inherit; border-width: 10px; width:100%;">
   
   <tr>
    <td>Nombres</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_nombre" ValidationGroup="UserGroup" style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txt_nombre" CssClass="failureNotification" 
            Font-Size="X-Small"  ErrorMessage="Ingrese Nombre"  
            ValidationGroup="ValidacionIngresoEmpleado"/></td>
  </tr>
  <tr>
    <td>Apellidos</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_apellido" ValidationGroup="UserGroup" style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
   <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ControlToValidate="txt_apellido" CssClass="failureNotification" 
           Font-Size="X-Small"  ErrorMessage="Ingrese Nombre"  
           ValidationGroup="ValidacionIngresoEmpleado"/></td>
 </tr>
  <tr>
    <td>Rut</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_rut" ValidationGroup="UserGroup" style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
   <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
           ControlToValidate="txt_rut" CssClass="failureNotification" Font-Size="X-Small"  
           ErrorMessage="Ingrese Nombre"  ValidationGroup="ValidacionIngresoEmpleado"/></td>
 </tr>
  <tr>
    <td>Cargo</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="DDL_Cargo" runat="server" AutoPostBack="True" style="margin-left: 110px; width:250px; font-family:Century Gothic;"></asp:DropDownList>
      </td>
   <td><asp:HyperLink ID="NuevoCargo" runat="server" EnableViewState="false" Font-Size="x-Small">Crear nuevo</asp:HyperLink></td>
 </tr>
  <tr>
    <td>Codigo</td>
    <td>:</td>
    <td><asp:TextBox runat="server" id="txt_codigo" ValidationGroup="UserGroup" 
            readOnly="True" 
            style="margin-left: 110px; width:250px; font-family:Century Gothic;" /></td>
    <td><asp:checkbox text="Ingresar Manualmente" ID="manual" runat="server" Font-Size="X-Small" oncheckedchanged="manual_CheckedChanged" AutoPostBack="True"/></td>

</tr>
  <tr>
    <td>Planta</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="DDL_Planta" runat="server" AutoPostBack="True" style="margin-left: 110px; width:250px; font-family:Century Gothic;"></asp:DropDownList>
      </td>
   <td> </td>
 </tr>
  <tr>
  <td></td>
  <td></td>
<td> <asp:Button ID="IngresarEmpleado" runat="server" Text="Guardar"  Width="100px" 
        OnClick="Guardar" ValidationGroup="ValidacionIngresoEmpleado" /></td>

  </tr>


   </table>
 
 </ContentTemplate>
 </asp:TabPanel>
</asp:TabContainer>



    </form>
</body>
</html>
