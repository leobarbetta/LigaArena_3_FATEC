using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Producao
{
    public class Categoria
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _nomeCategoria;

        public string NomeCategoria
        {
            get { return _nomeCategoria; }
            set { _nomeCategoria = value; }
        }

    }
}