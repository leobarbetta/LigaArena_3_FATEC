using LigaArena.Classes.Producao;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RecebePedido : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        PedidoBD pedBD = new PedidoBD();
        DataSet ds = pedBD.RecebePedido();
        gdvRecebePedido.DataSource = ds.Tables[0].DefaultView;
        gdvRecebePedido.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaGrid();
    }
    protected void gdvRecebePedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "status":
                int id = Convert.ToInt32(e.CommandArgument);
                
                PedidoBD pedBD = new PedidoBD();
                Pedido ped = new Pedido();
                ped.Codigo = id;
                
                ped.Status = 1;
                pedBD.UpdateStatus(ped);
                CarregaGrid();
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