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
    public partial class cadChamada : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void CarregarDdlEventos()
        {
            EventosBL eveBL = new EventosBL();
            List<Eventos> eventos = eveBL.PesquisarBL();

            ddlEvento.Items.Add(new ListItem("Selecione", ""));
            foreach (Eventos ltEve in eventos)
                ddlEvento.Items.Add(new ListItem(ltEve.Descricao, ltEve.Id.ToString()));

            ddlEvento.SelectedIndex = 0;
        }

        private void CarregarDdlTurmas(Int32 id_tur)
        {
            TurmasBL turBL = new TurmasBL();
            List<Turmas> turmas = turBL.PesquisarEveBL(id_tur);

            ddlTurmas.Items.Clear();
            ddlTurmas.Items.Add(new ListItem("Selecione", ""));
            foreach (Turmas ltTur in turmas)
                ddlTurmas.Items.Add(new ListItem(ltTur.Descricao, ltTur.Id.ToString()));

            ddlTurmas.SelectedIndex = 0;
        }
        private DataTable CriarDtPesquisa()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            return tabela;
        }

        private void Pesquisar(int id_tur, int id_eve)
        {
            DateTime dataSelecionada = Convert.ToDateTime(txtSelData.Text);
            if (Convert.ToDateTime(txtSelData.Text) > DateTime.Now)
                ExibirMensagem("Não é permitido registrar frequências futuras !");
            else
            {
                DataTable tabela = new DataTable();

                DataColumn coluna1 = new DataColumn("TURMAPARTICIPANTEID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("CODPARTICIPANTE", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("DESCPARTICIPANTE", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("PRESENCA", Type.GetType("System.Boolean"));
                DataColumn coluna5 = new DataColumn("DATA", Type.GetType("System.String"));
                DataColumn coluna6 = new DataColumn("ID", Type.GetType("System.Int32"));

                tabela.Columns.Add(coluna1);
                tabela.Columns.Add(coluna2);
                tabela.Columns.Add(coluna3);
                tabela.Columns.Add(coluna4);
                tabela.Columns.Add(coluna5);
                tabela.Columns.Add(coluna6);

                TurmasBL turBL = new TurmasBL();
                TurmasParticipantesBL tParBL = new TurmasParticipantesBL();
                ChamadasBL chaBL = new ChamadasBL();
                List<Turmas> turmas = turBL.PesquisarBL(id_tur, id_eve);

                if (turmas.Count != 0)
                {
                    if (turmas[0].DiaSemana.IndexOf(char.Parse(Convert.ToString((int)dataSelecionada.DayOfWeek + 1))) == -1)
                    {
                        ExibirMensagem("Dia da semana selecionado não cadastrado para essa turma.");
                    }
                }

                foreach (Turmas ltTur in turmas)
                {
                    List<TurmasParticipantes> tPar = tParBL.PesquisarBL(ltTur.Id);

                    foreach (TurmasParticipantes ltTpar in tPar)
                    {
                        DataRow linha = tabela.NewRow();

                        linha["TURMAPARTICIPANTEID"] = ltTpar.Id;
                        linha["CODPARTICIPANTE"] = ltTpar.Pessoa.Codigo;
                        linha["DESCPARTICIPANTE"] = ltTpar.Pessoa.Nome;

                        List<Chamadas> cha = chaBL.PesquisarBL(ltTpar.Id, Convert.ToDateTime(txtSelData.Text));

                        if (cha.Count > 0)
                        {
                            foreach (Chamadas ltCha in cha)
                            {
                                linha["ID"] = ltCha.Id;
                                linha["PRESENCA"] = ltCha.Presenca;
                                linha["DATA"] = ltCha.Data.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            linha["ID"] = 0;
                            linha["PRESENCA"] = false;
                            linha["DATA"] = txtSelData.Text;
                        }

                        tabela.Rows.Add(linha);
                    }
                }

                repPermissao.DataSource = tabela;
                repPermissao.DataBind();
            }

        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        
        private void CarregarAtributos()
        {
            txtSelData.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarAtributos();
                txtSelData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CarregarDdlEventos();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            ChamadasBL chaBL = new ChamadasBL();
            Chamadas chamadas = new Chamadas();

            foreach (RepeaterItem item in repPermissao.Items)
            {
                chamadas.Id = utils.ComparaIntComZero(((TextBox)item.FindControl("txtId")).Text);
                chamadas.TurmaParticipanteId = utils.ComparaIntComZero(((TextBox)item.FindControl("txtTurmaParticipanteId")).Text);
                chamadas.Presenca = ((CheckBox)item.FindControl("chkPresenca")).Checked;
                chamadas.Data = Convert.ToDateTime(((Label)item.FindControl("lblData")).Text);

                if (chamadas.Id > 0)
                {

                    if (chaBL.EditarBL(chamadas))
                        ExibirMensagem("Registros salvos com sucesso!");
                    else
                        ExibirMensagem("Não foi possível atualizar os registros. Revise as informações!");


                }
                else
                {

                    if (chaBL.InserirBL(chamadas))
                        ExibirMensagem("Registros salvos com sucesso!");
                    else
                        ExibirMensagem("Não foi possível atualizar os registros. Revise as informações!");

                }
            }

            Pesquisar(utils.ComparaIntComZero(ddlTurmas.SelectedValue), utils.ComparaIntComZero(ddlEvento.SelectedValue));
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar(utils.ComparaIntComZero(ddlTurmas.SelectedValue), utils.ComparaIntComZero(ddlEvento.SelectedValue));
        }

        protected void ddlEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            repPermissao.DataSource = null;
            repPermissao.DataBind();
            CarregarDdlTurmas(utils.ComparaIntComZero(ddlEvento.SelectedValue));
            ddlTurmas.Focus();
        }      

    }
}
