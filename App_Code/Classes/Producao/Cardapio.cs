using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Producao
{
    public class Cardapio
    {
        private int _Codigo;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _item;

        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }

        private double _valor;

        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private int _FKProduto;

        public int FKProduto
        {
            get { return _FKProduto; }
            set { _FKProduto = value; }
        }

    }
}