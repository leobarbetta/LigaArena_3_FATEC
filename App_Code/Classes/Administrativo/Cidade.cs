using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Administrativo
{
    public class Cidade
    {
        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private int _codestado;

        public int Codestado
        {
            get { return _codestado; }
            set { _codestado = value; }
        }
    }
}