using LigaArena.Classes.Producao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Producao
{
    public class ProdutoBD
    {
        public bool Insert(Produto produto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO TBL_PRODUTOS(CAP_CODIGO, PRO_DESCRICAO, PRO_VALORCUSTO, PRO_DATAVALIDADE, PRO_UNMEDIDA, PRO_QTDATUAL, PRO_QTDMINIMA, PRO_ATIVO) VALUES (?CodigoCategoria, ?DESCRICAO, ?VALORCUSTO, ?DATAVALIDADE, ?UNMEDIDA, ?QTDATUAL, ?QTDMINIMA, ?ATIVO);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("CodigoCategoria", produto.CodigoCategoria));
            objCommand.Parameters.Add(Mapped.Parameter("?DESCRICAO", produto.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?VALORCUSTO", produto.ValorCusto));
            objCommand.Parameters.Add(Mapped.Parameter("?DATAVALIDADE", produto.DataValidade));
            objCommand.Parameters.Add(Mapped.Parameter("?UNMEDIDA", produto.UnidadeMedida));
            objCommand.Parameters.Add(Mapped.Parameter("?QTDATUAL", produto.QuantidadeAtual));
            objCommand.Parameters.Add(Mapped.Parameter("?QTDMINIMA", produto.QuantidadeMinima));
            objCommand.Parameters.Add(Mapped.Parameter("?ATIVO", 1));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public DataSet SelectProdutoDS(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "SELECT * FROM TBL_PRODUTOS where pro_codigo=?produto";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objCommand.Parameters.Add(Mapped.Parameter("?produto", id));

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public int GetUltimoID(Produto produto)
        {

            int retorno = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_PRODUTOS WHERE PRO_DESCRICAO=?descricao AND PRO_VALORCUSTO=?valorcusto";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", produto.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?valorcusto", produto.ValorCusto));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                Produto pro = new Produto();
                pro.Codigo = Convert.ToInt32(objDataReader["PRO_CODIGO"]);
                retorno = pro.Codigo;
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return retorno;
        }

        public Produto SelectProduto(int id)
        {

            Produto produto = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_PRODUTOS WHERE PRO_CODIGO=?codigo";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                produto = new Produto();
                produto.Codigo = Convert.ToInt32(objDataReader["PRO_CODIGO"]);
                produto.DataValidade = Convert.ToDateTime(objDataReader["PRO_DATAVALIDADE"]);
                produto.ValorCusto = Convert.ToDouble(objDataReader["PRO_VALORCUSTO"]);
                produto.Descricao = Convert.ToString(objDataReader["PRO_DESCRICAO"]);
                produto.UnidadeMedida = Convert.ToString(objDataReader["PRO_UNMEDIDA"]);
                produto.QuantidadeAtual = Convert.ToInt32(objDataReader["PRO_QTDATUAL"]);
                produto.QuantidadeMinima = Convert.ToInt32(objDataReader["PRO_QTDMINIMA"]);
                produto.Ativo = Convert.ToInt16(objDataReader["PRO_ATIVO"]);
                produto.CodigoCategoria = Convert.ToString(objDataReader["CAP_CODIGO"]);
               
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return produto;
        }

        public bool Update(Produto produto)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PRODUTOS set CAP_CODIGO=?codigocategoria, PRO_DESCRICAO=?DESCRICAO, PRO_VALORCUSTO=?VALORCUSTO, PRO_DATAVALIDADE=?DATAVALIDADE, PRO_UNMEDIDA=?UNMEDIDA, PRO_QTDATUAL=?QTDATUAL, PRO_QTDMINIMA=?QTDMINIMA, PRO_ATIVO=?ATIVO  WHERE PRO_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("CodigoCategoria", produto.CodigoCategoria));
            objCommand.Parameters.Add(Mapped.Parameter("?DESCRICAO", produto.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?VALORCUSTO", produto.ValorCusto));
            objCommand.Parameters.Add(Mapped.Parameter("?DATAVALIDADE", produto.DataValidade));
            objCommand.Parameters.Add(Mapped.Parameter("?UNMEDIDA", produto.UnidadeMedida));
            objCommand.Parameters.Add(Mapped.Parameter("?QTDATUAL", produto.QuantidadeAtual));
            objCommand.Parameters.Add(Mapped.Parameter("?QTDMINIMA", produto.QuantidadeMinima));
            objCommand.Parameters.Add(Mapped.Parameter("?ATIVO", produto.Ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?CODIGO", produto.Codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public DataSet SelectAllProducts()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "SELECT PRO_CODIGO, PRO_QTDATUAL, PRO_DESCRICAO, PRO_DATAVALIDADE, CASE PRO_ATIVO WHEN 1 THEN 'Ativo' WHEN 0 THEN 'Desativo' end AS PRO_ATIVO from tbl_produtos";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public bool AddProduto(int codigo ,int qtd)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "Update tbl_produtos set PRO_QTDATUAL = PRO_QTDATUAL + ?quantidade where PRO_CODIGO = ?codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("quantidade", qtd));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public bool UpdateCusto(double custo, int codigo)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "Update tbl_produtos set PRO_VALORCUSTO=?custo where PRO_CODIGO = ?codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("custo", custo));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public int SelectProdutoPelaFK(int id)
        {

            int variavel = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "select * from tbl_cardapios inner join tbl_cardapios_produtos on (tbl_cardapios_produtos.CAR_CODIGO = tbl_cardapios.CAR_CODIGO) inner join tbl_produtos on (tbl_cardapios_produtos.PRO_CODIGO = tbl_produtos.PRO_CODIGO) where tbl_cardapios.CAR_CODIGO = ?codigo;";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                
                variavel = Convert.ToInt32(objDataReader["PRO_CODIGO"]);
               
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return variavel;
        }

        public bool UpdateEstoque(int codigo)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "update tbl_produtos set PRO_QTDATUAL = PRO_QTDATUAL -1 where PRO_CODIGO =?produto;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?produto", codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }


        

    }
}