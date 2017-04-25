Public Class WebForm6
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CargarAlPrincipio(sender As Object, e As EventArgs) Handles DropDownList1.DataBound

        mediaAlumnos(DropDownList1.SelectedItem.Text)

    End Sub
    Public Sub mediaAlumnos(cod As String)

        Dim func As New coordinador.coordinador
        Dim s = func.MediaAlumnos(cod)
        horas.Text = s

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        mediaAlumnos(DropDownList1.SelectedItem.Text)

    End Sub



End Class