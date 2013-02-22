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
    public partial class cadDoacao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void CarregarAtributos()
        {
            txtValor.Attributes.Add("onkeypress", "return(Real(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
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
            Pessoas pe = new Pessoas();
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


            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCliente.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesCliente.ClientID + "','',600,500);", true);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/defautl.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DoacoesBL doaBL = new DoacoesBL();
            Doacoes doacoes = new Doacoes();

            doacoes.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
            doacoes.Valor = utils.ComparaDecimalComZero(txtValor.Text);
            doacoes.Data = Convert.ToDateTime(txtData.Text);

            if (Session["usuario"] != null)
            {
                List<Usuarios> usuarios = (List<Usuarios>)Session["usuario"];
                foreach (Usuarios ltUsu in usuarios)
                    doacoes.UsuarioId = ltUsu.Id;

            }

            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                doaBL.InserirBL(doacoes);
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            Response.Redirect("~/viewDoacao.aspx");
        }
    }
}