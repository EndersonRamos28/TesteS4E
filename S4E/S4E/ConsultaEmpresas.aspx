<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="ConsultaEmpresas.aspx.vb" Inherits="ConsultaEmpresas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Consulta Empresas</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.min.css">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.all.min.js"></script>

        <style>
            .form-control {
                margin-bottom: 15px;
            }

            .btn-salvar {
                margin-top: 15px;
            }
        </style>
    </head>

    <body>
        <form>

            <div class="row">
                <div id="submenu">
                    <iframe name="frame_cadastro" src="SubMenuConsulta.aspx" id="frame_consulta" style="width: 100%; border-style: none; height: 70px;"></iframe>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <h3 class="text-center">Consulta Empresas</h3>
                <hr />
            </div>

            <div class="row">

                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gridViewEmpresas" runat="server" AutoGenerateColumns="False" Style="width: 100%;"
                        OnRowDataBound="gridViewEmpresas_RowDataBound"
                        OnRowCommand="gridViewEmpresas_RowCommand"
                        OnRowDeleting="gridViewEmpresas_RowDeleting"
                        DataKeyNames="Id">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <AlternatingRowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="cnpj" HeaderText="CNPJ" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Link" DeleteText="Excluir" />

                        </Columns>
                    </asp:GridView>
                </div>

            </div>

        </form>
    </body>
    </html>
</asp:Content>

