<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenProductoTerminado_juntos.aspx.cs" Inherits="Mainsite.Reporte.ResumenProductoTerminado_juntos" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" >

    function cerrarpagina() {

        window.close();
        return false;

    }

</script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="Button1" runat="server" Text="Cerrar" Font-Names="Century Gothic" Font-Size="Small" OnClientClick="return cerrarpagina();" />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>
