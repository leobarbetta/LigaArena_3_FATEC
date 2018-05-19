using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cliente
/// </summary>
/// 
namespace LigaArena.Classes.Administrativo
{
    public class Cliente : PessoaFisica
    {
        private DateTime _dataCadastro;
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro=value;}
        }

        private int _fkEndereco;

        public int FkEndereco
        {
            get { return _fkEndereco; }
            set { _fkEndereco = value; }
        }

    }
}