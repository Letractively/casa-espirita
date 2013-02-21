using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class viewTurma : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("EVENTOID", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DTINICIAL", Type.GetType("System.DateTime"));
            DataColumn coluna6 = new DataColumn("DTFINAL", Type.GetType("System.DateTime"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            TurmasBL turBL = new TurmasBL();
            List<Turmas> turmas = turBL.PesquisarBL();

            foreach (Turmas tur in turmas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = tur.Id;
                linha["CODIGO"] = tur.Codigo;
                linha["DESCRICAO"] = tur.Descricao;
                linha["EVENTOID"] = tur.EventoId;
                linha["DTINICIAL"] = tur.DataInicial;
                linha["DTFINAL"] = tur.DataFinal;

                EventosBL curBL = new EventosBL();
                List<Eventos> eventos = curBL.PesquisarBL(tur.EventoId);
                foreach (Eventos eve in eventos)
                {
                    linha["DESCRICAO"] = eve.Descricao;
                }

                tabela.Rows.Add(linha);
            }

            dtgTurmas.DataSource = tabela;
            dtgTurmas.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurma.aspx?operacao=new");
        }

        protected void dtgTurmas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {       

            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                TurmasBL turBL = new TurmasBL();
                Turmas turmas = new Turmas();
                turmas.Id = utils.ComparaIntComZero(dtgTurmas.DataKeys[e.RowIndex][0].ToString());
                turBL.ExcluirBL(turmas);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
                         

        protected void dtgTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tur = 0;
            str_tur = utils.ComparaIntComZero(dtgTurmas.SelectedDataKey[0].ToString());
            Response.Redirect("cadTurma.aspx?id_tur=" + str_tur.ToString() + "&operacao=edit");
        }

        


    }
}