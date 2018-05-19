using LigaArena.Classes.Producao;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Producao_RelatorioProdutos : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        ProdutoBD proBD = new ProdutoBD();
        DataSet ds = proBD.SelectAllProducts();
        gdvProdutos.DataSource = ds.Tables[0].DefaultView;
        gdvProdutos.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaGrid();
    }

    protected void gdvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ProdutoBD proBD = new ProdutoBD();
        Produto pro = new Produto();

        int idProduto = 0;
        switch (e.CommandName)
        {
            case "ativo":

                idProduto = Convert.ToInt32(e.CommandArgument);
                //ira ativar ou desativar o cliente
                proBD.SelectProduto(idProduto);

                pro = proBD.SelectProduto(Convert.ToInt32(idProduto));

                int ativo = pro.Ativo;

                if (ativo == 1)
                {
                    pro = proBD.SelectProduto(Convert.ToInt32(idProduto));

                    pro.Ativo = 0;
                    proBD.Update(pro);
                    CarregaGrid();
                }
                else
                {
                    pro = proBD.SelectProduto(Convert.ToInt32(idProduto));

                    pro.Ativo = 1;
                    proBD.Update(pro);
                    CarregaGrid();
                }

                break;
            case "add":
                Session["idProduto"] = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("AdicionaProduto.aspx");
                break;
        }
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}