<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="ConsultaAssociados.aspx.vb" Inherits="ConsultaAssociados" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html>
    <head>
        <title>Consulta Associados</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.min.css">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.all.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    </head>

    <body>
        <form id="consultaAssociados">

            <div class="row">
                <div id="submenu">
                    <iframe name="frame_cadastro" src="SubMenuConsulta.aspx" id="frame_consulta" style="width: 100%; border-style: none; height: 70px;"></iframe>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <h3 class="text-center">Consulta Associados</h3>
                <hr />
            </div>

            <div class="row">

                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gridViewAssociados" runat="server" AutoGenerateColumns="False" Style="width: 100%;"
                        OnRowDataBound="gridViewAssociados_RowDataBound"
                        OnRowCommand="gridViewAssociados_RowCommand"
                        OnRowDeleting="gridViewAssociados_RowDeleting"
                        DataKeyNames="Id">

                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <AlternatingRowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="Cpf" HeaderText="CPF" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Link" DeleteText="Excluir" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnOpenModal" runat="server" CommandName="OpenModal" Text="Abrir Vincular Empresa" OnClientClick='<%# "abrirModal(" & Eval("Id") & "); return false;" %>' AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>

            </div>

        </form>

        <script>
            function abrirModal(associadoId) {
                // Altere a URL da nova página e inclua o ID do associado
                window.location.href = 'VincularAssociadoAEmpresa.aspx?associadoId=' + associadoId;
            }

            // Adicione um manipulador de evento para o LinkButton
            $(document).ready(function () {
                $('[id$=lnkOpenModal]').on('click', function () {
                    abrirModal($(this).data('associadoId'));
                });
            });
        </script>
    </body>
    </html>
</asp:Content>

