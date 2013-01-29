using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;

namespace FIBIESA
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region funcoes
        private void logout()
        {
            Session["usuario"] = null;
            Response.Redirect("~/login.aspx");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    List <Usuarios> usuarios;
                    usuarios = (List<Usuarios>)Session["usuario"];

                    foreach (Usuarios usu in usuarios)
                    {
                        lblNomeUsuario.Text = usu.Nome;
                        lblCategoria.Text = usu.Categoria.Descricao;
                    }
                }
            }
        }

        protected void imbSair_Click(object sender, ImageClickEventArgs e)
        {
            logout();
        }
    }
}