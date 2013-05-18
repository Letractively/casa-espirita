using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;


namespace BusinessLayer
{
    public class EstadosBL : BaseBL
    {
        public bool InserirBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.InserirDA(est);
        }

        public bool EditarBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.EditarDA(est);
        }

        public bool ExcluirBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.ExcluirDA(est);
        }

        public List<Estados> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.PesquisarDA();
        }

        public List<Estados> PesquisarBL(int id_est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.PesquisarDA(id_est);
        }

        public List<Estados> PesquisarBL(string campo, string valor)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.PesquisarDA(campo, valor);
        }

        public DataSet PesquisaBL(int id_est)
        {
            EstadosDA estDA = new EstadosDA();

            return estDA.PesquisaDA(id_est);
        }

        public List<Estados> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            EstadosDA estDA = new EstadosDA();

            return estDA.Pesquisar(codDes);
        }

        public bool CodigoJaUtilizadoBL(string codigo)
        {
            EstadosDA estDA = new EstadosDA();

            return estDA.CodigoJaUtilizadoDA(codigo);
        }
    }
}
