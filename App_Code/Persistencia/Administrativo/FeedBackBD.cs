using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class FeedBackBD
    {
        public bool Insert(FeedBack feedback)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_FEEDBACKS(FED_NOTA, FED_DESCRICAO, PES_CODIGO ) VALUES (?nota, ?descricao, ?pesCodigo)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?nota", feedback.Nota));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", feedback.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?pesCodigo", feedback.PesCodigo));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            string sql = "select tbl_feedbacks.FED_CODIGO, tbl_feedbacks.FED_NOTA, tbl_feedbacks.FED_DESCRICAO, tbl_pessoas.PES_NOME from tbl_feedbacks inner join tbl_pessoas on (tbl_feedbacks.PES_CODIGO = tbl_pessoas.PES_CODIGO)";

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