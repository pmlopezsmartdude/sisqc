<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DESCARGAEXCEL.aspx.cs" Inherits="Mainsite.AppFiles.DESCARGAEXCEL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
   
       <fieldset>
        <legend style="font-family:Century Gothic; font-size:small;">DESCARGA ARCHIVO EXCEL</legend>
        <asp:Table ID="Table2" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
        <asp:TableCell>
        <asp:Label ID="Label3" runat="server" Text="TURNO"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
        <asp:Label ID="Label1" runat="server" Text="LINEA"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
        <asp:Label ID="Label2" runat="server" Text="INICIO"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
        <asp:Label ID="Label4" runat="server" Text="FIN"></asp:Label>
        </asp:TableCell>
 
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
        <asp:TableCell>
        <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno" DataTextField="turno" DataValueField="turno" Height="30px" Width="80" Font-Names="Century Gothic">
        </asp:DropDownList>  
        </asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="linea" DataValueField="linea" Height="30px" Width="80" Font-Names="Century Gothic">
        </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell>
        <asp:TextBox ID="txt_fechainicio" runat="server" Width="70"  >
       </asp:TextBox><asp:ImageButton ID="imgPopup" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" /><cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txt_fechainicio"
    Format="yyyy-MM-dd"></cc1:CalendarExtender>
        </asp:TableCell>
        <asp:TableCell>
         <asp:TextBox ID="txt_fechafin" runat="server" Width="70"   ></asp:TextBox><asp:ImageButton ID="imgPopup_fin" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" />

   <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup_fin" runat="server" TargetControlID="txt_fechafin"
    Format="yyyy-MM-dd">
</cc1:CalendarExtender>
        </asp:TableCell>
   
        </asp:TableRow>
        </asp:Table>


        <br />
         <br />
         <asp:Table ID="Table1" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
        <asp:TableCell>
        <asp:ImageButton ID="desc003" runat="server" ImageUrl="~/Images/Descargar_Mesa_de_seleccion.png" CommandName="Select"  AlternateText="Seleccionar" Height="36px" ImageAlign="AbsMiddle" OnClick="Click_003"/>
        </asp:TableCell>
        <asp:TableCell>
        <asp:ImageButton ID="desc005" runat="server" ImageUrl="~/Images/Descargar_Producto_Terminado.png" CommandName="Select"  AlternateText="Seleccionar" Height="36px" ImageAlign="AbsMiddle" OnClick="Click_005"/>
        </asp:TableCell>
        <asp:TableCell>
        <asp:ImageButton ID="desc075" runat="server" ImageUrl="~/Images/Descargar_Descarte_Comercial.png" CommandName="Select"  AlternateText="Seleccionar" Height="36px" ImageAlign="AbsMiddle" OnClick="Click_075"/>
        </asp:TableCell>
       
 
        </asp:TableRow>
      
        </asp:Table>

        </fieldset>

    </form>
</body>
</html>
