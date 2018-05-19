using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class ClienteBD
    {
        //******************************************************//
        // METODO INSERT USADO PARA DAR INSERT NO BANCO DE DADOS//
        // METODO PARA DAR INSERT NOS DADOS DO CLIENTE          //
        //******************************************************//

        public bool Insert(Cliente cliente)
        {
            // 
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO TBL_PESSOAS(PES_NOME, PES_CPF, PES_TELEFONE, PES_DATANASCIMENTO, PES_SEXO, PES_EMAIL, PES_TIPO, PES_ATIVO, PES_SENHA, END_CODIGO, PES_DATACADASTRO) VALUES (?NOME, ?CPF, ?TELEFONE, ?DATANASCIMENTO, ?SEXO, ?EMAIL, ?TIPO, ?ATIVO, ?SENHA, ?endereco, ?datacadastro)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?NOME", cliente.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?CPF", cliente.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?TELEFONE", cliente.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?DATANASCIMENTO", cliente.DataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?SEXO", cliente.Sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?EMAIL", cliente.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?TIPO", 2));
            //para indicar se esta ativo ou nao esta sendo usando 0(inativo) 1(ativo)
            //ele cadastra o usuario com 1 que indica que o usuario esta ativo//
            objCommand.Parameters.Add(Mapped.Parameter("ATIVO", 1));
            objCommand.Parameters.Add(Mapped.Parameter("?SENHA", cliente.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?endereco", cliente.Endereco.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?datacadastro", cliente.DataCadastro));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }
        //***********************************************************//
        //        METODO SELECTALL PARA MOSTRAR TODOS CLIENTES      //
        //*********************************************************//
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
           
            string sql = "SELECT PES_CODIGO, PES_NOME, PES_EMAIL, PES_TELEFONE, CASE PES_ATIVO WHEN 1 THEN 'Ativo' WHEN 0 THEN 'Desativado' end AS PES_ATIVO FROM TBL_PESSOAS WHERE PES_TIPO=2 ORDER BY PES_NOME";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
        //**********************************************************//
        //METODO DELETE PARA PROPRIETARIO PODER DELETAR ALGUM CLIENTE//
        //**********************************************************//
        public bool Delete(int codigo)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "DELETE FROM TBL_PESSOAS WHERE PES_CODIGO=?CODIGO";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?CODIGO", codigo));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        //**********************************************************//
        // METODO SELECT PARA VERIFICAR SE O CPF JA ESTA CADASTRADO //
        //**********************************************************//
        public Cliente VerificarCPF(string CPF)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Cliente cliente = null;

            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_CPF =?CPF";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?CPF", CPF));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                cliente = new Cliente();
                cliente.CPF = Convert.ToString(objReader["PES_CPF"]);

            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return cliente;
        }

        //************************************************************//
        // METODO SELECT PARA VERIFICAR SE O EMAIL JA ESTA CADASTRADO //
        //************************************************************//

        public Cliente VerificarEmail(string email)
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;

            Cliente cliente = null;
            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_EMAIL=?EMAIL";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?EMAIL", email));

            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                cliente = new Cliente();
                cliente.Email = Convert.ToString(objReader["PES_EMAIL"]);

            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return cliente;
        }


        //*************************************************************//
        //              METODO SELECT PARA FAZER O LOGIN               //
        //*************************************************************//

        public Cliente ValidaCliente(string email, string senha, int tipo, int ativo)
        {

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Cliente cliente = null;

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
                cliente = new Cliente();
                cliente.Email = Convert.ToString(objReader["PES_EMAIL"]);
                cliente.Senha = Convert.ToString(objReader["PES_SENHA"]);
                cliente.Codigo = Convert.ToInt32(objReader["PES_CODIGO"]);


            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return cliente;
        }

        //*************************************************************//
        //            METODO SELECT PARA EDITAR CLIENTE               //
        //***********************************************************//

        public Cliente SelectCliente(int id)
        {
            Cliente cliente = null;

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
                cliente = new Cliente();
                cliente.Codigo = Convert.ToInt32(objDataReader["PES_CODIGO"]);
                cliente.Nome = Convert.ToString(objDataReader["PES_NOME"]);
                cliente.CPF = Convert.ToString(objDataReader["PES_CPF"]);
                cliente.DataNascimento = Convert.ToDateTime(objDataReader["PES_DATANASCIMENTO"]);
                cliente.Sexo = Convert.ToString(objDataReader["PES_SEXO"]);
                cliente.Telefone = Convert.ToString(objDataReader["PES_TELEFONE"]);
                cliente.Email = Convert.ToString(objDataReader["PES_EMAIL"]);
                cliente.Ativo = Convert.ToInt16(objDataReader["PES_ATIVO"]);
                cliente.FkEndereco = Convert.ToInt32(objDataReader["END_CODIGO"]);

            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return cliente;
        }

        //*************************************************************//
        //            METODO UPDATE PARA EDITAR CLIENTE               //
        //***********************************************************//
        public bool Update(Cliente cliente)
        {
            
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PESSOAS set PES_NOME=?nome, PES_CPF=?cpf, PES_DATANASCIMENTO=?datanascimento, PES_SEXO=?sexo, PES_TELEFONE=?telefone, PES_ATIVO=?ativo WHERE PES_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?nome", cliente.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cpf", cliente.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?datanascimento", cliente.DataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?sexo", cliente.Sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?telefone", cliente.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?ativo", cliente.Ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", cliente.Codigo));
            
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

        //*************************************************************//
        //            METODO UPDATE PARA ALTERAR SENHA               //
        //***********************************************************//
        public bool UpdateSenha(Cliente cliente)
        {

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE TBL_PESSOAS set PES_SENHA=?senha WHERE PES_CODIGO=?CODIGO";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?senha", cliente.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", cliente.Codigo));


            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

    }
}