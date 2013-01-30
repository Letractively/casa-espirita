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
    public partial class cadFormulario : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_for)
        {
            FormulariosBL forBL = new FormulariosBL();
            List<Formularios> formularios = forBL.PesquisarBL(id_for);

            foreach (Formularios ltFor in formularios)
            {
                hfId.Value = ltFor.Id.ToString();
                txtCodigo.Text = ltFor.Codigo.ToString();
                txtDescricao.Text = ltFor.Descricao;
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_for = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_for"] != null)
                            id_for = Convert.ToInt32(Request.QueryString["id_for"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_for);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            FormulariosBL forBL = new FormulariosBL();
            Formularios formulario = new Formularios();

            formulario.Id = utils.ComparaIntComZero(hfId.Value);
            formulario.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            formulario.Descricao = txtDescricao.Text;

            if (formulario.Id > 0)
                forBL.EditarBL(formulario);
            else
                forBL.InserirBL(formulario);

            Response.Redirect("~/viewFormulario.aspx");
        }
    }
}