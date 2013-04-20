using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using System.Data;
using BusinessLayer;
using FG;

namespace FIBIESA
{
    public partial class viewInstituicao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadForm"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadForm"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadForm"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("RAZAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("EMAIL", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("CNPJ", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("CIDADEID", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("CEP", Type.GetType("System.String"));
            DataColumn coluna8 = new DataColumn("ENDERECO", Type.GetType("System.String"));
            DataColumn coluna9 = new DataColumn("NUMERO", Type.GetType("System.String"));
            DataColumn coluna10 = new DataColumn("COMPLEMENTO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);
            tabela.Columns.Add(coluna10);

            InstituicoesBL insBL = new InstituicoesBL();
            List<Instituicoes> instituicoes;

            instituicoes = insBL.PesquisarBuscaBL(valor);
            
            foreach (Instituicoes ins in instituicoes)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ins.Id;
                linha["CODIGO"] = ins.Codigo;
                linha["RAZAO"] = ins.Razao;
                linha["EMAIL"] = ins.Email;
                linha["CNPJ"] = ins.Cnpj;
                linha["CIDADEID"] = ins.CidadeId;
                linha["CEP"] = ins.Cep;
                linha["ENDERECO"] = ins.Endereco;
                linha["NUMERO"] = ins.Numero;
                linha["COMPLEMENTO"] = ins.Complemento;

                tabela.Rows.Add(linha);   
            }

            dtbPesquisa = tabela;
            dtgInstituicao.DataSource = tabela;
            dtgInstituicao.DataBind();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadInstituicao.aspx?operacao=new");
        }

        protected void dtgInstituicao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                InstituicoesBL insBL = new InstituicoesBL();
                Instituicoes instituicoes = new Instituicoes();
                instituicoes.Id = utils.ComparaIntComZero(dtgInstituicao.DataKeys[e.RowIndex][0].ToString());
                insBL.ExcluirBL(instituicoes);
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgInstituicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ins = 0;
            str_ins = utils.ComparaIntComZero(dtgInstituicao.SelectedDataKey[0].ToString());
            Response.Redirect("cadInstituicao.aspx?id_ins=" + str_ins.ToString() + "&operacao=edit");
        }

        protected void dtgInstituicao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgInstituicao.DataSource = dtbPesquisa;
            dtgInstituicao.PageIndex = e.NewPageIndex;
            dtgInstituicao.DataBind();
        }

        protected void dtgInstituicao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgInstituicao_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgInstituicao.DataSource = m_DataView;
                dtgInstituicao.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);  
        }
    }
}