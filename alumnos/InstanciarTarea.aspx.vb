Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usuarioBox.Text = Session("username")
        tareaBox.Text = Session("TareaI")
        horasEstBox.Text = Session("HEstimadas")
        If Not Page.IsPostBack Then
            rellenarGridView()
        End If
    End Sub


    Protected Sub rellenarGridView()
        Dim conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
        Dim dapTareas As New SqlDataAdapter
        Dim dstTareas As New DataSet
        Dim tblTareas As New DataTable


        dapTareas = New SqlDataAdapter("Select * FROM EstudiantesTareas where email='" & Session("username") & "'", conString)
        Dim bldMbrs As New SqlCommandBuilder(dapTareas)
        dapTareas.Fill(dstTareas, "EstudiantesTareas")
        tblTareas = dstTareas.Tables("EstudiantesTareas")
        Session("Tabla") = tblTareas
        gv1.DataSource = tblTareas
        gv1.DataBind()
        Session("set") = dstTareas
        Session("adapter") = dapTareas

    End Sub

    Protected Sub anadirTarea()
        Dim conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
        Dim dapTareas = Session("adapter")
        Dim dstTareas = Session("set")
        Dim tabla As New DataTable

        tabla = Session("Tabla")
        Dim row As DataRow = tabla.NewRow()
        row("Email") = usuarioBox.Text
        row("CodTarea") = tareaBox.Text
        row("HEstimadas") = horasEstBox.Text
        row("HReales") = horasRealesBox.Text
        tabla.Rows.Add(row)
        gv1.DataSource = tabla
        gv1.DataBind()

        dapTareas.Update(dstTareas, "EstudiantesTareas")
        dstTareas.AcceptChanges()



    End Sub



    Protected Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        anadirTarea()
    End Sub
End Class