using LigaArena.Classes.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Producao
{
    public class PedidoBD
    {
        public bool Insert(Pedido pedido)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_PEDIDOS(PED_NUMEROMESA, PED_QTDITEM, PED_DATAHORA, PED_VALORTOTAL, PES_CODIGO, PED_PAGO, PED_STATUS) VALUE (?mesa, ?qtditem, ?datahora, ?valortotal, ?pessoa, ?pago, ?status)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?mesa", pedido.Numeromesa));
            objCommand.Parameters.Add(Mapped.Parameter("?qtditem", pedido.QuantidadeItem));
            objCommand.Parameters.Add(Mapped.Parameter("?datahora", pedido.DataHoraPedido));
            objCommand.Parameters.Add(Mapped.Parameter("?valortotal", pedido.ValorTotal));
            objCommand.Parameters.Add(Mapped.Parameter("?pessoa", pedido.FKPessoa));
            objCommand.Parameters.Add(Mapped.Parameter("?pago", 0));
            objCommand.Parameters.Add(Mapped.Parameter("?status", 0));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }
        public double SomaPedido(int id)
        {
            double retorno = 0;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;

            string sql = "select sum(tbl_cardapios.CAR_VALOR) as valor from tbl_cardapios inner join tbl_pedidos_cardapios on (tbl_pedidos_cardapios.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_pedidos on (tbl_pedidos.PED_CODIGO = tbl_pedidos_cardapios.PED_CODIGO) where tbl_pedidos.PED_CODIGO = ?pedido";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?pedido", id));
           

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
               
                retorno = Convert.ToDouble(objReader["valor"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return retorno;
        }

        public int GetUltimoID(Pedido pedido)
        {

            int retorno = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_PEDIDOS WHERE PED_NUMEROMESA=?mesa";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?mesa", pedido.Numeromesa));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                Pedido ped = new Pedido();
                ped.Codigo = Convert.ToInt32(objDataReader["PED_CODIGO"]);
                retorno = ped.Codigo;
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return retorno;
        }

        public bool InsertFK(int pedido, int cardapio, double valor)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_PEDIDOS_CARDAPIOS(PED_CODIGO, CAR_CODIGO, CAR_VALOR, PED_QUANTIDADE) VALUE (?pedido, ?cardapio, ?valor, ?quantidade);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pedido", pedido));
            objCommand.Parameters.Add(Mapped.Parameter("?cardapio", cardapio));
            objCommand.Parameters.Add(Mapped.Parameter("?valor", valor ));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", 1));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public DataSet SelectContaCliente(int pessoa)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select * from tbl_produtos inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) inner join tbl_cardapios on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_pedidos_cardapios on (tbl_pedidos_cardapios.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_pedidos on (tbl_pedidos_cardapios.PED_CODIGO = tbl_pedidos.PED_CODIGO) inner join tbl_pessoas on (tbl_pedidos.PES_CODIGO = tbl_pessoas.PES_CODIGO) where tbl_pessoas.PES_CODIGO = ?pessoa and tbl_pedidos.PED_PAGO = 0;";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objCommand.Parameters.Add(Mapped.Parameter("?pessoa", pessoa));
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public DataSet RetornaTotal(int pessoa)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select * from tbl_pedidos inner join tbl_pessoas on (tbl_pedidos.PES_CODIGO = tbl_pessoas.PES_CODIGO) where tbl_pessoas.PES_CODIGO=?pessoa and tbl_pedidos.PED_PAGO = 0;";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objCommand.Parameters.Add(Mapped.Parameter("?pessoa", pessoa));
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public bool UpdateStatus(Pedido pedido)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PEDIDOS set PED_STATUS=?status WHERE PED_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?status", pedido.Status));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", pedido.Codigo));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }
        public bool UpdatePago(Pedido pedido)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PEDIDOS set PED_PAGO=?pago WHERE PED_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pago", pedido.Pago));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", pedido.Codigo));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public bool UpdateValorTotal(Pedido pedido)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PEDIDOS set PED_VALORTOTAL=?total WHERE PED_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?total", pedido.ValorTotal));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", pedido.Codigo));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public Pedido Select(int id)
        {

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Pedido pedido = null;

            string sql = "select * from tbl_pedidos inner join tbl_pessoas on (tbl_pedidos.PES_CODIGO = tbl_pessoas.PES_CODIGO) where tbl_pessoas.PES_CODIGO=?id and tbl_pedidos.PED_PAGO = 0;"; 

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?id", id));
            
            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                pedido = new Pedido();
                pedido.Codigo = Convert.ToInt32(objReader["PED_CODIGO"]);
                pedido.ValorTotal = Convert.ToDouble(objReader["PED_VALORTOTAL"]);
                pedido.Status = Convert.ToInt32(objReader["PED_STATUS"]);
                pedido.Pago = Convert.ToInt32(objReader["PED_PAGO"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return pedido;
        }

        public DataSet SelectVendas(DateTime data1, DateTime data2)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select * from tbl_pedidos inner join tbl_pessoas on (tbl_pedidos.PES_CODIGO = tbl_pessoas.PES_CODIGO) where tbl_pessoas.PES_TIPO=2 and tbl_pedidos.PED_PAGO = 1 and tbl_pedidos.PED_DATAHORA between ?data1 and ?data2;";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objCommand.Parameters.Add(Mapped.Parameter("?data1", data1));
            objCommand.Parameters.Add(Mapped.Parameter("?data2", data2));

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public double SelectVendasSemDataSet(DateTime data1, DateTime data2)
        {


            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            double totalVenda = 0;

            string sql = "select sum(tbl_pedidos.PED_VALORTOTAL) as total from tbl_pedidos where tbl_pedidos.PED_PAGO = 1 and tbl_pedidos.PED_DATAHORA between ?data1 and ?data2;";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?data1", data1));
            objComando.Parameters.Add(Mapped.Parameter("?data2", data2));


            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                totalVenda = Convert.ToDouble(objReader["total"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return totalVenda;
        }

        public DataSet RecebePedido()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select * from tbl_produtos inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) inner join tbl_cardapios on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_pedidos_cardapios on (tbl_pedidos_cardapios.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_pedidos on (tbl_pedidos_cardapios.PED_CODIGO = tbl_pedidos.PED_CODIGO) inner join tbl_pessoas on (tbl_pedidos.PES_CODIGO = tbl_pessoas.PES_CODIGO)where tbl_pedidos.PED_STATUS = 0 order by tbl_pedidos.PED_DATAHORA";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }


        public DataSet TotalVendas(DateTime data1, DateTime data2)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select sum(tbl_pedidos.PED_VALORTOTAL) as total from tbl_pedidos where tbl_pedidos.PED_PAGO = 1 and tbl_pedidos.PED_DATAHORA between ?data1 and ?data2;";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objCommand.Parameters.Add(Mapped.Parameter("?data1", data1));
            objCommand.Parameters.Add(Mapped.Parameter("?data2", data2));

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

    }
}