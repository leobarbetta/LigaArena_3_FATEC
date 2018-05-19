<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterarSenha.aspx.cs" Inherits="Pages_Administrativo_AlterarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Alterar Senha</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<body>
    <form id="form2" runat="server">
        <header class="container">
            <h1>
                <img src="../Imagens/logoOficial.png" alt="Liga Arena" style="height: 94px; width: 102px" /></h1>


        </header>

        <div class="container destaque">



            <h1>ALTERAR SENHA</h1>

            <section class="labels">
                <p>Email:</p>
                <p>Senha Antiga:</p>
                <p>Nova Senha:</p>
                <p>Confirmar Nova Senha:</p>
            </section>

            <section class="campos cliente">
                <asp:TextBox ID="txtEmail" runat="server" Width="50%" />
                <asp:RegularExpressionValidator ID="revEmail" ForeColor="Red" ValidationGroup="Cliente" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" SetFocusOnError="true" ControlToValidate="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ErrorMessage="Insira seu email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AlteraSenha" />

                <asp:TextBox ID="txtSenhaAntiga" runat="server" TextMode="Password" Width="50%" />


                <asp:TextBox ID="txtsenha" runat="server" TextMode="Password" Width="50%" />
                <asp:RequiredFieldValidator ID="rfvtxtSenha" runat="server" ErrorMessage="Insira a nova senha" ControlToValidate="txtSenha" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AlteraSenha" />

                <asp:TextBox ID="txtsenha2" runat="server" TextMode="Password" Width="50%" />
                <asp:CompareValidator ID="cvSenha" runat="server" ErrorMessage="Senha diferentes" ValidationGroup="AlteraSenha" SetFocusOnError="True" ControlToValidate="txtsenha2" ForeColor="Red" ControlToCompare="txtsenha" />

                <br />
                <asp:LinkButton ID="btnSalvar" runat="server" Text="Salvar" CssClass="but but-success but-rc but-shadow but-size1"  OnClick="btnSalvar_Click" />
                <asp:LinkButton ID="btnCancelar" runat="server" Text="Voltar" CausesValidation="false" CssClass="but but-warning but-shadow but-rc but-size1" onclientclick="javascript:history.go(-1);" />
                <br />
                <asp:Label ID="lblMensagem" runat="server" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
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
