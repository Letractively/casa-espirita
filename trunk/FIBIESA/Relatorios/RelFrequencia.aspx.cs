using System;
using System.Data;
using BusinessLayer;
using DataObjects;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

namespace FIBIESA.Relatorios
{
    public partial class RelFrequencia : System.Web.UI.Page
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
            lDtPesquisa = (DataTable)Session["ldsRel"];
            if (lDtPesquisa.Rows.Count > 0)
            {
                string mes = Request.QueryString["mes"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceFrequencia = new ReportDataSource("DataSet_Frequencia", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("mes", mes);

                rptFrequencia.LocalReport.SetParameters(param);
                rptFrequencia.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptFrequencia.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptFrequencia.LocalReport.DataSources.Add(rptDatasourceFrequencia);

                rptFrequencia.LocalReport.Refresh();
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