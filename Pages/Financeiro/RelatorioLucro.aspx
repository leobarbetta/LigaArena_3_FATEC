<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelatorioLucro.aspx.cs" Inherits="Pages_Administrativo_RelatorioLucro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Liga Arena</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<script src="../JavaScript/MascaraCampos.js"></script>
<script src="../JavaScript/Menu.js"></script>
<script src="../JavaScript/jQuery.js"></script>

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
                                <li><a href="../Administrativo/CadastroFuncionario.aspx">Funcionario</a></li>
                                <li><a href="../Administrativo/Cadastrar.aspx">Cliente</a></li>
                                <li><a href="../Financeiro/Despesas.aspx">Despesa</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#">Relatorios</a>
                            <ul>
                                <li><a href="../Administrativo/RelatorioClientes.aspx">Clientes Cadastrados</a></li>
                                <li><a href="../Administrativo/HomePageFuncionario.aspx">Funcionarios Cadastrados</a></li>
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
            <section class="conteudo-site">
                <h1>RELATÓRIO DE LUCRO</h1>

                <section class="labels">
                    <p>De:</p>
                    <p>a:</p>
                </section>

                <section class="campos">
                    <asp:TextBox ID="txtData" runat="server" />
                    <br />
                    <asp:TextBox ID="txtData2" runat="server" />
                    <asp:LinkButton ID="btnExibir" runat="server" OnClick="btnExibir_Click" Text="Exibir" Font-Overline="False" />
                </section>

                <asp:GridView ID="gdvRelatorioVendas1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" Font-Size="Small" CellSpacing="10">
                    <Columns>
                        <asp:BoundField DataField="total" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Total Vendas">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gdvRelatorioDespesas" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" Font-Size="Small" CellSpacing="10">
                    <Columns>
                        <asp:BoundField DataField="total" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Total Despesas">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

                <section class="labels">
                    <asp:Label ID="lblLucro" runat="server" />
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
