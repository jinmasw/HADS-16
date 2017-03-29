<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="proyecto_HADS.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="height: 133px">
            Correo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="correoBox" runat="server" ViewStateMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="correoBox" ErrorMessage="Introduzca el usuario"></asp:RequiredFieldValidator>
            <br />
            <br />
            Password&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passBox" runat="server" TextMode="Password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="passBox" ErrorMessage="Introduzca la contraseña"></asp:RequiredFieldValidator>

            <br />

            <br />

            <asp:Label ID="credencialesIncorrectas" runat="server" Text="Credenciales incorrectas, intentelo de nuevo" Visible="False"></asp:Label>

        </div>
          
          <asp:Button ID="Button1" runat="server" Text="Loguearse" />
          
          <br />
        <br />
        <br />
                   
    <div>
        <a href="CambiarContrasena.aspx">Cambiar Contraseña</a>
        <a href="Registro.aspx">Registro</a>
        <br />
        <br />
          
    </div>
          
          </form>
                   
    </body>
</html>
