Imports System.Data.SqlClient
Imports System.Xml

Public Class WebForm4
    Inherits System.Web.UI.Page

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
            dstAsignaturas = Session("datosdd2")
        Else
            conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
            dapAsignaturas = New SqlDataAdapter("Select distinct GruposClase.codigoasig from GruposClase inner join ProfesoresGrupo on codigogrupo=codigo where ProfesoresGrupo.email='" & Session("username") & "'", conString)
            dstAsignaturas = New DataSet()
            dapAsignaturas.Fill(dstAsignaturas, "Asignaturas") 'Se carga la tabla Asignaturas en una Datable de un DataSet
            dd1.DataSource = dstAsignaturas.Tables("Asignaturas") 'Se enlaza la DataTable con el DataGrid
            dd1.DataValueField = "codigoasig"
            dd1.DataBind()
            Session("datosdd2") = dstAsignaturas
            Session("adaptadordd2") = dapAsignaturas
        End If
    End Sub

    Private Sub mostrarEnTabla()
        Dim conString = New SqlConnection("Data Source=tcp:jinma2.database.windows.net,1433;Initial Catalog=HADS16;Persist Security Info=True;User ID=jinma@jinma2;Password=Ratagorda0")
        Dim dapTareas As New SqlDataAdapter
        Dim dstTareas As New DataSet
        Dim tblTareas As New DataTable

        dapTareas = New SqlDataAdapter("Select * FROM TareasGenericas where CodAsig='" & dd1.SelectedValue & "'", conString)
        Dim bldMbrs As New SqlCommandBuilder(dapTareas)
        dapTareas.Fill(dstTareas, "TareasGenericas")
        tblTareas = dstTareas.Tables("TareasGenericas")
        gv1.DataSource = tblTareas
        gv1.DataBind()
        Session("dst_genericas") = dstTareas
        Session("dap_genericas") = dapTareas
    End Sub

    Protected Sub importarBTN_Click(sender As Object, e As EventArgs) Handles importarBTN.Click
        Exportar()
    End Sub

    Protected Sub Exportar()

        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True ' añade sangrias al fichero xml generado

        Using xtr As XmlWriter = XmlWriter.Create(Server.MapPath("APP_DATA\" & dd1.SelectedValue & ".xml"), settings)

            xtr.WriteStartDocument()
            xtr.WriteStartElement("tareas") 'el root del xml

            Dim tabla_genericas = Session("dst_genericas").Tables("TareasGenericas")
            Dim row As DataRow
            For Each row In tabla_genericas.rows
                xtr.WriteStartElement("tarea")
                xtr.WriteElementString("codigo", row("Codigo"))
                xtr.WriteElementString("descripcion", row("Descripcion"))
                xtr.WriteElementString("hestimadas", row("HEstimadas"))
                xtr.WriteElementString("explotacion", row("Explotacion"))
                xtr.WriteElementString("tipotarea", row("TipoTarea"))
            Next
            xtr.WriteEndElement()
            xtr.WriteEndDocument()
        End Using

        Label1.Text = "Tareas exportadas correctamente"

    End Sub
End Class