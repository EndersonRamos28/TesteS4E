<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SubMenuConsulta.aspx.vb" Inherits="SubMenuConsulta" %>

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
                <li runat="server"><a href="ConsultaAssociados.aspx" runat="server" target="frame1">Consulta Associado</a></li>
                <li runat="server"><a href="ConsultaEmpresas.aspx" runat="server" target="frame1">Consulta Empresa</a></li>
            </ul>
        </div>

    </form>

</body>
</html>
