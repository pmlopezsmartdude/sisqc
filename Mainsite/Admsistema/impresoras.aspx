<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="impresoras.aspx.cs" Inherits="Mainsite.Admsistema.impresoras" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/workarea.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/jquery-1.4.2.min.js" type="text/javascript" />
    <script src="~/Scripts/jquery.metadata.js" type="text/javascript" />
    <script src="~/Scripts/jquery.dataTables.min.js" type="text/javascript" />
    <script type="text/javascript">
    $(document).ready(function ()
    {
    // Setup Metadata plugin
    $.metadata.setType("class");
    // Setup GridView
    $("table.grid").each(function () {
        var jTbl = $(this);
        if (jTbl.find("tbody>tr>th").length > 0) {
            jTbl.find("tbody").before("<thead><tr></tr></thead>");
            jTbl.find("thead:first tr").append(jTbl.find("th"));
            jTbl.find("tbody tr:first").remove();
        }
    // If GridView has the 'sortable' class and has more than 10 rows
    if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 10) {
        // Run DataTable on the GridView
        jTbl.dataTable({
            sPaginationType: "full_numbers",
            sDom: '<"top"lf>rt<"bottom"ip>',
            oLanguage: {
               sInfoFiltered: "(from _MAX_ entries)",
               sSearch: ""
            },
            aoColumnDefs: [
                { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
            ]
        });
      }
    });
    }); 
     </script>
     <script type="text/javascript">
         function enhancedGridView() {
             // Setup Metadata plugin
             $.metadata.setType("class");
             // Setup GridView
             $("table.grid").each(function () {
                 var jTbl = $(this);
                 if (jTbl.find("tbody>tr>th").length > 0) {
                     jTbl.find("tbody").before("<thead><tr></tr></thead>");
                     jTbl.find("thead:first tr").append(jTbl.find("th"));
                     jTbl.find("tbody tr:first").remove();
                 }
                 // If GridView has the 'sortable' class and has more than 10 rows
                 if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 10) {
                     // Run DataTable on the GridView
                     jTbl.dataTable({
                         sPaginationType: "full_numbers",
                         sDom: '<"top"lf>rt<"bottom"ip>',
                         oLanguage: {
                             sInfoFiltered: "(from _MAX_ entries)",
                             sSearch: ""
                         },
                         aoColumnDefs: [
                { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
            ]
                     });
                 }
             });
         }
    
     </script>
</head>
<body onload="enhancedGridView">
<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
</asp:ToolkitScriptManager>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:trazabilidadConnectionString1 %>"
    
    SelectCommand="SELECT [nombre], [marca], [IPDottedNotation], [puerto] FROM [vistaImpresoras]">
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:trazabilidadConnectionString1 %>"

    SelectCommand="SELECT [marca] FROM [impresorasmarca]">
    </asp:SqlDataSource>
<asp:ObjectDataSource ID="impresorasDataSource" runat="server" SelectMethod="obtenerImpresoras" TypeName="Mainsite.AccesoDatos" />
<asp:TabContainer ID="Tabcontainer1" runat="server" ActiveTabIndex="0" Font-Names="Century Gothic" Font-Size="Small" style="height:100%;">
<asp:TabPanel runat="server" HeaderText="Impresoras Sistema" ID="Tabpanel1" Enabled="true" Font-Names="Century Gothic" Font-Size="X-Small" style="width:100%;">
<ContentTemplate>
<asp:Table ID="impresorastbl" runat="server"
        style="display:block; width:100%; border:none; margin:5; padding:10; height:100%;"
        Height="430px" Font-Names="Century Gothic" Font-Size="X-Small"
        BackColor="White">
