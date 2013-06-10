using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
                Response.Redirect("~/login.aspx");
        }

        protected void imgAtaVendas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/cadVenda.aspx");
        }

        protected void imgAtaFrequencia_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/cadChamada.aspx");
        }

        protected void imgAtaEmprestimos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/cadCirculacaoLivros.aspx");
        }

        protected void imgAtaEstoque_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/cadAcertoEstoque.aspx");
        }

        protected void imgPessoas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/viewPessoa.aspx");
        }
    }
}