using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class EnderecoBD
    {

        //*******************************************************//
        // METODO INSERT USADO PARA DAR INSERT NO BANCO DE DADOS//
        // METODO PARA DAR INSERT NOS DADOS DO ENDEREÇO        //
        //****************************************************//
        public bool Insert(Endereco endereco)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO TBL_ENDERECOS(END_LOGRADOURO, END_NUMERO, END_BAIRRO, END_COMPLEMENTO, END_CEP, CID_CODIGO) VALUES (?LOGRADOURO, ?NUMERO, ?BAIRRO, ?COMPLEMENTO, ?CEP, ?cidade)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?LOGRADOURO", endereco.Logradouro));
            objCommand.Parameters.Add(Mapped.Parameter("?NUMERO", endereco.Numero));
            objCommand.Parameters.Add(Mapped.Parameter("?BAIRRO", endereco.Bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?COMPLEMENTO", endereco.Complemento));
            objCommand.Parameters.Add(Mapped.Parameter("?CEP", endereco.CEP));
            objCommand.Parameters.Add(Mapped.Parameter("?cidade", endereco.CodigoCidade));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        public Endereco SelectEndereco(int id)
        {
            Endereco endereco = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_ENDERECOS WHERE END_CODIGO=?CODIGO";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?CODIGO", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                endereco = new Endereco();
                endereco.Codigo = Convert.ToInt32(objDataReader["END_CODIGO"]);
                endereco.Bairro = Convert.ToString(objDataReader["END_BAIRRO"]);
                endereco.CEP = Convert.ToString(objDataReader["END_CEP"]);
                endereco.Logradouro = Convert.ToString(objDataReader["END_LOGRADOURO"]);
                endereco.Numero = Convert.ToString(objDataReader["END_NUMERO"]);
                endereco.Complemento = Convert.ToString(objDataReader["END_COMPLEMENTO"]);
                endereco.CodigoCidade = Convert.ToInt32(objDataReader["CID_CODIGO"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return endereco;
        }

       

        public int GetUltimoID(Endereco endereco)
        {

            int retorno = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_ENDERECOS WHERE END_LOGRADOURO=?logradouro AND END_CEP=?cep";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?logradouro", endereco.Logradouro));
            objCommand.Parameters.Add(Mapped.Parameter("?cep", endereco.CEP));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                Endereco end = new Endereco();
                end.Codigo = Convert.ToInt32(objDataReader["END_CODIGO"]);
                retorno = end.Codigo;
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return retorno;
        }

        public bool Update(Endereco endereco)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_ENDERECOS set END_LOGRADOURO=?logradouro, END_NUMERO=?numero, END_COMPLEMENTO=?complemento, END_BAIRRO=?bairro, END_CEP=?CEP WHERE END_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?logradouro", endereco.Logradouro));
            objCommand.Parameters.Add(Mapped.Parameter("?numero", endereco.Numero));
            objCommand.Parameters.Add(Mapped.Parameter("?complemento", endereco.Complemento));
            objCommand.Parameters.Add(Mapped.Parameter("?bairro", endereco.Bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?CEP", endereco.CEP));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", endereco.Codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

    }
}