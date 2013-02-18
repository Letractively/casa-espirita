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
    public partial class viewFormulario : System.Web.UI.Page
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

            FormulariosBL forBL = new FormulariosBL();

            List<Formularios> formularios = forBL.PesquisarBL();

            foreach (Formularios formu in formularios)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = formu.Id;
                linha["CODIGO"] = formu.Codigo;
                linha["DESCRICAO"] = formu.Descricao;


                tabela.Rows.Add(linha);
            }

            dtgFormularios.DataSource = tabela;
            dtgFormularios.DataBind();
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadFormulario.aspx?operacao=new");
        }

        protected void dtgFormularios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FormulariosBL formBL = new FormulariosBL();
            Formularios formularios = new Formularios();
            formularios.Id = utils.ComparaIntComZero(dtgFormularios.DataKeys[e.RowIndex][0].ToString());
            formBL.ExcluirBL(formularios);
            Pesquisar();
        }

        protected void dtgFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_for = 0;
            str_for = utils.ComparaIntComZero(dtgFormularios.SelectedDataKey[0].ToString());
            Response.Redirect("cadFormulario.aspx?id_for=" + str_for.ToString() + "&operacao=edit");
        }

        protected void dtgFormularios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgFormularios.PageIndex = e.NewPageIndex;
            dtgFormularios.DataBind();
        }

        protected void dtgFormularios_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = dtgFormularios.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                dtgFormularios.DataSource = dataView;
                dtgFormularios.DataBind();
            }
        }
         
    }
}