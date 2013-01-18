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
        private void SalvarParametro(string descricao, string valor)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();

            List<Parametros> ltPar = parBL.PesquisarBL(descricao);

            if (ltPar.Count > 0)
            {
                foreach (Parametros par in ltPar)
                {
                    parametros.Id = par.Id;
                    parametros.Descricao = par.Descricao;
                    parametros.Valor = valor;

                    parBL.EditarBL(parametros);
                }
            }
            else
            {
                parametros.Descricao = descricao;
                parametros.Valor = valor;

                parBL.InserirBL(parametros);
            }          

        }
        private string PesquisarParametro(string descricao)
        {
            ParametrosBL parBL = new ParametrosBL();
            Parametros parametros = new Parametros();
            string v_descricao = "";
            List<Parametros> ltPar = parBL.PesquisarBL(descricao);

            foreach (Parametros par in ltPar)
            {
                v_descricao = par.Descricao;
            }

            return v_descricao;         
 
        }
        private void CarregarDados()
        {
            #region biblioteca
            txtQtdMaxEmp.Text = PesquisarParametro(lblQtdMaxEmp.Text);
            txtQtdMaxRen.Text = PesquisarParametro(lblQtdMaxRen.Text);
            txtTempoMinRetirada.Text = PesquisarParametro(lblTempoMinRetirada.Text);
            txtQtdMinRetirada.Text = PesquisarParametro(lblQtdMinRetirada.Text);
            #endregion

            #region financeiro
            txtValorMulta.Text = PesquisarParametro(lblValorMulta.Text);
            txtPerLucro.Text = PesquisarParametro(lblPerLucro.Text);
            txtDesconto.Text = PesquisarParametro(lblDesconto.Text);
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
            SalvarParametro(lblQtdMaxEmp.Text, txtQtdMaxEmp.Text);
            SalvarParametro(lblQtdMaxRen.Text, txtQtdMaxRen.Text);
            SalvarParametro(lblTempoMinRetirada.Text, txtTempoMinRetirada.Text);
            SalvarParametro(lblQtdMinRetirada.Text, txtQtdMinRetirada.Text);
            #endregion

            #region financeiro
            SalvarParametro(lblValorMulta.Text, txtValorMulta.Text);
            SalvarParametro(lblPerLucro.Text, txtPerLucro.Text);
            SalvarParametro(lblDesconto.Text, txtDesconto.Text);
            #endregion

        }
    }
}