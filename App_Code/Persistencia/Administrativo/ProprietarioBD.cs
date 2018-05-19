using LigaArena;
using LigaArena.Classes.Administrativo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LigaArena.Persistencia.Administrativo
{
    public class ProprietarioBD
    {

        //*************************************************************//
        //              METODO SELECT PARA FAZER O LOGIN               //
        //*************************************************************//
        public Proprietario ValidaProprietario(string email, string senha, int tipo)
        {

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            Proprietario proprietario = null;

            string sql = "SELECT * FROM TBL_PESSOAS WHERE PES_EMAIL=?EMAIL AND PES_SENHA=?SENHA AND PES_TIPO=?TIPO";

            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?EMAIL", email));
            objComando.Parameters.Add(Mapped.Parameter("?SENHA", senha));
            objComando.Parameters.Add(Mapped.Parameter("?TIPO", 0));
            objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                proprietario = new Proprietario();
                proprietario.Email = Convert.ToString(objReader["PES_EMAIL"]);
                proprietario.Senha = Convert.ToString(objReader["PES_SENHA"]);
                proprietario.Codigo = Convert.ToInt32(objReader["PES_CODIGO"]);


            }

            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

            return proprietario;
        }


    }
}