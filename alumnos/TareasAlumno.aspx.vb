Imports System.Data.SqlClient

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        llenar_ddlist()
        If Not Page.IsPostBack Then
            rellenarGridView()
        End If
    End Sub


    Private Sub llenar_ddlist()
        Dim conString As SqlConnection
        Dim dapAsignaturas As SqlDataAdapter
        Dim dstAsignaturas As DataSet

        If Page.IsPostBack Then
            dstAsignaturas = Session("datosddl")
        Else
            conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
            dapAsignaturas = New SqlDataAdapter("Select Asignaturas.codigo FROM ((Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig) INNER JOIN EstudiantesGrupo ON GruposClase.codigo=EstudiantesGrupo.grupo) INNER JOIN Usuarios ON EstudiantesGrupo.Email=Usuarios.email WHERE Usuarios.email='" & Session("username") & "'", conString)
            dstAsignaturas = New DataSet()
            dapAsignaturas.Fill(dstAsignaturas, "Asignaturas") 'Se carga la tabla Asignaturas en una Datable de un DataSet
            dd1.DataSource = dstAsignaturas.Tables("Asignaturas") 'Se enlaza la DataTable con el DataGrid
            dd1.DataValueField = "codigo"
            dd1.DataBind()
            Session("datosddl") = dstAsignaturas
            Session("adaptadorddl") = dapAsignaturas
        End If
    End Sub

    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd1.SelectedIndexChanged

        rellenarGridView()

    End Sub

    Protected Sub rellenarGridView()
        Dim conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
        Dim dapTareas As New SqlDataAdapter
        Dim dstTareas As New DataSet
        Dim tblTareas As New DataTable

        dapTareas = New SqlDataAdapter("Select * FROM TareasGenericas where Explotacion=1 and CodAsig='" & dd1.SelectedValue & "' and Codigo not in (SELECT CodTarea FROM EstudiantesTareas WHERE Email='" & Session("username") & "')", conString)
        Dim bldMbrs As New SqlCommandBuilder(dapTareas)
        dapTareas.Fill(dstTareas, "TareasGenericas")
        tblTareas = dstTareas.Tables("TareasGenericas")
        gv1.DataSource = tblTareas
        gv1.DataBind()

    End Sub

    Protected Sub gv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gv1.SelectedIndexChanged

        Session("TareaI") = gv1.SelectedRow.Cells(1).Text
        Session("HEstimadas") = gv1.SelectedRow.Cells(4).Text
        Response.Redirect("InstanciarTarea.aspx")
    End Sub
End Class