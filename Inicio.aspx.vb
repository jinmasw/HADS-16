Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccesoBD.accesodatosSQL.conectar()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim c As String = correoBox.Text
        Dim p As String = passBox.Text
        Dim pEnc = encrypt(p)

        Dim cuantos = AccesoBD.accesodatosSQL.loginAlumno(c, pEnc)
        Dim cuantos2 = AccesoBD.accesodatosSQL.loginProfe(c, pEnc)
        'MsgBox(c)
        'MsgBox(passBox.Text)
        'MsgBox(cuantos)
        If (cuantos = 1) Then
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage("alumno", False)
            Session("username") = correoBox.Text
            Dim listaA As ListBox = Application("listaAlumnos")
            listaA.Items.Add(correoBox.Text)
            Application("listaAlumnos") = listaA
            Response.Redirect("alumnos/Alumno.aspx")
        ElseIf (cuantos2 = 1) Then
            If (correoBox.Text = "vadillo@ehu.es") Then
                Session("username") = correoBox.Text
                Dim listaP As ListBox = Application("listaProfes")
                listaP.Items.Add(correoBox.Text)
                Application("listaProfes") = listaP
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage("vadillo", False)
                Response.Redirect("profesores/Profesor.aspx")
            Else
                Session("username") = correoBox.Text
                Dim listaP As ListBox = Application("listaProfes")
                listaP.Items.Add(correoBox.Text)
                Application("listaProfes") = listaP
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage("profesor", False)
                Response.Redirect("profesores/Profesor.aspx")
            End If
        Else
            credencialesIncorrectas.Visible = True
            'MsgBox("Credenciales no validas, intentelo de nuevo")
        End If
    End Sub

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