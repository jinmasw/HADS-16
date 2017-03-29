<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="proyecto_HADS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="usuarioBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        Tareas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tareaBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        Horas Est.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="horasEstBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        Horas Reales&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="horasRealesBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="horasRealesBox" ErrorMessage="El campo no puede estar vacío"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <br />
          
          <asp:Button ID="b1" runat="server" Text="Crear Tarea" />
          
          <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="gv1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
