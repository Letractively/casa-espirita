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
    public partial class cadBairro : System.Web.UI.Page
    {        
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void carregarDados(int id_bai)
        {
            BairrosBL baiBL = new BairrosBL();
            Bairros bairros = new Bairros();
            List<Bairros> bai = baiBL.PesquisarBL(id_bai);

            foreach (Bairros ltBai in bai)
            {
                hfId.Value = ltBai.Id.ToString();
                txtCodigo.Text = ltBai.Codigo.ToString();
                txtDescricao.Text = ltBai.Descricao;
            }

        }
        #endregion
                
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_bai"] != null)
                            id_bai = Convert.ToInt32(Request.QueryString["id_bai"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_bai);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBairro.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            BairrosBL baiBL = new BairrosBL();
            Bairros bairros = new Bairros();
            bairros.Id = utils.ComparaIntComZero(hfId.Value);
            bairros.Codigo = utils.ComparaIntComZero(txtCodigo.Text);               
            bairros.Descricao = txtDescricao.Text;

            if (bairros.Id > 0)
                baiBL.EditarBL(bairros);
            else
                baiBL.InserirBL(bairros);

            Response.Redirect("viewBairro.aspx");
        }
    }
}