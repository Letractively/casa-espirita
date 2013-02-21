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
        private void Pesquisar(int turmaId)
        {          
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

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

            dtgParticipantes.DataSource = tabela;
            dtgParticipantes.DataBind();

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["turmaId"] != null)
                {
                    if (Request.QueryString["lblDesTurma"] != null)
                        lblTurma.Text = Request.QueryString["lblDesTurma"].ToString();

                    hfIdTurma.Value = Request.QueryString["turmaId"].ToString();
                    Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value));
                }
            }

        }

        protected void btnPesParticipante_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtParticipante.ClientID + "&id=" + hfIdParticipante.ClientID + "&lbl=" + lblDesParticipante.ClientID + "','',600,500);", true);
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

       
    }
}