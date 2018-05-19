using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RelatorioFeedback : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        FeedBackBD feedBD = new FeedBackBD();
        DataSet ds = feedBD.SelectAll();

        gdvFeedback.DataSource = ds.Tables[0].DefaultView;
        gdvFeedback.DataBind();

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