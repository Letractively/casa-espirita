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
using System.Text;
using System.IO;
namespace FIBIESA
{
    public partial class emissaoBloqBan : System.Web.UI.Page
    {
        Utils utils = new Utils();

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
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            
            //TitulosBL titulosBL = new TitulosBL();
            //Titulos titulos = new Titulos();
            //DataSet dtsTitulos = new DataSet();
                        
            //dtsTitulos = titulosBL.PesquisarBuscaDataSetBL(txtTitulo.Text, txtAssociado.Text, txtPortador.Text, "CR", ddlTipoDocumento.SelectedValue, true, txtDataEmissaoIni.Text, txtDataEmissaoFim.Text, txtDataVencimentoIni.Text, txtDataVencimentoFim.Text, txtDataPagamentoIni.Text, txtDataPagamentoFim.Text).Tables[0];

            //foreach (DataRow ltExe in dtsTitulos.Tables[0].Rows)
            //{
            //    DataRow linha = dt.NewRow();
            //    linha["ID"] = ltExe["Id"];
            //    linha["CODIGO"] = ltExe["tombo"];
            //    linha["DESCRICAO"] = ltExe["titulo"];

            //    dt.Rows.Add(linha);
            //}
            
            //if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            //{
            //    string periodo = "";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelContasReceber.aspx?periodo=" + periodo + "','',590,980);", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            //}
            
            
            //TitulosBL titBL = new TitulosBL();
            //List<Titulos> titulos = titBL.PesquisarBuscaBL("R",null);
            
            
            //PessoasBL pesBL = new PessoasBL();
            //List<Pessoas> pes;
            //PortadoresBL porBL = new PortadoresBL();
            //List<Portadores> portadores;

            
            //foreach (Titulos ltTit in titulos)
            //{
            //    #region header
            //    StringBuilder header = new StringBuilder();

            //    //posicoes 001 - 009 
            //    header.Append("01REMESSA"); 

            //    //posicoes 010 - 026 brancos
            //    IncluirBrancos(header, 16);

               
            //   // String numeroDocumento = "B20005446";
            //    //Cedente cedente;
            //    portadores = porBL.PesquisarBL(utils.ComparaIntComZero(ltTit.Portadorid.ToString()));

            //    //DADOS DO CEDENTE
            //    foreach (Portadores ltPor in portadores)
            //    {                    
            //        //posicoes 027 - 039 codigo do cedente
            //        CompletarComZerosDireita(header, ltPor.CodCedente.ToString().Length - 12);
            //        header.Append(ltPor.CodCedente);
                    
            //        //posicoes 040 - 046 brancos
            //        IncluirBrancos(header, 7);

            //        //posicoes 047 - 076 nome da empresa
            //        header.Append("instituicoes.razao 30");

            //        //posicoes 077 - 087 
            //        header.Append("041BANRISUL");

            //        //posicoes 088 - 094 brancos
            //        IncluirBrancos(header, 7);

            //        //posicoes 095 - 100 
            //        header.Append(DateTime.Now.ToString("dd/MM/yy"));

            //        //posicoes 101 - 109 brancos
            //        IncluirBrancos(header, 9);

            //        //posicoes 110 - 113
            //        if (ltPor.Carteira == "R" || ltPor.Carteira == "S" || ltPor.Carteira == "X")
            //        {
            //            header.Append("0808");
            //            //posicoes 114 - 114 branco
            //            IncluirBrancos(header, 1);
                        
            //            // posicoes 115 - 115
            //            header.Append("P");

            //            //posicoes 116 - 116
            //            IncluirBrancos(header,1);

            //            //posicoes 117 - 126
            //            IncluirBrancos(header, ltPor.CodEmpBanriMicro.Length - 10);
            //            header.Append(ltPor.CodEmpBanriMicro);
            //        }
            //        else
            //        {  
            //            //posicoes 110 - 113 e 114 ao 126
            //            IncluirBrancos(header, 17);
                        
            //        }                    

            //        //posicoes 127 - 394 brancos
            //        IncluirBrancos(header, 268);
                    
