using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using System.Data;
using FG;
namespace FIBIESA
{
    public partial class viewRelVendas : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public void CarregarPesquisaCliente(string conteudo)
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


            grdPesquisaCliente.DataSource = dt;
            grdPesquisaCliente.DataBind();
        }

        public void CarregarPesquisaItem(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ItensEstoqueBL itBL = new ItensEstoqueBL();
            ItensEstoque it = new ItensEstoque();
            List<ItensEstoque> lItensEstoque = itBL.PesquisarBuscaBL(conteudo);

            foreach (ItensEstoque pes in lItensEstoque)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Obra.Codigo;
                linha["DESCRICAO"] = pes.Obra.Titulo;

                dt.Rows.Add(linha);
            }


            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
        }
        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IntClientes"] = null;
                Session["IntItem"] = null;
            }
        }

        #region Click
        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            VendaItensBL vendaItemBL = new VendaItensBL();
            string paginaRel = "";
            if (rbMaisVendidos.Checked)
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(txtCliente.Text, txtItem.Text, txtDataIni.Text, txtDataFim.Text, "desc").Tables[0];
                paginaRel = "WinOpen('/Relatorios/RelVendasAcumulados.aspx?acumulado=Mais&DtIni=" + txtDataIni.Text + "&DtFim=" + txtDataFim.Text + "','',600,760);";
            }
            else if (rbMenosVendidos.Checked)
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(txtCliente.Text, txtItem.Text, txtDataIni.Text, txtDataFim.Text, "asc").Tables[0];
                paginaRel = "WinOpen('/Relatorios/RelVendasAcumulados.aspx?acumulado=Menos&DtIni=" + txtDataIni.Text + "&DtFim=" + txtDataFim.Text + "','',600,760);";
            }
            else
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(txtCliente.Text, txtItem.Text, txtDataIni.Text, txtDataFim.Text).Tables[0];
                paginaRel = "WinOpen('/Relatorios/RelVendas.aspx?DtIni=" + txtDataIni.Text + "&DtFim=" + txtDataFim.Text + "','',600,1125);";
            }

            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),  paginaRel.ToString() , true);
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

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {

            CarregarPesquisaCliente(null);
            ModalPopupExtenderPesquisaCliente.Enabled = true;
            ModalPopupExtenderPesquisaCliente.Show();
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {

            CarregarPesquisaItem(null);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntClientes"] != null && Session["IntClientes"] != string.Empty)
                txtCliente.Text = Session["IntClientes"].ToString() + ",";

            txtCliente.Text = txtCliente.Text + gvrow.Cells[2].Text;
            Session["IntClientes"] = txtCliente.Text;
            ModalPopupExtenderPesquisaCliente.Hide();
            ModalPopupExtenderPesquisaCliente.Enabled = false;
        }

        protected void btnSelectItem_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntItem"] != string.Empty && Session["IntItem"] != null)
                txtItem.Text = Session["IntItem"].ToString() + ",";

            txtItem.Text = txtItem.Text + gvrow.Cells[2].Text;
            Session["IntItem"] = txtItem.Text;
            ModalPopupExtenderPesquisaItem.Hide();
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaCliente.Enabled = false;
        }

        protected void btnCancelItem_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }
        #endregion Click


        #region TextChanged

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaCliente(txtPesquisa.Text);
            ModalPopupExtenderPesquisaCliente.Enabled = true;
            ModalPopupExtenderPesquisaCliente.Show();
            txtPesquisa.Text = "";
        }

        protected void txtPesquisaItem_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisaItem.Text);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();
            txtPesquisaItem.Text = "";
        }


        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
                Session["IntClientes"] = null;
            Session["IntClientes"] = txtCliente.Text;

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (txtItem.Text == "")
                Session["IntItem"] = null;
            Session["IntItem"] = txtItem.Text;
        }

        #endregion TextChanged

        #region RowDataBound
        protected void grdPesquisaCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        #endregion

        
    }
}