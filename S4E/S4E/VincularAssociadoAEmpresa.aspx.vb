
Imports S4EService

Partial Class VincularAssociadoAEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then
                Dim associadoId As String = Request.QueryString("associadoId")

                PopularListaEmpresas(associadoId)

            End If

        Catch ex As Exception
            SwalMensagemErro("Erro", "Houve um erro ao carregar informações.")
        End Try
    End Sub

    Protected Sub btnAdicionarEmpresas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionarEmpresas.Click
        Dim empresasSelecionadas As New List(Of Integer)()
        Dim associadoId As Integer = Convert.ToInt32(Request.QueryString("associadoId"))


        For Each item As RepeaterItem In rptEmpresas.Items
            If item.ItemType = ListItemType.Item OrElse item.ItemType = ListItemType.AlternatingItem Then
                Dim chkEmpresa As CheckBox = FindControlRecursive(item, "checkbox-empresa")

                If chkEmpresa IsNot Nothing AndAlso chkEmpresa.Checked Then
                    empresasSelecionadas.Add(Convert.ToInt32(chkEmpresa.Attributes("value")))
                End If
            End If
        Next

        If empresasSelecionadas.Count = 0 Then
            SwalMensagemErro("Erro", "Nenhuma empresa selecionada.")
            Exit Sub
        End If
        Dim serviceAssociadosEmpresas = New AssociadosEmpresasService()

        serviceAssociadosEmpresas.VincularEmpresasAoAssociado(empresasSelecionadas, associadoId)
        SwalMensagemSucessoDeleteRefresh("Empresa(s) Vinculada")
    End Sub

    Protected Sub btnRemoverEmpresas_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim empresasSelecionadas As New List(Of Integer)()
        Dim associadoId As Integer = Convert.ToInt32(Request.QueryString("associadoId"))

        For Each item As RepeaterItem In rptEmpresas.Items
            If item.ItemType = ListItemType.Item OrElse item.ItemType = ListItemType.AlternatingItem Then
                Dim chkEmpresa As CheckBox = DirectCast(item.FindControl("checkbox-empresa-vinculada"), CheckBox)
                If chkEmpresa.Checked Then
                    empresasSelecionadas.Add(Convert.ToInt32(chkEmpresa.Attributes("value")))
                End If
            End If
        Next

        Dim serviceAssociadosEmpresas = New AssociadosEmpresasService()

        serviceAssociadosEmpresas.RemoverEmpresasAoAssociado(empresasSelecionadas, associadoId)
        SwalMensagemSucessoDeleteRefresh("Empresa(s) Removidas")
    End Sub

    Private Function FindControlRecursive(container As Control, id As String) As Control
        For Each ctrl As Control In container.Controls
            If ctrl.ID = id Then
                Return ctrl
            End If

            If ctrl.HasControls() Then
                Dim foundCtrl As Control = FindControlRecursive(ctrl, id)
                If foundCtrl IsNot Nothing Then
                    Return foundCtrl
                End If
            End If
        Next

        Return Nothing
    End Function
    Protected Sub rptEmpresasVinculadas_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Footer Then
            If rptEmpresasVinculadas.Items.Count = 0 Then
                Dim litEmptyMessage As Literal = DirectCast(e.Item.FindControl("litEmptyMessage"), Literal)
                litEmptyMessage.Visible = True
                litEmptyMessage.Text = "<p class='text-center'>Nenhuma empresa vinculada encontrada.</p>"
            End If
        End If
    End Sub

    Private Sub SwalMensagemErro(titulo As String, mensagem As String)
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "ALERT", "Swal.fire({title: '" & titulo & "', text: '" & mensagem & "', icon: 'error', position: 'top'})", True)
    End Sub

    Private Sub SwalMensagemSucessoDeleteRefresh(tipo As String)
        Dim script As String = "Swal.fire({
                                   title: 'Concluído!',
                                   text: '" & tipo & " com sucesso',
                                   icon: 'success'
                               }).then(() => {
                                   window.location.href = window.location.href;
                               });"

        ScriptManager.RegisterStartupScript(Me, GetType(Page), "SwalScript", script, True)

    End Sub

    Protected Sub PopularListaEmpresas(associadoId As Integer)
        Dim service = New EmpresaService()
        Dim empresas = service.BuscarTodasEmpresasNaoVinculadasAoAssociado(associadoId)
        rptEmpresas.DataSource = empresas
        rptEmpresas.DataBind()

        Dim empresasVinculadas = service.BuscarTodasEmpresasVinculadasAoAssociado(associadoId)
        rptEmpresasVinculadas.DataSource = empresasVinculadas
        rptEmpresasVinculadas.DataBind()
    End Sub

End Class
