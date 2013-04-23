using System;
using System.Data;
using BusinessLayer;
using DataObjects;
using Microsoft.Reporting.WebForms;

namespace FIBIESA.Relatorios
{
    public partial class RelCursos : System.Web.UI.Page
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

                string curso = Request.QueryString["curso"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceCursos = new ReportDataSource("DataSet_Cursos", lDtPesquisa);

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("curso", curso);
                param[1] = new ReportParameter("totalEventos", lDtPesquisa.Rows.Count.ToString());

                rptEventos.LocalReport.SetParameters(param);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceCursos);

                rptEventos.LocalReport.Refresh();
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