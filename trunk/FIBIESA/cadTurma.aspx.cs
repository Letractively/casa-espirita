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

namespace Admin
{
    public partial class cadTurma : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_tur)
        {
            TurmasBL turBL = new TurmasBL();
            List<Turmas> turmas = turBL.PesquisarBL(id_tur);

            foreach (Turmas ltTur in turmas)
            {
                hfId.Value = ltTur.Id.ToString();
                txtCodigo.Text = ltTur.Codigo.ToString();
                txtDescricao.Text = ltTur.Descricao;
                txtSala.Text = ltTur.Sala;
                txtNroMax.Text = ltTur.Nromax.ToString();
                txtDiaSemana.Text = ltTur.DiaSemana;
                txtDtFim.Text = ltTur.DataFinal.ToString();
                txtDtInicio.Text = ltTur.DataInicial.ToString();
                txtHoraFim.Text = ltTur.HoraFim.ToString();
                txtHoraInicio.Text = ltTur.HoraIni.ToString();
                hfIdEvento.Value = ltTur.EventoId.ToString();
                hfIdPessoa.Value = ltTur.PessoaId.ToString();

            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tur = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_tur"] != null)
                            id_tur = Convert.ToInt32(Request.QueryString["id_tur"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_tur);

                btnParticipantes.Visible = v_operacao.ToLower() == "edit";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TurmasBL turBL = new TurmasBL();
            Turmas turmas = new Turmas();

            turmas.Id = utils.ComparaIntComZero(hfId.Value);
            turmas.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            turmas.Descricao = txtDescricao.Text;
            turmas.DiaSemana = txtDiaSemana.Text;
            turmas.Nromax = utils.ComparaIntComZero(txtNroMax.Text);
            turmas.EventoId = utils.ComparaIntComZero(hfIdEvento.Value);
            turmas.HoraFim = utils.ComparaDataComNull(txtHoraFim.Text);
            turmas.HoraIni = utils.ComparaDataComNull(txtHoraInicio.Text);
            turmas.DataFinal = utils.ComparaDataComNull(txtDtFim.Text);
            turmas.DataInicial = utils.ComparaDataComNull(txtDtInicio.Text);
            turmas.Sala = txtSala.Text;
            turmas.PessoaId = utils.ComparaIntComNull(hfIdPessoa.Value);
            
            if (turmas.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    turBL.EditarBL(turmas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    turBL.InserirBL(turmas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewTurma.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTurma.aspx");
        }

        protected void btnPesEvento_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            EventosBL eveBL = new EventosBL();
            List<Eventos> eventos = eveBL.PesquisarBL();

            foreach (Eventos eve in eventos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = eve.Id;
                linha["CODIGO"] = eve.Codigo;
                linha["DESCRICAO"] = eve.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

           
            Eventos ev = new Eventos();

            Session["objBLPesquisa"] = eveBL;
            Session["objPesquisa"] = ev;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtEvento.ClientID + "&id=" + hfIdEvento.ClientID + "&lbl=" + lblDesEvento.ClientID + "','',600,500);", true);
        }

        protected void btnPesInstrutor_Click(object sender, EventArgs e)
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


            Pessoas pe = new Pessoas();

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtInstrutor.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesInstrutor.ClientID + "','',600,500);", true);
        }

        protected void btnParticipantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurmaParticipantes.aspx?turmaId=" + hfId.Value + "&lblDesTurma=" + txtDescricao.Text);
        }        
      
    }
}