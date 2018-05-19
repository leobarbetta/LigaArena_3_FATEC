using LigaArena.Persistencia.Fincanceiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Financeiro_RelatorioDespesa : System.Web.UI.Page
{
    private void CarregaDespesas()
    {
        DespesasBD desBD = new DespesasBD();
        DataSet ds = desBD.SelectAll();
        gdvRelDespesas.DataSource = ds.Tables[0].DefaultView;
        gdvRelDespesas.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDespesas();
    }
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        DateTime data = Convert.ToDateTime(txtData1.Text);
        DespesasBD desBD = new DespesasBD();
        DataSet ds = desBD.SelectAllDespesas(data);
        gdvRelDespesas.DataSource = ds.Tables[0].DefaultView;
        gdvRelDespesas.DataBind();

        DataSet ds2 = desBD.SomaDespesa(data, Convert.ToDateTime(txtData2.Text));
        gdvTotal.DataSource = ds2.Tables[0].DefaultView;
        gdvTotal.DataBind();
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}