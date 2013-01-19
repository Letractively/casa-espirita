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
    public partial class cadParametro : System.Web.UI.Page
    {
        #region funcoes
        private void SalvarParametro(int codigo, string modulo, string descricao, string valor)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();

            List<Parametros> ltPar = parBL.PesquisarBL(codigo, modulo);

            if (ltPar.Count > 0)
            {
                foreach (Parametros par in ltPar)
                {
                    parametros.Id = par.Id;
                    parametros.Codigo = codigo;
                    parametros.Descricao = par.Descricao;
                    parametros.Valor = valor;
                    parametros.Modulo = par.Modulo;

                    parBL.EditarBL(parametros);
                }
            }
            else
            {
                parametros.Codigo = codigo;
                parametros.Descricao = descricao.Trim();
                parametros.Valor = valor;
                parametros.Modulo = modulo;
 
                parBL.InserirBL(parametros);
            }          

        }
        private string CarregarParametro(int codigo, string modulo)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();
            string v_valor = "";
            List<Parametros> ltPar = parBL.PesquisarBL(codigo, modulo);

            foreach (Parametros par in ltPar)
            {
                v_valor = par.Valor;
            }

            return v_valor;         
 
        }
        private void CarregarDados()
        {
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
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarDados();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

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
    }
}