<asp:TableRow style="width:100%;" runat="server" BackColor="White">
<asp:TableCell style="width:100%;" runat="server" BackColor="White">
<asp:GridView ID="impresorasGrid" 
        runat="server"  AutoGenerateColumns="False"  AllowPaging="true"
        CssClass="grid sortable {disableSortCols: [1]}" BackColor="White" style="width:100%; font-family:Century Gothic; font-size:x-small; padding-right:5; padding-left:5;" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="impresorasgrid_indexchanged">
                <pagersettings mode="NumericFirstLast"
            firstpagetext="Primero"
            lastpagetext="Ultimo"
            nextpagetext="Siguiente"
            previouspagetext="Anterior"
            pagebuttoncount="10"
          position="Bottom"           
          />
                  <pagerstyle backcolor="#CCCCCC"
          height="20px"
          verticalalign="Bottom"
          horizontalalign="Center"/><Columns>
<asp:CommandField ShowSelectButton="True" ButtonType="Button" >
<ControlStyle CssClass="btnstyle" />

<ItemStyle CssClass="btnstyle" />
</asp:CommandField>
<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
<asp:BoundField DataField="Marca" HeaderText="Marca"  />
<asp:BoundField DataField="IPDottedNotation" HeaderText="Ip" />
<asp:BoundField DataField="puerto" HeaderText="Puerto" />
</Columns>
</asp:GridView>
</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
</fieldset>                
            </ContentTemplate>
</asp:TabPanel>
<asp:TabPanel runat="server" HeaderText="Agregar Impresora" ID="Tabpanel2" Enabled="true" Font-Names="Century Gothic" Font-Size="X-Small" style="width:100%;">
<ContentTemplate>
<asp:Table ID="Table2" runat="server"
        style="display:block; width:100%; border:none; margin:5; padding:10; height:100%;"
        Height="430px" Font-Names="Century Gothic" Font-Size="X-Small"
        BackColor="White">
<asp:TableRow ID="TableRow3" style="width:100%;" runat="server" BackColor="White">
<asp:TableCell></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="NuevoNombreImp" Height="20">Nombre Impresora</asp:Label></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl20" Height="20">:</asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox runat="server" ID="txtnomimpr" Width="80" Height="20" Font-Names="Century Gothic" Font-Size="X-Small" MaxLength="20"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server"
ControlToValidate="txtnomimpr"
ErrorMessage="Por favor ingrese un nombre Válido" ForeColor="Red"
ValidationExpression="^[A-Z0-9 a-z]*$" /></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="MarcaImp" Height="20">Marca</asp:Label></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl21" Height="20">:</asp:Label></asp:TableCell>
<asp:TableCell><asp:DropDownList runat="server" ID="nuevamarca" Height="20" Font-Names="Century Gothic" Font-Size="X-Small" DataSourceID="SqlDataSource2" DataTextField="marca" DataValueField="marca"></asp:DropDownList></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl22" Height="20">Ip</asp:Label></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl23" Height="20">:</asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox runat="server" ID="newimpip" Height="20" Font-Names="Century Gothic" Font-Size="X-Small" Width="80"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
ControlToValidate="newimpip"
ErrorMessage="Por favor ingrese una Dirección IP válida" ForeColor="Red"
ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$" /></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl24" Height="20">Puerto</asp:Label></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lbl25" Height="20">:</asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox runat="server" ID="newimpport" Height="20" Font-Names="Century Gothic" Font-Size="X-Small" Text="9100" MaxLength="4" Width="40"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
ControlToValidate="newimpport"
ErrorMEssage="Por favor ingrese un puerto válido" ForeColor="Red"
ValidationExpression="^[0-9]*$" />
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell><asp:Button ID="btngrabar" runat="server" Text="Agregar" Font-Size="X-Small" Font-Names="Century Gothic" onclick="btnagregar" /></asp:TableCell>
<asp:TableCell><asp:Button ID="btnlimpiar" runat="server" Text="Limpiar" Font-Size="X-Small" Font-Names="Century Gothic" onclick="limpiaagrimp"  /></asp:TableCell>
</asp:TableRow>
</asp:Table>
</ContentTemplate>
</asp:TabPanel>
</asp:TabContainer>

