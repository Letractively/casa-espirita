﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;


namespace BusinessLayer
{
    public class EmprestimoMovBL
    {

        public bool InserirBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.ExcluirDA(instancia);
        }

        public DataSet PesquisarRelatorioBL(Emprestimos instancia, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.PesquisarRelatorioDA(instancia, dataRetiradaIni, dataRetiradaFim, dataDevolucaoIni, dataDevolucaoFim, Status);
        }

        public DataSet PesquisarRelatorioBL(Emprestimos instancia, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status, string ordenacao)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.PesquisarRelatorioDA(instancia, dataRetiradaIni, dataRetiradaFim, dataDevolucaoIni, dataDevolucaoFim, Status, ordenacao);
        }

    }
}