<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profesor.aspx.vb" Inherits="proyecto_HADS.profesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="Logout" runat="server">Logout</asp:LinkButton>
        <br />
        <br />
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ImportarTareas.aspx">Importar Tareas</asp:HyperLink>
    
        <br />
        
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ExportarTareas.aspx">Exportar Tareas</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/profesores/Coordinador.aspx" Visible="False">Medias de dedicación</asp:HyperLink>
    </div>

        <br />
      
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="3000">
                </asp:Timer>
                <br />
                Número de profesores conectados:&nbsp;
                <asp:Label ID="LabelProfes" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:ListBox ID="lprofes" runat="server"></asp:ListBox>
                <ajaxToolkit:DragPanelExtender ID="lprofes_DragPanelExtender0" runat="server" TargetControlID="lprofes" />
                <br />
                <br />
                <br />
                <br />
                <br />
                Número de alumnos conectados:&nbsp;
                <asp:Label ID="LabelAlumnos" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:ListBox ID="lalumnos" runat="server"></asp:ListBox>
                <ajaxToolkit:DragPanelExtender ID="lalumnos_DragPanelExtender0" runat="server" TargetControlID="lalumnos" />
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
          
    </div>
    
    <div>
    </div>
          
        <br />

    </form>
</body>
</html>
