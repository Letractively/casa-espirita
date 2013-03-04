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
                        linha["DATA"] = DateTime.Now.ToString("dd/MM/yyyy"); 
                    }

                    tabela.Rows.Add(linha);
                }                
            }

            repPermissao.DataSource = tabela;
            repPermissao.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtSelData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnPesEvento_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable tabela = CriarDtPesquisa();

            EventosBL eveBL = new EventosBL();
            Eventos ev = new Eventos();
            List<Eventos> eventos = eveBL.PesquisarBL();

            foreach (Eventos eve in eventos)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = eve.Id;
                linha["CODIGO"] = eve.Codigo;
                linha["DESCRICAO"] = eve.Descricao;

                tabela.Rows.Add(linha);
            }

            if (tabela.Rows.Count > 0)
                Session["tabelaPesquisa"] = tabela;


            Session["objBLPesquisa"] = eveBL;
            Session["objPesquisa"] = ev;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtEvento.ClientID + "&id=" + hfIdEvento.ClientID + "&lbl=" + lblDesEvento.ClientID + "','',600,500);", true);
        }

        protected void btnPesTurma_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable tabela = CriarDtPesquisa();

            TurmasBL turBL = new TurmasBL();
            Turmas tu = new Turmas();
            List<Turmas> turmas = turBL.PesquisarBL();

            foreach (Turmas tur in turmas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = tur.Id;
                linha["CODIGO"] = tur.Codigo;
                linha["DESCRICAO"] = tur.Descricao;

                tabela.Rows.Add(linha);
            }

            if (tabela.Rows.Count > 0)
                Session["tabelaPesquisa"] = tabela;

            Session["objBLPesquisa"] = turBL;
            Session["objPesquisa"] = tu;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtTurma.ClientID + "&id=" + hfIdTurma.ClientID + "&lbl=" + lblDesTurma.ClientID + "','',600,500);", true);
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
                chamadas.Data =  Convert.ToDateTime(((Label)item.FindControl("lblData")).Text);

                if (chamadas.Id > 0)
                {
                    if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                        chaBL.EditarBL(chamadas);
                    else
                        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

                }
                else
                {
                    if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                        chaBL.InserirBL(chamadas);
                    else
                        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
                }
            }

            Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value), utils.ComparaIntComZero(hfIdEvento.Value));
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar(utils.ComparaIntComZero(hfIdTurma.Value), utils.ComparaIntComZero(hfIdEvento.Value));
        }

        
    }
}
