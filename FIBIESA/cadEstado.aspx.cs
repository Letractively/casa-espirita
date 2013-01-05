using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;

namespace Admin
{
    public partial class cadEstado : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("cadEstado.aspx?id_est=" + str_Est.ToString() + "&operacao=edit");
        }

        protected void bntSalvar_Click(object sender, EventArgs e)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();

            estados.Uf = txtUf.Text;
            estados.Descricao = txtDescricao.Text;

            estBL.InserirBL(estados);
            Response.Redirect("viewEstado.aspx");
        }

        protected void bntVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEstado.aspx");
        }
    }
}