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
            string mes = Request.QueryString["mes"].ToString();
            if (lDtPesquisa.Rows.Count > 0)
            {
                int countfalta, countPresenca;
                foreach (DataRow row in lDtPesquisa.Rows)
                {
                    countfalta = 0;
                    countPresenca = 0;
                    foreach (DataColumn column in lDtPesquisa.Columns)
                    {

                        if ((column.ColumnName.Contains("dia")) && (row[column].ToString() == "F"))
                            countfalta += 1;
                        if ((column.ColumnName.Contains("dia")) && (row[column].ToString() == "P"))
                            countPresenca += 1;
                        if (column.ColumnName.Contains("totalFalta"))
                            row[column] = countfalta;
                        if (column.ColumnName.Contains("totalPresenca"))
                            row[column] = countPresenca;
                    }
                }
                //string mes = Request.QueryString["mes"].ToString();
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