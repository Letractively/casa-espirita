using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Portadores : Base
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _codigo;
        public Int32 Codigo
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

        private Int32? _agenciaId;
        public Int32? AgenciaId
        {
            get { return _agenciaId; }
            set { _agenciaId = value; }
        }

        private Int32? _bancoId;
        public Int32? BancoId
        {
            get { return _bancoId; }
            set { _bancoId = value; }
        }

        private Bancos _banco;
        public Bancos Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        private Agencias _agencia;
        public Agencias Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        private Int32? _contaId;
        public Int32? ContaId
        {
            get { return _contaId; }
            set { _contaId = value; }
        }

        private Contas _contas;
        public Contas Contas
        {
            get { return _contas; }
            set { _contas = value; }
        }

        private Int32? _codCedente;
        public Int32? CodCedente
        {
            get { return _codCedente; }
            set { _codCedente = value; }
        }

        private string _carteira;
        public string Carteira
        {
            get { return _carteira; }
            set { _carteira = value; }
        }

        private string _codEmpBanriMicro;
        public string CodEmpBanriMicro
        {
            get { return _codEmpBanriMicro; }
            set { _codEmpBanriMicro = value; }
        }
    }
}
