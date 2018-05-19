using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RelatorioClientes : System.Web.UI.Page
{
    private void CarregaGrid()
    {
       ClienteBD cliBD = new ClienteBD();

        DataSet ds = cliBD.SelectAll();

        gdvClientes.DataSource = ds.Tables[0].DefaultView;
        gdvClientes.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaGrid();

    }
    protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ClienteBD cliBD = new ClienteBD();
        Cliente cli = new Cliente();

        int idCliente = 0;
        switch (e.CommandName)
        {
            case "AD":
                idCliente = Convert.ToInt32(e.CommandArgument);
                //ira ativar ou desativar o cliente
                cliBD.SelectCliente(idCliente);

                cli = cliBD.SelectCliente(Convert.ToInt32(idCliente));

                int ativo = cli.Ativo;

                if (ativo == 1)
                {
                    cli = cliBD.SelectCliente(Convert.ToInt32(idCliente));

                    cli.Ativo = 0;
                    cliBD.Update(cli);
                    CarregaGrid();
                }
                else
                {
                    cli = cliBD.SelectCliente(Convert.ToInt32(idCliente));

                    cli.Ativo = 1;
                    cliBD.Update(cli);
                    CarregaGrid();
                }

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