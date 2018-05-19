using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class CidadeBD
    {
        public DataSet SelectAllByState(int estado)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_CIDADES WHERE EST_CODIGO=?codigo ORDER BY CID_DESCRICAO";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", estado));


            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public Cidade SelectCidade(int id)
        {
            //teste = false;
            Cidade cidade = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM TBL_CIDADES WHERE cid_codigo=?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                cidade = new Cidade();

                cidade.Codigo = Convert.ToInt32(objDataReader["cid_codigo"]);
                cidade.Descricao = Convert.ToString(objDataReader["cid_descricao"]);
                cidade.Codestado = Convert.ToInt32(objDataReader["EST_CODIGO"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return cidade;

        }


    }
}