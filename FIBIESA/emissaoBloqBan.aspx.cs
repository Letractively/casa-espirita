﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;
using FG;
using BoletoNet;
using System.Globalization;
using System.Text;
using System.IO;
namespace FIBIESA
{
    public partial class emissaoBloqBan : System.Web.UI.Page
    {
        Utils utils = new Utils();
        DataTable dt_boletos = new DataTable();

        #region funcoes
        public string Nomedoarquivo
        {
            get { return ViewState["nomedoarquivo"].ToString(); }
            set { ViewState["nomedoarquivo"] = value; }
        }
        public void CarregarPesquisa(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
        }
        public void CarregarPesquisaTitulos(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            TitulosBL titBL = new TitulosBL();
            Titulos tit = new Titulos();
            List<Titulos> titulos = titBL.PesquisarBuscaBL("R",conteudo);

            foreach (Titulos ltTit in titulos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = ltTit.Id;
                linha["CODIGO"] = ltTit.Numero;
                linha["DESCRICAO"] = ltTit.Parcela;

                dt.Rows.Add(linha);
            }


            grdPesquisatit.DataSource = dt;
            grdPesquisatit.DataBind();
        }
        private void CarregarDdlTipoDoc()
        {
            TiposDocumentosBL tipDBL = new TiposDocumentosBL();
            List<TiposDocumentos> tipoDoc = tipDBL.PesquisarBL("CR");

            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.Items.Add(new ListItem());
            foreach (TiposDocumentos ltTip in tipoDoc)
                ddlTipoDoc.Items.Add(new ListItem(ltTip.Codigo + " - " + ltTip.Descricao, ltTip.Id.ToString()));

            ddlTipoDoc.SelectedIndex = 0;
        }
        private void CarregarDdlPortador()
        {
            PortadoresBL porDBL = new PortadoresBL();
            List<Portadores> port = porDBL.PesquisarBL();

            ddlPortador.Items.Add(new ListItem());
            foreach (Portadores ltPort in port)
                ddlPortador.Items.Add(new ListItem(ltPort.Codigo + " - " + ltPort.Descricao, ltPort.Id.ToString()));

            ddlPortador.SelectedIndex = 0;
        }
        private void CarregarDdlInstrucao(DropDownList ddl)
        {
            BancosInstrucoesBL banInstBL = new BancosInstrucoesBL();
            List<BancosInstrucoes> banInst = banInstBL.PesquisarBL();

            ddl.Items.Add(new ListItem());
            foreach (BancosInstrucoes ltbI in banInst)
                ddl.Items.Add(new ListItem(ltbI.Codigo + " - " + ltbI.Descricao, ltbI.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                    updPrincipal,
                                    this.GetType(),
                                    "Alert",
                                    "window.alert(\"" + mensagem + "\");",
                                    true);
        }
        private void CarregarAtributos()
        {            
            txtDtEmiIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtEmiFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");      
        }                
        private string LerParametro(int codigo, string modulo)
        {
            ParametrosBL parBL = new ParametrosBL();
            DataSet dsPar = parBL.PesquisarBL(codigo, modulo);
            string valor = "";

            if (dsPar.Tables[0].Rows.Count != 0)
                valor = dsPar.Tables[0].Rows[0]["VALOR"].ToString();

            return valor;
        }
        private void CriarDtBoletos()
        {
            //cedente
            DataColumn coluna1 = new DataColumn("CodCedente", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CedNossonumero", Type.GetType("System.String"));
            //DataColumn coluna3 = new DataColumn("CED_CPFCNPJ", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("Cedente", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CedAgencia", Type.GetType("System.Int32"));
            //DataColumn coluna6 = new DataColumn("CED_CONTA", Type.GetType("System.String"));
            //DataColumn coluna7 = new DataColumn("CED_DIGITOCONTA", Type.GetType("System.String"));
            //sacado
            //DataColumn coluna8 = new DataColumn("SAC_CPFCNPJ", Type.GetType("System.String"));
            //DataColumn coluna9 = new DataColumn("SAC_NOME", Type.GetType("System.String"));
            //DataColumn coluna10 = new DataColumn("SAC_ENDERECO", Type.GetType("System.String"));
            //DataColumn coluna11 = new DataColumn("SAC_BAIRRO", Type.GetType("System.String"));
            //DataColumn coluna12 = new DataColumn("SAC_CIDADE", Type.GetType("System.String"));
            //DataColumn coluna13 = new DataColumn("SAC_CEP", Type.GetType("System.String"));
            //DataColumn coluna14 = new DataColumn("SAC_UF", Type.GetType("System.String"));

            //titulo
            DataColumn coluna5 = new DataColumn("DataVencimento", Type.GetType("System.DateTime"));
            DataColumn coluna6 = new DataColumn("ValorBoleto", Type.GetType("System.Decimal"));
            DataColumn coluna7 = new DataColumn("NumeroDocumento", Type.GetType("System.Int32"));
            DataColumn coluna8 = new DataColumn("Instrucoes1", Type.GetType("System.String"));
            DataColumn coluna9 = new DataColumn("Instrucoes2", Type.GetType("System.String"));
            
            //
            DataColumn coluna10 = new DataColumn("Banco", Type.GetType("System.String"));
            DataColumn coluna11 = new DataColumn("LinhaDigitavel", Type.GetType("System.String"));
            DataColumn coluna12 = new DataColumn("Carteira", Type.GetType("System.String"));
            DataColumn coluna13 = new DataColumn("LocalPagamento", Type.GetType("System.String"));
            DataColumn coluna14 = new DataColumn("Aceite", Type.GetType("System.String"));
            DataColumn coluna15 = new DataColumn("DataDocumento", Type.GetType("System.DateTime"));
            DataColumn coluna16 = new DataColumn("DataProcessamento", Type.GetType("System.DateTime"));
            DataColumn coluna17 = new DataColumn("Quantidade", Type.GetType("System.Int32"));
                        
            dt_boletos.Columns.Add(coluna1);
            dt_boletos.Columns.Add(coluna2);
            dt_boletos.Columns.Add(coluna3);
            dt_boletos.Columns.Add(coluna4);
            dt_boletos.Columns.Add(coluna5);
            dt_boletos.Columns.Add(coluna6);
            dt_boletos.Columns.Add(coluna7);
            dt_boletos.Columns.Add(coluna8);
            dt_boletos.Columns.Add(coluna9);
            dt_boletos.Columns.Add(coluna10);
            dt_boletos.Columns.Add(coluna11);
            dt_boletos.Columns.Add(coluna12);
            dt_boletos.Columns.Add(coluna13);
            dt_boletos.Columns.Add(coluna14);
            dt_boletos.Columns.Add(coluna15);
            dt_boletos.Columns.Add(coluna16);
            dt_boletos.Columns.Add(coluna17);
            //dt_boletos.Columns.Add(coluna18);
            //dt_boletos.Columns.Add(coluna19);
            

          
        }
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarAtributos();
                CarregarDdlPortador();
                CarregarDdlTipoDoc();
                CarregarDdlInstrucao(ddlInstrucao1);
                CarregarDdlInstrucao(ddlInstrucao2);
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            TitulosBL titulosBL = new TitulosBL();
            PortadoresBL portadoresBL = new PortadoresBL();
            SelecaoTitulos selTitulos = new SelecaoTitulos();
            InstituicoesBL instBL = new InstituicoesBL();            
            
            CriarDtBoletos();
            DataSet dsInst = instBL.PesquisarDsBL();
            List<Titulos> titulos = titulosBL.PesquisarBuscaBL(selTitulos);

            StringBuilder linhaDigitavel = new StringBuilder();
            DateTime dtInicialFV = new DateTime(1997, 10, 07); 
                        
            foreach (Titulos ltTit in titulos)
            {
                DataRow linha = dt_boletos.NewRow();

                //cedente que vai receber o valor
                List<Portadores> portadores = portadoresBL.PesquisarBL(utils.ComparaIntComZero(ltTit.Portadorid.ToString()));
                
                foreach (Portadores ltPor in portadores)
                {
                    linha["CodCedente"] = ltPor.CodCedente;
                    linha["CedNossonumero"] = "2222";
                    //linha["CED_CPFCNPJ"] =  ;
                    linha["Cedente"] = dsInst.Tables[0].Rows[0]["razao"].ToString();
                    linha["CedAgencia"] = ltPor.Agencia.Codigo;
                    //linha["CED_CONTA"] = ltPor.Contas.Codigo;
                    //linha["CED_DIGITOCONTA"] = ltPor.Contas.Digito;

                    if (ltPor.Banco != null)
                        linha["Banco"] = ltPor.Banco.Codigo;
                    else
                        linha["Banco"] = "";
                }

                ////sacado quem vai pagar o titulo                
                //linha["SAC_CPFCNPJ"] = ltTit.Pessoas.CpfCnpj;
                //linha["SAC_NOME"] = ltTit.Pessoas.Nome;
                //linha["SAC_ENDERECO"] = ltTit.Pessoas.Endereco;
                //linha["SAC_BAIRRO"] = ltTit.Pessoas.Bairro.Descricao;
                //linha["SAC_CIDADE"] = ltTit.Pessoas.Cidade.Descricao;
                //linha["SAC_CEP"] = ltTit.Pessoas.Cep;
                //linha["SAC_UF"] = ltTit.Pessoas.Cidade.Estados.Uf;

                linha["DataVencimento"] = ltTit.DataVencimento;
                linha["ValorBoleto"] = ltTit.Valor;
                linha["NumeroDocumento"] = ltTit.Numero;
                linha["Instrucoes1"] = ddlInstrucao1.SelectedValue;
                linha["Instrucoes2"] = ddlInstrucao2.SelectedValue;
                linha["Carteira"] = "teste";
                linha["LocalPagamento"] = "Até o vencimento, preferencialmente no Banco Banrisul";
                linha["Aceite"] ="N"; //implementar o aceite.
                linha["DataDocumento"] = ltTit.DataEmissao;
                linha["DataProcessamento"] = DateTime.Now;
                linha["Quantidade"] = 1;

                //codigo do banco 01 - 03
                linhaDigitavel.Append(linha["LinhaDigitavel"]);
                //moeda 9 real 04 - 04
                linhaDigitavel.Append("9");
                //DAC 05 - 05
                linhaDigitavel.Append(" ");
                //fator de vencimento 06 - 09
                linhaDigitavel.Append(utils.CalcularNumeroDiasEntreDatas(dtInicialFV, DateTime.Now));
                //valor 10 -19
                utils.IncluirCampoNumerico(linhaDigitavel, linha["ValorBoleto"].ToString(), 10);
                //campo livre 20 - 44
                linhaDigitavel.Append("");
                //Produto 20 - 20 2 cobrança direta, fichario emitido pelo cliente
                linhaDigitavel.Append("2");
                //Constante 1
                linhaDigitavel.Append("1");
                //Codigo da agencia 22 - 25
                utils.IncluirCampoNumerico(linhaDigitavel, linha["CedAgencia"].ToString(), 4);
                //Codigo do cedente 26 - 32
                utils.IncluirCampoNumerico(linhaDigitavel, linha["CodCedente"].ToString(), 7);
                //Nosso numero 33 - 40
                linhaDigitavel.Append("");
                //Constante 40 41 - 42
                linhaDigitavel.Append("40");
                //Duplo digito modulos 10 e 11 
                linhaDigitavel.Append("");

                linha["LinhaDigitavel"] = linhaDigitavel.ToString();

                dt_boletos.Rows.Add(linha);
            }

            Session["ldsRel"] = dt_boletos;
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelBoletos.aspx?Eventos=" + ddlPortador.SelectedValue + "','',600,1000);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
           
   
        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            CarregarPesquisa(null);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show(); 
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntClientes"] != null)
                txtIntClientes.Text = Session["IntClientes"].ToString() +",";

            txtIntClientes.Text = txtIntClientes.Text + gvrow.Cells[2].Text;
            Session["IntClientes"] = txtIntClientes.Text;
            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void txtIntClientes_TextChanged(object sender, EventArgs e)
        {
            if (txtIntClientes.Text == "")
                Session["IntClientes"] = null;
                     
        }
        
        protected void grdPesquisaTit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
               
        protected void txtIntTitulos_TextChanged(object sender, EventArgs e)
        {
            if (txtIntTitulos.Text == "")
                Session["IntTitulos"] = null;

        }

        protected void btnSelectTit_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntTitulos"] != null)
                txtIntTitulos.Text = Session["IntTitulos"].ToString() + ",";

            txtIntTitulos.Text = txtIntTitulos.Text + gvrow.Cells[2].Text +" - "+ gvrow.Cells[3].Text;
            Session["IntTitulos"] = txtIntTitulos.Text;
            pnlTitulos_ModalPopupExtender.Hide();
            pnlTitulos_ModalPopupExtender.Enabled = false;
        }

        protected void btnCancelTit_Click(object sender, EventArgs e)
        {
            pnlTitulos_ModalPopupExtender.Enabled = false;
        }

        protected void btnPesTitulo_Click(object sender, EventArgs e)
        {
            CarregarPesquisaTitulos(null);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show(); 
        }

        protected void btnBuscarTit_Click(object sender, EventArgs e)
        {
            CarregarPesquisaTitulos(txtPesquisa.Text);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
            txtPesTitulo.Text = "";

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarPesquisa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
        }
        
    }
}