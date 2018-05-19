using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_HomePage : System.Web.UI.Page
{
    //metodo carrega todos estados ja cadastrados no banco de dados
    private void CarregaEstado()
    {
        EstadoBD estadobd = new EstadoBD();
        DataSet ds = estadobd.SelectAll();
        ddlEstado.DataSource = ds.Tables[0].DefaultView;
        ddlEstado.DataTextField = "est_uf";
        ddlEstado.DataValueField = "est_codigo";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, "Selecione");
        txtNome.Focus();
    }

    private void CarregaCidade()
    {
        CidadeBD cidadebd = new CidadeBD();
        DataSet ds = cidadebd.SelectAllByState(Convert.ToInt32(ddlEstado.SelectedItem.Value));
        ddlCidade.DataSource = ds.Tables[0].DefaultView;
        ddlCidade.DataTextField = "cid_descricao";
        ddlCidade.DataValueField = "cid_codigo";
        ddlCidade.DataBind();
        ddlCidade.Items.Insert(0, "Selecione");
        ddlCidade.Focus();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaEstado();
        }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente cli = new Cliente();
            Endereco end = new Endereco();
            Cidade cid = new Cidade();
            Estado est = new Estado();

            //usar classe cultureinfo que faz com que todas string jogada para variavel "PrimeiraLetra" tenha a primeira letra de cada palavra maiuscula
            //e em seguida as stopword tem um replace para minuscula 
            System.Globalization.CultureInfo PrimeiraLetra = System.Threading.Thread.CurrentThread.CurrentCulture;

            cli.Nome = txtNome.Text;
            cli.Nome = PrimeiraLetra.TextInfo.ToTitleCase(cli.Nome);
            cli.Nome = cli.Nome.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");

            try
            {
                cli.CPF = txtCPF.Text;
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "CPF Invalido";
            }
            try
            {
                cli.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "Data invalida";
            }
            try
            {
                cli.Telefone = txtTelefone.Text;
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "Telefone Invalido";
            }

            ddlSexo.Items.Insert(0, "Selecione");
            if (ddlSexo.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione um sexo";
            }
            else
            {
                cli.Sexo = ddlSexo.SelectedItem.Value;
            }

            if (ddlEstado.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione um estado";
            }
            if (ddlCidade.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione uma cidade";
            }

            est.UF = ddlEstado.Text;

            end.Bairro = txtBairro.Text;
            end.Bairro = PrimeiraLetra.TextInfo.ToTitleCase(end.Bairro);
            end.Bairro = end.Bairro.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");
            end.CEP = txtCEP.Text;
            end.Logradouro = txtEndereco.Text;
            end.Logradouro = PrimeiraLetra.TextInfo.ToTitleCase(end.Logradouro);
            end.Logradouro = end.Logradouro.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");

            end.Numero = txtNumero.Text;
            end.Complemento = txtComplemento.Text;
            cli.Email = txtEmail.Text;

            DateTime data = DateTime.Now;

            cli.DataCadastro = data;

            //criptografica a senha no banco 
            cli.Senha = Crip.GetSHA256(txtSenha.Text);

            end.CodigoCidade = Convert.ToInt32(ddlCidade.SelectedItem.Value);

            ClienteBD cliBD = new ClienteBD();
            EnderecoBD endBD = new EnderecoBD();
            CidadeBD cidBD = new CidadeBD();
            EstadoBD estBD = new EstadoBD();

            // verifica se email e ou cpf ja existem, se nao existir o cadastro é realisado 
            if (cliBD.VerificarEmail(txtEmail.Text) != null)
            {
                lblMenssagem.Text = "Email ja existe";
            }
            else if (cliBD.VerificarCPF(txtCPF.Text) != null)
            {
                lblMenssagem.Text = "CPF ja existe";
            }
            else
            {

                try
                {
                    //insert no endereco
                    if (endBD.Insert(end))
                    {
                    }
                    else
                    {
                        lblMenssagem.Text = "Erro no endereço";
                    }

                    //recupera o PK do ultimo endereço cadastrado
                    int idEndereco = endBD.GetUltimoID(end);

                    //atribui o valor da FK para cli.endereco para dar insert na tabela
                    cli.Endereco = endBD.SelectEndereco(idEndereco);

                    if (cliBD.Insert(cli))
                    {
                        Session["Mensagem"] = 1;
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        lblMenssagem.Text = "Erro no cliente";
                    }

                }
                catch (MySqlException ex)
                {
                    lblMenssagem.Text = ex.Message;
                }
            }

         //catch de todo codigo
        }
        catch (Exception ex)
        {

            lblMenssagem.Text = "Erro: " + ex.Message;
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }



    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaCidade();
    }

}