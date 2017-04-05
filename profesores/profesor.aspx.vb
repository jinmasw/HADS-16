Public Class profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        lalumnos.Items.Clear()
        lprofes.Items.Clear()

        Dim listaA As ListBox = Application("listaAlumnos")
        Dim listaP As ListBox = Application("listaProfes")

        For Each alumno In listaA.Items
            lalumnos.Items.Add(alumno)
        Next
        LabelAlumnos.Text = lalumnos.Items.Count

        For Each profe In listaP.Items
            lprofes.Items.Add(profe)
        Next
        LabelProfes.Text = lprofes.Items.Count
    End Sub


    Protected Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click

        Dim listaP As ListBox = Application("listaProfes")
        listaP.Items.Remove(Session("username"))
        Application("listaProfes") = listaP
        Session.Abandon()
        Response.Redirect("../Inicio.aspx")

    End Sub
End Class