using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;
using System.Data;
using System.Data.SqlClient;

namespace FIBIESA
{
    public partial class viewDoacao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("DATA", Type.GetType("System.DateTime"));
            DataColumn coluna3 = new DataColumn("CODPESSOA", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("VALOR", Type.GetType("System.Decimal"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            DoacoesBL doaBL = new DoacoesBL();
            List<Doacoes> doacoes = doaBL.PesquisarBL();

            foreach (Doacoes ltDoa in doacoes)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltDoa.Id;
                linha["DATA"] = ltDoa.Data;
                linha["CODPESSOA"] = ltDoa.Pessoa.Codigo;
                linha["NOME"] = ltDoa.Pessoa.Nome;
                linha["VALOR"] = ltDoa.Valor;

                tabela.Rows.Add(linha);               
            }

            dtgDoacao.DataSource = tabela;
            dtgDoacao.DataBind(); 
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadDoacao.aspx");
        }
                
        protected void dtgDoacao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                DoacoesBL doaBL = new DoacoesBL();
                Doacoes doacoes = new Doacoes();
                doacoes.Id = utils.ComparaIntComZero(dtgDoacao.DataKeys[e.RowIndex][0].ToString());
                doaBL.ExcluirBL(doacoes);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        
    }
}