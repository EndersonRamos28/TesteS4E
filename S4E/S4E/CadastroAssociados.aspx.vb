Imports S4EService

Partial Class CadastroAssociados
    Inherits System.Web.UI.Page

    Protected Sub Salvar_Associado_Click(sender As Object, e As EventArgs)
        Try
            Dim cpf As String = RemoverMascaraCpf(textCpf.Text)

            If Not ValidarCPF(cpf) Then
                Exit Sub
            End If

            Dim dataNascimento As DateTime?

            If Not String.IsNullOrWhiteSpace(textDataNascimento.Text) Then
                dataNascimento = DateTime.Parse(textDataNascimento.Text)
            End If

            Dim service = New AssociadoService()
            service.SalvarAssociado(textNome.Text, cpf, dataNascimento)

            SwalMensagemSucesso("Concluido! ", "Associado salvo com sucesso")

        Catch ex As Exception
            SwalMensagemErro("Erro", "Houve um erro no cadastro.")
        End Try
    End Sub

    Private Function ValidarCPF(cpf As String) As Boolean
        Dim i, x, n1, n2 As Integer

        If cpf.Length <> 11 Then
            SwalMensagemErro("CPF Inválido", "O CPF informado não possui 11 dígitos.")
            Return False
        End If

        For x = 0 To 1
            n1 = 0
            For i = 0 To 8 + x
                n1 = n1 + Val(cpf.Substring(i, 1)) * (10 + x - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(cpf.Substring(9 + x, 1)) Then
                SwalMensagemErro("CPF Inválido", "O CPF informado não é válido.")
                Return False
            End If
        Next

        Return True
    End Function

    Private Function RemoverMascaraCpf(textCpf As String) As String
        Dim cpf = textCpf.Replace(".", "")
        Return cpf.Replace("-", "").Trim()
    End Function

    Private Sub SwalMensagemErro(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'error', position: 'top'})", True)
    End Sub

    Private Sub SwalMensagemSucesso(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'success', position: 'top'})", True)

    End Sub

End Class
