using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using DataObjects;


namespace FIBIESA
{
    public partial class recuperacaoLogin : System.Web.UI.Page
    {
        #region funcoes
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            UsuariosBL usuBL = new UsuariosBL();
            Usuarios usu = new Usuarios();
            string msg;

            DataSet usuDS = usuBL.PesquisarDAEmail(txtEmail.Text);

            if (usuDS.Tables[0].Rows.Count > 0)
            {
                msg = usuBL.EnviarEmailSenha(usuDS);
                if (msg == string.Empty)
                    lblMensagem.Text = "Sua nova senha foi enviada para o email informado!";
                else
                    ExibirMensagem(msg);

                txtEmail.Text = "";    
                    
            }
            else
            {
                lblMensagem.Text = "Email não cadastrado no sistema!";
                txtEmail.Focus();              
            }
 
        }        
    }
}