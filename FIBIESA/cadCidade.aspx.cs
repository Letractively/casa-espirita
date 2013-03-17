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
        private void CarregarDdlEstado()
        {
            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            ddlEstado.Items.Add(new ListItem());
            foreach (Estados ltEst in estados)            
               ddlEstado.Items.Add(new ListItem(ltEst.Uf +" - "+ltEst.Descricao,ltEst.Id.ToString()));                
            
            ddlEstado.SelectedIndex = 0;
 
        }
        private void CarregarDados(int id_cid)
        {
            CidadesBL cidBL = new CidadesBL();
            EstadosBL estBL = new EstadosBL();


            DataSet dsCid = cidBL.PesquisarBL(id_cid);

            if (dsCid.Tables[0].Rows.Count != 0)
            {
                Cidades cid = new Cidades();

                hfId.Value  = (string)dsCid.Tables[0].Rows[0]["id"].ToString();
                txtCodigo.Text = (string)dsCid.Tables[0].Rows[0]["codigo"].ToString();
                txtDescricao.Text = (string)dsCid.Tables[0].Rows[0]["descricao"];
                ddlEstado.SelectedValue = (string)dsCid.Tables[0].Rows[0]["estadoid"].ToString();
                                
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

                CarregarDdlEstado();

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_cid);
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
            cidades.EstadoId = utils.ComparaIntComZero(ddlEstado.SelectedValue.ToString());

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
              
    }
}