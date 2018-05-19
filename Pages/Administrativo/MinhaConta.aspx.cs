using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_MinhaConta : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        PedidoBD proBD = new PedidoBD();
        DataSet ds = proBD.SelectContaCliente(Convert.ToInt32(Session["Cliente"]));
        gdvMinhaConta.DataSource = ds.Tables[0].DefaultView;
        gdvMinhaConta.DataBind();

        DataSet ds2 = proBD.RetornaTotal(Convert.ToInt32(Session["Cliente"]));
        gdvTotal.DataSource = ds2.Tables[0].DefaultView;
        gdvTotal.DataBind();
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaGrid();
    }
        protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}
