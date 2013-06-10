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

        private void Pesquisar(int turmaId)
        {          
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            TurmasBL turBL = new TurmasBL();
            DataSet dsTur = turBL.PesquisarBL(turmaId);

            if (dsTur.Tables[0].Rows.Count != 0)
                lblTurma.Text = (string)dsTur.Tables[0].Rows[0]["descricao"].ToString();
          
            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            List<TurmasParticipantes> tPar = tParBL.PesquisarBL(turmaId);
            
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

        }

        public void CarregarPesquisaPessoa(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
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
                }
            }

        }

        protected void btnPesParticipante_Click(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(null);           
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurma.aspx?id_tur="+hfIdTurma.Value + "&operacao=edit");
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
            TurmasParticipantes tPar = new TurmasParticipantes();

            tPar.Id = utils.ComparaIntComZero(hfId.Value);
            tPar.PessoaId = utils.ComparaIntComZero(hfIdParticipante.Value);
            tPar.TurmaId = utils.ComparaIntComZero(hfIdTurma.Value);

            if (tPar.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    tParBL.EditarBL(tPar);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    tParBL.InserirBL(tPar);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            txtParticipante.Text = "";
            lblDesParticipante.Text = "";
            Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value)); 

        }

        protected void dtgParticipantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
                TurmasParticipantes tPar = new TurmasParticipantes();
                tPar.Id = utils.ComparaIntComZero(dtgParticipantes.DataKeys[e.RowIndex][0].ToString());
                tParBL.ExcluirBL(tPar);
                Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value));
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgParticipantes_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void dtgParticipantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgParticipantes.DataSource = dtbPesquisa;
            dtgParticipantes.PageIndex = e.NewPageIndex;
            dtgParticipantes.DataBind();
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdParticipante.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtParticipante.Text = gvrow.Cells[2].Text;
            lblDesParticipante.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;

        }

        protected void txtParticipante_TextChanged(object sender, EventArgs e)
        {
            hfIdParticipante.Value = "";
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO", txtParticipante.Text);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdParticipante.Value = ltpessoa.Id.ToString();
                txtParticipante.Text = ltpessoa.Codigo.ToString();
                lblDesParticipante.Text = ltpessoa.Nome;
                btnInserir.Focus();
            }

            if (utils.ComparaIntComZero(hfIdParticipante.Value) <= 0)
            {
                ExibirMensagem("Cliente não cadastrado !");
                txtParticipante.Text = "";
                lblDesParticipante.Text = "";
                txtParticipante.Focus();
                hfIdParticipante.Value = "";
            }
        }

       
    }
}