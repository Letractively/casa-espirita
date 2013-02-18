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
                txtCodigo.Text = eve.Codigo.ToString();
                txtDescricao.Text = eve.Descricao;
                txtDtInicio.Text = eve.DtInicio.ToString();
                txtDtFim.Text = eve.DtFim.ToString();
            }
            
        }

        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_eve = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_eve"] != null)
                            id_eve = Convert.ToInt32(Request.QueryString["id_eve"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_eve);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            EventosBL eveBL = new EventosBL();
            Eventos eventos = new Eventos();

            eventos.Id = utils.ComparaIntComZero(hfId.Value);
            eventos.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            eventos.Descricao = txtDescricao.Text;
            eventos.DtInicio = Convert.ToDateTime(txtDtInicio.Text);
            eventos.DtFim = Convert.ToDateTime(txtDtFim.Text);

            if (eventos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    eveBL.EditarBL(eventos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    eveBL.InserirBL(eventos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewEvento.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEvento.aspx");
        }
       
        
    }
}