<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareas.aspx.vb" Inherits="proyecto_HADS.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="dd1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    
    </div>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <asp:Button ID="importarBTN" runat="server" Text="Importar" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
