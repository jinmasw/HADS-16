<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profesor.aspx.vb" Inherits="proyecto_HADS.profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ImportarTareas.aspx">Importar Tareas</asp:HyperLink>
    
        <br />
        
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ExportarTareas.aspx">Exportar Tareas</asp:HyperLink>
    </div>
    </form>
</body>
</html>
