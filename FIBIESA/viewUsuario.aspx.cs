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
    public partial class viewUsuario : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadUsu"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadUsu"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadUsu"] = value; }
        }

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("PESSOAID", Type.GetType("System.String"));                                                 
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("EMAIL", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("STATUS", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DTINICIO", Type.GetType("System.String"));
            DataColumn coluna7 = new DataColumn("DTFIM", Type.GetType("System.String"));
            DataColumn coluna8 = new DataColumn("CODCAT", Type.GetType("System.Int32"));
            DataColumn coluna9 = new DataColumn("DESCAT", Type.GetType("System.String"));
                       
            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);
           
            UsuariosBL usuBL = new UsuariosBL();           
            List<Usuarios> usuarios;

            if (campo != null && valor.Trim() != "")
                usuarios = usuBL.PesquisarBL(campo, valor);
            else
                usuarios = usuBL.PesquisarBL();

            foreach (Usuarios usu in usuarios)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = usu.Id;
                linha["PESSOAID"] = usu.PessoaId;
                linha["NOME"] = usu.Nome;
                linha["EMAIL"] = usu.Email;
                linha["STATUS"] = usu.Status;
                linha["DTINICIO"] = usu.DtInicio.ToString("dd/MM/yyyy");
                linha["DTFIM"] = usu.DtFim.ToString("dd/MM/yyyy");
                linha["CODCAT"] = usu.Categoria.Codigo;
                linha["DESCAT"] = usu.Categoria.Descricao;
              
                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgUsuarios.DataSource = tabela;
            dtgUsuarios.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar(null, null);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
           Pesquisar(ddlCampo.SelectedValue, txtBusca.Text); 
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadUsuario.aspx?operacao=new");
        }

        protected void dtgUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                UsuariosBL usuBL = new UsuariosBL();
                Usuarios usuarios = new Usuarios();

                usuarios.Id = utils.ComparaIntComZero(dtgUsuarios.DataKeys[e.RowIndex][0].ToString());
                usuBL.ExcluirBL(usuarios);
                Pesquisar(null,null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_usu = 0;
            str_usu = utils.ComparaIntComZero(dtgUsuarios.SelectedDataKey[0].ToString());
            Response.Redirect("cadUsuario.aspx?id_usu=" + str_usu.ToString() + "&operacao=edit");
        }

        protected void dtgUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgUsuarios.DataSource = dtbPesquisa;
            dtgUsuarios.PageIndex = e.NewPageIndex;
            dtgUsuarios.DataBind();
        }

        protected void dtgUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void dtgUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (dtbPesquisa != null)
            {
                string ordem = e.SortExpression;

                DataView m_DataView = new DataView(dtbPesquisa);

                if (ViewState["dtbPesquisa_sort"] != null)
                {
                    if (ViewState["dtbPesquisa_sort"].ToString() == e.SortExpression)
                    {
                        m_DataView.Sort = ordem + " DESC";
                        ViewState["dtbPesquisa_sort"] = null;
                    }
                    else
                    {
                        m_DataView.Sort = ordem;
                        ViewState["dtbPesquisa_sort"] = e.SortExpression;
                    }
                }
                else
                {
                    m_DataView.Sort = ordem;
                    ViewState["dtbPesquisa_sort"] = e.SortExpression;
                }

                dtbPesquisa = m_DataView.ToTable();
                dtgUsuarios.DataSource = m_DataView;
                dtgUsuarios.DataBind();
            }
        }

       
        
    }
}