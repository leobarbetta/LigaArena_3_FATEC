using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_FeedBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        FeedBack feed = new FeedBack();
        FeedBackBD feedBD = new FeedBackBD();
        Cliente cli = new Cliente();

        feed.Nota = Convert.ToInt32(rblFeedBack.SelectedItem.Value);
        feed.Descricao = Convert.ToString(txtFeedBack.Text);

        //ira receber o id do cliente que esta dando o feedback
        feed.PesCodigo = Convert.ToInt32(Session["Cliente"]);

        feedBD.Insert(feed);
        Response.Redirect("HomePageCliente.aspx");

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageCliente.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}