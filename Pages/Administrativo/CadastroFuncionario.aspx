<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroFuncionario.aspx.cs" Inherits="Pages_Administrativo_CadastroFuncionario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Cadastrar Funcionario</title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/EstiloPaginas.css" rel="stylesheet" />
    <link href="../Css/EstiloBotoes.css" rel="stylesheet" />
</head>

<script src="../JavaScript/MascaraCampos.js"></script>
<script src="../JavaScript/jQuery.js"></script>
<script src="../JavaScript/maskMoney.js"></script>
<script src="../JavaScript/Menu.js"></script>
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
                                <li><a href="CadastroFuncionario.aspx">Funcionario</a></li>
                                <li><a href="Cadastrar.aspx">Cliente</a></li>
                                <li><a href="../Financeiro/Despesas.aspx">Despesa</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#">Relatorios</a>
                            <ul>
                                <li><a href="RelatorioClientes.aspx">Clientes Cadastrados</a></li>
                                <li><a href="RelatorioFuncionarios.aspx">Funcionarios Cadastrados</a></li>
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
                        <li><a href="RelatorioFeedback.aspx">Visualizar FeedBacks</a></li>
                        <li> <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">SAIR</asp:LinkButton> </li>
                        
                    </ul>
                </nav>

            </section>
            <!-- fim do menu -->
            <section class="conteudo-site">
                <h1>CADASTRAR FUNCIONÁRIO</h1>

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
                    <p>Numero de Registro:</p>
                    <p>Cargo:</p>
                    <p>Data Admissão:</p>
                    <p>Salário:</p>
                    <p>Senha:</p>
                    <p>Confirmar Senha:</p>
                </section>

                <section class="campos">

                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome Completo" Width="50%" />
                    <asp:RequiredFieldValidator ID="rfvtxtNome" runat="server" ErrorMessage="Insira seu Nome" ControlToValidate="txtNome" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Funcionario" />


                    <asp:TextBox ID="txtCPF" runat="server" placeholder="XXX.XXX.XXX-XX" MaxLength="14" OnKeyPress="formatar('###.###.###-##', this)" Width="50%" />
                    <asp:RequiredFieldValidator ID="rvftxtCPF" runat="server" ErrorMessage="*" ControlToValidate="txtCPF" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Funcionario" />

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
                    <asp:RegularExpressionValidator ID="revEmail" ForeColor="Red" ValidationGroup="Funcionario" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" SetFocusOnError="true" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Invalido" />
                    <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Funcionario" />
                    <br />
                    <asp:TextBox ID="txtRegistro" runat="server" Width="50%" />

                    <br />
                    <asp:DropDownList ID="ddlCargo" runat="server">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="1" Text="Garçom" />
                        <asp:ListItem Value="2" Text="Chapeiro" />
                        <asp:ListItem Value="3" Text="Ajudante Geral" />
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txtDataAdimissao" runat="server" placeholder="01/01/2010" MaxLength="10" OnKeyPress="formatar('##/##/####', this)" Width="50%" />

                    <asp:TextBox ID="txtSalario" runat="server" class="monetario" Width="50%" />

                    <asp:TextBox ID="txtSenha" runat="server" Width="50%" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rfvtxtSenha" runat="server" ErrorMessage="*" ControlToValidate="txtSenha" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Funcionario" />

                    <asp:TextBox ID="txtConfirmaSenha" runat="server" Width="50%" TextMode="Password" />
                    <asp:CompareValidator ID="cvSenha" runat="server" ErrorMessage="Senha Inválida" SetFocusOnError="True" ControlToValidate="txtSenha" ForeColor="Red" ControlToCompare="txtConfirmaSenha" ValidationGroup="Funcionario" />

                    <br />
                    <asp:Label ID="lblMenssagem" runat="server" ForeColor="Red" />
                    <br />
                    <asp:LinkButton ID="btnVoltar" runat="server" Text="Voltar" CssClass="but but-error but-rc but-shadow but-size1" CausesValidation="false" OnClick="btnVoltar_Click" />

                    <asp:LinkButton ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="but but-success but-shadow but-rc but-size1" OnClick="btnCadastrar_Click" />

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

