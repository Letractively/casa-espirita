using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;
using FG;
namespace FIBIESA
{
    public partial class viewRelTurmas : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public void CarregarPesquisaEvento(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            EventosBL eveBL = new EventosBL();
            Eventos eve = new Eventos();
            List<Eventos> lEventos = eveBL.PesquisarBuscaBL(conteudo);

            foreach (Eventos pes in lEventos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Descricao;

                dt.Rows.Add(linha);
            }


            grdPesquisaEvento.DataSource = dt;
            grdPesquisaEvento.DataBind();
        }

        public void CarregarPesquisaTurma(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            TurmasBL turBL = new TurmasBL();
            Eventos tur = new Eventos();
            List<Turmas> lTurmas = turBL.PesquisarBuscaBL(conteudo);

            foreach (Turmas pes in lTurmas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Descricao;

                dt.Rows.Add(linha);
            }


            grdPesquisaTurma.DataSource = dt;
            grdPesquisaTurma.DataBind();
        }

        private void CarregarAtributos()
        {
            txtDataIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataIniF.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFimI.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");            
        }
        #endregion
        
        public DataTable dtGeral;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            CarregarAtributos();           
        }

        protected void btnPesEvento_Click(object sender, EventArgs e)
        {
            CarregarPesquisaEvento(null);
            ModalPopupExtenderPesquisaEvento.Enabled = true;
            ModalPopupExtenderPesquisaEvento.Show();        
        }

        protected void btnPesTurma_Click(object sender, EventArgs e)
        {
            CarregarPesquisaTurma(null);
            ModalPopupExtenderPesquisaTurma.Enabled = true;
            ModalPopupExtenderPesquisaTurma.Show();        
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntEvento"] != null && Session["IntEvento"] != string.Empty)
                txtEvento.Text = Session["IntEvento"].ToString() + ",";

            txtEvento.Text = txtEvento.Text + gvrow.Cells[2].Text;
            Session["IntEvento"] = txtEvento.Text;
            ModalPopupExtenderPesquisaEvento.Hide();
            ModalPopupExtenderPesquisaEvento.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaEvento.Enabled = false;
        }

        protected void btnSelectTurma_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntTurma"] != null && Session["IntTurma"] != string.Empty)
                txtTurma.Text = Session["IntTurma"].ToString() + ",";

            txtTurma.Text = txtTurma.Text + gvrow.Cells[2].Text;
            Session["IntTurma"] = txtTurma.Text;
            ModalPopupExtenderPesquisaTurma.Hide();
            ModalPopupExtenderPesquisaTurma.Enabled = false;
        }

        protected void btnCancelTurma_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaEvento.Enabled = false;
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {


            TurmasBL turmasBL = new TurmasBL();

            Session["ldsRel"] = turmasBL.PesquisarDataset(txtEvento.Text, txtTurma.Text, txtDataIni.Text, txtDataIniF.Text, txtDataFimI.Text, txtDataFim.Text, ckbTurmasAbertos.Checked).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelTurmas.aspx?Eventos=" + txtEvento.Text + "','',600,915);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaEvento(txtPesquisa.Text);
            ModalPopupExtenderPesquisaEvento.Enabled = true;
            ModalPopupExtenderPesquisaEvento.Show();
            txtPesquisa.Text = "";
        }

        protected void txtPesquisaTurma_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaTurma(txtPesquisaTurma.Text);
            ModalPopupExtenderPesquisaTurma.Enabled = true;
            ModalPopupExtenderPesquisaTurma.Show();
            txtPesquisaTurma.Text = "";
        }

        protected void txtEvento_TextChanged(object sender, EventArgs e)
        {
            if (txtEvento.Text == "")
                Session["IntEvento"] = null;
            Session["IntEvento"] = txtEvento.Text;
        }

        protected void txtTurma_TextChanged(object sender, EventArgs e)
        {
            if (txtTurma.Text == "")
                Session["IntTurma"] = null;
            Session["IntTurma"] = txtTurma.Text;
        }

        protected void grdPesquisaEvento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void grdPesquisaTurma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
    }
}