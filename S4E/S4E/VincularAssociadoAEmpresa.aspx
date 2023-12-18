<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="VincularAssociadoAEmpresa.aspx.vb" Inherits="VincularAssociadoAEmpresa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html>
    <head>
        <title>Vincular Associados A Empresa</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.min.css">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.0.0/dist/sweetalert2.all.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

        <style>
            .form-control {
                margin-bottom: 15px;
            }

            .btn-salvar {
                margin-top: 15px;
            }

            .modal-content {
                display: flex;
                justify-content: space-between;
            }

            .modal-column {
                width: 48%;
                padding: 10px;
            }

            .square-item {
                display: flex;
                flex-direction: column;
                align-items: center;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
                margin-bottom: 10px;
            }

                .square-item input {
                    margin-bottom: 5px;
                }

            .close {
                font-size: 35px; /* Ajuste o tamanho conforme necessário */
                cursor: pointer;
                color: red;
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
                <h3 class="text-center">Empresas Não Vinculadas</h3>
                <hr />
            </div>

            <div class="row">
                <asp:Repeater ID="rptEmpresas" runat="server">
                    <ItemTemplate>
                        <div class="square-item">
                            <input type="checkbox" id='<%# Eval("Id") %>' value='<%# Eval("Id") %>' class="checkbox-empresa" itemid="checkbox-empresa" clientidmode="Static" />
                            <label for='<%# Eval("Id") %>'><%# Eval("Nome") %></label>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="btnAdicionarEmpresas" runat="server" Text="Adicionar Empresas" OnClick="btnAdicionarEmpresas_Click" CssClass="btn btn-primary" />

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <h3 class="text-center">Empresas Vinculadas</h3>
                    <hr />
                    <asp:Repeater ID="rptEmpresasVinculadas" runat="server" OnItemDataBound="rptEmpresasVinculadas_ItemDataBound">
                        <ItemTemplate>
                            <div class="square-item">
                                <input type="checkbox" id='<%# Eval("Id") %>' value='<%# Eval("Id") %>' class="checkbox-empresa-vinculada" />
                                <label for='<%# Eval("Id") %>'><%# Eval("Nome") %></label>
                            </div>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Literal runat="server" ID="litEmptyMessage" Visible="false" />
                        </HeaderTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnRemoverEmpresas" runat="server" Text="Remover Empresas" OnClick="btnRemoverEmpresas_Click" CssClass="btn btn-primary" />
                </div>
        </form>


    </body>
    </html>
</asp:Content>

