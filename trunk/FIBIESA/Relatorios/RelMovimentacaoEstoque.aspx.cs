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
    public partial class RelMovimentacaoEstoque : System.Web.UI.Page
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
                ReportDataSource rptDatasourceMovEstoque = new ReportDataSource("DataSet_MovimentacaoEstoque", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("periodo", periodo);

                rptMovestoque.LocalReport.SetParameters(param);
                rptMovestoque.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptMovestoque.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptMovestoque.LocalReport.DataSources.Add(rptDatasourceMovEstoque);

                rptMovestoque.LocalReport.Refresh();
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