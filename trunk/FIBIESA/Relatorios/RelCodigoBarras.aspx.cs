using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using BusinessLayer;
using DataObjects;
using System.Collections.Generic;

namespace FIBIESA.Relatorios
{
    public partial class RelCodigoBarras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.geraRelatorio();
            }
        }

        DataTable lDtPesquisa;

        private void geraRelatorio()
        {
            if (Session["ldsRel"] != null)
            {
                lDtPesquisa = (DataTable)Session["ldsRel"];
                if (lDtPesquisa.Rows.Count > 0)
                {
                    
                    InstituicoesBL instBL = new InstituicoesBL();
                    Instituicoes inst = new Instituicoes();

                    InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                    InstituicoesLogo instLogo = new InstituicoesLogo();

                    ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                    ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                    ReportDataSource rptDatasourceEmprestimos = new ReportDataSource("DataSet_CodigoBarras", lDtPesquisa);
                    
                    //rpvEmprestimos.ProcessingMode = ProcessingMode.Local;
                    rpvCodigoBarras.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                    rpvCodigoBarras.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                    rpvCodigoBarras.LocalReport.DataSources.Add(rptDatasourceEmprestimos);

                    rpvCodigoBarras.LocalReport.Refresh();
                    //Session["ldsRel"] = null;
                }
                else
                {
                    divRelatorio.Visible = false;
                    divMensagem.Visible = true;
                    lblMensagem.Text = "Este relatorio não possui dados.";
                }
            }

        }
    }
}