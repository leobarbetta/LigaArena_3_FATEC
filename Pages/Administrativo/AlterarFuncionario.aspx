﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterarFuncionario.aspx.cs" Inherits="Pages_Administrativo_AlterarFuncionario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Alterar Funcionario</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<script src="../JavaScript/MascaraCampos.js"></script>
<script src="../JavaScript/Menu.js"></script>
<script src="../JavaScript/jQuery.js"></script>
<script src="../JavaScript/maskMoney.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input.monetario").maskMoney({ showSymbol: false, symbol: "R$", decimal: ",", thousands: "." });
    });
</script>

<body>
    <form id="form2" runat="server">
        <header class="container">
            <h1>
                <img src="../Imagens/logoOficial.png" alt="Liga Arena" style="height: 94px; width: 102px" /></h1>
        </header>

        <div class="container destaque">

            <section class="menu-departamentos">
                <h2>Menu</h2>

                <nav>
                    <ul>
                        <li>
                            <a href="RecebePedido.aspx">Pedidos em Aberto</a>
                        </li>
                        <li>
                            <a href="#">Cadastrar</a>
                            <ul>
                                <li><a href="../Producao/CadastroProduto.aspx">Produto</a></li>
                                <li><a href="CadastroFuncionario.aspx">Funcionario</a></li>
                                <li><a href="Cadastrar.aspx">Cliente</a></li>
                                <li><a href="../Financeiro/Despesas.aspx">Despesa</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#">Relatorios</a>
                            <ul>
                                <li><a href="RelatorioClientes.aspx">Clientes Cadastrados</a></li>
                                <li><a href="RelatorioFuncionarios.aspx">Funcionarios Cadastrados</a></li>
                                <li><a href="../Producao/RelatorioProdutos.aspx">Produtos Cadastrados</a></li>

                            </ul>
                        </li>
                        <li>
                            <a href="#">Financeiro</a>
                            <ul>
                                <li><a href="../Financeiro/RelatorioVenda.aspx">Relatorio de Vendas</a></li>
                                <li><a href="../Financeiro/RelatorioDespesa.aspx">Relatorio de Despesas</a></li>
                                <li><a href="../Financeiro/RelatorioLucro.aspx">Relatorio de Lucro</a></li>
                            </ul>
                        </li>
                        <li><a href="RelatorioFeedback.aspx">Visualizar FeedBacks</a></li>
                        <li> <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton> </li>
                        
                    </ul>
                </nav>
            </section>
            <!-- fim do menu -->
            <section class="conteudo-site">
                <h1>ALTERAR FUNCIONÁRIO</h1>

                <section class="labels">
                    <p>Numero de Registro:</p>
                    <p>Cargo:</p>
                    <p>Data de Admissão:</p>
                    <p>Salário</p>
                </section>

                <section class="campos">
                    <asp:TextBox ID="txtRegistro" runat="server" Width="50%" />
                    <br />
                    <asp:DropDownList ID="ddlCargo" runat="server">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="1" Text="Garçom" />
                        <asp:ListItem Value="2" Text="Chapeiro" />
                        <asp:ListItem Value="3" Text="Ajudante Geral" />
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txtDataAdimissao" runat="server" MaxLength="10" onkeypress="formatar('##/##/####', this)" Width="50%" />

                    <asp:TextBox ID="txtSalario" runat="server" class="monetario" Width="50%" />
                    <br />
                    <asp:LinkButton ID="btnSalvar" runat="server" Text="Salvar" CssClass="but but-success but-rc but-shadow but-size1" OnClick="btnSalvar_Click" />
                    <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" CssClass="but but-error but-rc but-shadow but-size1" OnClick="Cancelar_Click" />


                </section>
            </section>

        </div>
        <!-- fim .container .destaque -->

        <footer class="container">
            <div class="container">
                <img src="../Imagens/logoOficial.png" alt="Logo Liga Arena" style="height: 58px; width: 66px" />

                <ul class="social">
                    <li><a href="http://facebook.com/ligaarena">Facebook</a></li>
                    <li><a href="http://twitter.com/ligaarena">Twitter</a></li>
                    <li><a href="http://plus.google.com/ligaarena">Google+</a></li>
                </ul>

            </div>
        </footer>
    </form>
</body>
</html>
