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
    public partial class viewJuroMulta : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("MESANO", Type.GetType("System.DateTime"));
            DataColumn coluna3 = new DataColumn("PERCJUROSDIA", Type.GetType("System.Decimal"));
            DataColumn coluna4 = new DataColumn("PERCJURSOMES", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("PERCMULTADIA", Type.GetType("System.Decimal"));
            DataColumn coluna6 = new DataColumn("PERCMULTAMES", Type.GetType("System.Decimal"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            JurosMultasBL jmBL = new JurosMultasBL();

            List<JurosMultas> jurosMultas = jmBL.PesquisarBL();

            foreach (JurosMultas jm in jurosMultas)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = jm.Id;
                linha["MESANO"] = jm.MesAno;
                linha["PERCJUROSDIA"] = jm.PercJurosDias;
                linha["PERCJURSOMES"] = jm.PercJurosMes;
                linha["PERCMULTADIA"] = jm.PercMultaDias;
                linha["PERCMULTAMES"] = jm.PercMultaMes;

                tabela.Rows.Add(linha);
            }

            dtgJurosMultas.DataSource = tabela;
            dtgJurosMultas.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadJuroMulta.aspx?operacao=new");
        }

        protected void dtgJurosMultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_jm = 0;
            str_jm = utils.ComparaIntComZero(dtgJurosMultas.SelectedDataKey[0].ToString());
            Response.Redirect("cadJuroMulta.aspx?id_jm=" + str_jm.ToString() + "&operacao=edit");
        }

        protected void dtgJurosMultas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                JurosMultasBL jmBL = new JurosMultasBL();
                JurosMultas jurosMultas = new JurosMultas();
                jurosMultas.Id = utils.ComparaIntComZero(dtgJurosMultas.DataKeys[e.RowIndex][0].ToString());
                jmBL.ExcluirBL(jurosMultas);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
    }
}