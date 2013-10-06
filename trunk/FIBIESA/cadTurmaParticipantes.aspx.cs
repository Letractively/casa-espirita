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
    public partial class cadTurmaAluno : System.Web.UI.Page
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

        public DataTable dtbPesquisaParticipanteNotInTurma
        {
            get
            {
                if (Session["_dtbPesquisaParticipanteNotInTurma_cadForm"] != null)
                    return (DataTable)Session["_dtbPesquisaParticipanteNotInTurma_cadForm"];
                else
                    return null;
            }
            set { Session["_dtbPesquisaParticipanteNotInTurma_cadForm"] = value; }
        }

        private void Pesquisar(int turmaId)
        {

            TurmasBL turBL = new TurmasBL();
            DataSet dsTur = turBL.PesquisarBL(turmaId);

            if (dsTur.Tables[0].Rows.Count != 0)
                lblTurma.Text = (string)dsTur.Tables[0].Rows[0]["descricao"].ToString();

        }

        private void PesquisarParticipante(int turmaId)
        {


            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            List<TurmasParticipantes> tPar = tParBL.PesquisarBL(turmaId, txtParticipante.Text);

            foreach (TurmasParticipantes ltTpar in tPar)
            {
                DataRow linha = tabela.NewRow();
                linha["ID"] = ltTpar.Id;
                linha["CODIGO"] = ltTpar.Pessoa.Codigo;
                linha["NOME"] = ltTpar.Pessoa.Nome;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgParticipantes.DataSource = tabela;
            dtgParticipantes.DataBind();
            mensagemErro.InnerText = string.Empty;


        }

        private void PesquisarParticipanteNotInTurma(int turmaId)
        {


            TurmasBL turBL = new TurmasBL();
            DataSet dsTur = turBL.PesquisarBL(turmaId);

            if (dsTur.Tables[0].Rows.Count != 0)
                lblTurma.Text = (string)dsTur.Tables[0].Rows[0]["descricao"].ToString();

            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            DataSet tPar = tParBL.PesquisarParticipantesNotInTurmaBL(turmaId, txtParticipante.Text);

            dtbPesquisaParticipanteNotInTurma = tPar.Tables[0];
            dtgParticipantesNotInTurma.DataSource = tPar;
            dtgParticipantesNotInTurma.DataBind();
            mensagemErro.InnerText = string.Empty;


        }

        public void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                    updPrincipal,
                                    this.GetType(),
                                    "Alert",
                                    "window.alert(\"" + mensagem + "\");",
                                    true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["turmaId"] != null)
                {
                    if (Request.QueryString["lblDesTurma"] != null)
                        lblTurma.Text = Request.QueryString["lblDesTurma"].ToString();

                    hfIdTurma.Value = Session["turmaId"].ToString();
                    Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value));
                    //PesquisarParticipanteNotInTurma(utils.ComparaIntComZero(hfIdTurma.Value));
                }

                else
                {
                    Session["turmaId"] = 1;
                    if (Session["turmaId"] != null)
                    {
                        if (Request.QueryString["lblDesTurma"] != null)
                            lblTurma.Text = Request.QueryString["lblDesTurma"].ToString();

                        hfIdTurma.Value = Session["turmaId"].ToString();
                        Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value));
                        //PesquisarParticipanteNotInTurma(utils.ComparaIntComZero(hfIdTurma.Value));
                    }
                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurma.aspx?id_tur=" + hfIdTurma.Value + "&operacao=edit");
        }

        protected void btnPesParticipante_Click(object sender, EventArgs e)
        {
                validapesquisa();
        }

        protected void dtgParticipantesNotInTurma_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            TurmasParticipantes tPar = new TurmasParticipantes();

            tPar.Id = utils.ComparaIntComZero(hfId.Value);
            tPar.PessoaId = utils.ComparaIntComZero(dtgParticipantesNotInTurma.DataKeys[e.RowIndex][0].ToString());
            tPar.TurmaId = utils.ComparaIntComZero(hfIdTurma.Value);

            if (!tParBL.InserirBL(tPar))
                ExibirMensagem("Erro: Número máximo de participantes atingido.");
            validapesquisa();

        }

        protected void dtgParticipantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            TurmasParticipantes tPar = new TurmasParticipantes();
            tPar.Id = utils.ComparaIntComZero(dtgParticipantes.DataKeys[e.RowIndex][0].ToString());
            tParBL.ExcluirBL(tPar);
            validapesquisa();
        }

        protected void dtgParticipantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgParticipantesNotInTurma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgParticipantes_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgParticipantes.DataSource = m_DataView;
                dtgParticipantes.DataBind();
            }
        }

        protected void dtgParticipantesNotInTurma_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (dtbPesquisaParticipanteNotInTurma != null)
            {
                string ordem = e.SortExpression;

                DataView m_DataView = new DataView(dtbPesquisaParticipanteNotInTurma);

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

                dtbPesquisaParticipanteNotInTurma = m_DataView.ToTable();
                dtgParticipantesNotInTurma.DataSource = m_DataView;
                dtgParticipantesNotInTurma.DataBind();
            }
        }

        protected void dtgParticipantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgParticipantes.DataSource = dtbPesquisa;
            dtgParticipantes.PageIndex = e.NewPageIndex;
            dtgParticipantes.DataBind();
        }

        protected void dtgParticipantesNotInTurma_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgParticipantesNotInTurma.DataSource = dtbPesquisaParticipanteNotInTurma;
            dtgParticipantesNotInTurma.PageIndex = e.NewPageIndex;
            dtgParticipantesNotInTurma.DataBind();
        }

        protected void txtParticipante_TextChanged(object sender, EventArgs e)
        {

            validapesquisa();


        }


        public void validapesquisa()
        {
            if (txtParticipante.Text.Length >= 3)
            {
                if (CheckBoxList1.Items[1].Selected)
                {
                    PesquisarParticipante(utils.ComparaIntComZero(hfIdTurma.Value));
                }
                else
                {
                    dtgParticipantes.DataBind();
                }

                if (CheckBoxList1.Items[0].Selected)
                {
                    PesquisarParticipanteNotInTurma(utils.ComparaIntComZero(hfIdTurma.Value));
                }
                else
                {
                    dtgParticipantesNotInTurma.DataBind();
                }

                if (!CheckBoxList1.Items[0].Selected && !CheckBoxList1.Items[1].Selected)
                {
                    mensagemErro.InnerText = "Selecione um tipo de filtro, Participante ou Não Participante.";
                }
            }
            else
            {
                mensagemErro.InnerText = "Para realizar a pesquisa digite no mínimo 3 caracteres.";
            }

        }

    }
}