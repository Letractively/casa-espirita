using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BusinessLayer;
using DataObjects;
using System.Data;

namespace FIBIESA.Relatorios
{
    public partial class RelItensEstoque : System.Web.UI.Page
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

                string status = Request.QueryString["status"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceItensEstoque = new ReportDataSource("DataSet_ItensEstoque", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("status", status);

                rptItensEstoque.LocalReport.SetParameters(param);
                rptItensEstoque.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptItensEstoque.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptItensEstoque.LocalReport.DataSources.Add(rptDatasourceItensEstoque);

                rptItensEstoque.LocalReport.Refresh();
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