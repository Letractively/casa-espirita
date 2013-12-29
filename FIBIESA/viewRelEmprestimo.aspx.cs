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
using FG;

namespace FIBIESA
{
    public partial class viewRelEmprestimo : System.Web.UI.Page
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

        public void CarregarPesquisaObra(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ObrasBL obBL = new ObrasBL();
            Obras ob = new Obras();
            List<Obras> lObras = obBL.PesquisarBuscaBL(conteudo);

            foreach (Obras pes in lObras)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Titulo;

                dt.Rows.Add(linha);
            }


            grdPesquisaObra.DataSource = dt;
            grdPesquisaObra.DataBind();
        }
        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        #region Click
        protected void btnPesAssociado_Click(object sender, EventArgs e)
        {

            CarregarPesquisaAssociado(null);
            ModalPopupExtenderPesquisaAssociado.Enabled = true;
            ModalPopupExtenderPesquisaAssociado.Show();
        }

        protected void btnPesCodigo_Click(object sender, EventArgs e)
        {

            CarregarPesquisaObra(null);
            ModalPopupExtenderPesquisaObra.Enabled = true;
            ModalPopupExtenderPesquisaObra.Show();
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntClientes"] != null && Session["IntClientes"] != string.Empty)
                txtAssociado.Text = Session["IntClientes"].ToString() + ",";

            txtAssociado.Text = txtAssociado.Text + gvrow.Cells[2].Text;
            Session["IntClientes"] = txtAssociado.Text;
            ModalPopupExtenderPesquisaAssociado.Hide();
            ModalPopupExtenderPesquisaAssociado.Enabled = false;

        }

        protected void btnSelectObra_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntObra"] != null && Session["IntObra"] != string.Empty)
                txtCodigo.Text = Session["IntObra"].ToString() + ",";

            txtCodigo.Text = txtCodigo.Text + gvrow.Cells[2].Text;
            Session["IntObra"] = txtCodigo.Text;
            ModalPopupExtenderPesquisaObra.Hide();
            ModalPopupExtenderPesquisaObra.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaAssociado.Enabled = false;
        }

        protected void btnCancelObra_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaObra.Enabled = false;
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            EmprestimoMovBL empMovBL = new EmprestimoMovBL();
            EmprestimoMov empMov = new EmprestimoMov();
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();


            string PaginaRelatorio = "";

            if (ddlTipo.SelectedValue == "A")
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(txtAssociado.Text, txtCodigo.Text, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString(), "desc").Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimoAcumulado.aspx?Acumulado=Mais&";
            }
            else if (ddlTipo.SelectedValue == "B")
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(txtAssociado.Text, txtCodigo.Text, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString(), "asc").Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimoAcumulado.aspx?Acumulado=Menos&";
            }
            else
            {
                Session["ldsRel"] = empMovBL.PesquisarRelatorioBL(txtAssociado.Text, txtCodigo.Text, txtDataRetiradaIni.Text, txtDataRetiradaFin.Text, txtDevolucaoIni.Text, txtDevolucaoFim.Text, ddlStatus.SelectedValue.ToString()).Tables[0];
                PaginaRelatorio = "/Relatorios/RelEmprestimos.aspx?";
            }
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('" + PaginaRelatorio + "PessoaId=" + txtAssociado.Text + "&obraId=" + txtCodigo.Text + "&DataRetiradaIni=" + txtDataRetiradaIni.Text + "&DataRetiradaFim=" + txtDataRetiradaFin.Text + "&DevolucaoFim=" + txtDevolucaoFim.Text + "&DevolucaoIni=" + txtDevolucaoIni.Text + "&Status=" + ddlStatus.SelectedValue.ToString() + "','',600,1125);", true);
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

        #endregion Click



        #region TextChanged
                              
        protected void txtAssociado_TextChanged(object sender, EventArgs e)
        {
            if (txtAssociado.Text == "")
                Session["IntClientes"] = null;
            Session["IntClientes"] = txtAssociado.Text;

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                Session["IntObra"] = null;
            Session["IntObra"] = txtCodigo.Text;
        }

        #endregion TextChanged




        protected void grdPesquisaAssociado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void grdPesquisaObra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarPesquisaObra(txtPesquisaObra.Text);
            ModalPopupExtenderPesquisaObra.Enabled = true;
            ModalPopupExtenderPesquisaObra.Show();
            txtPesquisaObra.Text = "";
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            CarregarPesquisaAssociado(txtPesquisa.Text);
            ModalPopupExtenderPesquisaAssociado.Enabled = true;
            ModalPopupExtenderPesquisaAssociado.Show();
            txtPesquisa.Text = "";
        }
    }
}