using LigaArena.Classes.Fincanceiro;
using LigaArena.Classes.Producao;
using LigaArena.Persistencia.Fincanceiro;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_CadastroProduto : System.Web.UI.Page
{
    private void CarregaCategoria()
    {
        CategoriaBD catBD = new CategoriaBD();
        DataSet ds = catBD.SelectAll();
        ddlCategoria.DataSource = ds.Tables[0].DefaultView;
        ddlCategoria.DataTextField = "CAP_NOME";
        ddlCategoria.DataValueField = "CAP_CODIGO";
        ddlCategoria.DataBind();
        ListItem item = new ListItem("Selecione", "0");
        ddlCategoria.Items.Insert(0, item);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaCategoria();
        }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            Produto pro = new Produto();
            Categoria cat = new Categoria();
            Cardapio car = new Cardapio();
            Despesas des = new Despesas();
            DespesasBD desBD = new DespesasBD();


            pro.Descricao = txtNomeItem.Text;

            try
            {
                if (txtValordecusto.Text == string.Empty)
                {
                    pro.ValorCusto = 0;
                }
                else
                {
                    pro.ValorCusto = Convert.ToDouble(txtValordecusto.Text);
                }
            }
            catch (FormatException)
            {
                lblMensagem.Text = "Valor de custo invalido!";
            }
            try
            {
                if (txtDataValidade.Text == string.Empty)
                {
                    pro.DataValidade = Convert.ToDateTime("11/11/1111");
                }
                else
                {
                    pro.DataValidade = Convert.ToDateTime(txtDataValidade.Text);
                }
            }
            catch (FormatException)
            {
                lblMensagem.Text = "Data de Validade invalida";
            }

            try
            {
                if (txtQuantidadeMinima.Text == string.Empty)
                {
                    pro.QuantidadeAtual = 0;
                }
                else
                {
                    pro.QuantidadeAtual = Convert.ToInt32(txtAddProduto.Text);
                }
            }
            catch (FormatException)
            {
                lblMensagem.Text = "Qautnidade invalida!";

            }
            try
            {
                if (txtQuantidadeMinima.Text == string.Empty)
                {
                    pro.QuantidadeMinima = 0;
                }
                else
                {
                    pro.QuantidadeMinima = Convert.ToInt32(txtQuantidadeMinima.Text);
                }
            }
            catch (FormatException)
            {
                lblMensagem.Text = "quantidade minima invalida!";

            }
            pro.UnidadeMedida = txtUnidadeMedida.Text;
            pro.CodigoCategoria = ddlCategoria.SelectedItem.Value;

            
            car.Valor = Convert.ToDouble(txtValorVarejo.Text);

            ProdutoBD proBD = new ProdutoBD();
            CardapioBD carBD = new CardapioBD();

            des.Descricao = txtNomeItem.Text;
            des.Pessoa = Convert.ToInt32(1);
            des.ValorDespesa = Convert.ToDouble(txtAddProduto.Text) * Convert.ToDouble(txtValordecusto.Text);
            DateTime data = DateTime.Now;
            des.Data = data;
            desBD.InsertDespesaProdutos(des);

            if (rblVendaEstoque.SelectedItem.Value == "E")
            {
                proBD.Insert(pro);
                lblMensagem.Text = "Produto cadastrado com sucesso!";
            }
            else
            {
                //insert tbl produto
                proBD.Insert(pro);

                // insert tbl cardapio
                carBD.Insert(car);

                //recupera ultimo produto cadastrado na tbl produto
                int idProduto = proBD.GetUltimoID(pro);
                int idCardapio = carBD.GetUltimoID(car);

                carBD.InsertFKs(idCardapio, idProduto);
                
                lblMensagem.Text = "Produto Cadastrado com sucesso!";
            }

            txtAddProduto.Text = string.Empty;
            txtDataValidade.Text = string.Empty;
            txtNomeItem.Text = string.Empty;
            txtQuantidadeMinima.Text = string.Empty;
            txtUnidadeMedida.Text = string.Empty;
            txtValordecusto.Text = string.Empty;
            txtValorVarejo.Text = string.Empty;

            ddlCategoria.SelectedValue = "0";



        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageProprietario.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}