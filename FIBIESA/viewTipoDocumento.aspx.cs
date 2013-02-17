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
    public partial class viewTipoDocumento : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("APLICACAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);

            TiposDocumentosBL tdoBL = new TiposDocumentosBL();           
            List<TiposDocumentos> tDoc = tdoBL.PesquisarBL();
            
            foreach (TiposDocumentos ltTdoc in tDoc)
            {
                DataRow linha = tabela.NewRow();
                linha["ID"] = ltTdoc.Id;
                linha["CODIGO"] = ltTdoc.Codigo;
                linha["DESCRICAO"] = ltTdoc.Descricao;
                linha["APLICACAO"] = ltTdoc.Aplicacao;

                tabela.Rows.Add(linha);
            }

            dtgTipoDocumento.DataSource = tabela;
            dtgTipoDocumento.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }
               

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTipoDocumento.aspx");
        }

        protected void dtgTipoDocumento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                TiposDocumentosBL tdoBL = new TiposDocumentosBL();
                TiposDocumentos tiposDocumento = new TiposDocumentos();
                tiposDocumento.Id = utils.ComparaIntComZero(dtgTipoDocumento.DataKeys[e.RowIndex][0].ToString());
                tdoBL.ExcluirBL(tiposDocumento);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tdo = 0;
            str_tdo = utils.ComparaIntComZero(dtgTipoDocumento.SelectedDataKey[0].ToString());
            Response.Redirect("cadTipoDocumento.aspx?id_tdo=" + str_tdo.ToString() + "&operacao=edit");
        }
    }
}