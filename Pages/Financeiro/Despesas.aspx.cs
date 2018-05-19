using LigaArena.Classes.Fincanceiro;
using LigaArena.Persistencia.Fincanceiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Financeiro_Despesas : System.Web.UI.Page
{
    private void CarregaDespesas()
    {
        CategoriaDespesaBD catBD = new CategoriaDespesaBD();
        DataSet ds = catBD.SelectAll();
        ddlCategoria.DataSource = ds.Tables[0].DefaultView;
        ddlCategoria.DataTextField = "CAD_DESCRICAO";
        ddlCategoria.DataValueField = "CAD_CODIGO";
        ddlCategoria.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDespesas();
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Despesas despesas = new Despesas();
        DespesasBD despesasBD = new DespesasBD();

        despesas.Descricao = txtTipoDespesa.Text;
        despesas.ValorDespesa = Convert.ToDouble(txtValorDespesa.Text);
        despesas.Categoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value);
        DateTime data = DateTime.Now;
        despesas.Data = data;

        despesas.Pessoa = Convert.ToInt32(Session["Proprietario"]);

        despesasBD.Insert(despesas);

        txtTipoDespesa.Text = string.Empty;
        txtValorDespesa.Text = string.Empty;


    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Administrativo/HomePageProprietario.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}