using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LigaArena.Classes.Administrativo
{
    public class Estado
    {
        //
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _uf;
        public string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}