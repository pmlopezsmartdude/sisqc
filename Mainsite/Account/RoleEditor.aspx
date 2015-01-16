<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEditor.aspx.cs" Inherits="Mainsite.Account.RoleEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/workarea.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="Tabcontainer1" runat="server" ActiveTabIndex="0" Font-Names="Century Gothic" Font-Size="Small" style="height:100%;">
    <asp:TabPanel runat="server" HeaderText="Editor de Roles" ID="Tabpanel1" Font-Names="Century Gothic" Font-Size="X-Small" style="width:100%;">
    <ContentTemplate>
    <asp:Button ID="AddButton" runat="server" Text="Agregar Rol" OnClick="AddButton_OnClick" style="font-family:Century Gothic; font-size:x-small;"/>
    <asp:Button ID="RemoveButton" runat="server" Text="Remover Rol" OnClick="RemoveButton_OnClick" style="font-family:Century Gothic; font-size:x-small;" />
        <table style="border-style: none; vertical-align:top; border-color: inherit; border-width: 10px; width:100%;">
            <tr style="width:100%;">
                <td style="width:30%; vertical-align:top; font-family:Century Gothic;">
                    <p><b><u>Roles actuales</u></b></p>
                    <div runat="server" id="RoleBox" />
                    <br />
                    <asp:Button ID="hiddenButton" runat="server" style="display:none;" />
                    <asp:ModalPopupExtender ID="AddButton_ModalPopupExtender" runat="server" 
                        TargetControlID="hiddenButton" PopupControlID="AddButPopUp" PopupDragHandleControlID="AddButPopUp">
                    </asp:ModalPopupExtender>
                    <asp:ModalPopupExtender ID="RemoveButton_ModalPopupExtender" runat="server" 
                        TargetControlID="hiddenButton" PopupControlID="RemoveButPopUp" PopupDragHandleControlID="RemoveButPopUp">
                    </asp:ModalPopupExtender>
                </td>
                <td style="width:70%">
                    <table style="border-style: none; border-color: inherit; border-width: 10px; width:100%;">
                        <tr style="width:100%;">
                            <td style="width:45%; font-family:Century Gothic;">
                                <p><b><u>Todos los usuarios existentes</u></b></p>
                                <asp:ListBox ID="AllUsersList" runat="server" Width="100%" Height="212px" 
                                    SelectionMode="Multiple" style="font-family:Century Gothic;"/>
                            </td>
                            <td style="width:20%; height:100%; margin:auto 0 auto 0; text-align:center; font-family:Century Gothic;">
                                <asp:Button runat="server" ID="leftButton" Text="<" Width="50%" OnClick="DeleteFromRole_OnClick"/>
                                <asp:Button runat="server" ID="rightButton" Text=">"  Width="50%" OnClick="MoveToRole_OnClick"/>
                            </td>
                            <td style="width:45%; font-family:Century Gothic;">
                                <p><b><u>Todos los usuarios en el Rol seleccionado</u></b></p>
                                <asp:ListBox ID="RoleUsersList" runat="server" Width="100%" Height="212px" 
                                    SelectionMode="Multiple" style="font-family:Century Gothic;"/>
                            </td>
                        </tr>
                    </table>
                    
                </td>  
            </tr>
        </table>
        

        
                        
    
    <div id="AddButPopUp" runat="server" style="width:284px; height:127px; text-align:center; background-color:White; border: 2px solid black; display:none;">
        <p><b><u>Ingrese nuevo Rol</u></b></p>
        <span>
            <asp:Label ID="Label1" runat="server" Text="Nombre Rol:" />
            <asp:TextBox runat="server" ID="RoleNameText" style="margin: 0 auto 0 10px; width:200px; font-family:Century Gothic;"/>
        </span>
        <br />
        <br />
        <span>
            <asp:Button ID="AddOkBut" runat="server" Text="Ok" Width="50px" OnClick="AddRole_OnClick" style="font-family:Century Gothic; font-size:x-small;"/>
            <asp:Button ID="AddCancelBut" runat="server" Text="Cancelar" Width="60px" style="margin:0 auto 0 10px; font-family:Century Gothic; font-size:x-small;" />
        </span>
    </div>

    <div id="RemoveButPopUp" runat="server" 
            style="width:181px; background-color:White; border: 2px solid black; text-align:center; display:none;">
        <p><b><u>Remover Role</u></b></p>
        <div id="Div1" runat="server">
            <p> Esta seguro de remover este Rol?</p>
        </div>
        <br />
        <div style="width:131px; margin: 0 auto 0 auto">
            <asp:Button ID="Button1" runat="server" Text="Ok" Width="50px" OnClick="RemoveRole_OnClick" style="font-family:Century Gothic; font-size:x-small;"/>
            <asp:Button ID="Button2" runat="server" Text="Cancelar" Width="60px" style="margin:0 auto 0 10px; font-family:Century Gothic; font-size:x-small;" />
        </div>
    </div>
    </ContentTemplate>
    </asp:TabPanel>
    </asp:TabContainer>
    </form>
</body>
</html>
