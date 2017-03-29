Public Class WebForm33
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NuevaBox0.Visible = True
        NuevaBox1.Visible = True
        Button2.Visible = True
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Page.IsValid Then
            Label1.Visible = True

        Else
            Label1.Visible = False
        End If


    End Sub
End Class