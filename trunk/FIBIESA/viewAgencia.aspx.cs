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


namespace Admin
{
    public partial class viewAgencia : System.Web.UI.Page
    {

        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CODBANCO", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DESBANCO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBL();

            foreach (Agencias ltAge in agencias)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltAge.Id;
                linha["CODIGO"] = ltAge.Codigo;
                linha["DESCRICAO"] = ltAge.Descricao;
                linha["CODBANCO"] = ltAge.Banco.Codigo;
                linha["DESBANCO"] = ltAge.Banco.Descricao;

                tabela.Rows.Add(linha);                
            }

            dtgAgencia.DataSource = tabela;
            dtgAgencia.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadAgencia.aspx?operacao=new");
        }

        protected void dtgAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_age = 0;
            str_age = utils.ComparaIntComZero(dtgAgencia.SelectedDataKey[0].ToString());
            Response.Redirect("cadAgencia.aspx?id_age=" + str_age.ToString() + "&operacao=edit");
        }

        protected void dtgAgencia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                AgenciasBL ageBL = new AgenciasBL();
                Agencias agencias = new Agencias();
                agencias.Id = utils.ComparaIntComZero(dtgAgencia.DataKeys[e.RowIndex][0].ToString());
                ageBL.ExcluirBL(agencias);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

      
    }
}