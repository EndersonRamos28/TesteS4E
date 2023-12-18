Imports System.Web.Script.Services
Imports System.Web.Services
Imports S4EService

Partial Class ConsultaAssociados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim service = New AssociadoService()
                Dim associados = service.BuscarTodosAssociados()
                gridViewAssociados.DataSource = associados
                gridViewAssociados.DataBind()
            End If

        Catch ex As Exception
            SwalMensagemErro("Erro", "Houve um erro ao carregar informações.")
        End Try
    End Sub

    Protected Sub gridViewAssociados_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cpf As String = DataBinder.Eval(e.Row.DataItem, "Cpf").ToString()

            Dim cpfCellIndex As Integer = -1

            For i As Integer = 0 To gridViewAssociados.Columns.Count - 1
                If gridViewAssociados.Columns(i).HeaderText = "CPF" Then
                    cpfCellIndex = i
                    Exit For
                End If
            Next

            If cpfCellIndex <> -1 AndAlso Not String.IsNullOrEmpty(cpf) Then
                e.Row.Cells(cpfCellIndex).Text = FormatarCPF(cpf)
            End If

            Dim dataNascimentoCellIndex As Integer = -1

            For i As Integer = 0 To gridViewAssociados.Columns.Count - 1
                If gridViewAssociados.Columns(i).HeaderText = "Data de Nascimento" Then
                    dataNascimentoCellIndex = i
                    Exit For
                End If
            Next

            If dataNascimentoCellIndex <> -1 Then
                Dim dataNascimentoValue As Object = DataBinder.Eval(e.Row.DataItem, "DataNascimento")

                If String.IsNullOrEmpty(dataNascimentoValue) Then
                    e.Row.Cells(dataNascimentoCellIndex).Text = ""
                    Return
                End If

                Dim dataNascimento As DateTime
                If DateTime.TryParse(dataNascimentoValue.ToString(), dataNascimento) Then
                    e.Row.Cells(dataNascimentoCellIndex).Text = dataNascimento.ToString("dd/MM/yyyy")
                End If

            End If
        End If
    End Sub

    Protected Sub gridViewAssociados_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gridViewAssociados.RowCommand
        If e.CommandName = "Delete" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Dim id As String = gridViewAssociados.DataKeys(index).Value.ToString()

            ExcluirRegistro(id)
            SwalMensagemSucessoDeleteRefresh()
        End If
    End Sub

    Protected Sub gridViewAssociados_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Private Sub ExcluirRegistro(ByVal id As Integer)
        Dim serviceAssociadosEmpresas = New AssociadosEmpresasService()

        Dim associadoPossuiVinculoEmpresa = serviceAssociadosEmpresas.VerificarSeAssociadoPossuiEmpresa(id)

        If associadoPossuiVinculoEmpresa Then
            SwalMensagemErro("Erro", "Associados está vinculado a uma empresa, retire o vinculo antes de excluir o registro")
            Exit Sub
        End If

        Dim service = New AssociadoService()
        service.ExcluirAssociado(id)
    End Sub

    Private Function FormatarCPF(cpf As String) As String
        Return String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpf))
    End Function

    Private Sub SwalMensagemErro(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'error', position: 'top'})", True)
    End Sub

    Private Sub SwalMensagemSucesso(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'success', position: 'top'})", True)
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

End Class
