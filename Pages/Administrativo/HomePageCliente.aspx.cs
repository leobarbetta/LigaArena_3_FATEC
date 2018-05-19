using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_HomePageCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSenha_Click(object sender, EventArgs e)
    {
        Response.Redirect("AlterarSenha.aspx");
    }
    protected void btnAlteradados_Click(object sender, EventArgs e)
    {

    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }

}