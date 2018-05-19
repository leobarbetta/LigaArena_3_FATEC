using LigaArena.Classes.Administrativo;
using LigaArena.Persistencia.Administrativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_AlterarFuncionario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int idFuncionario = Convert.ToInt32(Session["AlteraFuncionario"]);

            Funcionario fun = new Funcionario();
            FuncionarioBD funBD = new FuncionarioBD();

            fun = funBD.SelectFuncionario(idFuncionario);

            txtRegistro.Text = Convert.ToString(fun.NumeroRegistro);
            txtDataAdimissao.Text = fun.DataAdmissao.ToString("dd/MM/yyyy");
            txtSalario.Text = Convert.ToString(fun.Salario);
            ddlCargo.SelectedItem.Text = fun.Cargo;
        }
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Funcionario fun = new Funcionario();
        FuncionarioBD funBD = new FuncionarioBD();

        fun = funBD.SelectFuncionario(Convert.ToInt32(Session["AlteraFuncionario"]));

        fun.NumeroRegistro = Convert.ToInt32(txtRegistro.Text);
        fun.DataAdmissao = Convert.ToDateTime(txtDataAdimissao.Text);
        fun.Salario = Convert.ToDouble(txtSalario.Text);
        fun.Cargo = ddlCargo.SelectedItem.Text;

        funBD.Update(fun);


    }
    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("RelatorioFuncionarios.aspx");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}