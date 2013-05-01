using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using BusinessLayer;
using DataObjects;

namespace FIBIESA.Relatorios
{
    public partial class viewRelDoacoes : System.Web.UI.Page
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

                string periodo = Request.QueryString["periodo"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceDoacoes = new ReportDataSource("DataSet_Doacoes", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("periodo", periodo);

                rptDoacoes.LocalReport.SetParameters(param);
                rptDoacoes.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptDoacoes.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptDoacoes.LocalReport.DataSources.Add(rptDatasourceDoacoes);

                rptDoacoes.LocalReport.Refresh();
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