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
    public partial class viewPessoa : System.Web.UI.Page
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
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CPFCNPJ", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("TIPO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("CATEGORIAID", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("DTCADASTRO", Type.GetType("System.String"));
            DataColumn coluna8 = new DataColumn("DESCATEGORIA", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);

            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pessoas;

            pessoas = pesBL.PesquisarBuscaBL(valor);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["NOME"] = pes.Nome;
                linha["CPFCNPJ"] = utils.FormataCNPJouCPF(pes.CpfCnpj);
                linha["TIPO"] = pes.Tipo;
                linha["CATEGORIAID"] = pes.CategoriaId;
                linha["DTCADASTRO"] = pes.DtCadastro.ToString("dd/MM/yyyy");

                CategoriasBL catBL = new CategoriasBL();
                List<Categorias> categorias = catBL.PesquisarBL(pes.CategoriaId);
                foreach (Categorias cat in categorias)
                {
                    linha["DESCATEGORIA"] = cat.Descricao;
                }

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgPessoas.DataSource = tabela;
            dtgPessoas.DataBind();
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPessoa.aspx?operacao=new&tipoPessoa=" + rblPesJurFis.SelectedValue);
        }

        protected void dtgPessoas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoas = new Pessoas();

            pessoas.Id = utils.ComparaIntComZero(dtgPessoas.DataKeys[e.RowIndex][0].ToString());
            if (pesBL.ExcluirBL(pessoas))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");
            Pesquisar(null);
        }

        protected void dtgPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_pes = 0;
            str_pes = utils.ComparaIntComZero(dtgPessoas.SelectedDataKey[0].ToString());
            Response.Redirect("cadPessoa.aspx?id_pes=" + str_pes.ToString() + "&operacao=edit&tipoPessoa=" + rblPesJurFis.SelectedValue);
        }

        protected void dtgPessoas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgPessoas.DataSource = dtbPesquisa;
            dtgPessoas.PageIndex = e.NewPageIndex;
            dtgPessoas.DataBind();
        }

        protected void dtgPessoas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void dtgPessoas_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgPessoas.DataSource = m_DataView;
                dtgPessoas.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            int pes_id = utils.ComparaIntComZero(dtgPessoas.DataKeys[gvrow.RowIndex].Value.ToString());

            if (pes_id > 0)                                                                                                                                                                                                                                                                                                                                                                                                                                                         //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "WinOpen('/Relatorios/RelCarteirinha.aspx?pessoaid=" + pes_id + "','',600,850);", true);

        }

    }
}