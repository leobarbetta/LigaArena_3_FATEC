using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtEmail.Focus();
        if (Convert.ToInt32(Session["Mensagem"]) == 1)
        {
            lblMensagem.Text = "Cadastro realizado com sucesso";
        }
    }
    protected void btnCdastrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastrar.aspx");
    }
    protected void btnCadastrarfuncinario_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastrarFuncionario.aspx");
    }
    protected void btnLogar_Click(object sender, EventArgs e)
    {
        ClienteBD cliBD = new ClienteBD();
        FuncionarioBD funBD = new FuncionarioBD();
        ProprietarioBD proBD = new ProprietarioBD();

        // a senha vai estar cripitografada no banco, para nao precisar descripitografar, usamos esse metodo e a senha que o usuario digita para logar fica cripitografada e eh comparada as duas senhas cripitografadas
        string senha = Crip.GetSHA256(txtSenha.Text);

        Cliente cli = cliBD.ValidaCliente(txtEmail.Text, senha, 2, 1);

        Funcionario fun = funBD.ValidaFuncionario(txtEmail.Text, senha, 1, 1);

        Proprietario pro = proBD.ValidaProprietario(txtEmail.Text, senha, 0);

        //2

        if (cli != null)
        {
            Session["Cliente"] = cli.Codigo;
            Response.Redirect("HomePageCliente.aspx");
        }
        else
        {
            lblMensagem.Text = "Usuario e/ou senha incorretos";
        }


        //1

        if (fun != null)
        {
            Session["Funcionario"] = fun.Codigo;
            Response.Redirect("HomePageFuncionario.aspx");
        }
        else
        {
            lblMensagem.Text = "Usuario e/ou senha incorretos";
        }


        //0
        if (pro != null)
        {
            Session["Proprietario"] = pro.Codigo;
            Response.Redirect("HomePageProprietario.aspx");
        }
        else
        {
            lblMensagem.Text = "Usuario e/ou senha incorretos";
        }
    }

}

