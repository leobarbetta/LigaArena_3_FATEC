using LigaArena.Classes.Fincanceiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Fincanceiro
{
    public class DespesasBD
    {
        public bool Insert(Despesas despesas)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_DESPESAS (PES_CODIGO, CAD_CODIGO, DES_DESCRICAO, DES_CUSTO, DES_DATADESPESA) VALUE (?pessoa, ?categoria, ?descricao, ?custo, ?data)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pessoa", despesas.Pessoa));
            objCommand.Parameters.Add(Mapped.Parameter("?categoria", despesas.Categoria));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", despesas.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?custo", despesas.ValorDespesa));
            objCommand.Parameters.Add(Mapped.Parameter("?data", despesas.Data));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public DataSet SelectAllDespesas(DateTime data)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select tbl_categoriadespesas.CAD_DESCRICAO, tbl_despesas.DES_DESCRICAO, tbl_despesas.DES_CUSTO, tbl_despesas.DES_DATADESPESA from tbl_despesas inner join tbl_categoriadespesas on (tbl_despesas.CAD_CODIGO = tbl_categoriadespesas.CAD_CODIGO) where tbl_despesas.DES_DATADESPESA>?data";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objCommand.Parameters.Add(Mapped.Parameter("?data", data));

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select  tbl_categoriadespesas.CAD_DESCRICAO, tbl_despesas.DES_DESCRICAO, tbl_despesas.DES_CUSTO, tbl_despesas.DES_DATADESPESA, tbl_categoriadespesas.CAD_CODIGO, tbl_despesas.CAD_CODIGO from tbl_despesas inner join tbl_categoriadespesas on tbl_despesas.CAD_CODIGO = tbl_categoriadespesas.CAD_CODIGO";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        public DataSet SomaDespesa(DateTime data1, DateTime data2)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select sum(tbl_despesas.DES_CUSTO) as total from tbl_despesas inner join tbl_categoriadespesas on tbl_despesas.CAD_CODIGO = tbl_categoriadespesas.CAD_CODIGO where tbl_despesas.DES_DATADESPESA between ?data1 and ?data2";

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

        public double SelectDespesaSemDataSet(DateTime data1, DateTime data2)
        {


            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            double totalDespesa = 0;

            string sql = "select sum(tbl_despesas.DES_CUSTO) as total from tbl_despesas inner join tbl_categoriadespesas on tbl_despesas.CAD_CODIGO = tbl_categoriadespesas.CAD_CODIGO where tbl_despesas.DES_DATADESPESA between ?data1 and ?data2";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?data1", data1));
            objComando.Parameters.Add(Mapped.Parameter("?data2", data2));


            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                totalDespesa = Convert.ToDouble(objReader["total"]);
            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return totalDespesa;
        }

        public bool InsertDespesaProdutos(Despesas despesas)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_DESPESAS (PES_CODIGO, CAD_CODIGO, DES_DESCRICAO, DES_CUSTO, DES_DATADESPESA) VALUE (?pessoa, ?categoria, ?descricao, ?custo, ?data)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pessoa", despesas.Pessoa));
            objCommand.Parameters.Add(Mapped.Parameter("?categoria", 6));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", despesas.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?custo", despesas.ValorDespesa));
            objCommand.Parameters.Add(Mapped.Parameter("?data", despesas.Data));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }



    }
}