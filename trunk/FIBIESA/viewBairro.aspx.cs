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
    public partial class viewBairro : System.Web.UI.Page
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

            /*Efetua a pesquisa dos bairros recebendo como retorno uma lista de bairros*/
            BairrosBL baiBL = new BairrosBL();
            //Esta pesquisando todos os livros sempre
            List<Bairros> bairros = baiBL.PesquisarBL();

            /*Preenche as linhas do datatable com o retorno da consulta*/
            foreach (Bairros bai in bairros)
            {
                /*Cria uma linha vazia*/
                DataRow linha = tabela.NewRow();
                /*Preenche as colunas desta linha vazia*/
                linha["ID"] = bai.Id;
                linha["CODIGO"] = bai.Codigo;
                linha["DESCRICAO"] = bai.Descricao;

                /*Adiciona a linha vazia no datatable*/
                tabela.Rows.Add(linha);
            }
            /*Vincula o datatable ao gridview para ser possivel visualizar o resultado da pesquisa */
            grdBairros.DataSource = tabela;
            /*efetua a atualização da datagrid para exibir os dados da consulta.*/
            grdBairros.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        protected void Busca_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadBairro.aspx?operacao=new");
        }

        protected void grdBairros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BairrosBL baiBL = new BairrosBL();
            Bairros bairros = new Bairros();
            bairros.Id = utils.ComparaIntComZero(grdBairros.DataKeys[e.RowIndex][0].ToString());
            baiBL.ExcluirBL(bairros);
            Pesquisar();
        }

        protected void grdBairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = Convert.ToInt32(grdBairros.SelectedDataKey[0].ToString());
            Response.Redirect("cadBairro.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }
    }
}