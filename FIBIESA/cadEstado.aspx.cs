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
    public partial class cadEstado : System.Web.UI.Page
    {        
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void carregarDados(int id_est)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();
            List<Estados> est = estBL.PesquisarBL(id_est);

            foreach (Estados ltEst in est)
            {
                hfId.Value = ltEst.Id.ToString();
                txtUf.Text = ltEst.Uf;
                txtDescricao.Text = ltEst.Descricao;
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_est = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_est"] != null)
                            id_est = Convert.ToInt32(Request.QueryString["id_est"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_est);
            }

        }

        protected void bntSalvar_Click(object sender, EventArgs e)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();
            estados.Id = utils.ComparaIntComZero(hfId.Value);
            estados.Uf = txtUf.Text;
            estados.Descricao = txtDescricao.Text;

            if (estados.Id > 0)
                estBL.EditarBL(estados);
            else
                estBL.InserirBL(estados);

            Response.Redirect("viewEstado.aspx");
        }

        protected void bntVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEstado.aspx");
        }
    }
}