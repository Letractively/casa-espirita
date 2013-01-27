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
    public partial class viewCurso : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("cursos");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            CursosBL curBL = new CursosBL();

            List<Cursos> cursos = curBL.PesquisarBL();

            foreach (Cursos cur in cursos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = cur.Id;
                linha["CODIGO"] = cur.Codigo;
                linha["DESCRICAO"] = cur.Descricao;


                tabela.Rows.Add(linha);
            }

            dtgCursos.DataSource = tabela;

            dtgCursos.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }


        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadCurso.aspx?operacao=new");
        }


        protected void btnBusca_Click(object sender, EventArgs e)
        {

        }

        protected void dtgCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_cur = 0;
            str_cur = utils.ComparaIntComZero(dtgCursos.SelectedDataKey[0].ToString());
            Response.Redirect("cadCurso.aspx?id_cur=" + str_cur.ToString() + "&operacao=edit");
        }

        protected void dtgCursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CursosBL curBL = new CursosBL();
            Cursos cursos = new Cursos();
            cursos.Id = utils.ComparaIntComZero(dtgCursos.DataKeys[e.RowIndex][0].ToString());
            curBL.ExcluirBL(cursos);
            Pesquisar();
        }


    }
}