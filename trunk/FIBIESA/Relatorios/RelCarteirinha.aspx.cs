using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using DataObjects;
using BusinessLayer;
using System.ComponentModel;

namespace FIBIESA.Relatorios
{
    public partial class RelCarteirinha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.geraRelatorio();
            }
        }

        DataTable lDtPessoa;


        private void geraRelatorio()
        {
            PessoasBL pessoasBL = new PessoasBL();
            Pessoas pessoas = new Pessoas();            
            int pessoaid = Convert.ToInt16(Request.QueryString["pessoaid"].ToString());
            lDtPessoa = pessoasBL.PesquisaDataSetDA(pessoaid).Tables[0];
            if (lDtPessoa.Rows.Count > 0)
            {


                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourcePessoa = new ReportDataSource("DataSet_Pessoa", lDtPessoa);
                                
                ReportCarteirinha.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                ReportCarteirinha.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                ReportCarteirinha.LocalReport.DataSources.Add(rptDatasourcePessoa);
                
                ReportCarteirinha.LocalReport.Refresh();
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