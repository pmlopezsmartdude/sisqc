<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CC_PAC_075_INGRESO.aspx.cs" Inherits="Mainsite.AppFiles.CC_PAC_075_INGRESO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
       <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  
   </asp:ToolkitScriptManager>  


     <fieldset>
        <legend style="font-family:Century Gothic; font-size:small;">PLANILLA DESCARTE COMERCIAL</legend>
 <asp:Panel ID="Panel1" runat="server">
  <asp:Table ID="Table2" runat="server" Width="653px" Height="100%" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
  <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
  <asp:TableCell>
    <asp:Label ID="Label3" runat="server" Text="Fecha : "></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
    <asp:Label ID="lbl_fecha" runat="server"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lbl_turno" runat="server" Text="Línea : " Width="50" Height="20"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
    <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lin_codice" DataValueField="lin_codice" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="lbl_linea" runat="server" Text="Turno : " Width="50" Height="20"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno" DataTextField="TUR_Descrizione" DataValueField="TUR_Descrizione" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList> 
  </asp:TableCell>
  </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
   <asp:TableCell>
   <asp:Label ID="Label6" runat="server" Text="Productor : "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
   <asp:DropDownList ID="DDL_prodreal_d"  runat="server"  DataSourceID="DDL_prodreal" DataTextField="DESCRIPCION" DataValueField="DESCRIPCION" Height="30px" Width="80" Font-Names="Century Gothic"  > </asp:DropDownList>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label8" runat="server" Text=" "></asp:Label>
   </asp:TableCell>

   <asp:TableCell>
   <asp:Label ID="Label9" runat="server" Text="Variedad : "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
    <asp:DropDownList ID="DDL_variedad_d"  runat="server"  DataSourceID="DDL_variedad" DataTextField="VARDESC" DataValueField="VARDESC" Height="30px" Width="80"  Font-Names="Century Gothic" > </asp:DropDownList>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label11" runat="server" Text=" "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label12" runat="server" Text=" "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
    <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Visible="false" Width="27px"></asp:TextBox>
   </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
   <asp:TableCell>
   <asp:Label ID="Label38" runat="server" Text="Proceso : "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
       <asp:DropDownList ID="drop_proc_d"  runat="server" DataSourceID="drop_porc" DataTextField="PROC_NumeroProcesso" DataValueField="PROC_NumeroProcesso" Height="30px" Width="80" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="proc_SelectedIndexChanged">
        </asp:DropDownList>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label40" runat="server" Text=" "></asp:Label>
   </asp:TableCell>

   <asp:TableCell>
   <asp:Label ID="Label41" runat="server" Text="Lote : "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
   <asp:DropDownList ID="drop_lote_d"  runat="server" DataSourceID="drop_lote" DataTextField="LOT_NumeroLotto" DataValueField="LOT_NumeroLotto" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="lote_SelectedIndexChanged" >
        </asp:DropDownList>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label45" runat="server" Text=" "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="Label43" runat="server" Text="Hora : "></asp:Label>
   </asp:TableCell>
   <asp:TableCell>
   <asp:Label ID="lbl_hora" runat="server"></asp:Label>
   </asp:TableCell>
   
   </asp:TableRow>


  </asp:Table>



   </asp:Panel></fieldset>
   <br />
    <fieldset>
        <legend style="font-family:Century Gothic; font-size:small;">SEGUIMIENTO DESCARTE COMERCIAL-UNITEC</legend>
        <br />
  <asp:Table ID="Table6" runat="server" Width="75%" Height="100%" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
  <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
  <asp:TableCell>
  <asp:Label ID="Label16" runat="server" Text="% Exportable Estimado"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="esp" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label17" runat="server" Text="% Exportable Descartador"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label23" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label18" runat="server" Text="% Descarte CAT 2"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label24" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label19" runat="server" Text="% Descarte CAT 3"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label25" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label20" runat="server" Text="CAT 1 %(Desecho)"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label26" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label21" runat="server" Text="CAT 2 %(Exportable)"></asp:Label>
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label27" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label22" runat="server" Text="CAT 3 %(Exportable)"></asp:Label>
  </asp:TableCell>
  </asp:TableRow>
  <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_exp_est" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_exp_est"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label29" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
 <asp:TextBox  MaxLength="4" runat="server" ID="txt_exp_desc" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_exp_desc"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label31" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_desc_2" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_desc_2"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label33" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_desc_3" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_desc_3"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label35" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_1desecho" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_1desecho"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label37" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_2_exp" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_2_exp"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell><asp:Label ID="Label42" runat="server" Text=""></asp:Label></asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_3_exp" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_3_exp"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  </asp:TableRow>
  </asp:Table>
  <br />

        </fieldset>
        <br />
                   <fieldset>
                    <legend style="font-family:Century Gothic; font-size:small;">SEGUIMIENTO DESCARTE COMERCIAL MANUAL</legend>
           
   <asp:Table ID="Table1" runat="server" Width="25%" Height="100%" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
  <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
  <asp:TableCell>
  <asp:Label ID="Label1" runat="server" Text="% Exportable Descarte Mesa de Selección"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label14" runat="server" Text=" "></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label13" runat="server" Text="% Exportable Descarte Manual Linea"></asp:Label>
  </asp:TableCell>
  </asp:TableRow>
  <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_desc_mesa" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_desc_mesa"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  <asp:TableCell>
  <asp:Label ID="Label28" runat="server" Text=" "></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
  <asp:TextBox  MaxLength="4" runat="server" ID="txt_desc_manual" Width="30"  Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" ></asp:TextBox>
  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_desc_manual"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
  </asp:TableCell>
  </asp:TableRow>
  </asp:Table>



               <asp:Table ID="Table5" runat="server" Width="700px" Height="90px"  Font-Names="Century Gothic" Font-Size="X-Small" HorizontalAlign="Center" >
   
   <asp:TableRow Width="162px">
   <asp:TableCell>
       <asp:Label ID="Label2" runat="server" Text="Label" Font-Names="Century Gothic" Font-Size="Small">Observaciones</asp:Label>
       </asp:TableCell> 
       </asp:TableRow>
       <asp:TableRow Width="162px">
       <asp:TableCell>
       <center><asp:TextBox ID="txt_obser" runat="server" Height="100" Width="690" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine"></asp:TextBox></center>
   </asp:TableCell>   
   </asp:TableRow>
      <asp:TableRow Width="162px">
   <asp:TableCell>

   </asp:TableCell>   </asp:TableRow>

   </asp:Table>
             
             
             
             
             <asp:Table ID="Table4" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30" HorizontalAlign="Center">
             <asp:Button ID="btnGrabar" runat="server" Text="Guardar y salir" onclick="Grabar_Click" Width="100" Font-Names="Century Gothic" Font-Size="X-Small" />
             </asp:TableCell><asp:TableCell Width="30" HorizontalAlign="Center">
             <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="Limpiar_Click" Width="100" Font-Names="Century Gothic" Font-Size="X-Small" />
            
             </asp:TableCell></asp:TableRow></asp:Table></fieldset> 
    </form>
</body>
</html>
