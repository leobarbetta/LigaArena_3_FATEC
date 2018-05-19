using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class EstadoBD
    {
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;


            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM TBL_ESTADOS ORDER BY EST_DESCRICAO", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public Estado SelectEstado(int id)
        {
            Estado estado = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_ESTADOS WHERE EST_CODIGO=?CODIGO";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?CODIGO", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                estado = new Estado();
                estado.Codigo = Convert.ToInt32(objDataReader["EST_CODIGO"]);
                estado.Descricao = Convert.ToString(objDataReader["EST_DESCRICAO"]);
                estado.UF = Convert.ToString(objDataReader["EST_UF"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return estado;
        }

    }
}