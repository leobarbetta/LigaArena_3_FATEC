<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterarCliente.aspx.cs" Inherits="Pages_Administrativo_AlterarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Alterar Cliente</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<script src="../JavaScript/MascaraCampos.js"></script>
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
                    <li> <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton> </li>
                </ul>
            </nav>
            </section>
            <!-- fim do menu -->

            <section class="conteudo-site">
                <h1>ALTERAR CLIENTE</h1>

                <section class="labels">
                    <p>Nome:</p>
                    <p>CPF:</p>
                    <p>Data de Nascimento:</p>
                    <p>Sexo</p>
                    <p>Telefone:</p>
                    <p>Estado:</p>
                    <p>Cidade:</p>
                    <p>Bairro:</p>
                    <p>CEP:</p>
                    <p>Endereço:</p>
                    <p>Numero:</p>
                    <p>Complemento:</p>

                </section>

                <section class="campos">
                    <asp:TextBox ID="txtNome" runat="server" Width="50%" />

                    <asp:TextBox ID="txtCPF" runat="server" MaxLength="14" OnKeyPress="formatar('###.###.###-##', this)" Width="50%" />
                    <asp:RequiredFieldValidator ID="rfvtxtCPF" runat="server" ErrorMessage="*" ControlToValidate="txtCPF" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente" />

                    <asp:TextBox ID="txtDataNascimento" runat="server" MaxLength="10" OnKeyPress="formatar('##/##/####', this)" Width="50%" />

                    <br />

                    <asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="M" Text="Masculino" />
                        <asp:ListItem Value="F" Text="Feminino" />
                    </asp:DropDownList>

                    <br />

                    <asp:TextBox ID="txtTelefone" runat="server" MaxLength="13" OnKeyPress="formatar('## #####-####', this)" Width="50%" />
                    <br />
                    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" />
                    <br />
                    <asp:DropDownList ID="ddlCidade" runat="server" />
                    <br />
                    <asp:TextBox ID="txtBairro" runat="server" Width="50%" />

                    <asp:TextBox ID="txtCEP" runat="server" MaxLength="9" OnKeyPress="formatar('#####-###', this)" Width="50%" />

                    <asp:TextBox ID="txtEndereco" runat="server" Width="50%" />

                    <asp:TextBox ID="txtNumero" runat="server" Width="50%" />

                    <asp:TextBox ID="txtComplemento" runat="server" Width="50%" />

                    <br />

                    <asp:LinkButton ID="btnSalvar" runat="server" CssClass="but but-success but-shadow but-rc but-size1" OnClick="btnSalvar_Click">Salvar</asp:LinkButton>

                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="but but-error but-shadow but-rc but-size1" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblMensagem" runat="server" Font-Bold="true" ForeColor="Green" />
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






