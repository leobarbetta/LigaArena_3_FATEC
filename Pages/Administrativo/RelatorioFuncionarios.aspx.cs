using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_RelatorioFuncionarios : System.Web.UI.Page
{
    private void CarregaGrid()
    {
        FuncionarioBD funBD = new FuncionarioBD();

        DataSet ds = funBD.SelectAll();

        gdvFuncionario.DataSource = ds.Tables[0].DefaultView;
        gdvFuncionario.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaGrid();
    }
    protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        FuncionarioBD funBD = new FuncionarioBD();
        Funcionario fun = new Funcionario();
        switch (e.CommandName)
        {
            case "AD":

                int idFuncionario = 0;
                idFuncionario = Convert.ToInt32(e.CommandArgument);
                //ira ativar ou desativar o cliente
                funBD.SelectFuncionario(idFuncionario);

                fun= funBD.SelectFuncionario(Convert.ToInt32(idFuncionario));

                int ativo = fun.Ativo;

                if (ativo == 1)
                {
                    fun = funBD.SelectFuncionario(Convert.ToInt32(idFuncionario));

                    fun.Ativo = 0;
                    funBD.Update(fun);
                    CarregaGrid();

                }
                else
                {
                    fun = funBD.SelectFuncionario(Convert.ToInt32(idFuncionario));

                    fun.Ativo = 1;
                    funBD.Update(fun);
                    CarregaGrid();

                }

                break;
            case "Editar":
                idFuncionario = Convert.ToInt32(e.CommandArgument);
                Session["AlteraFuncionario"] = idFuncionario;
                Response.Redirect("AlterarFuncionario.aspx");
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