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
namespace FIBIESA
{
    public partial class viewRelFrequencia : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public void CarregarDdlEvento()
        {
            EventosBL eveBL = new EventosBL();
            List<Eventos> lEventos = eveBL.PesquisarBL();

            foreach (Eventos eventos in lEventos)
                ddlEvento.Items.Add(new ListItem(eventos.Codigo + " - " + eventos.Descricao, eventos.Id.ToString()));

            ddlEvento.Items.Insert(0, "Selecione");
            ddlEvento.SelectedIndex = 0;
        }

        public void CarregarDdlTurma()
        {
            TurmasBL turBL = new TurmasBL();
            List<Turmas> lTurmas = turBL.PesquisarEveBL(Convert.ToInt16(ddlEvento.SelectedValue.ToString()));

            foreach (Turmas turmas in lTurmas)
                ddlTurma.Items.Add(new ListItem(turmas.Codigo + " - " + turmas.Descricao, turmas.Id.ToString()));

            ddlTurma.Items.Insert(0, "Selecione");
            ddlTurma.SelectedIndex = 0;
        }

        private void CarregarDdlInstrutor()
        {
            TurmasBL turBL = new TurmasBL();
            List<Turmas> lTurmas = turBL.PesquisarBL(Convert.ToInt16(ddlTurma.SelectedValue.ToString()));

            lblInstrutor.Text = lTurmas[0].Pessoa.Nome;
        }

        private void CarregarDdlParticipante()
        {
            TurmasParticipantesBL turParBL = new TurmasParticipantesBL();
            List<TurmasParticipantes> lTurmasParticipantes = turParBL.PesquisarBL(Convert.ToInt16(ddlTurma.SelectedValue.ToString()));

            foreach (TurmasParticipantes turmasParticipantes in lTurmasParticipantes)
                ddlParticipante.Items.Add(new ListItem(turmasParticipantes.Pessoa.Codigo + " - " + turmasParticipantes.Pessoa.Nome, turmasParticipantes.Pessoa.Id.ToString()));
            ddlParticipante.Items.Insert(0, "Todos");
            ddlParticipante.SelectedIndex = 0;
        }

        private void CarregarDdlAno()
        {
            ChamadasBL chaBL = new ChamadasBL();
            DataSet dsChamada = chaBL.PesquisarAnosChamada();
            ddlAno.DataValueField = "ano";
            ddlAno.DataTextField = "ano";
            ddlAno.DataSource = dsChamada;
            ddlAno.DataBind();
            ddlAno.SelectedIndex = 0;
        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDdlEvento();
                CarregarDdlAno();
                ddlMes.SelectedValue = DateTime.Now.Month.ToString();
            }

        }

        protected void ddlEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTurma.Items.Clear();
            ddlParticipante.Items.Clear();
            lblInstrutor.Text = string.Empty;
            if (ddlEvento.SelectedIndex != 0)
                CarregarDdlTurma();
        }

        protected void ddlTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlParticipante.Items.Clear();
            lblInstrutor.Text = string.Empty;            
            if (ddlTurma.SelectedIndex != 0)
            {
                CarregarDdlInstrutor();
                CarregarDdlParticipante();
            }            
                
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}