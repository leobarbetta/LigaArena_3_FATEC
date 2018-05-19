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

public partial class Pages_Administrativo_CadastroFuncionario : System.Web.UI.Page
{
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
        Funcionario funci = new Funcionario();
        Endereco end = new Endereco();
        Cidade cid = new Cidade();
        Estado est = new Estado();

       
            System.Globalization.CultureInfo PrimeiraLetra = System.Threading.Thread.CurrentThread.CurrentCulture; //usar classe cultureinfo da namespace globalization

            funci.Nome = txtNome.Text;
            funci.Nome = PrimeiraLetra.TextInfo.ToTitleCase(funci.Nome);
            funci.Nome = funci.Nome.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");
            funci.CPF = txtCEP.Text;
            try
            {
                funci.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "Data de nascimento invalida";
            }
            ddlSexo.Items.Insert(0, "Selecione");
            if (ddlSexo.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione um sexo";
            }
            else
            {
                funci.Sexo = ddlSexo.SelectedItem.Value;
            }

            if (ddlEstado.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione um estado";
            }
            if (ddlCidade.SelectedItem.Text == "Selecione")
            {
                lblMenssagem.Text = "Selecione uma cidade";
            }
            funci.Telefone = txtTelefone.Text;

            end.Bairro = txtBairro.Text;
            end.Bairro = PrimeiraLetra.TextInfo.ToTitleCase(end.Bairro);
            end.Bairro = end.Bairro.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");

            end.CEP = txtCEP.Text;

            end.Logradouro = txtEndereco.Text;
            end.Logradouro = PrimeiraLetra.TextInfo.ToTitleCase(end.Logradouro);
            end.Logradouro = end.Logradouro.Replace("De ", "de ").Replace("Da ", "da ").Replace("Das ", "das ").Replace("Dos ", "dos ");

            end.Numero = txtNumero.Text;
            end.Complemento = txtComplemento.Text;

            funci.NumeroRegistro = Convert.ToInt32(txtRegistro.Text);
            funci.Cargo = ddlCargo.SelectedItem.Text;
            try
            {
                funci.DataAdmissao = Convert.ToDateTime(txtDataAdimissao.Text);
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "Data de Adimissao invalida!!";
            }
            try
            {
                funci.Salario = Convert.ToDouble(txtSalario.Text);
            }
            catch (FormatException)
            {
                lblMenssagem.Text = "Salario invalido!!";
            }
            funci.Email = txtEmail.Text;
            funci.Senha = Crip.GetSHA256(txtSenha.Text);

            end.CodigoCidade = Convert.ToInt32(ddlCidade.SelectedItem.Value);

            FuncionarioBD funBD = new FuncionarioBD();
            EnderecoBD endBD = new EnderecoBD();
            CidadeBD cidBD = new CidadeBD();
            EstadoBD estBD = new EstadoBD();

            // verifica se email e ou cpf ja existem, se nao existir o cadastro é realisado 
            if (funBD.VerificarEmail(txtEmail.Text) != null)
            {
                lblMenssagem.Text = "Email ja existe";
            }
            else if (funBD.VerificarCPF(txtCPF.Text) != null)
            {
                lblMenssagem.Text = "CPF ja existe";
            }
            else
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
                    funci.Endereco = endBD.SelectEndereco(idEndereco);

                    if (funBD.Insert(funci))
                    {
                        txtNome.Text = string.Empty;
                        txtCPF.Text = string.Empty;
                        txtDataNascimento.Text = string.Empty;
                        ddlSexo.SelectedItem.Text = "Selecione";
                        txtTelefone.Text = string.Empty;
                        txtBairro.Text = string.Empty;
                        txtCEP.Text = string.Empty;
                        txtEndereco.Text = string.Empty;
                        txtNumero.Text = string.Empty;
                        txtComplemento.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtRegistro.Text = string.Empty;
                        ddlCargo.SelectedItem.Text = "Selecione";
                        txtDataAdimissao.Text = string.Empty;
                        txtSalario.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        txtConfirmaSenha.Text = string.Empty;
                        for (int i = 0; i < ddlCidade.Items.Count; i++)
                        {
                            ddlCidade.Items[i].Selected = false;
                        }
                        for (int i = 0; i < ddlEstado.Items.Count; i++)
                        {
                            ddlEstado.Items[i].Selected = false;
                        }
                    }
                    else
                    {
                        lblMenssagem.Text = "Erro no Cadastro";
                    }

                
            }
        //final do try 
        
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageProprietario.aspx");
    }
    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaCidade();
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}