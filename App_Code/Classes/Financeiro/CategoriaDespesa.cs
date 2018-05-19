using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LigaArena.Classes.Fincanceiro
{
    public class CategoriaDespesa
    {
        private int _codigo;


        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _tipoCategoria;

        public string TipoCategoria
        {
            get { return _tipoCategoria; }
            set { _tipoCategoria = value; }
        }


    }
}