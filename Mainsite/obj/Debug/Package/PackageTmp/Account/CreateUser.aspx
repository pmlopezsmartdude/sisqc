<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Mainsite.Account.CreateUser" %>
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
    <asp:TabPanel runat="server" HeaderText="Crear Usuario" ID="Tabpanel1" Font-Names="Century Gothic" Font-Size="X-Small">
    <ContentTemplate>
    <table style="border-style: none; border-color: inherit; border-width: 10px; width:100%;">
        <tr style="width:100%;">
            <td class="style1">
                <p><b>Crear nuevo usuario</b></p>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <p><b>Información de Usuario</b></p>
                 <span>
                    <asp:Label ID="label" runat="server" Text="Nombre:" style="width:100px;" />
                    <asp:TextBox runat="server" id="NameText" ValidationGroup="UserGroup" 
                    style="margin-left: 110px; width:250px; font-family:Century Gothic;" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="NameText" ValidationGroup="UserGroup" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Campo es requerido." />
                </span>
                <br />
                <br />
                <span>
                    <asp:Label ID="Label1" runat="server" Text="Nombre Usuario:" style="width:100px;"/>
                    <asp:TextBox runat="server" id="UserNameText" ValidationGroup="UserGroup" style="margin-left: 74px; width:250px; font-family:Century Gothic;" />
                    <asp:RequiredFieldValidator ID="UserNameReq" ControlToValidate="UserNameText" ValidationGroup="UserGroup" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Campo es requerido." />
                </span>
                <br />
                <br />
                <span>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:" style="width:100px;"/>
                    <asp:TextBox runat="server" id="PassText" 
                    style="margin-left: 94px; width:250px;" TextMode="Password" ValidationGroup="UserGroup" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="UserGroup" ControlToValidate="PassText" runat="server" Display="Dynamic" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Campo es requerido." />
                    <asp:CompareValidator ID="ComparePasswordsValidator" ValidationGroup="UserGroup" runat="server" ErrorMessage="Contraseña no coincide!" Display="Dynamic" style="color:red;" ControlToValidate="PassText" ControlToCompare="PassConfirmText" />
                </span>
                <br />
                <br />
                <span>
                    <asp:Label ID="Label3" runat="server" Text="Confirmar Contraseña:" style="width:100px;"/>
                    <asp:TextBox runat="server" id="PassConfirmText" 
                    style="margin-left: 42px; width:250px;" TextMode="Password" ValidationGroup="UserGroup" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="UserGroup" ControlToValidate="PassConfirmText" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Campo es requerido." />
                    <asp:CompareValidator ID="CompareValidator1" ValidationGroup="UserGroup" runat="server" ErrorMessage="Contraseña no coincide!" Display="Dynamic" style="color:red;" ControlToValidate="PassConfirmText" ControlToCompare="PassText" />
                </span>
                <br />
                <br />
                <span>
                    <asp:Label ID="Label4" runat="server" Text="E-mail:" style="width:100px;" />
                    <asp:TextBox runat="server" ValidationGroup="UserGroup" id="EmailText" style="margin-left: 122px; width:250px; font-family:Century Gothic;" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="UserGroup" ControlToValidate="EmailText" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Campo es requerido." />
                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" ValidationGroup="UserGroup" runat="server" ControlToValidate="EmailText" style="color:red;margin: 0 auto 0 10px;" Display="Dynamic" ErrorMessage="Email no válido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
                </span>
                <br />
                <asp:CheckBox ID="ActiveUser" runat="server" Text="Usuario Activo" style="margin:0 auto 0 145px" Checked="true" />
            </td>
            <td style="width:50%; vertical-align:top">
                <p><b>Asignar a Roles</b></p>
                <div id="CheckBoxRoles" runat="server">
                </div>
            </td>
        </tr>
    </table>
        <div id="buttonBank" style="width:152px; margin: 0 auto 0 232px;">
         <asp:Button runat="server" ID="CreateButton" Text="Crear" ValidationGroup="UserGroup" OnClick="CreateButton_OnClick" style="font-family:Century Gothic;" /> 
         <asp:ModalPopupExtender ID="CreateButton_ModalPopupExtender" runat="server" 
             TargetControlID="hiddenButton" PopupControlID="MyPopUp" PopupDragHandleControlID="MyPopUp">
         </asp:ModalPopupExtender>
         <asp:Button runat="server" ID="CancelButton" Text="Cancelar" OnClick="CancelButton_OnClick" style="margin-left: 7px; font-family:Century Gothic;" />
    </div>

    <div id="MyPopUp" runat="server" 
        style="width:300px; height:100px; background-color: White; border: 2px solid black; display:none;">
        <div style=" text-align:center;">
            <p><b>Tarea creación de usuario</b></p>
        </div>
        <div id="PopUpText" runat="server" style="text-align:center;">
        </div>
        <div style="width:50px; margin:0 auto 0 auto;">
            <asp:Button ID="PopUpOkButton" runat="server" Text="Ok" Width="50px" style="font-family:Century Gothic;"/>
        </div>
    </div>
    <asp:Button ID="hiddenButton" runat="server" style="display:none;"/>
    </ContentTemplate>
    </asp:TabPanel>
    </asp:TabContainer>
  

    </form>
</body>
</html>
