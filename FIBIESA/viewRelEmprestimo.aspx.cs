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
                }

            }
            if (this.txtAssociado.Text != string.Empty)
            {
                pesquisaAssociado("CODIGO");
                if (Session["tabelaPesquisa"] != null)
                {
                    dtGeral = (DataTable)Session["tabelaPesquisa"];
                    this.lblDesAssociado.Text = dtGeral.Rows[0].ItemArray[2].ToString();

                }

            }

        }

        protected void btnPesAssociado_Click(object sender, EventArgs e)
        {

            pesquisaAssociado("");
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
                lObras = obrasBl.PesquisarBL(this.txtCodigo.Text, lCampoPesquisa);
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
            
            if (txtAssociado.Text != string.Empty)
            {
                emp.PessoaId = int.Parse(txtAssociado.Text);
            }
            if (txtCodigo.Text != string.Empty)
            {
                emp.ExemplarId = int.Parse(txtCodigo.Text);
            }

             Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(emp, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text,ddlStatus.SelectedValue.ToString()).Tables[0];
             if (Session["ldsRel"] != null)
             {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelEmprestimos.aspx?PessoaId=" + emp.PessoaId + "&ExemplarId=" + emp.ExemplarId + "&DataRetiradaIni=" + txtDataRetiradaIni.Text + "&DataRetiradaFim=" + txtDataRetiradaFin.Text + "&DevolucaoFim=" + txtDevolucaoFim.Text + "&DevolucaoIni=" + txtDevolucaoIni.Text + "&Status=" + ddlStatus.SelectedValue.ToString() + "','',600,500);", true);
             }
             else
             {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Alert('Sua pesquisa não retornou dados.');", true);
             }
            

            //emp. txtDataRetiradaIni.Text



        }

    }
}