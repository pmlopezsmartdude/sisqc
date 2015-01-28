<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GraficoProductoTerminado.aspx.cs" Inherits="Mainsite.Reporte.GraficoProductoTerminado" %>
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
        <legend style="font-family:Century Gothic; font-size:small;">REPORTE</legend>
        <asp:Table ID="Table2" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
      
        <asp:TableCell>
        <asp:Label ID="Label2" runat="server" Text="DESDE"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
        <asp:Label ID="Label4" runat="server" Text="HASTA"></asp:Label>
        </asp:TableCell>
 
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
       
        <asp:TableCell>
        <asp:TextBox ID="txt_fechainicio" runat="server" Width="70"  Font-Names="Century Gothic" ValidationGroup="IngresoFechaGroup">
       </asp:TextBox><asp:ImageButton ID="imgPopup" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" /><cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txt_fechainicio"
    Format="yyyy-MM-dd"></cc1:CalendarExtender>
        </asp:TableCell>
        <asp:TableCell>
         <asp:TextBox ID="txt_fechafin" runat="server" Width="70"   Font-Names="Century Gothic" ValidationGroup="IngresoFechaGroup"></asp:TextBox><asp:ImageButton ID="imgPopup_fin" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" />

   <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup_fin" runat="server" TargetControlID="txt_fechafin"
    Format="yyyy-MM-dd">
</cc1:CalendarExtender>
        </asp:TableCell>
   
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
        <asp:TableCell>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fechainicio" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Fecha Inicio"  ValidationGroup="IngresoFechaGroup"/>
        </asp:TableCell><asp:TableCell>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fechafin" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Fecha Fin"  ValidationGroup="IngresoFechaGroup"/>
        </asp:TableCell></asp:TableRow></asp:Table><asp:Table ID="Table1" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" >
      
        <asp:TableCell Width="34%">
        <asp:Label ID="Label1" runat="server" Text="PLANTA"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
        <asp:Label ID="Label5" runat="server" Text="LINEA"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
        <asp:Label ID="Label6" runat="server" Text="TURNO"></asp:Label>
        </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
      
        <asp:TableCell>
        <asp:DropDownList ID="ddl_planta_d"  runat="server" Width="80" DataSourceID="ddl_planta" DataTextField="planta" DataValueField="plantaid" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="planta_SelectedIndexChanged"> </asp:DropDownList>
        </asp:TableCell><asp:TableCell>
        <asp:DropDownList ID="ddl_linea_d"  runat="server" Width="80" DataSourceID="ddl_linea" DataTextField="linea" DataValueField="linea" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="linea_SelectedIndexChanged"> </asp:DropDownList>
        </asp:TableCell><asp:TableCell>
        <asp:DropDownList ID="ddl_turno_d"  runat="server" Width="80" DataSourceID="ddl_turno" DataTextField="turno" DataValueField="turno" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="turno_SelectedIndexChanged"> </asp:DropDownList>
        </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" >
      
        <asp:TableCell Width="34%">
        <asp:Label ID="Label9" runat="server" Text="PROCESO"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
        <asp:Label ID="Label10" runat="server" Text="LOTE"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
        
        </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
      
        <asp:TableCell>
        <asp:DropDownList ID="ddl_proceso_d"  runat="server" Width="80" DataSourceID="ddl_proceso" DataTextField="proceso" DataValueField="proceso" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="proceso_SelectedIndexChanged"> </asp:DropDownList>
        </asp:TableCell><asp:TableCell>
  <asp:DropDownList ID="ddl_lote_d"  runat="server" Width="80" DataSourceID="ddl_lote" DataTextField="lote" DataValueField="lote" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="lote_SelectedIndexChanged"> </asp:DropDownList>
       
        </asp:TableCell><asp:TableCell>
         </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" >
      
        <asp:TableCell Width="34%">
        <asp:Label ID="Label11" runat="server" Text="VARIEDAD"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
       <asp:Label ID="Label3" runat="server" Text="PRODUCTOR"></asp:Label>
        </asp:TableCell><asp:TableCell Width="34%">
        <asp:Label ID="Label14" runat="server" Text="ACEPTADA/RECHAZADA"></asp:Label>
        </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
      
        <asp:TableCell >
        <asp:DropDownList ID="ddl_variedad_d"  runat="server" Width="80" DataSourceID="ddl_variedad" DataTextField="variedad" DataValueField="variedad_id" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="variedad_SelectedIndexChanged"> </asp:DropDownList>
        </asp:TableCell><asp:TableCell>
        <asp:DropDownList ID="ddl_productor_d"  runat="server" Width="80" DataSourceID="ddl_productor" DataTextField="productor" DataValueField="productor_id" Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="productor_SelectedIndexChanged"> </asp:DropDownList>
        
        </asp:TableCell><asp:TableCell>
        <asp:DropDownList ID="ddl_acep_d"  runat="server" Width="80" DataSourceID="ddl_acep_d" DataTextField="tipo" DataValueField="tipo" Font-Names="Century Gothic"> </asp:DropDownList>
        
        </asp:TableCell></asp:TableRow></asp:Table>
        <br />
        <br />
    
        
        
        <asp:Table ID="Table3" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="50">
      
        <asp:TableCell>
       <asp:ImageButton ID="Reporte005" runat="server" ImageUrl="~/Images/Def_cal_y_condicion.png" CommandName="Select"  AlternateText="Seleccionar" Height="36px" ImageAlign="AbsMiddle" OnClick="Click_005" ValidationGroup="IngresoFechaGroup"/>
         
        </asp:TableCell><asp:TableCell>
        <asp:ImageButton   ID="Reporte6" runat="server" ImageUrl="~/Images/Solidos_Solubles.png" CommandName="Select"  AlternateText="Seleccionar" Height="36px" ImageAlign="AbsMiddle" OnClick="Click_005_v2" ValidationGroup="IngresoFechaGroup"/>
        
        </asp:TableCell></asp:TableRow></asp:Table></fieldset> </form></body></html>