using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using Microsoft.Reporting.WebForms;

namespace FIBIESA.Relatorios
{
    public partial class RelVendasAcumulados : System.Web.UI.Page
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
                string periodo;
                if ((Request.QueryString["DtIni"].ToString() != string.Empty) && (Request.QueryString["DtFim"].ToString() != string.Empty))
                {
                    periodo = Request.QueryString["DtIni"].ToString() + " a " + Request.QueryString["DtFim"].ToString();
                }
                else
                {
                    periodo = "Todos";
                }
                string acumulado = Request.QueryString["acumulado"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceVendaItens = new ReportDataSource("DataSet_VendaItens", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("periodo", periodo);
                param[1] = new ReportParameter("acumulado", acumulado);

                rptVendasAcumulado.LocalReport.SetParameters(param);
                rptVendasAcumulado.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptVendasAcumulado.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptVendasAcumulado.LocalReport.DataSources.Add(rptDatasourceVendaItens);

                rptVendasAcumulado.LocalReport.Refresh();
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