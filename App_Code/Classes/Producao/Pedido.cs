using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaArena.Classes.Producao
{
    public class Pedido
    {
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _numeromesa;

        public int Numeromesa
        {
            get { return _numeromesa; }
            set { _numeromesa = value; }
        }

        private int _quantidadeItem;

        public int QuantidadeItem
        {
            get { return _quantidadeItem; }
            set { _quantidadeItem = value; }
        }

        private double _valorTotal;

        public double ValorTotal
        {
            get { return _valorTotal; }
            set { _valorTotal = value; }
        }

        private DateTime _dataHoraPedido;

        public DateTime DataHoraPedido
        {
            get { return _dataHoraPedido; }
            set { _dataHoraPedido = value; }
        }

        private int _FKPessoa;

        public int FKPessoa
        {
            get { return _FKPessoa; }
            set { _FKPessoa = value; }
        }

        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private int _pago;

        public int Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }

    }
}