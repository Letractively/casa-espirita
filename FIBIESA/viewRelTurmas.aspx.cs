using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class viewRelTurmas : System.Web.UI.Page
    {
        #region funcoes
        private DataTable CriarTabelaPesquisa()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            return dt;

        }
        #endregion

        #region "Pesquisas"



        public void pesquisaEvento(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            EventosBL eventosBL = new EventosBL();
            Eventos eventos = new Eventos();
            List<Eventos> lEventos;

            if (this.txtCurso.Text != string.Empty)
                lEventos = eventosBL.PesquisarBL("CODIGO", this.txtCurso.Text);
            else
                lEventos = eventosBL.PesquisarBL();

            foreach (Eventos eventoItem in lEventos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = eventoItem.Id;
                linha["CODIGO"] = eventoItem.Codigo;
                linha["DESCRICAO"] = eventoItem.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Evento não encontrado.');", true);
            }

            Session["objBLPesquisa"] = eventosBL;
            Session["objPesquisa"] = eventos;

        }


        public void pesquisaTurma(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            TurmasBL turmasBL = new TurmasBL();
            Turmas turmas = new Turmas();
            List<Turmas> lTurmas;

            if (this.txtTurma.Text != string.Empty)
                lTurmas = turmasBL.PesquisarBL("CODIGO", this.txtTurma.Text);
            else
                lTurmas = turmasBL.PesquisarBL();

            foreach (Turmas turmasItem in lTurmas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = turmasItem.Id;
                linha["CODIGO"] = turmasItem.Codigo;
                linha["DESCRICAO"] = turmasItem.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Turma não encontrado.');", true);
            }

            Session["objBLPesquisa"] = turmasBL;
            Session["objPesquisa"] = turmas;

        }


        #endregion


        public DataTable dtGeral;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.txtCurso.Text != string.Empty)
            {
                carregaCurso();
            }
            if (this.txtTurma.Text != string.Empty)
            {
                carregaTurma();
            }
        }

        public void carregaCurso()
        {
            pesquisaEvento("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesCurso.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdCurso.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesCurso.Text = string.Empty;
                this.hfIdCurso.Value = string.Empty;
            }
        }

        public void carregaTurma()
        {
            pesquisaTurma("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesTurma.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdTurma.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesTurma.Text = string.Empty;
                this.hfIdTurma.Value = string.Empty;
            }
        }

        protected void btnPesCurso_Click(object sender, EventArgs e)
        {
            pesquisaEvento("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCurso.ClientID + "&id=" + hfIdCurso.ClientID + "&lbl=" + lblDesCurso.ClientID + "','',600,500);", true);
        }

        protected void btnPesTurma_Click(object sender, EventArgs e)
        {
            pesquisaTurma("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtTurma.ClientID + "&id=" + hfIdTurma.ClientID + "&lbl=" + lblDesTurma.ClientID + "','',600,500);", true);
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {


            TurmasBL turmasBL = new TurmasBL();

            Session["ldsRel"] = turmasBL.PesquisarDataset(hfIdCurso.Value, hfIdTurma.Value, txtDataIni.Text, txtDataIniF.Text, txtDataFimI.Text, txtDataFim.Text, ckbTurmasAbertos.Checked).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelTurmas.aspx?Eventos=" + txtCurso.Text + "','',600,915);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }
    }
}