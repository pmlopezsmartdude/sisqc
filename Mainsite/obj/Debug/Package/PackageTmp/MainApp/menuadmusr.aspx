<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuadmusr.aspx.cs" Inherits="Mainsite.MainApp.menuadmusr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeViewAdmUsr" runat="server" Font-Names="Century Gothic" 
            Font-Size="X-Small" ShowLines="True" LineImagesFolder="~/TreeLineImages" Visible="True">
            <Nodes>
                <asp:TreeNode SelectAction="Expand" Text="Administración de usuarios" 
                    Value="Administracion de usuarios" Expanded="False">
                    <asp:TreeNode Text="Crear usuario" Value="Crear usuario"
                    Target="workingarea" NavigateUrl="~/Account/CreateUser.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="Administrar Usuarios" Value="Administrar Usuarios" 
                        Target="workingarea" NavigateUrl="~/Account/ManageUsers.aspx"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Administración de Roles" Value="Administración de Roles"
                        Target="workingarea" NavigateUrl="~/Account/RoleEditor.aspx">
                </asp:TreeNode>
 <%--               <asp:TreeNode SelectAction="Expand" Text="Administración Sistema"
                    Value="Administracion Sistema" Expanded="False">
                    <asp:TreeNode Text="Administrar Impresoras" Value="Administrar Impresoras"
                    Target="workingarea" NavigateUrl="~/Admsistema/impresoras.aspx" />
                    <asp:TreeNode Text="Ingresar Nuevo Trabajador" Value="Ingresar Nuevo"
                    Target="workingarea" NavigateUrl="~/Admsistema/IngresoEmpleados.aspx"></asp:TreeNode>
                    
                </asp:TreeNode>--%>
            </Nodes>
        </asp:TreeView>
        <asp:TreeView ID="TreeViewAppsJefatura" runat="server" Font-Names="Century Gothic"
            Font-Size="X-Small" ShowLines="true" LineImagesFolder="~/TreeLineImages" Visible="true">
            <Nodes>
            <asp:TreeNode SelectAction="Expand" Text="Menu Principal Aplicaciones"
                Value="Menu Principal Aplicaciones" Expanded="False">
                <asp:TreeNode Text="Control Calidad" Value="Control Calidad Cerezas" 
                    Expanded="False" SelectAction="Expand">
                    <asp:TreeNode NavigateUrl="~/MainApp/SisConPT.aspx" Target="workingarea" 
                        Text="Cerezas" Value="Cerezas"></asp:TreeNode>
                </asp:TreeNode>
               <%-- <asp:TreeNode Text="Informes" Value="Aplicación 2" Expanded="False" 
                    SelectAction="Expand">
                  

                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="Control Calidad" 
                        Value="Control Calidad">
                        <asp:TreeNode Target="workingarea" Text="Cerezas" Value="Cerezas" 
                            NavigateUrl="~/MainApp/InformesCereza.aspx">
                        </asp:TreeNode>--%>
                    </asp:TreeNode>
               
            </Nodes>
            </asp:TreeView>
           
           
           
           
            <asp:TreeView ID="TreeViewPruebas" runat="server" Font-Names="Century Gothic"
            Font-Size="X-Small" ShowLines="true" LineImagesFolder="~/TreeLineImages" Visible="true">
            <Nodes>
            <asp:TreeNode SelectAction="Expand" Text="Menu Principal Aplicaciones"
                Value="Menu Principal Aplicaciones" Expanded="False">
                <asp:TreeNode Text="Control Calidad" Value="Control Calidad Cerezas" 
                    Expanded="False" SelectAction="Expand">
                    <asp:TreeNode NavigateUrl="~/MainApp/SisConPT.aspx" Target="workingarea" 
                        Text="Cerezas" Value="Cerezas"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Informes" Value="Aplicación 2" Expanded="False" 
                    SelectAction="Expand">
                  

                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="Control Calidad" 
                        Value="Control Calidad">
                        <asp:TreeNode Target="workingarea" Text="Cerezas" Value="Cerezas" 
                            NavigateUrl="~/MainApp/InformesCereza.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            </asp:TreeView>


                    <asp:TreeView ID="TreeView1" runat="server" Font-Names="Century Gothic"
            Font-Size="X-Small" ShowLines="true" LineImagesFolder="~/TreeLineImages" Visible="true">
            <Nodes>
            <asp:TreeNode SelectAction="Expand" Text="Menu Principal Aplicaciones"
                Value="Menu Principal Aplicaciones" Expanded="False">
                <asp:TreeNode Text="Control Calidad" Value="Control Calidad Cerezas" 
                    Expanded="False" SelectAction="Expand">
                    <asp:TreeNode NavigateUrl="~/MainApp/SisConPT.aspx" Target="workingarea" 
                        Text="Cerezas" Value="Cerezas"></asp:TreeNode>
                </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            </asp:TreeView>
    </div>
    </form>
</body>
</html>
