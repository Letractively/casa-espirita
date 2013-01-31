using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FIBIESA
{
    public partial class erroPermissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder mensagem = new StringBuilder();

            if (Request.QueryString["nomeUsuario"] != null)            
                mensagem.Append("O usuário " + Request.QueryString["nomeUsuario"]);
            else
                mensagem.Append("O usuário ");

            if (Request.QueryString["usuOperacao"] != null)
                mensagem.Append(" não tem permissão para acessar a "+ Request.QueryString["usuOperacao"] + " solicitada. Contate o administrador do sistema."); 
            else
                mensagem.Append(" não tem permissão para acessar a página solicitada. Contate o administrador do sistema.");                    
         

            lblMensagem.Text = mensagem.ToString();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
       
    }
}