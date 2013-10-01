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
    public partial class viewRelCodigoBarras : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes

        public void CarregarPesquisaExemplar(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("TOMBO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);

            ExemplaresBL exeBL = new ExemplaresBL();
            Exemplares exe = new Exemplares();
            List<Exemplares> lExemplares = exeBL.PesquisarBuscaBL(conteudo);

            foreach (Exemplares pes in lExemplares)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Obras.Codigo;
                linha["DESCRICAO"] = pes.Obras.Titulo;
                linha["TOMBO"] = pes.Tombo;

                dt.Rows.Add(linha);
            }


            grdPesquisaExemplar.DataSource = dt;
            grdPesquisaExemplar.DataBind();
        }
        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IntExemplar"] = null;
            }

        }
        #region Click

        protected void btnPesCodigo_Click(object sender, EventArgs e)
        {

            CarregarPesquisaExemplar(null);
            ModalPopupExtenderPesquisaExemplar.Enabled = true;
            ModalPopupExtenderPesquisaExemplar.Show();
        }


        protected void btnSelectExemplar_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntExemplar"] != null)
                txtCodigo.Text = Session["IntExemplar"].ToString() + ",";

            txtCodigo.Text = txtCodigo.Text + gvrow.Cells[4].Text;
            Session["IntExemplar"] = txtCodigo.Text;
            ModalPopupExtenderPesquisaExemplar.Hide();
            ModalPopupExtenderPesquisaExemplar.Enabled = false;
        }


        protected void btnCancelExemplar_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaExemplar.Enabled = false;
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            ExemplaresBL exeBL = new ExemplaresBL();

            Session["ldsRel"] = exeBL.PesquisarBuscaExemplaresDA(txtCodigo.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelCodigoBarras.aspx','',600,1125);", true);
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

        #endregion Click



        #region TextChanged
        

        protected void txtPesquisaExemplar_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaExemplar(txtPesquisaExemplar.Text);
            ModalPopupExtenderPesquisaExemplar.Enabled = true;
            ModalPopupExtenderPesquisaExemplar.Show();
            txtPesquisaExemplar.Text = "";
        }

       
        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                Session["IntExemplar"] = null;
            Session["IntExemplar"] = txtCodigo.Text;
        }

        #endregion TextChanged


        protected void grdPesquisaExemplar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
    }
}