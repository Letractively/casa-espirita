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

namespace StarFestaEventos
{
    public partial class Pesquisar : System.Web.UI.Page
    {
        private BaseBL baBL;
        private Base ba;
        Utils utils = new Utils();
        #region funcoes
        private void PesquisarConteudo(string pesquisa)
        {
            Session["tabelaPesquisa"] = null;
            
            
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            
            baBL =(BaseBL)Session["objBLPesquisa"];
            ba = (Base)Session["objPesquisa"];
            
            List<Base> baPes = baBL.Pesquisar(pesquisa);

            foreach (Base bas in baPes)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = bas.PesId1;
                linha["CODIGO"] = bas.PesCodigo;
                linha["DESCRICAO"] = bas.PesDescricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            
            grdPesquisa.DataSource = dt;                        
            grdPesquisa.DataBind();

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tabelaPesquisa"] != null) 
                {
                    DataTable tabela;

                    tabela = (DataTable)Session["tabelaPesquisa"];

                    grdPesquisa.DataSource = tabela;
                    grdPesquisa.DataBind();
                }
            }

        }

        protected void grdPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder js = new StringBuilder();
            string str_nome_caixa = Request.QueryString["caixa"].ToString();
            string str_nome_lbl = Request.QueryString["lbl"].ToString();
            string str_nome_id = Request.QueryString["id"].ToString();
            string str_id = grdPesquisa.SelectedDataKey[0].ToString();
            GridViewRow row = grdPesquisa.SelectedRow;
            string str_cod = row.Cells[2].Text;
            string str_des = row.Cells[3].Text;

            js.Append("<script language='javascript'>");
            js.Append("window.opener.document.getElementById('" + str_nome_caixa + "').value = '" + str_cod + "';");
            js.Append("window.opener.document.getElementById('" + str_nome_id + "').value = '" + str_id + "';");
            js.Append("window.opener.document.getElementById('" + str_nome_lbl + "').innerHTML = '" + str_des + "';");

            if (Request.QueryString["caixaPost"] != null)
                js.Append("window.opener.__doPostBack('" + Request.QueryString["caixaPost"].ToString() + "','');");

            js.Append("window.close();");
            js.Append("</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), js.ToString(), false);
        }

        protected void btnPesquisa_Click(object sender, ImageClickEventArgs e)
        {
            PesquisarConteudo(txtPesquisa.Text);
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

      
    }
}