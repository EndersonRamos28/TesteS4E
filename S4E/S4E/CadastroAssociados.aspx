<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="CadastroAssociados.aspx.vb" Inherits="CadastroAssociados" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Cadastro Associados</title>

        <script type="text/javascript">
            function formatarCPF() {

                let cpfInput = document.getElementById('<%= textCpf.ClientID %>');
                let cpfValue = cpfInput.value;

                cpfValue = cpfValue.replace(/\D/g, '');

                cpfValue = cpfValue.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');

                cpfInput.value = cpfValue;
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
        <form id="cadastroAssociados">

            <div class="row">
                <div id="submenu">
                    <iframe name="frame_cadastro" src="SubMenuCadastro.aspx" id="frame_cadastro" style="width: 100%; border-style: none; height: 70px;"></iframe>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <h3 class="text-center">Cadastro Associados</h3>
                <hr />
            </div>

            <div id="cadastroAssociado" class="col-md-12 col-sm-12 col-xs-12">

                <div>
                    <label class="panel-title pull-left">Dados do Associado: </label>
                </div>

                <br />

                <div class="panel-body">
                    <div class="form-control col-md-12">
                        <label>Nome: <span style="color: red;"><b>*</b> </span></label>
                        <asp:TextBox ID="textNome" runat="server" type="text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="textNome" ErrorMessage="O campo Nome é obrigatório." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>

                    <div class="form-control col-md-12">
                        <label>CPF: <span style="color: red;"><b>*</b> </span></label>
                        <asp:TextBox ID="textCpf" runat="server" type="text" MaxLength="14" oninput="formatarCPF()"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCpf" runat="server" ControlToValidate="textCpf" ErrorMessage="O campo CPF é obrigatório." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCpf" runat="server" ControlToValidate="textCpf"
                            ErrorMessage="O CPF informado não é válido." ForeColor="Red" Display="Dynamic"
                            ValidationExpression="\d{3}\.\d{3}\.\d{3}-\d{2}"></asp:RegularExpressionValidator>
                    </div>

                    <div class="form-control col-md-12">
                        <label>Data de Nascimento: </label>
                        <asp:TextBox ID="textDataNascimento" runat="server" type="date"></asp:TextBox>
                    </div>

                    <div class="row">
                        <asp:Button ID="SalvarAssociado" CssClass="btn btn-success btn-salvar" Text="Salvar Associado" runat="server" OnClick="Salvar_Associado_Click" CausesValidation="True" />
                    </div>

                </div>
            </div>

        </form>
    </body>

    </html>
</asp:Content>