<asp:ModalPopupExtender ID="impEditOrder" runat="server"
        DynamicServicePath="" TargetControlID="hideButton" Enabled="true" PopupControlID="divPopUp"  PopupDragHandleControlID="panelDragHandle"></asp:ModalPopupExtender>
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" 
        DynamicServicePath="" TargetControlID="hideButton" Enabled="true" PopupControlID="divConfirmDelete" PopupDragHandleControlID="panelDragHandle"></asp:ModalPopupExtender>
 <div id="hiddenButton" style="display:none;">
        <asp:Button id="hideButton" runat="server" />

</div>
        <div id="divConfirmDelete" style="display:none; background-color:White; width:400px; height:94px; text-align:center; border: 2px solid black; font-size:small;" >
        <p> Esta seguro que desea eliminar esta impresora?</p>
            <div style="width:250px; margin: auto auto auto auto; display:inline">
            <asp:Button runat="server" Text="Confirmar" ID="ConfirmDelete" 
            OnClick="DeleteImpresora" Width="80px" style="margin-left: 34px; font-family:Century Gothic; font-size:x-small;" CssClass="style1" />

            <asp:Button runat="server" Width="80px" id="CancelDelete" Text="Cancelar" 
            style="margin-left: 11px; font-family:Century Gothic; font-size:x-small;"  CssClass="style1" />

        </div>
    </div>
   
<asp:Panel ID="divPopUp" runat="server" BackColor="White" BorderStyle="Double" ScrollBars="Auto" Width="60%" Height="95%">

<div id="popupcontainer" style="width:99%; height: 101px;">
<fieldset>
<legend>Editar Impresora</legend>
<asp:Table ID="Tableimp" runat="server" style="width:100%;"  Height="90px" 
        Font-Names="Century Gothic" Font-Size="X-Small">
<asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
<asp:TableCell>
<asp:Label ID="Label1" runat="server" Height="20">Impresora</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label2" runat="server" Height="20">:</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label_nimp" runat="server" Height="20"></asp:Label>
</asp:TableCell>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>

</asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
<asp:TableCell>
<asp:Label ID="Label3" runat="server" Height="20">Marca</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label4" runat="server" Height="20">:</asp:Label>
</asp:TableCell>
<asp:TableCell>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="20" Font-Names="Century Gothic" Font-Size="X-Small" DataSourceID="SqlDataSource2" DataTextField="marca" DataValueField="marca" Visible="false">
    </asp:DropDownList>
    <asp:Label ID="lbl_marca" runat="server" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label>
    <%--<asp:TextBox runat="server" ID="txt_marca" Width="60" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>--%>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label5" runat="server" Height="20">Ip</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label6" runat="server" Height="20">:</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="txt_ip" Width="80" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
<asp:RegularExpressionValidator ID="vldRejex" runat="server"
ControlToValidate="txt_ip"
ErrorMessage="Por favor ingrese una Dirección IP válida" ForeColor="Red"
ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$" />
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label7" runat="server" Height="20">Puerto</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Label8" runat="server" Height="20">:</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Lbl_puerto" runat="server" Height="20" Font-Names="Century Gothic" Font-Size="X-Small"></asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>

</asp:TableCell>
<asp:TableCell>
<asp:Button ID="Guardar" runat="server" Font-Names="Century Gothic" Font-Size="X-Small" Text="Guardar" onclick="btnGuardar" Visible="false"/>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="Cancelar" runat="server" Font-Names="Century Gothic" Font-Size="X-Small" Text="Cancelar" onclick="btnClose_Click" CausesValidation="false"/>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="Eliminar" runat="server" Font-Names="Century Gothic" Font-Size="X-Small" Text="Eliminar" onclick="AskMessage"/>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="Prueba" runat="server" Font-Names="Century Gothic" Font-Size="X-Small" Text="Prueba" OnClick="pruebaimp" />
</asp:TableCell>
</asp:TableRow>
 </asp:Table>
</fieldset>
</div>
</asp:Panel>
    </form>
</body>
</html>
