Imports System.Data.SqlClient
Imports System.Xml

Public Class WebForm2

    Inherits System.Web.UI.Page

    Dim docxml As New XmlDocument


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        llenar_ddlist()
        mostrarEnTabla()

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd1.SelectedIndexChanged
        mostrarEnTabla()
    End Sub

    Private Sub llenar_ddlist()
        Dim conString As SqlConnection
        Dim dapAsignaturas As SqlDataAdapter
        Dim dstAsignaturas As DataSet

        If Page.IsPostBack Then
            dstAsignaturas = Session("datosddl")
        Else
            conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
            dapAsignaturas = New SqlDataAdapter("Select distinct GruposClase.codigoasig from GruposClase inner join ProfesoresGrupo on codigogrupo=codigo where ProfesoresGrupo.email='" & Session("username") & "'", conString)
            dstAsignaturas = New DataSet()
            dapAsignaturas.Fill(dstAsignaturas, "Asignaturas") 'Se carga la tabla Asignaturas en una Datable de un DataSet
            dd1.DataSource = dstAsignaturas.Tables("Asignaturas") 'Se enlaza la DataTable con el DataGrid
            dd1.DataValueField = "codigoasig"
            dd1.DataBind()
            Session("datosddl") = dstAsignaturas
            Session("adaptadorddl") = dapAsignaturas
        End If
    End Sub


    Private Sub cargarDocumento()
        docxml.Load(Server.MapPath("APP_DATA\" & dd1.SelectedValue & ".xml"))
    End Sub

    Private Sub mostrarEnTabla()

        Xml1.DocumentSource = Server.MapPath("APP_DATA/" & dd1.SelectedValue & ".xml")
        Xml1.TransformSource = Server.MapPath("APP_DATA/XSLTFile.xsl")

    End Sub

    Private Sub importar()
        cargarDocumento()
        Dim conString As SqlConnection
        Dim dapAsignaturas As SqlDataAdapter
        Dim dstAsignaturas As DataSet
        Dim repetidas = False
        conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
        dapAsignaturas = New SqlDataAdapter("Select * from TareasGenericas", conString)
        dstAsignaturas = New DataSet()
        dapAsignaturas.Fill(dstAsignaturas, "Tareas")
        Dim tabla = dstAsignaturas.Tables("Tareas")

        tabla.Columns("Codigo").Unique = True

        Dim bldAsignaturas As New SqlCommandBuilder(dapAsignaturas)

        Dim listaTarea As XmlNodeList
        listaTarea = docxml.SelectNodes("/tareas/tarea")

        Dim codigoNode As XmlNodeList = docxml.SelectNodes("/tareas/tarea/codigo")
        Dim descripcionNode As XmlNodeList = docxml.SelectNodes("/tareas/tarea/descripcion")
        Dim hEstimadasNode As XmlNodeList = docxml.SelectNodes("/tareas/tarea/hestimadas")
        Dim explotacionNode As XmlNodeList = docxml.SelectNodes("/tareas/tarea/explotacion")
        Dim tipoTareaNode As XmlNodeList = docxml.SelectNodes("/tareas/tarea/tipotarea")

        Dim i As Integer
        For i = 0 To listaTarea.Count - 1

            Dim row = tabla.NewRow()
            row("Codigo") = codigoNode(i).InnerText
            row("Descripcion") = descripcionNode(i).InnerText
            row("CodAsig") = dd1.SelectedItem
            row("HEstimadas") = hEstimadasNode(i).InnerText
            row("Explotacion") = explotacionNode(i).InnerText
            row("TipoTarea") = tipoTareaNode(i).InnerText

            Try

                tabla.Rows.Add(row)

            Catch ex As ConstraintException

                Label1.Text = "Hay tareas repetidas"
                repetidas = True

            End Try

        Next

        dapAsignaturas.Update(dstAsignaturas, "Tareas")
        dstAsignaturas.AcceptChanges()

        If repetidas = False Then

            Label1.Text = "Tareas añadidas correctamente"

        End If


    End Sub

    Protected Sub importarBTN_Click(sender As Object, e As EventArgs) Handles importarBTN.Click
        importar()
    End Sub
End Class