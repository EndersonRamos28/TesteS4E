
Imports S4EService

Partial Class CadastroEmpresas
    Inherits System.Web.UI.Page

    Protected Sub Salvar_Empresa_Click(sender As Object, e As EventArgs)
        Try
            Dim cnpj As String = RemoverMascaraCnpj(textCnpj.Text)

            If Not ValidarCNPJ(cnpj) Then
                Exit Sub
            End If

            Dim service = New EmpresaService()
            service.SalvarEmpresa(textNome.Text, cnpj)

            SwalMensagemSucesso("Concluido! ", "Empresa salva com sucesso")

        Catch ex As Exception
            SwalMensagemErro("Erro", "Houve um erro no cadastro.")
        End Try
    End Sub

    Private Function ValidarCNPJ(cnpj As String) As Boolean
        Dim n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12 As Integer

        If cnpj.Length <> 14 Then
            SwalMensagemErro("CNPJ Inválido", "O CNPJ informado não possui 14 dígitos.")
            Return False
        End If

        n1 = Val(cnpj.Substring(0, 1))
        n2 = Val(cnpj.Substring(1, 1))
        n3 = Val(cnpj.Substring(2, 1))
        n4 = Val(cnpj.Substring(3, 1))
        n5 = Val(cnpj.Substring(4, 1))
        n6 = Val(cnpj.Substring(5, 1))
        n7 = Val(cnpj.Substring(6, 1))
        n8 = Val(cnpj.Substring(7, 1))
        n9 = Val(cnpj.Substring(8, 1))
        n10 = Val(cnpj.Substring(9, 1))
        n11 = Val(cnpj.Substring(10, 1))
        n12 = Val(cnpj.Substring(11, 1))

        ' Calcular o primeiro dígito verificador
        Dim soma1 As Integer = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2
        Dim resto1 As Integer = soma1 Mod 11
        Dim dv1 As Integer = If(resto1 < 2, 0, 11 - resto1)

        If dv1 <> Val(cnpj.Substring(12, 1)) Then
            SwalMensagemErro("CNPJ Inválido", "O CNPJ informado não é válido.")
            Return False
        End If

        ' Calcular o segundo dígito verificador
        Dim soma2 As Integer = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + dv1 * 2
        Dim resto2 As Integer = soma2 Mod 11
        Dim dv2 As Integer = If(resto2 < 2, 0, 11 - resto2)

        If dv2 <> Val(cnpj.Substring(13, 1)) Then
            SwalMensagemErro("CNPJ Inválido", "O CNPJ informado não é válido.")
            Return False
        End If

        Return True
    End Function

    Private Function RemoverMascaraCnpj(textCnpj As String) As String
        Dim cnpj = textCnpj.Replace(".", "")
        cnpj = cnpj.Replace("/", "")
        Return cnpj.Replace("-", "").Trim()
    End Function

    Private Sub SwalMensagemErro(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'error', position: 'top'})", True)
    End Sub

    Private Sub SwalMensagemSucesso(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'success', position: 'top'})", True)
    End Sub
End Class
