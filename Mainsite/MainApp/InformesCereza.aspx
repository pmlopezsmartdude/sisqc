<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformesCereza.aspx.cs" Inherits="Mainsite.MainApp.InformesCereza" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Table ID="Table1" runat="server" Height="100%" Width="100%">
<asp:TableRow style="vertical-align:top; height:50px;" >
<asp:TableCell Width="100%" Height="50px">
    <iframe id="DropDown" runat="server" src="HeadInformeCCCereza.aspx" style="display:block; width:100%; height:100%; border:none; margin:0; padding:0;" ></iframe>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow style="vertical-align:top; height:410px;" >
<asp:TableCell Width="100%" Height="410px">
<iframe id="idframe" name="idframe" runat="server" style="display:block; width:100%; height:100%; border:none; margin:0; padding:0;" ></iframe>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
    </div>
    </form>
</body>
</html>
