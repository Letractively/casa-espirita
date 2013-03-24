using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{

    public partial class cadJuroMulta : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_jm)
        {
            JurosMultasBL jmBL = new JurosMultasBL();
            List<JurosMultas> jurosMultas = jmBL.PesquisarBL(id_jm);

            foreach (JurosMultas ltJm in jurosMultas)
            {
                hfId.Value = ltJm.Id.ToString();
                txtMesAno.Text = ltJm.MesAno.ToString("MM/yyyy");
                txtJuroDia.Text = ltJm.PercJurosDias.ToString();
                txtJuroMes.Text = ltJm.PercJurosMes.ToString();
                txtMultaDia.Text = ltJm.PercMultaDias.ToString();
                txtMultaMes.Text = ltJm.PercMultaMes.ToString();
            }

        }
        private void CarregarAtributos()
        {
            txtMesAno.Attributes.Add("onkeypress", "return(formatar(this,'##/####',event))");
            txtMultaDia.Attributes.Add("onkeyup", "formataValor(this,event);");
            txtMultaMes.Attributes.Add("onkeyup", "formataValor(this,event);");           
            txtJuroDia.Attributes.Add("onkeyup", "return(formataValor(this,event))");
            txtJuroMes.Attributes.Add("onkeyup", "return(formataValor(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_jm = 0;           

            if (!IsPostBack)
            {
                CarregarAtributos();

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_jm"] != null)
                            id_jm = Convert.ToInt32(Request.QueryString["id_jm"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_jm);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewJuroMulta.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            JurosMultasBL jmBL = new JurosMultasBL();
            JurosMultas jurosMultas = new JurosMultas();

            jurosMultas.Id = utils.ComparaIntComZero(hfId.Value);
            jurosMultas.MesAno = Convert.ToDateTime(txtMesAno.Text);
            jurosMultas.PercJurosDias = utils.ComparaDecimalComZero(txtJuroDia.Text);
            jurosMultas.PercJurosMes = utils.ComparaDecimalComZero(txtJuroMes.Text);
            jurosMultas.PercMultaDias = utils.ComparaDecimalComZero(txtMultaDia.Text);
            jurosMultas.PercMultaMes = utils.ComparaDecimalComZero(txtMultaMes.Text);

            if (jurosMultas.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    jmBL.EditarBL(jurosMultas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    jmBL.InserirBL(jurosMultas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewJuroMulta.aspx");
        }

       
       
    }
}