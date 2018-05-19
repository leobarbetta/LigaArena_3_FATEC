<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cardapio.aspx.cs" Inherits="Pages_Administrativo_Cardapio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Fazer Pedido</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloCheckBox.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<script src="../JavaScript/jQuery.js"></script>
<script src="../JavaScript/Menu.js"></script>

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
                        <li><a href="Cardapio.aspx">Fazer Pedido</a></li>
                        <li><a href="MinhaConta.aspx">Minha Conta</a></li>
                        <li><a href="AlterarCliente.aspx">Alterar Meu Cadastro</a></li>
                        <li><a href="AlterarSenha.aspx">Alterar Minha Senha</a></li>
                        <li><a href="FeedBack.aspx">Deixe sua opinião</a></li>
                        <li>
                            <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton>
                        </li>
                    </ul>
                </nav>
            </section>
            <!-- fim do menu -->
            <section class="conteudo-site">
                <h1>CARDÁPIO</h1>

                <section class="destaque-cardapio">
                    <h2><b>Lanches</b></h2>
                    <asp:CheckBoxList ID="cblLanches" runat="server"></asp:CheckBoxList>
                    <br />
                    <h4>Adicionais lanches</h4>
                    <br />
                    <asp:CheckBoxList ID="cblADCLanches" runat="server"></asp:CheckBoxList>

                    <h2><b>Porçoes</b></h2>
                    <asp:CheckBoxList ID="cblPorções" runat="server"></asp:CheckBoxList>
                    <br />
                    <h2><b>Açai</b></h2>
                    <asp:CheckBoxList ID="cblAcai" runat="server"></asp:CheckBoxList>
                    <br />
                    <h4>Adicionais Açai</h4>
                    <br />
                    <asp:CheckBoxList ID="cblADCAcai" runat="server"></asp:CheckBoxList>

                    <h2><b>Diversos</b></h2>
                    <asp:CheckBoxList ID="cblDiversos" runat="server"></asp:CheckBoxList>

                    <br />
                    <asp:Label ID="lblMesa" Text="Mesa: " runat="server" />
                    <asp:TextBox ID="txtMesa" runat="server" Width="10%" />
                    <br />
                    <br />
                    <asp:LinkButton ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="but but-success but-rc but-shadow but-size2" OnClick="btnConfirmar_Click" />
                    <asp:Label ID="lblMensagem" runat="server" Text="Pedido realizado com sucesso!" />
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
