<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownCC.aspx.cs" Inherits="Mainsite.MainApp.DropDownCC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Table runat="server" Width="100%" Height="30px">
    <asp:TableRow>
    <asp:TableCell>
     <asp:DropDownList ID="DropPlanta_d"  runat="server" DataSourceID="DropPlanta" DataTextField="pladescri" DataValueField="pladescri" Height="20px" Width="310px" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="planta_SelectedIndexChanged"></asp:DropDownList>
    </asp:TableCell>
        <asp:TableCell>
 <asp:hyperlink id="link_ing005" runat="server" NavigateUrl="~/AppFiles/CC_PAC_005_INGRESO.aspx" target="idframe" ><asp:Image id="img" runat="server" ImageUrl="~/Images/CCPAC005.png" Height="26px"></asp:Image></asp:hyperlink>
 <asp:hyperlink id="link_ing005_manual" runat="server" NavigateUrl="~/AppFiles/CC_PAC_005_INGRESO_MANUAL.aspx" target="idframe" ><asp:Image id="Image3" runat="server" ImageUrl="~/Images/CCPAC005.png"  Height="26px"></asp:Image></asp:hyperlink>
               
       
         </asp:TableCell>
              <asp:TableCell>
 <asp:hyperlink id="link_ing003" runat="server" NavigateUrl="~/AppFiles/CC_PAC_003_INGRESO.aspx" target="idframe"><asp:Image id="Image1" runat="server" ImageUrl="~/Images/CCPAC003.png"  Height="26px"></asp:Image></asp:hyperlink>
 <asp:hyperlink id="link_ing003_manual" runat="server" NavigateUrl="~/AppFiles/CC_PAC_003_INGRESO_MANUAL.aspx" target="idframe" ><asp:Image id="Image4" runat="server" ImageUrl="~/Images/CCPAC003.png"  Height="26px"></asp:Image></asp:hyperlink>
                    
       
         </asp:TableCell>
           <asp:TableCell>
 <asp:hyperlink id="link_ing075" runat="server" NavigateUrl="~/AppFiles/CC_PAC_075_INGRESO.aspx" target="idframe"><asp:Image id="Image2" runat="server" ImageUrl="~/Images/CCPAC075.png" Height="26px"></asp:Image></asp:hyperlink>
                     
       
         </asp:TableCell>
    </asp:TableRow>
    
    </asp:Table>
    

             </div>
    </form>
</body>
</html>
