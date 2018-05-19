<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelatorioProdutos.aspx.cs" Inherits="Pages_Producao_RelatorioProdutos" %>

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
<script src="../JavaScript/jQuery.js"></script>
<script src="../JavaScript/Menu.js"></script>

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

            <section class="conteudo-site">
                <h1>PRODUTOS CADASTRADOS</h1>

                <div id="tabelas">
                <asp:GridView ID="gdvProdutos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" Font-Size="Small" OnRowCommand="gdvProdutos_RowCommand" CellSpacing="10">
                    <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField DataField="PRO_DESCRICAO" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Produto" DataFormatString="{0:C}">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRO_DATAVALIDADE" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Data de Validade" DataFormatString="{0:d}">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRO_QTDATUAL" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Estoque" >
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRO_ATIVO" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Ativo">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Adicionar Produto" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="WindowFrame" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" CommandName="add" CssClass="but but-success but-rc but-shadow but-size1" Text="Add"
                                    CommandArgument='<%# Bind("PRO_CODIGO")%>' />
                            </ItemTemplate>

                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" ForeColor="WhiteSmoke"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ativar/Desativar" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="WindowFrame" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAD" runat="server" CommandName="ativo" CssClass="but but-warning but-rc but-shadow but-size1" Text="Ativar/Desativar"
                                    CommandArgument='<%# Bind("PRO_CODIGO")%>' />
                            </ItemTemplate>

                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" ForeColor="WhiteSmoke"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>



                    </Columns>
                </asp:GridView>
                    </div>
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
