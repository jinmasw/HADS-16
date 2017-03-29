<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareas.aspx.vb" Inherits="proyecto_HADS.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div>
    
        <asp:DropDownList ID="dd1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    
        <br />
        <asp:GridView ID="gv1" runat="server">
        </asp:GridView>
    
    </div>
        <asp:Button ID="importarBTN" runat="server" Text="Exportar" />
    
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
