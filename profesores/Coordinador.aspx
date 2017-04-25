<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinador.aspx.vb" Inherits="proyecto_HADS.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS16ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="horas" runat="server" Text="Label"></asp:Label>
                &nbsp;<asp:Label ID="horasText" runat="server" Text="horas"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
