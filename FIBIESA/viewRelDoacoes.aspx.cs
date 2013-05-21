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
    public partial class viewRelDoacoes : System.Web.UI.Page
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

        private void CarregarAtributos()
        {
            txtDataIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            //txtCodPessoa.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtValorIni.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtValorFim.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }
        #endregion
        public DataTable dtGeral;

        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();          
        }
                        

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {

            DoacoesBL doacoesBL = new DoacoesBL();


            Session["ldsRel"] = doacoesBL.PesquisarDataset(txtCliente.Text, txtValorIni.Text, txtValorFim.Text, txtDataIni.Text, txtDataFim.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                string periodo = "Todos";
                if((txtDataIni.Text != string.Empty) && (txtDataFim.Text != string.Empty))
                {
                    periodo = txtDataIni.Text + " a " + txtDataFim.Text;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelDoacoes.aspx?periodo=" + periodo + "','',590,805);", true);
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

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {

            CarregarPesquisaCliente(null);
            ModalPopupExtenderPesquisaCliente.Enabled = true;
            ModalPopupExtenderPesquisaCliente.Show();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntClientes"] != null || Session["IntClientes"] != null)
                txtCliente.Text = Session["IntClientes"].ToString() + ",";

            txtCliente.Text = txtCliente.Text + gvrow.Cells[2].Text;
            Session["IntClientes"] = txtCliente.Text;
            ModalPopupExtenderPesquisaCliente.Hide();
            ModalPopupExtenderPesquisaCliente.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaCliente.Enabled = false;
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaCliente(txtPesquisa.Text);
            ModalPopupExtenderPesquisaCliente.Enabled = true;
            ModalPopupExtenderPesquisaCliente.Show();
            txtPesquisa.Text = "";
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
                Session["IntClientes"] = null;
            Session["IntClientes"] = txtCliente.Text;

        }

        protected void grdPesquisaCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
    }
}