using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;
using FG;

namespace FIBIESA
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        Utils utils = new Utils();
        #region funcoes
        private void Logout()
        {
            Session["usuario"] = null;
            Response.Redirect("~/login.aspx");
        }
        private void CarregarInstituicao()
        {
            InstituicoesBL insBL = new InstituicoesBL();
            List<Instituicoes> instituicoes = insBL.PesquisarBL(true);

            foreach (Instituicoes inst in instituicoes)
            {
                lblNomeEmpresa.Text = inst.NomeFantasia;
            }

        }
        //public void JQueryValor(string CssClass, Int16 Maximo, Int16 CasasDecimais)
        //{
        //    Page.ClientScript.RegisterClientScriptInclude("jQueryPriceFormat", Page.ResolveClientUrl("~/javascript/jquery.price_format.1.4.js"));

        //    string script = " $(document).ready(function () { " +
        //                   " $('." + CssClass + "').priceFormat({" +
        //                   "     limit: " + Maximo.ToString() + "," +
        //                   "     centsLimit: " + CasasDecimais.ToString() + "," +
        //                   "     prefix: ''," +
        //                   "     centsSeparator: ','," +
        //                   "     thousandsSeparator: '.'" +
        //                   " });" +
        //                "});";

        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JQueryMask" + CssClass, script, true);
        //}

        private void CarregarMenuPermissoes()
        {
            PermissoesBL perBL = new PermissoesBL();

            DataSet ds = perBL.PesquisarPermissoesBL(utils.ComparaIntComZero(hfIdCategoria.Value));

            ds.Tables[0].TableName = "tblCategorias";
            ds.Tables[1].TableName = "tblSubCategoria";

            //Relação para o segundo repeater (SubCategorias)
            ds.Relations.Add("SubCategorias",
                  ds.Tables["tblCategorias"].Columns["DESMODULO"],
                  ds.Tables["tblSubCategoria"].Columns["DESMODULO"]);
            ds.Relations[0].Nested = true;

            rptMenu.DataSource = ds.Tables["tblCategorias"];
            rptMenu.DataBind();
                                  
           
        }
                
        #endregion
                
        protected void Page_Load(object sender, EventArgs e)
        {            
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
                        hfIdCategoria.Value = usu.Categoria.Id.ToString();
                    }
                   
                    CarregarMenuPermissoes();
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