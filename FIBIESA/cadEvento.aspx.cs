using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;

namespace Admin
{
    public partial class cadCurso : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_eve)
        {
            EventosBL eveBL = new EventosBL();
            List<Eventos> eventos = eveBL.PesquisarBL(id_eve);

            foreach (Eventos eve in eventos)
            {
                hfId.Value = eve.Id.ToString();
                lblCodigo.Text = eve.Codigo.ToString();
                txtDescricao.Text = eve.Descricao;
                txtDtInicio.Text = eve.DtInicio.ToString("dd/MM/yyyy");
                txtDtFim.Text = eve.DtFim.ToString("dd/MM/yyyy");
            }
            
        }

        private void CarregarAtributos()
        {            
            txtDtInicio.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtDtInicio.Text = "";
            txtDtFim.Text = "";
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_eve = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null  && (Request.QueryString["id_eve"] != null))
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                    {
                        id_eve = Convert.ToInt32(Request.QueryString["id_eve"].ToString());
                        CarregarDados(id_eve);
                    }
                }
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            EventosBL eveBL = new EventosBL();
            Eventos eventos = new Eventos();

            eventos.Id = utils.ComparaIntComZero(hfId.Value);
            eventos.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            eventos.Descricao = txtDescricao.Text;
            eventos.DtInicio = Convert.ToDateTime(txtDtInicio.Text);
            eventos.DtFim = Convert.ToDateTime(txtDtFim.Text);

            if (eventos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (eveBL.EditarBL(eventos))
                        ExibirMensagem("Evento atualizado com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar o evento. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    if (eveBL.InserirBL(eventos))
                    {
                        ExibirMensagem("Evento gravado com sucesso !");
                        LimparCampos();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar o evento. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
                        
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEvento.aspx");
        }
       
        
    }
}