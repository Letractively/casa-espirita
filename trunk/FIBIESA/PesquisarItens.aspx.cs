using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;
using System.Text;

namespace FIBIESA
{
    public partial class PesquisarItens : System.Web.UI.Page
    {
        #region funcoes
        private void PesquisarConteudo()
        {
            
            /*DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("QUANTIDADE", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);
            dt.Columns.Add(coluna5);

            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            MovimentosEstoqueBL movEstBL = new MovimentosEstoqueBL();
            DataTable dt = itEstBL.PesquisarItensEstoqueBL();
            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();

            List<ItensEstoque> itensEstoque = itEstBL.Pesquisar();

            foreach (ItensEstoque itEst in itensEstoque)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = itEst.Id;
                linha["CODIGO"] = itEst.PesCodigo;
                linha["TITULO"] = bas.PesDescricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            DataTable tabela;

            
            grdPesquisa.DataSource = tabela;
            grdPesquisa.DataBind();*/

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            PesquisarConteudo();
        }

        protected void btnPesquisa_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grdPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder js = new StringBuilder();
            string str_nome_caixa = Request.QueryString["caixa"].ToString();
            string str_nome_lbl = Request.QueryString["lbl"].ToString();
            string str_nome_id = Request.QueryString["id"].ToString();
            string str_nome_valor = Request.QueryString["valor"].ToString();
            string str_id = grdPesquisa.SelectedDataKey[0].ToString();
            GridViewRow row = grdPesquisa.SelectedRow;
            string str_cod = row.Cells[2].Text;
            string str_des = row.Cells[3].Text;
            string str_valor = row.Cells[4].Text;

            js.Append("<script language='javascript'>");
            js.Append("window.opener.document.getElementById('" + str_nome_caixa + "').value = '" + str_cod + "';");
            js.Append("window.opener.document.getElementById('" + str_nome_id + "').value = '" + str_id + "';");
            js.Append("window.opener.document.getElementById('" + str_nome_valor + "').value = '" + str_valor + "';");
            js.Append("window.opener.document.getElementById('" + str_nome_lbl + "').innerHTML = '" + str_des + "';");

            if (Request.QueryString["caixaPost"] != null)
                js.Append("window.opener.__doPostBack('" + Request.QueryString["caixaPost"].ToString() + "','');");

            js.Append("window.close();");
            js.Append("</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), js.ToString(), false);
        }
    }
}