            //        //posicoes 395 - 400
            //        header.Append("000001");

            //        #endregion header;
                   
            //        #region detalhe

            //        StringBuilder detalhe = new StringBuilder();
                    
            //        //posicoes 001 - 001
            //        detalhe.Append("1");

            //        //posicoes 002 - 017
            //        IncluirBrancos(detalhe, 16);
                    
            //        //posicoes 018 - 030 codigo cedente
            //        IncluirBrancos(detalhe, ltPor.CodCedente.ToString().Length - 13);
            //        detalhe.Append(ltPor.CodCedente);

            //        //posicoes 031 - 037 brancos
            //        IncluirBrancos(detalhe, 7);

            //        //posicoes 038 - 062 
            //        detalhe.Append(ltTit.Id);
            //        IncluirBrancos(detalhe, ltTit.Id.ToString().Length - 25);

            //        //posicoes 063 - 072 nosso numero
            //        detalhe.Append(" 10 posicoes ");

            //        //posicoes 073 - 104 mensagem no bloqueto
            //        detalhe.Append(" 32 posicoes");

            //        //posicoes 105 - 107 brancos
            //        IncluirBrancos(detalhe, 3);

            //        //posicoes 108 -108 tipo de carteira
            //        detalhe.Append(ltPor.Carteira != null ? ltPor.Carteira :"0");
                    
            //        //incluir essa opção nessa tela por defaul 1
            //        //posicoes 109 - 110 codigo de ocorrencia
            //        detalhe.Append("01 - remessa ocorrencia ");

            //        //posicoes 111 - 120 seu numero

            //        //posicoes 121 - 126 data de vencimento
            //        detalhe.Append(ltTit.DataVencimento.ToString("dd/MM/yy"));

            //        //posicoes 127 - 139 valor do título
            //        detalhe.Append(ltTit.Valor);

            //        //posicoes 140 - 142
            //        detalhe.Append("041");

            //        //posicoes 123 - 147 brancos
            //        IncluirBrancos(detalhe, 5);     
         
            //        //posicoes 148 - 149  tipo de documento 
            //        //cobrança credenciada banrisul CCB
            //        detalhe.Append("08");

            //        //posicoes 150 - 150 aceite
            //        detalhe.Append("A");

            //        //posicoes 151 - 156 
            //        detalhe.Append(ltTit.DataEmissao.ToString("dd/MM/yy"));

            //        //posicoes 157 - 158 instrucao 1
            //        CompletarComZerosDireita(detalhe, ddlInstrucao1.SelectedValue.Length - 2);
            //        detalhe.Append(ddlInstrucao1.SelectedValue);

            //        //posicoes 159 - 160 instrucao 2
            //        CompletarComZerosDireita(detalhe, ddlInstrucao2.SelectedValue.Length - 2);
            //        detalhe.Append(ddlInstrucao2.SelectedValue);

            //        //posicoes 161 - 161 código de mora
            //        if (ltPor.Carteira == "R" || ltPor.Carteira == "S" || ltPor.Carteira == "X" || ltPor.Carteira == "N")
            //           IncluirBrancos(detalhe,1);
            //        else
            //            detalhe.Append("0");

            //        //posicoes 162 - 173 
            //        if (ltPor.Carteira == "R" || ltPor.Carteira == "S" || ltPor.Carteira == "X" || ltPor.Carteira == "N")
            //            CompletarComZerosDireita(detalhe, 12);                  
            //        else
            //            detalhe.Append("pesquisar o valor da multa cadastro de juros e multa");
                    
            //        //posicoes 174 - 179 data de desconto
            //        IncluirBrancos(detalhe,6);

            //        //posicoes 180 - 192 valor do desconto
            //        IncluirBrancos(detalhe, 13);

            //        //posicoes 193 - 205 valor IOF
            //        IncluirBrancos(detalhe, 13);

            //        //posicoes 206 - 218
            //        IncluirBrancos(detalhe, 13);
                    
