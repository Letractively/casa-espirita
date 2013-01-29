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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            UsuariosBL usuBL = new UsuariosBL();
            List<Usuarios> usuarios  = usuBL.PesquisarBL(txtLogin.Text, txtSenha.Text);
           

            if (usuarios.Count == 0)
            {
                txtLogin.Text = "";
                lblMensagem.Text = "O nome de usuário ou a senha estão incorretos. Tente digitá-los novamente.";
            }
            else
            {
                Session["usuario"] = usuarios;
                Response.Redirect("~/default.aspx");
            }
        }
    }
}