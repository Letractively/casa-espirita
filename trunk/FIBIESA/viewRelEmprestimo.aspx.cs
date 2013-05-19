using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class viewRelEmprestimo : System.Web.UI.Page
    {
        #region funcoes
        private DataTable CriarTabelaPesquisa()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            return dt;

        }
        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            if (this.txtCodigo.Text != string.Empty)
            {
                pesquisaObra("CODIGO");
                if (Session["tabelaPesquisa"] != null)
                {
                    dtGeral = (DataTable)Session["tabelaPesquisa"];
                    this.lblDesCodigo.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                    this.hfIdCodigo.Value = dtGeral.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    this.lblDesCodigo.Text = string.Empty;
                    this.hfIdCodigo.Value = string.Empty;
                }


            }
            if (this.txtAssociado.Text != string.Empty)
            {
                pesquisaAssociado("CODIGO");
                if (Session["tabelaPesquisa"] != null)
                {
                    dtGeral = (DataTable)Session["tabelaPesquisa"];
                    this.lblDesAssociado.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                    this.hfIdAssociado.Value = dtGeral.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    this.lblDesAssociado.Text = string.Empty;
                    this.hfIdAssociado.Value = string.Empty;
                }

            }

        }

        protected void btnPesAssociado_Click(object sender, EventArgs e)
        {

            pesquisaAssociado("CODIGO");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtAssociado.ClientID + "&id=" + hfIdAssociado.ClientID + "&lbl=" + lblDesAssociado.ClientID + "','',600,500);", true);
        }

        protected void btnPesCodigo_Click(object sender, EventArgs e)
        {

            pesquisaObra("NOMECODIGO");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCodigo.ClientID + "&id=" + hfIdCodigo.ClientID + "&lbl=" + lblDesCodigo.ClientID + "','',600,500);", true);
        }


        #region "Pesquisas"



        public void pesquisaObra(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            ObrasBL obrasBl = new ObrasBL();
            Obras obras = new Obras();
            List<Obras> lObras;

            if (this.txtCodigo.Text != string.Empty)
            {
                lObras = obrasBl.PesquisarBL("CODIGO",this.txtCodigo.Text);
            }
            else
            {
                lObras = obrasBl.PesquisarBL();
            }
            foreach (Obras obraItem in lObras)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = obraItem.Id;
                linha["CODIGO"] = obraItem.Codigo;
                linha["DESCRICAO"] = obraItem.Titulo;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Obra não encontrada.');", true);
            }

            Session["objBLPesquisa"] = obrasBl;
            Session["objPesquisa"] = obras;

        }

        public void pesquisaAssociado(string lCampoPesquisa)
        {

            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas;
            if (this.txtAssociado.Text != string.Empty)
            {
                pessoas = pesBL.PesquisarBL(lCampoPesquisa, this.txtAssociado.Text);
            }
            else
            {
                pessoas = pesBL.PesquisarBL();
            }


            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Cliente não encontrado.');", true);
            }

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;
        }

        #endregion

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            EmprestimoMovBL empMovBL = new EmprestimoMovBL();
            EmprestimoMov empMov = new EmprestimoMov();
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();

            if (hfIdAssociado.Value != string.Empty)
            {
                emp.PessoaId = int.Parse(hfIdAssociado.Value);
            }

            string PaginaRelatorio = "";

            if (rbLivrosMais.Checked)
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(emp,hfIdCodigo.Value, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString(), "desc").Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimoAcumulado.aspx?Acumulado=Mais&";
            }
            else if (rbLivrosMenos.Checked)
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(emp, hfIdCodigo.Value, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString(), "asc").Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimoAcumulado.aspx?Acumulado=Menos&";
            }
            else
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(emp, hfIdCodigo.Value, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString()).Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimos.aspx?";
            }
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('" + PaginaRelatorio + "PessoaId=" + hfIdAssociado.Value + "&obraId=" + hfIdCodigo.Value + "&DataRetiradaIni=" + txtDataRetiradaIni.Text + "&DataRetiradaFim=" + txtDataRetiradaFin.Text + "&DevolucaoFim=" + txtDevolucaoFim.Text + "&DevolucaoIni=" + txtDevolucaoIni.Text + "&Status=" + ddlStatus.SelectedValue.ToString() + "','',600,1125);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }


            //emp. txtDataRetiradaIni.Text


        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void txtAssociado_TextChanged(object sender, EventArgs e)
        {
            if (txtAssociado.Text == "")
            {
                lblDesAssociado.Text = "";
                hfIdAssociado.Value = "";
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                lblDesCodigo.Text = "";
                hfIdCodigo.Value = "";                     
            }
        }

    }
}