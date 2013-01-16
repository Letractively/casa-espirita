using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

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

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            EstadosDA estDA = new EstadosDA();

            return estDA.Pesquisar(codDes, tipo);
        }
            
    }
}
