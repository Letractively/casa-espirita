using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using BusinessLayer;
using DataObjects;
using System.Collections.Generic;

namespace FIBIESA.Relatorios
{
    public partial class RelEmprestimos : System.Web.UI.Page
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
                    string PessoaId = Request.QueryString["PessoaId"].ToString();
                    string obraId = Request.QueryString["obraId"].ToString();
                    string dataRetiradaIni = Request.QueryString["DataRetiradaIni"].ToString();
                    string dataRetiradaFim = Request.QueryString["DataRetiradaFim"].ToString();
                    string dataDevolucaoFim = Request.QueryString["DevolucaoFim"].ToString();
                    string dataDevolucaoIni = Request.QueryString["DevolucaoIni"].ToString();
                    string Status = Request.QueryString["Status"].ToString();
                    int nrAtrasos = 0;
                    int nrEmprestimos = 0;
                    int totalEmprestimos = lDtPesquisa.Rows.Count;
                    for (int i = 0; i <= lDtPesquisa.Rows.Count - 1; i++)
                    {
                        if (lDtPesquisa.Rows[i]["status"] == "A")
                        {
                            nrAtrasos += 1;
                        }
                        if (lDtPesquisa.Rows[i]["status"] == "E")
                        {
                            nrEmprestimos += 1;
                        }

                    }



                    InstituicoesBL instBL = new InstituicoesBL();
                    Instituicoes inst = new Instituicoes();

                    InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                    InstituicoesLogo instLogo = new InstituicoesLogo();

                    ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                    ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                    ReportDataSource rptDatasourceEmprestimos = new ReportDataSource("DataSet_Emprestimo", lDtPesquisa);
                    string nome = string.Empty;
                    if (PessoaId != string.Empty)
                    {
                    PessoasBL peBL = new PessoasBL();
                    Pessoas pe = new Pessoas();
                    
                        List<Base> lPessoas = peBL.PesquisarPessoas(PessoaId);

                        
                        foreach (Base pes in lPessoas)
                        {
                            if (nome == string.Empty)
                                nome += pes.PesDescricao;
                            else
                                nome += ", " + pes.PesDescricao;
                        }
                    }

                    string titulo = string.Empty;
                    if (obraId != string.Empty)
                    {
                        ObrasBL obrasBl = new ObrasBL();
                        Obras obras = new Obras();
                        List<Base> lObras = obrasBl.PesquisarObras(obraId);
                     
                        foreach (Base pes in lObras)
                        {
                            if (titulo == string.Empty)
                                titulo += pes.PesDescricao;
                            else
                                titulo += ", " + pes.PesDescricao;
                        }
                    }
                    ReportParameter[] param = new ReportParameter[10];
                    param[0] = new ReportParameter("nome", nome);
                    param[1] = new ReportParameter("titulo", titulo);
                    param[2] = new ReportParameter("dataRetiradaIni", dataRetiradaIni);
                    param[3] = new ReportParameter("dataRetiradaFim", dataRetiradaFim);
                    param[4] = new ReportParameter("dataDevolucaoIni", dataDevolucaoIni);
                    param[5] = new ReportParameter("dataDevolucaoFim", dataDevolucaoFim);
                    param[6] = new ReportParameter("Status", Status);
                    param[7] = new ReportParameter("nrAtrasos", nrAtrasos.ToString());
                    param[8] = new ReportParameter("nrEmprestimos", nrEmprestimos.ToString());
                    param[9] = new ReportParameter("totalEmprestimos", totalEmprestimos.ToString());

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
}