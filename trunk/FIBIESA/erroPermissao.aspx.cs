using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIBIESA
{
    public partial class erroPermissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nomeUsuario"] != null)
            {
                lblMensagem.Text = "O usuário " + Request.QueryString["nomeUsuario"] +
                                   " não tem permissão para acessar a página solicitada. Contate o administrador do sistema.";
            }
            else           
                lblMensagem.Text = "O usuário não tem permissão para acessar a página solicitada. Contate o administrador do sistema.";
           
            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
       
    }
}