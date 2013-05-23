using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
namespace FIBIESA
{
    public partial class viewRelCursos : System.Web.UI.Page
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

        private void CarregarAtributos()
        {
            txtDataIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataIniF.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFimF.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }

        #endregion
        public void pesquisaEvento(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            EventosBL eventosBL = new EventosBL();
            Eventos eventos = new Eventos();
            List<Eventos> lEventos;

            lEventos = eventosBL.PesquisarBL();

            foreach (Eventos eventoItem in lEventos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = eventoItem.Id;
                linha["CODIGO"] = eventoItem.Codigo;
                linha["DESCRICAO"] = eventoItem.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = eventosBL;
            Session["objPesquisa"] = eventos;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
        }

        protected void btnPesCurso_Click(object sender, EventArgs e)
        {
            pesquisaEvento("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtcurso.ClientID + "&id=" + hfIdCodigo.ClientID + "&lbl=" + lblDesCodigo.ClientID + "','',600,500);", true);
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            EventosBL eventosBL = new EventosBL();
            
           

            Session["ldsRel"] = eventosBL.PesquisarDataset(txtcurso.Text, txtDataIni.Text, txtDataIniF.Text, txtDataFim.Text, txtDataFimF.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelCursos.aspx?Eventos=" + txtcurso.Text + "','',600,815);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }

        }

        protected void txtcurso_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}