using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;

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

      
    }
}