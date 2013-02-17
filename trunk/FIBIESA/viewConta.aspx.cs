using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class viewConta : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CODAGENCIA", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DESCAGENCIA", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            ContasBL conBL = new ContasBL();
            List<Contas> contas = conBL.PesquisarBL();

            foreach (Contas ltCon in contas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltCon.Id;
                linha["CODIGO"] = ltCon.Codigo;
                linha["DESCRICAO"] = ltCon.Descricao;
                if (ltCon.Agencia != null)
                {
                    linha["CODAGENCIA"] = ltCon.Agencia.Codigo.ToString();
                    linha["DESCAGENCIA"] = ltCon.Agencia.Descricao.ToString();
                }

                tabela.Rows.Add(linha);
            }

            dtgContas.DataSource = tabela;
            dtgContas.DataBind();
        }   
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadConta.aspx?operacao=new");
        }

        protected void dtgContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_con = 0;
            str_con = utils.ComparaIntComZero(dtgContas.SelectedDataKey[0].ToString());
            Response.Redirect("cadConta.aspx?id_con=" + str_con.ToString() + "&operacao=edit");
        }

        protected void dtgContas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                ContasBL conBL = new ContasBL();
                Contas contas = new Contas();
                contas.Id = utils.ComparaIntComZero(dtgContas.DataKeys[e.RowIndex][0].ToString());
                conBL.ExcluirBL(contas);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
    }
}