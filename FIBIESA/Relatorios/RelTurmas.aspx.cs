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
    public partial class RelTurmas : System.Web.UI.Page
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

                string eventos = Request.QueryString["Eventos"].ToString();
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();

                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceEventos = new ReportDataSource("DataSet_Eventos", lDtPesquisa);

                string nome = string.Empty;
                if (eventos != string.Empty)
                {
                    EventosBL eveBL = new EventosBL();
                    Eventos eve = new Eventos();

                    List<Base> lEventos = eveBL.PesquisarEventos(eventos);


                    foreach (Base pes in lEventos)
                    {
                        if (nome == string.Empty)
                            nome += pes.PesDescricao;
                        else
                            nome += ", " + pes.PesDescricao;
                    }
                }

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("evento", nome);
                
                rptEventos.LocalReport.SetParameters(param);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                rptEventos.LocalReport.DataSources.Add(rptDatasourceEventos);

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