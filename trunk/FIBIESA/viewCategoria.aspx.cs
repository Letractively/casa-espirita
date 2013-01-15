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
    public partial class viewCategoria : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("tabela");
            /*Cria as colunas do datatable*/
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            /*Adiciona as colunas a datatable*/
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

            dtgCategorias.DataSource = tabela;
            dtgCategorias.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
               
        protected void btnBusca_Click(object sender, EventArgs e)
        {

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadCategoria.aspx");
        }

        protected void dtgCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriasBL catBL = new CategoriasBL();
            Categorias categorias = new Categorias();
            categorias.Id = utils.ComparaIntComZero(dtgCategorias.DataKeys[e.RowIndex][0].ToString());
            catBL.ExcluirBL(categorias);
            Pesquisar();
        }

        protected void dtgCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_cat = 0;
            str_cat = Convert.ToInt32(dtgCategorias.SelectedDataKey[0].ToString());
            Response.Redirect("cadCategoria.aspx?id_cat=" + str_cat.ToString() + "&operacao=edit"); 
        }
    }
}