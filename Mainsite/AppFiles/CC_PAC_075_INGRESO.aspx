﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CC_PAC_075_INGRESO.aspx.cs" Inherits="Mainsite.AppFiles.CC_PAC_075_INGRESO" %>
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
        <legend style="font-family:Century Gothic;">CC-PAC-075</legend>
 <asp:Panel ID="Panel1" runat="server">
   <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
              <asp:TableCell Width="30">
            <asp:Label ID="lbl_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lin_codice" DataValueField="lin_codice" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
        <asp:TableCell Width="30">
            <asp:Label ID="lbl_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno" DataTextField="TUR_Descrizione" DataValueField="TUR_Descrizione" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_cod_plan" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
                  
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"></asp:TableCell></asp:TableRow>

   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
                <asp:Label ID="lbl_cod_proc" runat="server" Text="Código Proceso" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
              <asp:DropDownList ID="drop_proc_d"  runat="server" DataSourceID="drop_porc" DataTextField="PROC_NumeroProcesso" DataValueField="PROC_NumeroProcesso" Height="30px" Width="80" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="proc_SelectedIndexChanged">
        </asp:DropDownList> </asp:TableCell>
           
              <asp:TableCell Width="30">
            <asp:Label ID="lblLote" runat="server" Text="Lote" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_lote_d"  runat="server" DataSourceID="drop_lote" DataTextField="LOT_NumeroLotto" DataValueField="LOT_NumeroLotto" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="lote_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
   </asp:TableRow>
  </asp:Table>
   </asp:Panel></fieldset>
   <br />
    <fieldset>
        <legend style="font-family:Century Gothic;">Seguimiento de Descarte Comercial por Lote</legend>
   <asp:Table ID="Table1" runat="server" Width="653px" Height="68px" 
            Font-Names="Century Gothic" Font-Size="x-Small"  HorizontalAlign="Center" >
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
       <asp:TableCell Width="70">
             <asp:Label ID="lbldescarte" runat="server" Text="% Exportable Descarte Manual" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="5"  runat="server" ID="txtDescarte"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtDescarte"  FilterType="numbers, Custom"  ValidChars="." runat="server" />
                   </asp:TableCell><asp:TableCell Width="70">
             <asp:Label ID="lblCATII" runat="server" Text="% Exportable Comercial" Width="70" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="60">
          
              <asp:RadioButton text="CAT II" id="CAT_II" groupname="CAT" runat="server" />
              <asp:RadioButton text="CAT III" id="CAT_III" groupname="CAT" runat="server" />
    </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="5"  runat="server" ID="txtCAT_Valor"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtCAT_Valor"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
                   </asp:TableCell> <asp:TableCell></asp:TableCell>
                   <asp:TableCell Width="90">
            
             <asp:Label ID="Label1" runat="server" Text="Referencia CAT 1 Justificación Ajuste" Width="90" Height="20"></asp:Label>
             </asp:TableCell>
                    <asp:TableCell>
                <asp:TextBox runat="server" ID="txt_ref"  Width="100" Height="50" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
                   </asp:TableCell></asp:TableRow></asp:Table>
           
  <fieldset>
           
        <legend style="font-family:Century Gothic;">Rangos de trabajo y porcentajes</legend>
            
<table style="width:700px; border:1; text-align:center;">
  <tr>
    <td  rowspan="3"  style="width:60px; text-align:center;"><asp:Label ID="Label37" runat="server" Text="PARAMETROS" Width="60" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   
  </tr>
  <tr>
    <td colspan="2" align="center"><asp:Label ID="Label17" runat="server" Text="Global" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:Label ID="Label19" runat="server" Text="Puntual" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:Label ID="Label20" runat="server" Text="Externo" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:Label ID="Label21" runat="server" Text="Punto Negro" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:Label ID="Label22" runat="server" Text="Punto Marrón" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:Label ID="Label23" runat="server" Text="Mancha Blanca" Width="70" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
  </tr>
  <tr>
   <td width="35" align="center"><asp:Label ID="Label18" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label24" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label25" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label26" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label27" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label28" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label29" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label30" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label31" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label32" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td width="35" align="center"><asp:Label ID="Label33" runat="server" Text="Valor" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   <td align="center" class="style1"><asp:Label ID="Label34" runat="server" Text="%" Width="30" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
   </tr>
  <tr>
    <td width="60" align="center"><asp:Label ID="Label35" runat="server" Text="RANGOS" Width="60" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_global_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_global_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_puntual_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_puntual_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_externo_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_externo_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_ptoneg_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_ptoneg_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_ptomar_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_ptomar_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td width="35" align="center">  <asp:TextBox  MaxLength="3" runat="server" ID="txt_mancha_v"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td align="center" class="style1">  <asp:TextBox  MaxLength="5" runat="server" ID="txt_mancha_p"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    </tr>
  <tr>
    <td width="60" align="center"><asp:Label ID="Label36" runat="server" Text="PRUEBA (% Exp)" Width="60" Height="20" Font-Names="Century Gothic" Font-Size="x-Small"></asp:Label></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_global_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_puntual_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_externo_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_ptoneg_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_ptomar_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>
    <td colspan="2" align="center"><asp:TextBox  MaxLength="5" runat="server" ID="txt_mancha_exp"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox></td>  </tr>
</table>

<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_global_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_global_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_global_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_puntual_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_puntual_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_puntual_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_externo_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_externo_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_externo_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txt_ptoneg_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txt_ptoneg_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txt_ptoneg_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txt_ptomar_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txt_ptomar_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txt_ptomar_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txt_mancha_v"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txt_mancha_p"  FilterType="numbers, Custom" ValidChars="."  runat="server" />
<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txt_mancha_exp"  FilterType="numbers, Custom" ValidChars="."  runat="server" />


             </fieldset>
            
            <asp:Table ID="Table3" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
      <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30">
             <asp:Label ID="Label13" runat="server" Text="KILOS LOTE" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="6" runat="server" ID="KilosLote"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="KilosLote"  FilterType="numbers, Custom" ValidChars="."  runat="server" />

            </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label14" runat="server" Text="N° TOTES" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4" runat="server" ID="NTotes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="NTotes"  FilterType="numbers"   runat="server" />

            </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label15" runat="server" Text="% EXP" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="5" runat="server" ID="porc_exp"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
             
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="porc_exp"  FilterType="numbers, Custom" ValidChars="." runat="server" />
            
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30">
             </asp:TableCell></asp:TableRow></asp:Table>
             
               <asp:Table ID="Table5" runat="server" Width="700px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" HorizontalAlign="Center" >
   
   <asp:TableRow Width="162px">
   <asp:TableCell>
       <asp:Label ID="Label2" runat="server" Text="Label" Font-Names="Century Gothic" Font-Size="Small">Observaciones</asp:Label>
       </asp:TableCell> 
       </asp:TableRow>
       <asp:TableRow Width="162px">
       <asp:TableCell>
       <center><asp:TextBox ID="txt_obser" runat="server" Height="120" Width="690" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine"></asp:TextBox></center>
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
