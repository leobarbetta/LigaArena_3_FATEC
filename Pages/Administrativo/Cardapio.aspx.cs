using LigaArena.Classes.Producao;
using LigaArena.Persistencia.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Administrativo_Cardapio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensagem.Visible = false;
        if (!Page.IsPostBack)
        {
            CarregaLanches();
            CarregaADCLanches();
            Carregaporcao();
            CarregaAcai();
            CarregaADCAacai();
            CarregaDiversos();
        }
    }

        
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Pedido ped = new Pedido();

        PedidoBD pedBD = new PedidoBD();

        CardapioBD carBD = new CardapioBD();

        ProdutoBD proBD = new ProdutoBD();

        ped.FKPessoa = Convert.ToInt32(Session["Cliente"]);

        ped.Numeromesa = Convert.ToInt32(txtMesa.Text);

        // a principio o usuario so podera pedir um item de cada vez
        ped.QuantidadeItem = 1;

        DateTime data = DateTime.Now;
        ped.DataHoraPedido = data;

        pedBD.Insert(ped);

        int FKPedido = pedBD.GetUltimoID(ped);
        


        for (int i = 0; i < cblLanches.Items.Count; i++)
        {
            if (cblLanches.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblLanches.Items[i].Value);
               
                double valorItem = carBD.SelectValor(fkLanche);
                
                pedBD.InsertFK(FKPedido, fkLanche, valorItem);
                
                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }
        for (int i = 0; i < cblADCLanches.Items.Count; i++)
        {
            if (cblADCLanches.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblADCLanches.Items[i].Value);

                double valorItem = carBD.SelectValor(fkLanche);

                pedBD.InsertFK(FKPedido, fkLanche, valorItem);


                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }
        for (int i = 0; i < cblPorções.Items.Count; i++)
        {
            if (cblPorções.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblPorções.Items[i].Value);

                double valorItem = carBD.SelectValor(fkLanche);

                pedBD.InsertFK(FKPedido, fkLanche, valorItem);

                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }
        for (int i = 0; i < cblAcai.Items.Count; i++)
        {
            if (cblAcai.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblAcai.Items[i].Value);

                double valorItem = carBD.SelectValor(fkLanche);

                pedBD.InsertFK(FKPedido, fkLanche, valorItem);

                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }
        for (int i = 0; i < cblADCAcai.Items.Count; i++)
        {
            if (cblADCAcai.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblADCAcai.Items[i].Value);

                double valorItem = carBD.SelectValor(fkLanche);

                pedBD.InsertFK(FKPedido, fkLanche, valorItem);

                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }
        for (int i = 0; i < cblDiversos.Items.Count; i++)
        {
            if (cblDiversos.Items[i].Selected)
            {
                int fkLanche = Convert.ToInt32(cblDiversos.Items[i].Value);

                double valorItem = carBD.SelectValor(fkLanche);

                pedBD.InsertFK(FKPedido, fkLanche, valorItem);

                int variavel = proBD.SelectProdutoPelaFK(fkLanche);

                proBD.UpdateEstoque(variavel);
            }

        }


        double valortoal = Convert.ToDouble(pedBD.SomaPedido(FKPedido));

        ped.Codigo = FKPedido;
        ped.ValorTotal = valortoal;
        pedBD.UpdateValorTotal(ped);

        txtMesa.Text = string.Empty;

        cblLanches.ClearSelection();
        cblADCLanches.ClearSelection();
        cblAcai.ClearSelection();
        cblADCAcai.ClearSelection();
        cblPorções.ClearSelection();
        cblDiversos.ClearSelection();
        lblMensagem.Visible = true;

    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }


    // check box list do cardapio, separado por categoria
    private void CarregaLanches()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllLanches();
        cblLanches.DataSource = ds.Tables[0].DefaultView;
        cblLanches.DataValueField = "CAR_CODIGO";
        cblLanches.DataTextField = "DESCRICAO";
        cblLanches.DataBind();
    }
    private void CarregaADCLanches()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllADCLanches();
        cblADCLanches.DataSource = ds.Tables[0].DefaultView;
        cblADCLanches.DataValueField = "CAR_CODIGO";
        cblADCLanches.DataTextField = "DESCRICAO";
        cblADCLanches.DataBind();
    }
    private void Carregaporcao()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllPorcoes();
        cblPorções.DataSource = ds.Tables[0].DefaultView;
        cblPorções.DataValueField = "CAR_CODIGO";
        cblPorções.DataTextField = "DESCRICAO";
        cblPorções.DataBind();
    }
    private void CarregaAcai()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllAcai();
        cblAcai.DataSource = ds.Tables[0].DefaultView;
        cblAcai.DataValueField = "CAR_CODIGO";
        cblAcai.DataTextField = "DESCRICAO";
        cblAcai.DataBind();
    }
    private void CarregaADCAacai()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllADCAcai();
        cblADCAcai.DataSource = ds.Tables[0].DefaultView;
        cblADCAcai.DataValueField = "CAR_CODIGO";
        cblADCAcai.DataTextField = "DESCRICAO";
        cblADCAcai.DataBind();
    }
    private void CarregaDiversos()
    {
        CardapioBD carBD = new CardapioBD();

        DataSet ds = carBD.SelectAllDiversos();
        cblDiversos.DataSource = ds.Tables[0].DefaultView;
        cblDiversos.DataValueField = "CAR_CODIGO";
        cblDiversos.DataTextField = "DESCRICAO";
        cblDiversos.DataBind();
    }

   
}