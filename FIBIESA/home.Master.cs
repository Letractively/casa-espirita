using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region funcoes
        private void Logout()
        {
            Session["usuario"] = null;
            Response.Redirect("~/login.aspx");
        }
        public bool VerificaPermissaoUsuario(string tipoPermissao)
        {
            if (Session["usuPermissoes"] != null)
            {
                Permissoes permissoes = (Permissoes)Session["usuPermissoes"];

                switch (tipoPermissao.ToUpper())
                {
                    case "INSERIR":
                        return permissoes.Inserir;

                    case "EXCLUIR":
                        return permissoes.Excluir;

                    case "EDITAR":
                        return permissoes.Editar;

                    default: return false;
                }
            }
            else
                return false;
        }
        private void CarregarInstituicao()
        {
            InstituicoesBL insBL = new InstituicoesBL();
            List<Instituicoes> instituicoes = insBL.PesquisarBL();

            foreach (Instituicoes inst in instituicoes)
            {
                lblNomeEmpresa.Text = inst.NomeFantasia;
            }

        }



        #endregion

        //habilita o menu ou nao
        private bool IsAllMenuItemsVisible = true;

        //protected void rptControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

        //    if (!IsAllMenuItemsVisible)
        //    {
        //        foreach (RepeaterItem item in rptControl.Items)
        //        {
        //            if (item.ItemType == ListItemType.Item || item.ItemType ==
        //                                                                              ListItemType.AlternatingItem)
        //            {
        //                SiteMapNode thisMapNode = (SiteMapNode)e.Item.DataItem;
        //                if (thisMapNode != null)
        //                {
        //                    if (thisMapNode["visibility"] != null &&
        //                       thisMapNode["visibility"].ToLower().Equals(bool.FalseString.ToLower()))
        //                    {
        //                        rptControl.Controls.Remove(e.Item);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["FromPage"] = "About";
            Session["FromPage"] = "Home";
            Session["FromPage"] = "Contact";


            if (!IsPostBack)
            {
                IsAllMenuItemsVisible = true;
            }
            if (Session["FromPage"] != null && Convert.ToString(Session["FromPage"])
                                                                                                             != "")
            {
                switch (Convert.ToString(Session["FromPage"]))
                {
                    case "About":
                        {
                            IsAllMenuItemsVisible = false;
                            break;
                        }
                    case "Contact":
                        {
                            IsAllMenuItemsVisible = false;
                            break;
                        }
                    case "Home":
                        {
                            IsAllMenuItemsVisible = true;
                            break;
                        }
                }
            }


            //rptControl.DataBind();


            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    List<Usuarios> usuarios;
                    usuarios = (List<Usuarios>)Session["usuario"];

                    foreach (Usuarios usu in usuarios)
                    {
                        lblNomeUsuario.Text = usu.Nome;
                        lblCategoria.Text = usu.Categoria.Descricao;
                    }
                }

                CarregarInstituicao();
            }
        }

        protected void imbSair_Click(object sender, ImageClickEventArgs e)
        {
            Logout();
        }

        protected void imgHome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}