using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;


namespace Admin
{
    public partial class viewEstado : System.Web.UI.Page
    {
        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("tabela");
            /*Cria as colunas do datatable*/
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("UF", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            /*Adiciona as colunas a datatable*/

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            /*Efetua a pesquisa dos estados recebendo como retorno uma lista de estados*/
            EstadosBL estBL = new EstadosBL();
            //Esta pesquisando todos os livros sempre
            List<Estados> estados = estBL.PesquisarBL();

            /*Preenche as linhas do datatable com o retorno da consulta*/
            foreach (Estados est in estados)
            {
                /*Cria uma linha vazia*/
                DataRow linha = tabela.NewRow();
                /*Preenche as colunas desta linha vazia*/
                linha["ID"] = est.Id;
                linha["UF"] = est.Uf;
                linha["DESCRICAO"] = est.Descricao;

                /*Adiciona a linha vazia no datatable*/
                tabela.Rows.Add(linha);
            }
            /*Vincula o datatable ao gridview para ser possivel visualizar o resultado da pesquisa */
            grdEstados.DataSource = tabela;
            /*efetua a atualização da datagrid para exibir os dados da consulta.*/
            grdEstados.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        protected void Busca_Click(object sender, EventArgs e)
        {

        }

        protected void grdEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

            int str_Est = 0;
            
            str_Est = Convert.ToInt32(grdEstados.SelectedDataKey[0].ToString());

            Response.Redirect("cadEstado.aspx?id_est=" + str_Est.ToString() + "&operacao=edit");
        }

        protected void imgBtnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnExcluir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grdEstados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();
            int est;
            est = int.Parse(grdEstados.DataKeys[e.RowIndex][0].ToString());
            estados.Id = int.Parse(grdEstados.DataKeys[e.RowIndex][0].ToString());
            estBL.ExcluirBL(estados);
            Pesquisar();

        }

        protected void bntInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadEstado.aspx?operacao=new");
        }

    }
}