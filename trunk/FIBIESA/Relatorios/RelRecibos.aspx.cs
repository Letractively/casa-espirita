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
    public partial class RelRecibos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.geraRelatorio();
            }
        }

        DataTable lDtEmp;

        private void geraRelatorio()
        {
            EmprestimosBL empBL = new EmprestimosBL();
            
            int empid = Convert.ToInt16(Request.QueryString["emprestimoid"].ToString());
            lDtEmp = empBL.PesquisarDataSet(empid).Tables[0];
            if (lDtEmp.Rows.Count > 0)
            {
                //VendasBL
                string nomeUsuarioLogado = string.Empty;
                int idUsuarioLogado = 0;
                if (Session["usuario"] != null)
                {
                    List<Usuarios> usuarios;
                    usuarios = (List<Usuarios>)Session["usuario"];

                    foreach (Usuarios usu in usuarios)
                    {
                        idUsuarioLogado = usu.Id;
                        nomeUsuarioLogado = usu.Nome;
                    }

                    //vendas.UsuarioId = usu_id;
                }
                InstituicoesBL instBL = new InstituicoesBL();
                Instituicoes inst = new Instituicoes();

                InstituicoesLogoBL instLogoBL = new InstituicoesLogoBL();
                InstituicoesLogo instLogo = new InstituicoesLogo();
                
                ReportDataSource rptDatasourceInstituicao = new ReportDataSource("DataSet_Instituicao", instBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceInstituicaoLogo = new ReportDataSource("DataSet_InstituicaoLogo", instLogoBL.PesquisarDsBL().Tables[0]);
                ReportDataSource rptDatasourceRecibo = new ReportDataSource("DataSet_Recibo", lDtEmp);

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("nomeUsuario", nomeUsuarioLogado);
                param[1] = new ReportParameter("idUsuario", idUsuarioLogado.ToString());

                ReportRecibos.LocalReport.SetParameters(param);
                ReportRecibos.LocalReport.DataSources.Add(rptDatasourceInstituicao);
                ReportRecibos.LocalReport.DataSources.Add(rptDatasourceInstituicaoLogo);
                ReportRecibos.LocalReport.DataSources.Add(rptDatasourceRecibo);
                
                ReportRecibos.LocalReport.Refresh();
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