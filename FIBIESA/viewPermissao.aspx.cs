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

namespace Admin
{
    public partial class viewPermicao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("tabela");
            
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
          
            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);           
            
            CategoriasBL catBL = new CategoriasBL();
            
            List<Categorias> categorias = catBL.PesquisarBL();

            foreach (Categorias cat in categorias)
            {
                
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;                
                              
                tabela.Rows.Add(linha);
            }
            
            dtgPermissoes.DataSource = tabela;           
            dtgPermissoes.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPermissao.aspx?operacao=new");
        }

        protected void dtgPermissoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_per_cat = 0;
            str_per_cat = utils.ComparaIntComZero(dtgPermissoes.SelectedDataKey[0].ToString());
            Response.Redirect("cadPermissao.aspx?id_per_cat=" + str_per_cat.ToString());
        }

                             
    }
}