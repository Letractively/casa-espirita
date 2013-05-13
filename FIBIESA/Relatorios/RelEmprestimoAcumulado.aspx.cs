using System;
using System.Data;
using BusinessLayer;
using DataObjects;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

namespace FIBIESA.Relatorios
{
    public partial class RelEmprestimoAcumulado : System.Web.UI.Page
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
                string PessoaId = Request.QueryString["PessoaId"].ToString();
                string obraId = Request.QueryString["obraId"].ToString();
                string dataRetiradaIni = Request.QueryString["DataRetiradaIni"].ToString();
                string dataRetiradaFim = Request.QueryString["DataRetiradaFim"].ToString();
                string dataDevolucaoFim = Request.QueryString["DevolucaoFim"].ToString();
                string dataDevolucaoIni = Request.QueryString["DevolucaoIni"].ToString();
                string acumulado = Request.QueryString["Acumulado"].ToString();
                

                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceEmprestimos = new ReportDataSource("DataSet_Emprestimo", lDtPesquisa);

                PessoasBL peBL = new PessoasBL();
                Pessoas pe = new Pessoas();
                List<Pessoas> lPessoas = peBL.PesquisarBuscaBL(PessoaId);

                string nome = "";
                if (lPessoas.Count != 0 && PessoaId != string.Empty)
                {
                    nome = lPessoas[0].Nome;
                }
                ObrasBL obrasBl = new ObrasBL();
                Obras obras = new Obras();
                List<Obras> lObras = obrasBl.PesquisarBuscaBL(obraId);
                string titulo = "";
                if (lPessoas.Count != 0 && obraId != string.Empty)
                {
                    titulo = lObras[0].Titulo;
                }



                ReportParameter[] param = new ReportParameter[7];
                
                param[0] = new ReportParameter("acumulado", acumulado);
                param[1] = new ReportParameter("dataRetiradaIni", dataRetiradaIni);
                param[2] = new ReportParameter("dataRetiradaFim", dataRetiradaFim);
                param[3] = new ReportParameter("dataDevolucaoIni", dataDevolucaoIni);
                param[4] = new ReportParameter("dataDevolucaoFim", dataDevolucaoFim);
                param[5] = new ReportParameter("nome", nome);
                param[6] = new ReportParameter("titulo", titulo);
                //rpvEmprestimos.ProcessingMode = ProcessingMode.Local;
                rpvEmprestimos.LocalReport.SetParameters(param);
                rpvEmprestimos.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rpvEmprestimos.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rpvEmprestimos.LocalReport.DataSources.Add(rptDatasourceEmprestimos);

                rpvEmprestimos.LocalReport.Refresh();
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