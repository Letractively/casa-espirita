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

            ddlEvento.Items.Add(new ListItem("Selecione",""));
            foreach (Eventos ltEve in eventos)            
                ddlEvento.Items.Add(new ListItem(ltEve.Codigo+" - "+ ltEve.Descricao, ltEve.Id.ToString()));

            ddlEvento.SelectedIndex = 0;
        }

        private void CarregarDdlInstrutor()
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();

            string valor = parBL.PesquisarValorBL(1,"E");

            if (utils.ComparaIntComZero(valor) > 0)
            {
                PessoasBL pesBL = new PessoasBL();
                List<Pessoas> pessoas = pesBL.PesquisarPorGeneroDA(utils.ComparaIntComZero(valor));

                ddlInstrutor.Items.Add(new ListItem("Selecione", ""));
                foreach (Pessoas ltPes in pessoas)
                    ddlInstrutor.Items.Add(new ListItem(ltPes.Codigo + " - " + ltPes.Nome, ltPes.Id.ToString()));

                ddlInstrutor.SelectedIndex = 0;
            }
        }

        private void CarregarDados(int id_tur)
        {
            TurmasBL turBL = new TurmasBL();
            DataSet dsTur = turBL.PesquisarBL(id_tur);
                   
            foreach(DataRow ltTur in dsTur.Tables[0].Rows)
            {
                hfId.Value = ltTur["id"].ToString();
                lblcodigo.Text = ltTur["Codigo"].ToString();
                txtDescricao.Text = ltTur["Descricao"].ToString();
                txtSala.Text = ltTur["Sala"].ToString();
                txtNroMax.Text = ltTur["Nromax"].ToString();
                txtDiaSemana.Text = ltTur["DiaSemana"].ToString();
                txtDtFim.Text = ltTur["DtFim"].ToString();
                txtDtInicio.Text = ltTur["DtIni"].ToString();
                txtHoraFim.Text = ltTur["HoraFim"].ToString(); 
                txtHoraInicio.Text = ltTur["HoraIni"].ToString();   
                ddlEvento.SelectedValue = ltTur["EventoId"].ToString();               
                ddlInstrutor.SelectedValue = ltTur["PessoaId"].ToString();

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
            txtHoraFim.Text = "";
            txtHoraInicio.Text = "";
            lblcodigo.Text = "Código gerado automaticamente.";

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tur = 0;

            CarregarAtributos();
            
            if (!IsPostBack)
            {
                CarregarDdlEventos();
                CarregarDdlInstrutor();
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
                txtDescricao.Focus();
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
                    {
                        ExibirMensagem("Turma atualizada com sucesso !");
                        txtDescricao.Focus();
                    }
                    else
                        ExibirMensagem("Não foi possível atualizar a turma. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                Int32 id_turma = 0;
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    id_turma = turBL.InserirBL(turmas);
                    hfId.Value = id_turma.ToString();
                    if (id_turma > 0)
                    {
                        ExibirMensagem("Turma gravada com sucesso !");                       
                        btnParticipantes.Visible = true;
                        txtDescricao.Focus();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar a turma. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTurma.aspx");
        }
               
        protected void btnParticipantes_Click(object sender, EventArgs e)
        {
            Session["turmaId"] = hfId.Value;
            Response.Redirect("cadTurmaParticipantes.aspx?");

        }        
      
    }
}