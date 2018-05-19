using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Producao
{
    public class Produto
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

        private double _valorCusto;

        public double ValorCusto
        {
            get { return _valorCusto; }
            set { _valorCusto = value; }
        }

        private DateTime _dataValidade;

        public DateTime DataValidade
        {
          get { return _dataValidade; }
          set { _dataValidade = value; }
        }

        private string _unidadeMedida;

        public string UnidadeMedida
        {
            get { return _unidadeMedida; }
            set { _unidadeMedida = value; }
        }

        private int _quantidadeAtual;

        public int QuantidadeAtual
        {
            get { return _quantidadeAtual; }
            set { _quantidadeAtual = value; }
        }

        private int _quantidadeMinima;

        public int QuantidadeMinima
        {
            get { return _quantidadeMinima; }
            set { _quantidadeMinima = value; }
        }

        private string _codigoCategoria;

        public string CodigoCategoria
        {
            get { return _codigoCategoria; }
            set { _codigoCategoria = value; }
        }

        private int _ativo;

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
    }
}