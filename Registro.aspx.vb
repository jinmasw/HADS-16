Imports System.Net.Mail
Imports System.Security.Cryptography


Public Class WebForm11
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccesoBD.accesodatosSQL.cerrarconexion()
        Dim result As String
        result = AccesoBD.accesodatosSQL.conectar()
        'MsgBox(result)
    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.accesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub RegistrarButton_Click(sender As Object, e As EventArgs) Handles RegistrarButton.Click
        Dim NumConf = CLng(Rnd() * 9000000) + 1000000
        Dim pass = PasswordBox.Text
        Dim passEnc = encrypt(pass)
        'MsgBox(passEnc)
        Dim k = AccesoBD.accesodatosSQL.insertar("Usuarios", "email,nombre,pregunta,respuesta,dni,confirmado,pass", "'" & CorreoBox.Text & "', '" & NombreBox.Text & "', '" & PreguntaBox.Text & "', '" & RespuestaBox.Text & "', '" & DNIBox.Text & "', 0, '" & passEnc & "'")
        'MsgBox(k)
        enviarEmail(NumConf)
        Response.Redirect("Inicio.aspx")
    End Sub

    Public Function enviarEmail(n As Integer) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("jinmasw@gmail.com", "Jinma")
            'Direccion de destino
            Dim s As String
            s = CorreoBox.Text
            Dim to_address As New MailAddress(s)
            'Password de la cuenta
            Dim from_pass As String = "ratagorda"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.gmail.com"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Registro en la aplicacion"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" & "Haga click aqui para completar su registro: http://localhost:54250/Confirmar.aspx?mbr=" & s & "&numconf=" & n & "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos    
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)

        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function encrypt(p As String) As String

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(p)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function



End Class