using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIBIESA
{
    public partial class ops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblMensagem.Text = "Ocorreu um erro inesperado. Se o erro persistir contate o administrador do sistema.";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}