using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LigaArena.Classes.Administrativo
{
    public class FeedBack
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private int _pesCodigo;

        public int PesCodigo
        {
            get { return _pesCodigo; }
            set { _pesCodigo = value; }
        }

        private int _nota;

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}