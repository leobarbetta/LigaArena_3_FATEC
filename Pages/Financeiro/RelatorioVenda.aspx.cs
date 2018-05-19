using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RelatorioVenda : System.Web.UI.Page
{
    private void CarregaVendas()
    {
        PedidoBD pedBD = new PedidoBD();
        DataSet ds = pedBD.SelectVendas(Convert.ToDateTime(txtData.Text), Convert.ToDateTime(txtData2.Text));
        gdvRelatorioVendas.DataSource = ds.Tables[0].DefaultView;
        gdvRelatorioVendas.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnExibir_Click(object sender, EventArgs e)
    {
        CarregaVendas();
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}