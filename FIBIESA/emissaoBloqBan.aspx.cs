using System;
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

namespace FIBIESA
{
    public partial class emissaoBloqBan : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
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

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDdlPortador();
                CarregarDdlTipoDoc();
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            TitulosBL titBL = new TitulosBL();
            List<Titulos> titulos = titBL.PesquisarBuscaBL("R",null);
            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pes;
            PortadoresBL porBL = new PortadoresBL();
            List<Portadores> portadores;

            
            foreach (Titulos ltTit in titulos)
            {   
                String numeroDocumento = "B20005446";
                Cedente cedente;
                portadores = porBL.PesquisarBL(utils.ComparaIntComZero(ltTit.Portadorid.ToString()));

                //DADOS DO CEDENTE
                foreach (Portadores ltPor in portadores)
                {
                    cedente = new Cedente("123.456.789-01"
                                          , ltPor.Descricao
                                          , ltPor.Agencia.Codigo.ToString()
                                          , ltPor.Contas.Codigo.ToString()
                                          , ltPor.Contas.Digito);

                    cedente.Codigo = Convert.ToInt32("13000");



                    String cedente_nossoNumeroBoleto = "22222222";

                    Boleto boleto = new Boleto(ltTit.DataVencimento, ltTit.Valor, "341", cedente_nossoNumeroBoleto, cedente);

                    boleto.NumeroDocumento = numeroDocumento;


                    //DADOS DO SACADO CLIENTE
                    Sacado sacado = new Sacado(ltTit.Pessoas.CpfCnpj, ltTit.Pessoas.Nome != "" ? ltTit.Pessoas.Nome : ltTit.Pessoas.NomeFantasia);
                    boleto.Sacado = sacado;

                    pes = pesBL.PesquisarBL(utils.ComparaIntComZero(ltTit.Pessoaid.ToString()));

                    foreach (Pessoas ltPes in pes)
                    {
                        boleto.Sacado.Endereco.End = ltPes.Endereco;
                        boleto.Sacado.Endereco.Bairro = ltPes.Bairro.Descricao;
                        boleto.Sacado.Endereco.Cidade = ltPes.Cidade.Descricao;
                        boleto.Sacado.Endereco.CEP = ltPes.Cep;
                        boleto.Sacado.Endereco.UF = ltPes.Cidade.Estados.Uf;
                    }

                    Instrucao_Banrisul instrucao = new Instrucao_Banrisul(999, 1);
                    Instrucao_Banrisul item1 = new Instrucao_Banrisul(9, 5);
                    Instrucao_Banrisul item2 = new Instrucao_Banrisul(81, 10);

                    boleto.Instrucoes.Add(instrucao);
                    boleto.Instrucoes.Add(item1);
                    boleto.Instrucoes.Add(item2);

                    BoletoBancario boleto_bancario = new BoletoBancario();
                    boleto_bancario.CodigoBanco = 041;
                    boleto_bancario.Boleto = boleto;
                    boleto_bancario.MostrarCodigoCarteira = true;
                    boleto_bancario.Boleto.Valida();

                    boleto_bancario.MostrarComprovanteEntrega = true;

                    Session["boleto"] = boleto_bancario;
                    Response.Redirect("~/WebForm1.aspx");
                }
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

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
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

        protected void txtPesTitulo_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaTitulos(txtPesquisa.Text);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
            txtPesTitulo.Text = "";
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
        
    }
}