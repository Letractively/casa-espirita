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
        private void CarregarDdlEventos()
        {
            EventosBL eveBL = new EventosBL();
            List<Eventos> eventos = eveBL.PesquisarBL();

            ddlEvento.Items.Add(new ListItem());
            foreach (Eventos ltEve in eventos)            
                ddlEvento.Items.Add(new ListItem(ltEve.Codigo+" - "+ ltEve.Descricao, ltEve.Id.ToString()));

            ddlEvento.SelectedIndex = 0;
        }

        private void CarregarDdlInstrutor()
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();

            DataSet dsPar = parBL.PesquisarBL(1,"E");

            if (dsPar.Tables[0].Rows.Count != 0)
               parametros.Valor = (string)dsPar.Tables[0].Rows[0]["valor"];

            if (utils.ComparaIntComZero(parametros.Valor) > 0)
            {
                PessoasBL pesBL = new PessoasBL();
                List<Pessoas> pessoas = pesBL.PesquisarPorGeneroDA(utils.ComparaIntComZero(parametros.Valor));

                ddlInstrutor.Items.Add(new ListItem());
                foreach (Pessoas ltPes in pessoas)
                    ddlInstrutor.Items.Add(new ListItem(ltPes.Codigo + " - " + ltPes.Nome, ltPes.Id.ToString()));

                ddlInstrutor.SelectedIndex = 0;
            }
        }

        private void CarregarDados(int id_tur)
        {
            TurmasBL turBL = new TurmasBL();
            List<Turmas> turmas = turBL.PesquisarBL(id_tur);

            foreach (Turmas ltTur in turmas)
            {
                hfId.Value = ltTur.Id.ToString();
                lblcodigo.Text = ltTur.Codigo.ToString();
                txtDescricao.Text = ltTur.Descricao;
                txtSala.Text = ltTur.Sala;
                txtNroMax.Text = ltTur.Nromax.ToString();
                txtDiaSemana.Text = ltTur.DiaSemana;
                txtDtFim.Text = ltTur.DataFinal.ToString("dd/MM/yyyy");
                txtDtInicio.Text = ltTur.DataInicial.ToString("dd/MM/yyyy");
                txtHoraFim.Text = ltTur.HoraFim != null ? Convert.ToDateTime(ltTur.HoraFim).ToString("HH:mm") : "";
                txtHoraInicio.Text = ltTur.HoraIni != null ? Convert.ToDateTime(ltTur.HoraIni).ToString("HH:mm") : "";   
                ddlEvento.SelectedValue = ltTur.EventoId.ToString();               
                ddlInstrutor.SelectedValue = ltTur.PessoaId.ToString();

            }

        }
        private void CarregarAtributos()
        {            
            txtNroMax.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtHoraInicio.Attributes.Add("onKeyPress", "return(formatar(this,'##:##',event))");
            txtHoraFim.Attributes.Add("onKeyPress", "return(formatar(this,'##:##',event))");
            txtDtInicio.Attributes.Add("onKeyPress", "return(formatar(this,'##/##/####',event))");
            txtDtFim.Attributes.Add("onKeyPress", "return(formatar(this,'##/##/####',event))");
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtNroMax.Text = "";
            txtSala.Text = "";
            txtDtInicio.Text = "";
            txtDtFim.Text = "";
            ddlEvento.SelectedIndex = 0;
            ddlInstrutor.SelectedIndex = 0;
            txtDiaSemana.Text = "";

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tur = 0;

            CarregarAtributos();
            CarregarDdlEventos();
            CarregarDdlInstrutor();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null && (Request.QueryString["id_tur"] != null))
                {
                    v_operacao = Request.QueryString["operacao"];
                    if (v_operacao == "edit")
                    {
                        id_tur = Convert.ToInt32(Request.QueryString["id_tur"].ToString());
                        CarregarDados(id_tur);
                    }
                }
                else
                    lblcodigo.Text = "Código gerado automaticamente.";

                btnParticipantes.Visible = v_operacao.ToLower() == "edit";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TurmasBL turBL = new TurmasBL();
            Turmas turmas = new Turmas();

            turmas.Id = utils.ComparaIntComZero(hfId.Value);
            turmas.Codigo = utils.ComparaIntComZero(lblcodigo.Text);
            turmas.Descricao = txtDescricao.Text;
            turmas.DiaSemana = txtDiaSemana.Text;
            turmas.Nromax = utils.ComparaIntComZero(txtNroMax.Text);
            turmas.EventoId = utils.ComparaIntComZero(ddlEvento.SelectedValue);
            turmas.HoraFim = utils.ComparaDataComNull(txtHoraFim.Text);
            turmas.HoraIni = utils.ComparaDataComNull(txtHoraInicio.Text);
            turmas.DataFinal = Convert.ToDateTime(txtDtFim.Text);
            turmas.DataInicial = Convert.ToDateTime(txtDtInicio.Text);
            turmas.Sala = txtSala.Text;
            turmas.PessoaId = utils.ComparaIntComNull(ddlInstrutor.SelectedValue);
            
            if (turmas.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    if (turBL.EditarBL(turmas))
                        ExibirMensagem("Turma atualizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar a turma. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if (turBL.InserirBL(turmas))
                    {
                        ExibirMensagem("Turma gravada com sucesso !");
                        LimparCampos();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar a turma. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewTurma.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTurma.aspx");
        }
               
        protected void btnParticipantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurmaParticipantes.aspx?turmaId=" + hfId.Value + "&lblDesTurma=" + txtDescricao.Text);
        }

         
      
    }
}