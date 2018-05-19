<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroProduto.aspx.cs" Inherits="Pages_Administrativo_CadastroProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Cadastrar Produto</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />
</head>

<script src="../JavaScript/MascaraCampos.js"></script>
<script src="../JavaScript/jQuery.js"></script>
<script src="../JavaScript/maskMoney.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input.monetario").maskMoney({ showSymbol: false, symbol: "R$", decimal: ",", thousands: "." });
    });
</script>

<body>
    <form id="form1" runat="server">
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
                                <li><a href="../Administrativo/CadastroFuncionario.aspx">Funcionario</a></li>
                                <li><a href="../Administrativo/Cadastrar.aspx">Cliente</a></li>
                                <li><a href="../Financeiro/Despesas.aspx">Despesa</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#">Relatorios</a>
                            <ul>
                                <li><a href="../Administrativo/RelatorioClientes.aspx">Clientes Cadastrados</a></li>
                                <li><a href="../Administrativo/RelatorioFuncionarios.aspx">Funcionarios Cadastrados</a></li>
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
                        <li><a href="../Administrativo/RelatorioFeedback.aspx">Visualizar FeedBacks</a></li>
                        <li> <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton> </li>
                        
                    </ul>
                </nav>
            </section>
            <!-- fim do menu -->

            <h1>CADASTRO DE PRODUTOS</h1>

            <section class="labels">
                <p>Categoria do Produto:</p>
                <p>Produto:</p>
                <p>Valor de Custo:</p>
                <p>Valor de Venda:</p>
                <p>Data de Validade:</p>
                <p>Unidade:</p>
                <p>Quantidade Minima:</p>
                <p>Quantidade em Estoque:</p>
            </section>
            <section class="campos">
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="50%" />

                <asp:TextBox ID="txtNomeItem" runat="server" Width="50%" TextMode="SingleLine" />

                <asp:TextBox ID="txtValordecusto" runat="server" class="monetario" Width="50%" />

                <asp:TextBox ID="txtValorVarejo" runat="server" class="monetario" Width="50%" />

                <asp:TextBox ID="txtDataValidade" runat="server" Width="50%" MaxLength="10" OnKeyPress="formatar('##/##/####', this)" TextMode="Date" />

                <asp:TextBox ID="txtUnidadeMedida" runat="server" Width="50%" />

                <asp:TextBox ID="txtQuantidadeMinima" runat="server" Width="50%" TextMode="Number" />

                <asp:TextBox ID="txtAddProduto" runat="server" Width="50%" TextMode="Number" />
                <br />
                <asp:RadioButtonList ID="rblVendaEstoque" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="E" Text="Estoque" Selected="True" />
                    <asp:ListItem Value="V" Text="Venda" />
                </asp:RadioButtonList>

                <asp:LinkButton ID="btnCadastrar" runat="server" CssClass="but but-success but-shadow but-rc but-size1" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" CssClass="but but-error but-rc but-shadow but-size1" OnClick="btnCancelar_Click" />
                <br />
                <asp:Label ID="lblMensagem" runat="server" />
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
