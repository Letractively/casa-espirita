using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using FG;
namespace FIBIESA
{
    public partial class viewRelContasPagar : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public void CarregarPesquisaAssociado(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisaAssociado.DataSource = dt;
            grdPesquisaAssociado.DataBind();
        }

        public void CarregarPesquisaTitulo(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            TitulosBL titBL = new TitulosBL();
            Titulos tit = new Titulos();
            List<Titulos> lTitulos = titBL.PesquisarBuscaBL(conteudo);
            foreach (Titulos pes in lTitulos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Numero;
                linha["DESCRICAO"] = pes.PesCodigo;

                dt.Rows.Add(linha);
            }


            grdPesquisaTitulo.DataSource = dt;
            grdPesquisaTitulo.DataBind();
        }

        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
            carregaTipoDocumentos();
        }

        #region pesquisas


        private void CarregarAtributos()
        {
            txtDataEmissaoIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataEmissaoFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataPagamentoIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataPagamentoFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataVencimentoIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataVencimentoFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");            
        }

        public DataTable pesquisaTipoDocumento()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            
            TiposDocumentosBL tipoDoBL = new TiposDocumentosBL();
            TiposDocumentos tipoDo = new TiposDocumentos();
            List<TiposDocumentos> lTiposDocumentos;
            
                lTiposDocumentos = tipoDoBL.PesquisarBL("CP");
            
            foreach (TiposDocumentos doc in lTiposDocumentos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = doc.Id;
                linha["CODIGO"] = doc.Codigo;
                linha["DESCRICAO"] = doc.Descricao;

                dt.Rows.Add(linha);
            }

            return dt;

        }
        #endregion pesquisas

        protected void btnPesAssociado_Click(object sender, EventArgs e)
        {

            CarregarPesquisaAssociado(null);
            ModalPopupExtenderPesquisaAssociado.Enabled = true;
            ModalPopupExtenderPesquisaAssociado.Show();
        }

        protected void btnPesTitulo_Click(object sender, EventArgs e)
        {

            CarregarPesquisaTitulo(null);
            ModalPopupExtenderPesquisaTitulo.Enabled = true;
            ModalPopupExtenderPesquisaTitulo.Show();
        }
        
        protected void btnSelectAssociado_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntAssociado"] != null || Session["IntAssociado"] != null)
                txtAssociado.Text = Session["IntAssociado"].ToString() + ",";

            txtAssociado.Text = txtAssociado.Text + gvrow.Cells[2].Text;
            Session["IntAssociado"] = txtAssociado.Text;
            ModalPopupExtenderPesquisaAssociado.Hide();
            ModalPopupExtenderPesquisaAssociado.Enabled = false;
        }

        protected void btnSelectTitulo_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntTitulo"] != null || Session["IntTitulo"] != null)
                txtTitulo.Text = Session["IntTitulo"].ToString() + ",";

            txtTitulo.Text = txtTitulo.Text + gvrow.Cells[2].Text;
            Session["IntTitulo"] = txtTitulo.Text;
            ModalPopupExtenderPesquisaTitulo.Hide();
            ModalPopupExtenderPesquisaTitulo.Enabled = false;
        }


        protected void btnCancelAssociado_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaAssociado.Enabled = false;
        }

        protected void btnCancelTitulo_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaTitulo.Enabled = false;
        }


        #region eventos textBox
        protected void txtPesquisaAssociado_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaAssociado(txtPesquisaAssociado.Text);
            ModalPopupExtenderPesquisaAssociado.Enabled = true;
            ModalPopupExtenderPesquisaAssociado.Show();
            txtPesquisaAssociado.Text = "";
        }

        protected void txtPesquisaTitulo_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaTitulo(txtPesquisaTitulo.Text);
            ModalPopupExtenderPesquisaTitulo.Enabled = true;
            ModalPopupExtenderPesquisaTitulo.Show();
            txtPesquisaTitulo.Text = "";
        }

        
        protected void txtAssociado_TextChanged(object sender, EventArgs e)
        {
            if (txtAssociado.Text == "")
                Session["IntAssociado"] = null;
            Session["IntAssociado"] = txtAssociado.Text;

        }

        
        protected void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
                Session["IntTitulo"] = null;
            Session["IntTitulo"] = txtTitulo.Text;

        }

        #endregion




        public void carregaTipoDocumentos()
        {
            this.ddlTipoDocumento.DataTextField = "DESCRICAO";
            this.ddlTipoDocumento.DataValueField = "id";
            this.ddlTipoDocumento.DataSource = pesquisaTipoDocumento();
            this.ddlTipoDocumento.DataBind();            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            TitulosBL titulosBL = new TitulosBL();
            Titulos titulos = new Titulos();

            
            Boolean blAtrasados = false;
            if (ckbAtrasados.Checked)
                blAtrasados = true;
            
            Session["ldsRel"] = titulosBL.PesquisarBuscaDataSetBL(txtTitulo.Text, txtAssociado.Text, string.Empty, "CP", ddlTipoDocumento.SelectedValue,blAtrasados,txtDataEmissaoIni.Text,txtDataEmissaoFim.Text,txtDataVencimentoIni.Text,txtDataVencimentoFim.Text, txtDataPagamentoIni.Text, txtDataPagamentoFim.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                string periodo = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelContasPagar.aspx?periodo=" + periodo + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }

        protected void grdPesquisaAssociado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void grdPesquisaTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
        
    }
}