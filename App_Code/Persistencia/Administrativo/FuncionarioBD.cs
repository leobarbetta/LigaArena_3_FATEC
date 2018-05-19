using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class FuncionarioBD
    {

        //*******************************************************//
        // METODO INSERT USADO PARA DAR INSERT NO BANCO DE DADOS//
        // METODO PARA DAR INSERT NOS DADOS DO FUNCIONARIO     //
        //****************************************************//
        public bool Insert(Funcionario funcionario)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO TBL_PESSOAS(PES_NOME, PES_CPF, PES_TELEFONE, PES_DATANASCIMENTO, PES_SEXO, PES_EMAIL, PES_TIPO, PES_SENHA, PES_DATAADMISSAO, PES_CARGO, PES_SALARIO, PES_ATIVO, END_CODIGO, PES_NUMEROREGISTRO) VALUES (?NOME, ?CPF, ?TELEFONE, ?DATANASCIMENTO, ?SEXO, ?EMAIL, ?TIPO, ?SENHA, ?DATAADMISSAO, ?CARGO, ?SALARIO, ?ATIVO, ?ENDERECO, ?NRegistro)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?NOME", funcionario.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?CPF", funcionario.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?TELEFONE", funcionario.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?DATANASCIMENTO", funcionario.DataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?SEXO", funcionario.Sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?EMAIL", funcionario.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?TIPO", 1));
            objCommand.Parameters.Add(Mapped.Parameter("?SENHA", funcionario.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?DATAADMISSAO", funcionario.DataAdmissao));
            objCommand.Parameters.Add(Mapped.Parameter("?CARGO", funcionario.Cargo));
            objCommand.Parameters.Add(Mapped.Parameter("?SALARIO", funcionario.Salario));
            objCommand.Parameters.Add(Mapped.Parameter("?ATIVO", 1));
            objCommand.Parameters.Add(Mapped.Parameter("?ENDERECO", funcionario.Endereco.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?NRegistro", funcionario.NumeroRegistro));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }


        //**********************************************************//
        // METODO SELECT PARA VERIFICAR SE O CPF JA ESTA CADASTRADO //
        //**********************************************************//
        public Funcionario VerificarCPF(string CPF)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Funcionario funcionario = null;

            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_CPF =?CPF";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?CPF", CPF));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                funcionario = new Funcionario();
                funcionario.CPF = Convert.ToString(objReader["PES_CPF"]);

            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return funcionario;
        }

        //************************************************************//
        // METODO SELECT PARA VERIFICAR SE O EMAIL JA ESTA CADASTRADO //
        //************************************************************//

        public Funcionario VerificarEmail(string email)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;

            Funcionario funcionario = null;
            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_EMAIL=?EMAIL";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?EMAIL", email));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                funcionario = new Funcionario();
                funcionario.Email = Convert.ToString(objReader["PES_EMAIL"]);

            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return funcionario;
        }

        //*************************************************************//
        //              METODO SELECT PARA FAZER O LOGIN               //
        //*************************************************************//

        public Funcionario ValidaFuncionario(string email, string senha, int tipo, int ativo)
        {

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Funcionario funcionario = null;

            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_EMAIL=?EMAIL AND PES_SENHA=?SENHA AND PES_TIPO=?TIPO AND PES_ATIVO=?ATIVO";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?EMAIL", email));
            objComando.Parameters.Add(Mapped.Parameter("?SENHA", senha));
            objComando.Parameters.Add(Mapped.Parameter("?TIPO", tipo));
            objComando.Parameters.Add(Mapped.Parameter("?ATIVO", ativo));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                funcionario = new Funcionario();
                funcionario.Email = Convert.ToString(objReader["PES_EMAIL"]);
                funcionario.Senha = Convert.ToString(objReader["PES_SENHA"]);
                funcionario.Codigo = Convert.ToInt32(objReader["PES_CODIGO"]);

            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return funcionario;
        }

        public Funcionario SelectFuncionario(int id)
        {
            Funcionario funcionario = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_CODIGO=?CODIGO";
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?CODIGO", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                funcionario = new Funcionario();
                funcionario.Codigo = Convert.ToInt32(objDataReader["PES_CODIGO"]);
                funcionario.Nome = Convert.ToString(objDataReader["PES_NOME"]);
                funcionario.CPF = Convert.ToString(objDataReader["PES_CPF"]);
                funcionario.DataNascimento = Convert.ToDateTime(objDataReader["PES_DATANASCIMENTO"]);
                funcionario.Sexo = Convert.ToString(objDataReader["PES_SEXO"]);
                funcionario.Telefone = Convert.ToString(objDataReader["PES_TELEFONE"]);
                funcionario.Email = Convert.ToString(objDataReader["PES_EMAIL"]);
                funcionario.Ativo = Convert.ToInt16(objDataReader["PES_ATIVO"]);
                funcionario.DataAdmissao = Convert.ToDateTime(objDataReader["PES_DATAADMISSAO"]);
                funcionario.Cargo = Convert.ToString(objDataReader["PES_CARGO"]);
                funcionario.Salario = Convert.ToDouble(objDataReader["PES_SALARIO"]);
                funcionario.NumeroRegistro = Convert.ToInt32(objDataReader["PES_NUMEROREGISTRO"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return funcionario;
        }

        public bool Update(Funcionario funcionario)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PESSOAS set PES_NOME=?nome, PES_CPF=?cpf, PES_DATANASCIMENTO=?datanascimento, PES_SEXO=?sexo, PES_TELEFONE=?telefone, PES_ATIVO=?ativo, PES_DATAADMISSAO=?dataadmissao, PES_CARGO=?cargo, PES_SALARIO=?salario WHERE PES_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?nome", funcionario.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cpf", funcionario.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?datanascimento", funcionario.DataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?sexo", funcionario.Sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?telefone", funcionario.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?ativo", funcionario.Ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?dataadmissao", funcionario.DataAdmissao));
            objCommand.Parameters.Add(Mapped.Parameter("?cargo", funcionario.Cargo));
            objCommand.Parameters.Add(Mapped.Parameter("?salario", funcionario.Salario));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", funcionario.Codigo));

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

            string sql = "SELECT PES_CODIGO, PES_NOME, PES_NUMEROREGISTRO, PES_TELEFONE, CASE PES_ATIVO WHEN 1 THEN 'Ativo' WHEN 0 THEN 'Desativado' end AS PES_ATIVO FROM TBL_PESSOAS WHERE PES_TIPO=1 ORDER BY PES_NOME";

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