            //        //posicoes 219 - 220 tipo de inscrição do sacado
            //        //01 pessoa fisica, 02 pessoa juridica
            //        detalhe.Append("01 ou 02");
                    
            //        //posicoes 221 - 234 cpf/cnfp
            //        detalhe.Append("cpfCnpf");

            //        //posicoes 235 - 269 nome do sacado
            //        detalhe.Append("nome cliente");

            //        //posicoes 270 - 274 brancos
            //        IncluirBrancos(detalhe,5);
 
            //        //posicoes 275 - 314 endereco 
            //        detalhe.Append("endereço do cliente");

            //        //posicoes 315 - 321 
            //        IncluirBrancos(detalhe, 7);


            //        #endregion detalhe

            //        #region trailler
            //        StringBuilder trailler = new StringBuilder();

            //        //posicoes 001 - 001
            //        trailler.Append("9");

            //        //posicoes 002 - 027
            //        IncluirBrancos(trailler, 26);

            //        //posicoes 028 - 040

            //        //posicoes 041 - 395 
            //        IncluirBrancos(trailler, 353);

            //        //posicoes 395 - 400 sequencia do registro
            //        trailler.Append("000001");

            //        #endregion trailler

                    //cedente = new Cedente("123.456.789-01"
                    //                      , ltPor.Descricao
                    //                      , ltPor.Agencia.Codigo.ToString()
                    //                      , ltPor.Contas.Codigo.ToString()
                    //                      , ltPor.Contas.Digito);

                    //cedente.Codigo = Convert.ToInt32("13000");


                    //try
                    //{

                    //    String cedente_nossoNumeroBoleto = "22222222";

                    //    Boleto boleto = new Boleto(ltTit.DataVencimento, ltTit.Valor, "341", cedente_nossoNumeroBoleto, cedente);

                    //    boleto.NumeroDocumento = numeroDocumento;


                    //    //DADOS DO SACADO CLIENTE
                    //    Sacado sacado = new Sacado(ltTit.Pessoas.CpfCnpj, ltTit.Pessoas.Nome != "" ? ltTit.Pessoas.Nome : ltTit.Pessoas.NomeFantasia);
                    //    boleto.Sacado = sacado;

                    //    pes = pesBL.PesquisarBL(utils.ComparaIntComZero(ltTit.Pessoaid.ToString()));

                    //    foreach (Pessoas ltPes in pes)
                    //    {
                    //        boleto.Sacado.Endereco.End = ltPes.Endereco;
                    //        boleto.Sacado.Endereco.Bairro = ltPes.Bairro.Descricao;
                    //        boleto.Sacado.Endereco.Cidade = ltPes.Cidade.Descricao;
                    //        boleto.Sacado.Endereco.CEP = ltPes.Cep;
                    //        boleto.Sacado.Endereco.UF = ltPes.Cidade.Estados.Uf;
                    //    }

                    //    Instrucao_Banrisul instrucao = new Instrucao_Banrisul(999, 1);
                    //    Instrucao_Banrisul item1 = new Instrucao_Banrisul(1, 5);
                    //    Instrucao_Banrisul item2 = new Instrucao_Banrisul(81, 10);

                    //    boleto.Instrucoes.Add(instrucao);
                    //    boleto.Instrucoes.Add(item1);
                    //    boleto.Instrucoes.Add(item2);

                    //    BoletoBancario boleto_bancario = new BoletoBancario();
                    //    boleto_bancario.CodigoBanco = 041;
                    //    boleto_bancario.Boleto = boleto;
                    //    boleto_bancario.MostrarCodigoCarteira = true;
                    //    boleto_bancario.Boleto.Valida();

                    //    boleto_bancario.MostrarComprovanteEntrega = true;

                    //    Session["boleto"] = boleto_bancario;
                    //    Response.Redirect("~/WebForm1.aspx");
                    //}
                    //catch(Exception ex)
                    //{
                    //    if (ex.Source.Equals("Boleto.Net"))
                    //    {
                    //        this.ExibirMensagem(ex.Message);
                    //    }
                    //    else
                    //        throw;
                    //}
                //}
           // }
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