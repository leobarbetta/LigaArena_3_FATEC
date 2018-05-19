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

public partial class Pages_Producao_AdicionaProduto : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        ProdutoBD proBD = new ProdutoBD();

        DataSet ds = proBD.SelectProdutoDS(Convert.ToInt32(Session["idProduto"]));

        gdvAddProdutos.DataSource = ds.Tables[0].DefaultView;
        gdvAddProdutos.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Produto pro = new Produto();
            ProdutoBD proBD = new ProdutoBD();
            pro = proBD.SelectProduto(Convert.ToInt32(Session["idProduto"]));
            int var = Convert.ToInt32(Session["idProduto"]);
            txtCusto.Text = Convert.ToString(pro.ValorCusto);
            CarregaGrid();
        }
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Produto pro = new Produto();
        ProdutoBD proBD = new ProdutoBD();
        Despesas des = new Despesas();
        DespesasBD desBD = new DespesasBD();
        pro = proBD.SelectProduto(Convert.ToInt32(Session["idProduto"]));
        proBD.UpdateCusto(Convert.ToDouble(txtCusto.Text), Convert.ToInt32(Session["idProduto"]));

        des.Descricao = pro.Descricao;
        des.Pessoa = Convert.ToInt32(Session["Proprietario"]);
        des.ValorDespesa = Convert.ToDouble(txtAdd.Text) * Convert.ToDouble(txtCusto.Text);
        DateTime data = DateTime.Now;
        des.Data = data;
        desBD.InsertDespesaProdutos(des);

       
        proBD.AddProduto(Convert.ToInt32(Session["idProduto"]), Convert.ToInt32(txtAdd.Text));

        CarregaGrid();
        txtAdd.Text = string.Empty;

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Producao/RelatorioProdutos.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}