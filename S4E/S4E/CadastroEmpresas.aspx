<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="CadastroEmpresas.aspx.vb" Inherits="CadastroEmpresas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Cadastro Empresas</title>

        <script type="text/javascript">
            function formatarCNPJ() {
                // Obtém o valor atual do campo CNPJ
                let cnpjInput = document.getElementById('<%= textCnpj.ClientID %>');
                let cnpjValue = cnpjInput.value;

                // Remove caracteres não numéricos
                cnpjValue = cnpjValue.replace(/\D/g, '');

                // Adiciona a máscara do CNPJ
                cnpjValue = cnpjValue.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');

                // Atualiza o valor do campo
                cnpjInput.value = cnpjValue;
            }
        </script>

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
        <form id="cadastroEmpresas">

            <div class="row">
                <div id="submenu">
                    <iframe name="frame_cadastro" src="SubMenuCadastro.aspx" id="frame_cadastro" style="width: 100%; border-style: none; height: 70px;"></iframe>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <h3 class="text-center">Cadastro Empresas</h3>
                <hr />
            </div>

            <div id="cadastroEmpresa" class="col-md-12 col-sm-12 col-xs-12">

                <div>
                    <label class="panel-title pull-left">Dados do Empresa: </label>
                </div>

                <br />

                <div class="panel-body">
                    <div class="form-control col-md-12">
                        <label>Nome: <span style="color: red;"><b>*</b> </span></label>
                        <asp:TextBox ID="textNome" runat="server" type="text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="textNome" ErrorMessage="O campo Nome é obrigatório." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>

                    <div class="form-control col-md-12">
                        <label>CNPJ: <span style="color: red;"><b>*</b> </span></label>
                        <asp:TextBox ID="textCnpj" runat="server" type="text" MaxLength="18" oninput="formatarCNPJ()"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCnpj" runat="server" ControlToValidate="textCnpj" ErrorMessage="O campo CNPJ é obrigatório." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCnpj" runat="server" ControlToValidate="textCnpj"
                            ErrorMessage="O CNPJ informado não é válido." ForeColor="Red" Display="Dynamic"
                            ValidationExpression="\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}"></asp:RegularExpressionValidator>
                    </div>

                    <div class="row">
                        <asp:Button ID="SalvarEmpresa" CssClass="btn btn-success btn-salvar" Text="Salvar Empresa" runat="server" OnClick="Salvar_Empresa_Click" CausesValidation="True" />
                    </div>

                </div>
            </div>

        </form>
    </body>

    </html>
</asp:Content>

