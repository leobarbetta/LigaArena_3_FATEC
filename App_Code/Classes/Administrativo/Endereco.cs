using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Endereco
/// </summary>
/// 
namespace LigaArena.Classes.Administrativo
{
    public class Endereco
    {

        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _bairro;
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private string _cep;
        public string CEP
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private int _CodigoCidade;

        public int CodigoCidade
        {
            get { return _CodigoCidade; }
            set { _CodigoCidade = value; }
        }

        private Cidade _cidade;

        public Cidade Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
    }
}