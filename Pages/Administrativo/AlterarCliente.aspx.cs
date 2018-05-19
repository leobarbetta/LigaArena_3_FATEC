using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_AlterarCliente : System.Web.UI.Page
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

        ListItem item = new ListItem("Selecione", "0");

        ddlCidade.Items.Insert(0, item);
    }
    private void CarregaCidade(int estado)
    {
        CidadeBD cidadebd = new CidadeBD();
        DataSet ds = cidadebd.SelectAllByState(estado);
        ddlCidade.DataSource = ds.Tables[0].DefaultView;
        ddlCidade.DataTextField = "cid_descricao";
        ddlCidade.DataValueField = "cid_codigo";
        ddlCidade.DataBind();
        ddlCidade.Items.Insert(0, "Selecione");
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ClienteBD cliBD = new ClienteBD();
            EnderecoBD endBD = new EnderecoBD();
            EstadoBD estBD = new EstadoBD();
            CidadeBD cidBD = new CidadeBD();


            Cliente cli = new Cliente();
            Endereco end = new Endereco();
            Estado est = new Estado();
            Cidade cid = new Cidade();

            int id = Convert.ToInt32(Session["CLIENTE"]);

            // cliente recebe informações de seu codigo
            cli = cliBD.SelectCliente(id);
            
             //recupera FK de endereço
            int FKendereco = cli.FkEndereco;

            // recupera FK de cidade
            end = endBD.SelectEndereco(FKendereco);

            // recupera fk de cidade
            int FKCidade = end.CodigoCidade;

            cid = cidBD.SelectCidade(FKCidade);

            int FKEstado = cid.Codestado;

            est = estBD.SelectEstado(FKEstado);

            string estado = est.Descricao;

           
            txtNome.Text = cli.Nome;
            txtCPF.Text = cli.CPF;
            txtDataNascimento.Text = cli.DataNascimento.ToString("dd/MM/yyyy");
            ddlSexo.SelectedValue = cli.Sexo;
            txtTelefone.Text = cli.Telefone;


            SelecionaEstado(FKEstado);
            SelecionaCidade(FKEstado, FKCidade);


            //carrega cidade ja de acordo com valor selecionado no ddestado
            //CarregaCidade();
         
            txtBairro.Text = end.Bairro;
            txtCEP.Text = end.CEP;
            txtEndereco.Text = end.Logradouro;
            txtNumero.Text = end.Numero;
            txtComplemento.Text = end.Complemento;

        }

    }

    private void SelecionaEstado(int estado)
    {
        CarregaEstado();

        for (int i = 0; i < ddlEstado.Items.Count; i++)
        {
            ddlEstado.Items[i].Selected = false;
        }

        for (int i = 0; i < ddlEstado.Items.Count; i++)
        {
            if (ddlEstado.Items[i].Text != "Selecione")
            {
                if (Convert.ToInt32(ddlEstado.Items[i].Value) == estado)
                {
                    ddlEstado.Items[i].Selected = true;
                    break;

                }
            }
        }
    
    }

    private void SelecionaCidade(int estado, int cidade)
    {
        CarregaCidade(estado);

        for (int i = 0; i < ddlCidade.Items.Count; i++)
        {
            ddlCidade.Items[i].Selected = false;
        }

        for (int i = 0; i < ddlCidade.Items.Count; i++)
        {
            if (ddlCidade.Items[i].Text != "Selecione")
            {
                if (Convert.ToInt32(ddlCidade.Items[i].Value) == cidade)
                {
                    ddlCidade.Items[i].Selected = true;
                    break;

                }
            }
        }

    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ClienteBD cliBD = new ClienteBD();
        Cliente cli = new Cliente();
        EnderecoBD endBD = new EnderecoBD();
        Endereco end = new Endereco();

        cli = cliBD.SelectCliente(Convert.ToInt32(Session["CLIENTE"]));
        end = endBD.SelectEndereco(Convert.ToInt32(Session["CLIENTE"]));

        cli.Nome = txtNome.Text;
        cli.CPF = txtCPF.Text;
        cli.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
        cli.Sexo = ddlSexo.SelectedItem.Value;
        cli.Telefone = txtTelefone.Text;



        end.Bairro = txtBairro.Text;
        end.CEP = txtCEP.Text;
        end.Logradouro = txtEndereco.Text;
        end.Numero = txtNumero.Text;
        end.Complemento = txtComplemento.Text;
        //end.CodigoCidade = ddlCidade.SelectedValue;


        if ((cliBD.Update(cli)) && (endBD.Update(end)))
        {

            lblMensagem.Text = "atualizado";
        }
        else
        {
            lblMensagem.Text = "DEU PAU!";
        }

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageCliente.aspx");
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