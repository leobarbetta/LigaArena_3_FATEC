<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Administrativo_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <meta charset="utf-8" />
    <title>Liga Arena</title>
  
    <link rel="stylesheet" href="../Css/estiloLogin.css" />

</head>

<body>

    <form id="form1" runat="server">


        <figure>
            <img src="../Imagens/logoOficial.png" style="height: 413px; width: 413px" />
        </figure>


        <div id="radio-button">
        </div>

        <div id="user-senha">
            <div id="label">
                <p>Email:</p>
                <p>Senha:</p>
            </div>

            <div id="campos">
                <asp:TextBox ID="txtEmail" runat="server" Width="50%" />
                <asp:RegularExpressionValidator ID="revEmail" ForeColor="Red" ValidationGroup="Login" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" SetFocusOnError="true" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Invalido" />
                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ErrorMessage="Insira seu email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Login" />
                <br />
                <br />
                <asp:TextBox ID="txtSenha" runat="server" Width="50%" TextMode="Password" />
                <br />
                
                <br />
                <br />
                <asp:Label ID="lblMensagem" runat="server" ForeColor="" />
            </div>
        </div>

        <br />

        <div id="botoes">
            <asp:LinkButton ID="btnLogar" runat="server" Text="Login" CssClass="but but-success but-shadow but-rc" Width="150px" OnClick="btnLogar_Click" />
            <br />
            <br />
            <asp:LinkButton ID="btnCdastrar" runat="server" Text="Cadastrar Cliente" CssClass="but but-primary but-shadow but-rc" Width="150px" OnClick="btnCdastrar_Click" />
        </div>

    </form>
</body>
</html>
