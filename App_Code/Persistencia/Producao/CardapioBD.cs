using LigaArena;
using LigaArena.Classes.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Producao
{
    public class CardapioBD
    {
        public bool Insert(Cardapio cardapio)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO TBL_CARDAPIOS(CAR_VALOR) VALUES (?valor)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?valor", cardapio.Valor));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public bool InsertFKs(int FKCardapio, int FKProduto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_cardapios_produtos(CAR_CODIGO, PRO_CODIGO) VALUES (?cardapio, ?produto)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?cardapio", FKCardapio));
            objCommand.Parameters.Add(Mapped.Parameter("?produto", FKProduto));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public Cardapio SelectCardapio(int codigo)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Cardapio cardapio = null;

            string sql = "select CAR_CODIGO from tbl_cardapio where car_codigo = ?codigo";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                cardapio = new Cardapio();
                cardapio.Codigo = Convert.ToInt32(objReader["CAR_CODIGO"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return cardapio;
        }

        public double SelectValor(int codigo)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            double retorno = 0;

            string sql = "select CAR_VALOR from tbl_cardapios where car_codigo = ?codigo";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {

                retorno = Convert.ToDouble(objReader["CAR_VALOR"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return retorno;
        }

        public int GetUltimoID(Cardapio cardapio)
        {

            int retorno = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_CARDAPIOS WHERE CAR_VALOR=?valor";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?valor", cardapio.Valor));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                Cardapio car = new Cardapio();
                car.Codigo = Convert.ToInt32(objDataReader["CAR_CODIGO"]);
                retorno = car.Codigo;
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return retorno;
        }

        public DataSet SelectAllLanches()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO=6;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAllADCLanches()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO = 10;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAllPorcoes()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO = 13;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAllAcai()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO = 9;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAllADCAcai()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO = 11;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAllDiversos()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = ("select concat(tbl_produtos.PRO_DESCRICAO, ' -- R$ ',tbl_cardapios.CAR_VALOR) as DESCRICAO, tbl_produtos.PRO_ATIVO, tbl_produtos.PRO_DESCRICAO, tbl_cardapios.CAR_CODIGO from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_produtos.PRO_ATIVO = 1 AND TBL_PRODUTOS.CAP_CODIGO = 12;");

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

    }
}