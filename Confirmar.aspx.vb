Imports System.Net.Mail

Public Class WebForm44
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim result As String
        result = AccesoBD.accesodatosSQL.conectar()

        Dim num As Integer = Convert.ToInt32(Request.QueryString("numconf"))
        MsgBox(num)
        Dim correo As String = Convert.ToString(Request.QueryString("mbr"))
        MsgBox(correo)


        If (comprobarRegistro(num, correo) = False) Then
            MsgBox("Ha ocurrido un problema al registrarse")
        End If

    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        AccesoBD.accesodatosSQL.cerrarconexion()

    End Sub

    Public Function comprobarRegistro(n As Integer, c As String) As Boolean

        If (AccesoBD.accesodatosSQL.numTuplas("Usuarios", "email='" & c & "' and numconfir='" & n & "'") = 1) Then
            AccesoBD.accesodatosSQL.actualizar("Usuarios", "confirmado='True'", "email='" & c & "'")
            Return True
        End If

        Return False

    End Function

End Class