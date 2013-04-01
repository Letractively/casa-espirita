using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;

namespace Admin
{
    public partial class cadParametro : System.Web.UI.Page
    {
        #region funcoes
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void CarregarDdlCategoria()
        {
            CategoriasBL catBL = new CategoriasBL();
            List<Categorias> categorias = catBL.PesquisarBL();

            ddlCategoria.Items.Add(new ListItem());
            foreach (Categorias ltPes in categorias)
                ddlCategoria.Items.Add(new ListItem(ltPes.Codigo + " - " + ltPes.Descricao, ltPes.Id.ToString()));

            ddlCategoria.SelectedIndex = 0;
        }
        private void SalvarParametro(int codigo, string modulo, string descricao, string valor)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();

            DataSet dsPar = parBL.PesquisarBL(codigo, modulo);

            if (dsPar.Tables[0].Rows.Count != 0)
                parametros.Valor = (string)dsPar.Tables[0].Rows[0]["valor"];

            parametros.Codigo = codigo;
            parametros.Descricao = descricao.Trim();
            parametros.Valor = valor;
            parametros.Modulo = modulo;

            if (dsPar.Tables[0].Rows.Count > 0)
            {
                parametros.Id = (int)dsPar.Tables[0].Rows[0]["id"];
                if(parBL.EditarBL(parametros))
                    ExibirMensagem("Parâmetros gravados com sucesso !");
                else
                    ExibirMensagem("Não foi possível gravar os parâmetros. Revise as informações.");
            }
            else
            {
                if (parBL.InserirBL(parametros))
                    ExibirMensagem("Parâmetros gravados com sucesso !");
                else
                    ExibirMensagem("Não foi possível gravar os parâmetros. Revise as informações.");
            }
                      

        }
        private string CarregarParametro(int codigo, string modulo)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();
            string v_valor = "";
            DataSet dsPar = parBL.PesquisarBL(codigo, modulo);

            if (dsPar.Tables[0].Rows.Count != 0)
                v_valor = (string)dsPar.Tables[0].Rows[0]["valor"];

            return v_valor;         
 
        }
        private void CarregarDados()
        {
            #region eventos
            ddlCategoria.SelectedValue = CarregarParametro(1, "E");
            #endregion

            #region biblioteca
            txtQtdMaxEmp.Text = CarregarParametro(1, "B");
            txtQtdMaxRen.Text = CarregarParametro(2, "B");
            txtTempoMinRetirada.Text = CarregarParametro(3, "B");
            txtQtdMinRetirada.Text = CarregarParametro(4, "B");
            #endregion

            #region financeiro
            txtValorMulta.Text = CarregarParametro(1, "F");
            txtPerLucro.Text = CarregarParametro(2, "F");
            txtDesconto.Text = CarregarParametro(3, "F");
            #endregion
        }
        private void CarregarAtributos()
        {           
            txtQtdMaxEmp.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtQtdMaxRen.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtQtdMinRetirada.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtTempoMinRetirada.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtValorMulta.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtPerLucro.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtDesconto.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();

            if (!IsPostBack)
            {
                CarregarDdlCategoria();
                CarregarDados();
               
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {
                #region eventos
                SalvarParametro(1, "E", lblCategoria.Text, ddlCategoria.SelectedValue);
                #endregion

                #region biblioteca
                SalvarParametro(1, "B", lblQtdMaxEmp.Text, txtQtdMaxEmp.Text);
                SalvarParametro(2, "B", lblQtdMaxRen.Text, txtQtdMaxRen.Text);
                SalvarParametro(3, "B", lblTempoMinRetirada.Text, txtTempoMinRetirada.Text);
                SalvarParametro(4, "B", lblQtdMinRetirada.Text, txtQtdMinRetirada.Text);
                #endregion

                #region financeiro
                SalvarParametro(1, "F", lblValorMulta.Text, txtValorMulta.Text);
                SalvarParametro(2, "F", lblPerLucro.Text, txtPerLucro.Text);
                SalvarParametro(3, "F", lblDesconto.Text, txtDesconto.Text);
                #endregion
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

        }
    }
}