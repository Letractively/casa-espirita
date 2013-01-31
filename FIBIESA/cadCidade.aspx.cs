using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;

namespace Admin
{
    public partial class cadCidade : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = ""; 

        #region funcoes
        private void carregarDados(int id_cid)
        {
            CidadesBL cidBL = new CidadesBL();
            EstadosBL estBL = new EstadosBL();
            
            List<Cidades> cid = cidBL.PesquisarBL(id_cid);

            foreach (Cidades ltCid in cid)
            {
                hfId.Value = ltCid.Id.ToString();
                txtCodigo.Text = ltCid.Codigo.ToString();
                txtDescricao.Text = ltCid.Descricao;
                hfIdEstado.Value = ltCid.EstadoId.ToString();
                
                if (ltCid.EstadoId > 0)
                {
                    List<Estados> estados = estBL.PesquisarBL(ltCid.EstadoId);

                    foreach (Estados est in estados)
                    {
                        txtEstado.Text = est.Uf;
                        lblDesEstado.Text = est.Descricao;
                    } 
                }
            }

        }
        private void CarregarAtributos()
        {           
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_cid = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_cid"] != null)
                            id_cid = Convert.ToInt32(Request.QueryString["id_cid"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_cid);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCidade.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CidadesBL cidBL = new CidadesBL();
            Cidades cidades = new Cidades();

            cidades.Id = utils.ComparaIntComZero(hfId.Value);
            cidades.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            cidades.Descricao = txtDescricao.Text;
            cidades.EstadoId = utils.ComparaIntComZero(hfIdEstado.Value);

            if (cidades.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    cidBL.EditarBL(cidades);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            else
            {
                if(this.Master.VerificaPermissaoUsuario("INSERIR"))
                    cidBL.InserirBL(cidades);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewCidade.aspx");

        }

        protected void btnPesEstado_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            foreach (Estados est in estados)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = est.Id;
                linha["CODIGO"] = est.Uf;
                linha["DESCRICAO"] = est.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            EstadosBL esBL = new EstadosBL();
            Estados es = new Estados();

            Session["objBLPesquisa"] = esBL; 
            Session["objPesquisa"] = es;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtEstado.ClientID + "&id=" + hfIdEstado.ClientID + "&lbl=" + lblDesEstado.ClientID + "','',600,500);", true);
        }
    }
}