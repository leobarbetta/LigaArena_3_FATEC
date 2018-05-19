using LigaArena.Classes.Producao;
using LigaArena.Persistencia.Administrativo;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_FinalizarConta : System.Web.UI.Page
{
    private void CarregaCliente()
    {
        ClienteBD cliBD = new ClienteBD();
        DataSet ds3 = cliBD.SelectAll();
        ddlCliente.DataSource = ds3.Tables[0].DefaultView;
        ddlCliente.DataValueField = "PES_CODIGO";
        ddlCliente.DataTextField = "PES_NOME";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, "Selecione");

    }
    private void CarregaGrid()
    {
        PedidoBD proBD = new PedidoBD();
        DataSet ds = proBD.SelectContaCliente(Convert.ToInt32(ddlCliente.SelectedItem.Value));
        gdvFinalizarConta.DataSource = ds.Tables[0].DefaultView;
        gdvFinalizarConta.DataBind();

        DataSet ds2 = proBD.RetornaTotal(Convert.ToInt32(ddlCliente.SelectedItem.Value));
        gdvTotal.DataSource = ds2.Tables[0].DefaultView;
        gdvTotal.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaCliente();
        }
    }
    protected void btnFechaConta_Click(object sender, EventArgs e)
    {
        Pedido ped = new Pedido();
        PedidoBD pedBD = new PedidoBD();
        ped = pedBD.Select(Convert.ToInt32(ddlCliente.SelectedItem.Value));
        ped.Pago = 1;
        if (pedBD.UpdatePago(ped))
        {
            lblFinal.Text = "Conta Paga";
        }
        CarregaGrid();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageFuncionario.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaGrid();
    }
}