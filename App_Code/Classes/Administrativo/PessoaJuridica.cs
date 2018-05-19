using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PessoaJuridica
/// </summary>
/// 
namespace LigaArena.Classes.Administrativo
{
    public class PessoaJuridica : Pessoa
    {
        private string _cnpj;
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

       

    }
}