<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastrar.aspx.cs" Inherits="Pages_Administrativo_HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Cadastrar Cliente</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />

</head>

<script src="../JavaScript/MascaraCampos.js"></script>


<body>
    <form id="form1" runat="server">

        <header class="container">
            <h1>
                <img src="../Imagens/logoOficial.png" alt="Liga Arena" style="height: 94px; width: 102px" /></h1>
        </header>

        <div class="container destaque">


            <h1>CADASTRAR CLIENTE</h1>

            <section class="labels">
                <p>Nome:</p>
                <p>CPF:</p>
                <p>Data de Nascimento:</p>
                <p>Sexo:</p>
                <p>Telefone:</p>
                <p>Estado:</p>
                <p>Cidade:</p>
                <p>Bairro:</p>
                <p>CEP:</p>
                <p>Endereço:</p>
                <p>Numero:</p>
                <p>Complemento:</p>
                <p>Email:</p>
                <p>Senha:</p>
                <p>Confirmar Senha:</p>
            </section>

            <section class="campos cliente">

                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome Completo" Width="50%" />
                <asp:RequiredFieldValidator ID="rfvtxtNome" runat="server" ErrorMessage="Insira seu Nome" ControlToValidate="txtNome" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente" />

                <asp:TextBox ID="txtCPF" runat="server" placeholder="XXX.XXX.XXX-XX" MaxLength="14" OnKeyPress="formatar('###.###.###-##', this)" Width="50%" />
                <asp:RequiredFieldValidator ID="rvftxtCPF" runat="server" ErrorMessage="*" ControlToValidate="txtCPF" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente" />

                <asp:TextBox ID="txtDataNascimento" runat="server" placeholder="01/01/2010" MaxLength="10" OnKeyPress="formatar('##/##/####', this)" Width="50%" />
                <br />
                <asp:DropDownList ID="ddlSexo" runat="server">
                    <asp:ListItem Value="0" Text="Selecione" />
                    <asp:ListItem Value="M" Text="Masculino" />
                    <asp:ListItem Value="F" Text="Feminino" />
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="txtTelefone" runat="server" placeholder="(00)91234-5678" MaxLength="13" OnKeyPress="formatar('## #####-####', this)" Width="50%" />

                <asp:DropDownList ID="ddlEstado" runat="server" Width="50%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" />

                <asp:DropDownList ID="ddlCidade" runat="server" Width="50%" />

                <asp:TextBox ID="txtBairro" runat="server" placeholder="Bairro" Width="50%" />

                <asp:TextBox ID="txtCEP" runat="server" placeholder="CEP" MaxLength="9" OnKeyPress="formatar('#####-###', this)" Width="50%" />

                <asp:TextBox ID="txtEndereco" runat="server" placeholder="Rua/Avenida" Width="50%" />

                <asp:TextBox ID="txtNumero" runat="server" placeholder="Nº" Width="50%" />

                <asp:TextBox ID="txtComplemento" runat="server" placeholder="Complemento" Width="50%" />

                <asp:TextBox ID="txtEmail" runat="server" placeholder="joaodasilva@ligaarena.com.br" Width="50%" />
                <asp:RegularExpressionValidator ID="revEmail" ForeColor="Red" ErrorMessage="Insira seu email" ValidationGroup="Cliente" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" SetFocusOnError="true" ControlToValidate="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente" />

                <asp:TextBox ID="txtSenha" runat="server" Width="50%" TextMode="Password" />
                <asp:RequiredFieldValidator ID="rfvtxtSenha" runat="server" ErrorMessage="*" ControlToValidate="txtSenha" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente" />

                <asp:TextBox ID="txtConfirmaSenha" runat="server" Width="50%" TextMode="Password" />
                <asp:CompareValidator ID="cvSenha" runat="server" ErrorMessage="Senha diferentes" ValidationGroup="Cliente" SetFocusOnError="True" ControlToValidate="txtSenha" ForeColor="Red" ControlToCompare="txtConfirmaSenha" />
                <br />
                <asp:Label ID="lblMenssagem" runat="server"></asp:Label>
                <br />

                <asp:LinkButton ID="btnVoltar" runat="server" CausesValidation="false" Text="Voltar" CssClass="but but-warning but-rc but-shadow but-size1" OnClick="btnVoltar_Click" />
                <asp:LinkButton ID="btnCadastrar" runat="server" CausesValidation="true" Text="Cadastrar" CssClass="but but-success but-rc but-shadow but-size1" OnClick="btnCadastrar_Click" />
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




