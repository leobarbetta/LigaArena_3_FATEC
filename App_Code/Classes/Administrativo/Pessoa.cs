using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Administrativo
{
    // classe pessoas, onde crio as propriedades
    public class Pessoa
    {
        private int _tipo;
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private int _ativo;

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        private Endereco _endereco;

        public Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
    }
}