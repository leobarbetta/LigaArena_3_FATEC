using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_AlterarSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ClienteBD cliBD = new ClienteBD();

        // a senha vai estar cripitografada no banco, para nao precisar descripitografar, usamos esse metodo e a senha que o usuario digita para logar fica cripitografada e eh comparada as duas senhas cripitografadas
        string senha = Crip.GetSHA256(txtSenhaAntiga.Text);

        Cliente cli = cliBD.ValidaCliente(txtEmail.Text, senha, 2, 1);

        if (cli != null)
        {
            cli.Senha = Crip.GetSHA256(txtsenha2.Text);
            cliBD.UpdateSenha(cli);
            lblMensagem.Text = "Senha alterada com sucesso";
        }
        else
        {
            lblMensagem.Text = "Senha e/ou email errado";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageCliente");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}