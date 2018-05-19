using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Fincanceiro
{
    public class Despesas
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private double _valorDespesa;

        public double ValorDespesa
        {
            get { return _valorDespesa; }
            set { _valorDespesa = value; }
        }

        private int _pessoa;

        public int Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

        private int _categoria;

        public int Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}