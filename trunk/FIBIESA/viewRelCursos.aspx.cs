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
    public partial class viewRelCursos : System.Web.UI.Page
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

        private void CarregarAtributos()
        {
            txtDataIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataIniF.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFimF.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }

        #endregion
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
        }

        protected void btnPesEvento_Click(object sender, EventArgs e)
        {         

            CarregarPesquisaEvento(null);
            ModalPopupExtenderPesquisaEvento.Enabled = true;
            ModalPopupExtenderPesquisaEvento.Show();
        
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


        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            EventosBL eventosBL = new EventosBL();
            
           

            Session["ldsRel"] = eventosBL.PesquisarDataset(txtEvento.Text, txtDataIni.Text, txtDataIniF.Text, txtDataFim.Text, txtDataFimF.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelCursos.aspx?Eventos=" + txtEvento.Text + "','',600,825);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }

        }

        #region TextChanged

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaEvento(txtPesquisa.Text);
            ModalPopupExtenderPesquisaEvento.Enabled = true;
            ModalPopupExtenderPesquisaEvento.Show();
            txtPesquisa.Text = "";
        }

        protected void txtEvento_TextChanged(object sender, EventArgs e)
        {
            if (txtEvento.Text == "")
                Session["IntEvento"] = null;
            Session["IntEvento"] = txtEvento.Text;
        }
        #endregion
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void grdPesquisaEvento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
    }
}