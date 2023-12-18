
Imports S4EService

Partial Class ConsultaEmpresas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim service = New EmpresaService()
                Dim empresas = service.BuscarTodasEmpresas()
                gridViewEmpresas.DataSource = empresas
                gridViewEmpresas.DataBind()
            End If

        Catch ex As Exception
            SwalMensagemErro("Erro", "Houve um erro ao carregar informações.")
        End Try
    End Sub

    Protected Sub gridViewEmpresas_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cnpj As String = DataBinder.Eval(e.Row.DataItem, "Cnpj").ToString()

            Dim cnpjCellIndex As Integer = -1

            For i As Integer = 0 To gridViewEmpresas.Columns.Count - 1
                If gridViewEmpresas.Columns(i).HeaderText = "CNPJ" Then
                    cnpjCellIndex = i
                    Exit For
                End If
            Next

            If cnpjCellIndex <> -1 AndAlso Not String.IsNullOrEmpty(cnpj) Then
                e.Row.Cells(cnpjCellIndex).Text = FormatarCNPJ(cnpj)
            End If
        End If
    End Sub

    Protected Sub gridViewEmpresas_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Delete" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Dim id As String = gridViewEmpresas.DataKeys(index).Value.ToString()

            ExcluirRegistro(id)
            SwalMensagemSucessoDeleteRefresh()
        End If
    End Sub

    Protected Sub gridViewEmpresas_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Private Sub ExcluirRegistro(ByVal id As Integer)
        Dim serviceAssociadosEmpresas = New AssociadosEmpresasService()

        Dim empresaPossuiVinculoAssociado = serviceAssociadosEmpresas.VerificarSeEmpresaPossuiAssociado(id)

        If empresaPossuiVinculoAssociado Then
            SwalMensagemErro("Erro", "Empresa está vinculada a um Associado, retire o vinculo antes de excluir o registro")
            Exit Sub
        End If

        Dim service = New EmpresaService()
        service.ExcluirEmpresa(id)
    End Sub

    Private Sub SwalMensagemSucessoDeleteRefresh()
        Dim script As String = "Swal.fire({
                                   title: 'Concluído!',
                                   text: 'Excluído com sucesso',
                                   icon: 'success'
                               }).then(() => {
                                   window.location.href = window.location.href;
                               });"

        ScriptManager.RegisterStartupScript(Me, GetType(Page), "SwalScript", script, True)

    End Sub

    Private Function FormatarCNPJ(cnpj As String) As String
        Return String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpj))
    End Function

    Private Sub SwalMensagemErro(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'error', position: 'top'})", True)
    End Sub
End Class
