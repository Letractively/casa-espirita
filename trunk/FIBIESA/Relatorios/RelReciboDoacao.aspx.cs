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

namespace FIBIESA.Relatorios
{
    public partial class RelReciboDoacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.geraRelatorio();
            }
        }

        DataTable lDtDoacao;

        private void geraRelatorio()
        {
            DoacoesBL doacoesBL = new DoacoesBL();
            Doacoes doacoes = new Doacoes();
            int doacaoid = Convert.ToInt16(Request.QueryString["doacaoid"].ToString());
            lDtDoacao = doacoesBL.PesquisarDataset(doacaoid).Tables[0];
            if (lDtDoacao.Rows.Count > 0)
            {


                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                VendaItensBL vendaItensBL = new VendaItensBL();
                VendaItens vendaItens = new VendaItens();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceVenda = new ReportDataSource("DataSet_Doacao", lDtDoacao);
                decimal valor = Convert.ToDecimal(lDtDoacao.Rows[0]["valor"].ToString());
                NumeroPorExtenso numeroPorExtenso = new NumeroPorExtenso(valor);
                string valorExtenso = numeroPorExtenso.ToString();
                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("valorExtenso", valorExtenso);

                rptDoacao.LocalReport.SetParameters(param);
                rptDoacao.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptDoacao.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptDoacao.LocalReport.DataSources.Add(rptDatasourceVenda);

                rptDoacao.LocalReport.Refresh();
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