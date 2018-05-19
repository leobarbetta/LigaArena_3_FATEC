using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Funcionario
/// </summary>
/// 
namespace LigaArena.Classes.Administrativo
{
    public class Funcionario : PessoaFisica
    {
        private int _numeroRegistro;
        public int NumeroRegistro
        {
            get { return _numeroRegistro; }
            set { _numeroRegistro = value; }
        }

        private string _cargo;
        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        private DateTime _dataAdmissao;
        public DateTime DataAdmissao
        {
            get { return _dataAdmissao; }
            set { _dataAdmissao = value; }
        }

        private double _salario;
        public double Salario
        {
            get { return _salario; }
            set { _salario = value; }
        }


    }
}