using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using DataObjects;
using BusinessLayer;


namespace Admin
{
    public partial class viewBanco : System.Web.UI.Page
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

            BancosBL banBL = new BancosBL();

            List<Bancos> bancos = banBL.PesquisarBL();

            foreach (Bancos ban in bancos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = ban.Id;
                linha["CODIGO"] = ban.Codigo;
                linha["DESCRICAO"] = ban.Descricao;


                tabela.Rows.Add(linha);
            }

            dtgBancos.DataSource = tabela;
            dtgBancos.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

     
        protected void dtgBancos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                BancosBL banBL = new BancosBL();
                Bancos bancos = new Bancos();
                bancos.Id = utils.ComparaIntComZero(dtgBancos.DataKeys[e.RowIndex][0].ToString());
                banBL.ExcluirBL(bancos);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

        }

        protected void dtgBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ban = 0;
            str_ban = utils.ComparaIntComZero(dtgBancos.SelectedDataKey[0].ToString());
            Response.Redirect("cadBanco.aspx?id_ban=" + str_ban.ToString() + "&operacao=edit");
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadBanco.aspx?operacao=new");
        }
    }
}