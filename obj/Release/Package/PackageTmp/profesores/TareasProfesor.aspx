<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="proyecto_HADS.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
     <form id="form1" runat="server">
       

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="DDLCodigos" DataTextField="codigoasig" DataValueField="codigoasig" Width="94px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DDLCodigos" runat="server" ConnectionString="<%$ ConnectionStrings:HADS16ConnectionString %>" SelectCommand="Select distinct GruposClase.codigoasig from GruposClase inner join ProfesoresGrupo on codigo=codigoGrupo where ProfesoresGrupo.email= @email">
                            <SelectParameters>
                                <asp:SessionParameter Name="email" SessionField="username" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="GVTareas">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="GVTareas" runat="server" ConnectionString="<%$ ConnectionStrings:HADS16ConnectionString %>" SelectCommand="Select * FROM TareasGenericas where CodAsig=@codigoasig">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList2" Name="codigoasig" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
               
    </form>
</body>
</html>
