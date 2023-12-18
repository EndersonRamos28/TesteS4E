<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SubMenuCadastro.aspx.vb" Inherits="SubMenuCadastro" %>


<!DOCTYPE html>
<html>
<head>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>

<body style="height: auto;">

    <form>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li runat="server"><a href="CadastroAssociados.aspx" runat="server" target="frame1">Cadastro Associado</a></li>
                <li runat="server"><a href="CadastroEmpresas.aspx" runat="server" target="frame1">Cadastro Empresa</a></li>
            </ul>
        </div>

    </form>

</body>
</html>
