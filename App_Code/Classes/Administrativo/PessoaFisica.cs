using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PessoaFisica
/// </summary>
/// 
namespace LigaArena.Classes.Administrativo
{
    public class PessoaFisica : Pessoa
    {
        private string _cpf;

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private string _sexo;
        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }



    }
}