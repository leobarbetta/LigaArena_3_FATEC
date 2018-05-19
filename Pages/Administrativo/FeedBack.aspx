<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Pages_Administrativo_FeedBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>FeedBack</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />
    
</head>



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

        <h1>DEIXE SUA OPINIÃO</h1>
      
            <section class="feedback">

                <asp:RadioButtonList ID="rblFeedBack" runat="server" RepeatDirection="Horizontal" Font-Bold ="True" Font-Size="Medium" Font-Names="Helvetica">
                    <asp:ListItem Value="0" Text="0" />
                    <asp:ListItem Value="1" Text="1" />
                    <asp:ListItem Value="2" Text="2" />
                    <asp:ListItem Value="3" Text="3" />
                    <asp:ListItem Value="4" Text="4" />
                    <asp:ListItem Value="5" Text="5" />
                    <asp:ListItem Value="6" Text="6" />
                    <asp:ListItem Value="7" Text="7" />
                    <asp:ListItem Value="8" Text="8" />
                    <asp:ListItem Value="9" Text="9" />
                    <asp:ListItem Value="10" Text="10" />
                 </asp:RadioButtonList>
                <br />
                <p>Deixe seu comentário (opcional):</p>
                <asp:TextBox ID="txtFeedBack" runat="server" Height="93px" Width="514px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" CssClass="but but-error but-rc but-shadow but-size2" OnClick="btnCancelar_Click" />
                <asp:LinkButton ID="btnEnviar" runat="server" Text="Enviar" CssClass="but but-success but-rc but-shadow but-size2" OnClick="btnEnviar_Click" />

                


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