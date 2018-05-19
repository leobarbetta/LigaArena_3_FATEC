<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MinhaConta.aspx.cs" Inherits="Pages_Administrativo_MinhaConta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Minha Conta</title>
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
                    <li><a href="Cardapio.aspx">Fazer Pedido</a></li>
                    <li><a href="MinhaConta.aspx">Minha Conta</a></li>
                    <li><a href="AlterarCliente.aspx">Alterar Meu Cadastro</a></li>
                    <li><a href="AlterarSenha.aspx">Alterar Minha Senha</a></li>
                    <li><a href="FeedBack.aspx">Deixe sua opinião</a></li>
                    <li> <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton> </li>
                </ul>
            </nav>
            </section>
            <!-- fim do menu -->

            <section class="conteudo-site">
                <h1>MINHA CONTA</h1>

                <asp:GridView ID="gdvMinhaConta" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" Font-Size="Small" CellSpacing="10">
                    <Columns>
                        <asp:BoundField DataField="PES_NOME" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Nome" DataFormatString="{0:C}">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRO_DESCRICAO" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Produto" DataFormatString="{0:d}">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CAR_VALOR" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Valor">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gdvTotal" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" Font-Size="Small" CellSpacing="10">
                    <Columns>
                        <asp:BoundField DataField="PED_VALORTOTAL" HeaderStyle-ForeColor="WhiteSmoke" HeaderText="Total" DataFormatString="{0:C}">
                            <HeaderStyle BackColor="WindowFrame" CssClass="text-center" />
                            <ControlStyle BackColor="WindowFrame" BorderColor="#000066" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

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
