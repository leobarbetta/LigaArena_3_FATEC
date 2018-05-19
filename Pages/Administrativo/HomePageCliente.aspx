<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePageCliente.aspx.cs" Inherits="Pages_Administrativo_HomePageCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Liga Arena</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
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

            <img src="../Imagens/Liga Arena.jpg" />

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
