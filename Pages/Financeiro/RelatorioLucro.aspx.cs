using LigaArena.Persistencia.Fincanceiro;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RelatorioLucro : System.Web.UI.Page
{
    private void CarregaVendas()
    {
        PedidoBD pedBD = new PedidoBD();
        DataSet ds = pedBD.TotalVendas(Convert.ToDateTime(txtData.Text), Convert.ToDateTime(txtData2.Text));
        gdvRelatorioVendas1.DataSource = ds.Tables[0].DefaultView;
        gdvRelatorioVendas1.DataBind();
    }
    private void CarregaDespesas()
    {
        DespesasBD desBD = new DespesasBD();
        DataSet ds = desBD.SomaDespesa(Convert.ToDateTime(txtData.Text), Convert.ToDateTime(txtData2.Text));
        gdvRelatorioDespesas.DataSource = ds.Tables[0].DefaultView;
        gdvRelatorioDespesas.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExibir_Click(object sender, EventArgs e)
    {
        PedidoBD pedBD = new PedidoBD();
        DespesasBD desBD = new DespesasBD();
        CarregaVendas();
        CarregaDespesas();
        double totalVenda = pedBD.SelectVendasSemDataSet(Convert.ToDateTime(txtData.Text), Convert.ToDateTime(txtData2.Text));
        double totalDespesa = desBD.SelectDespesaSemDataSet(Convert.ToDateTime(txtData.Text), Convert.ToDateTime(txtData2.Text));

        double lucro = totalVenda - totalDespesa;

        lblLucro.Text = Convert.ToString(lucro);


    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}