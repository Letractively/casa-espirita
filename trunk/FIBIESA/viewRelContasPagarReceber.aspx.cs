using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
namespace FIBIESA
{
    public partial class viewRelContasPagarReceber : System.Web.UI.Page
    {
        #region funcoes
        private DataTable CriarTabelaPesquisa()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            return dt;

        }
        #endregion
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaTipoDocumentos();
            }
        }

        #region pesquisas

        public void pesquisaTitulo(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            TitulosBL titBL = new TitulosBL();
            Titulos tit = new Titulos();
            List<Titulos> lTitulos;
            if (this.txtTitulo.Text != string.Empty && lCampoPesquisa != string.Empty)
            {
                lTitulos = titBL.PesquisarBuscaBL(this.txtAssociado.Text);
            }
            else
            {
                lTitulos = titBL.PesquisarBL();
            }

            foreach (Titulos pes in lTitulos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Numero;
                linha["DESCRICAO"] = pes.PesDescricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Título não encontrado.');", true);
            }

            Session["objBLPesquisa"] = titBL;
            Session["objPesquisa"] = tit;

        }
        
        public void pesquisaAssociado(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas;
            if (this.txtAssociado.Text != string.Empty && lCampoPesquisa != string.Empty)
            {
                pessoas = pesBL.PesquisarBL(lCampoPesquisa, this.txtAssociado.Text);
            }
            else
            {
                pessoas = pesBL.PesquisarBL();
            }

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Associado não encontrado.');", true);
            }

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

        }

        public void pesquisaPortador(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PortadoresBL porBL = new PortadoresBL();
            Portadores po = new Portadores();
            List<Portadores> portadores;
            if (this.txtPortador.Text != string.Empty && lCampoPesquisa != string.Empty)
            {
                portadores = porBL.PesquisarBuscaBL(this.txtPortador.Text);
            }
            else
            {
                portadores = porBL.PesquisarBL();
            }

            foreach (Portadores pes in portadores)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Portador não encontrado.');", true);
            }

            Session["objBLPesquisa"] = porBL;
            Session["objPesquisa"] = po;



        }

        public DataTable pesquisaTipoDocumento()
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            TiposDocumentosBL tipoDoBL = new TiposDocumentosBL();
            TiposDocumentos tipoDo = new TiposDocumentos();
            List<TiposDocumentos> lTiposDocumentos;
            
                lTiposDocumentos = tipoDoBL.PesquisarBuscaBL(string.Empty);
            
            foreach (TiposDocumentos doc in lTiposDocumentos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = doc.Id;
                linha["CODIGO"] = doc.Codigo;
                linha["DESCRICAO"] = doc.Descricao;

                dt.Rows.Add(linha);
            }

            return dt;

        }
        #endregion pesquisas

        #region eventos textBox
        protected void txtAssociado_TextChanged(object sender, EventArgs e)
        {
            carregaPessoa();
        }

        protected void txtPortador_TextChanged(object sender, EventArgs e)
        {
            carregaPortador();
        }

        protected void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            carregaTitulos();
        }

        #endregion


        #region carrega Informações
        public void carregaPessoa()
        {
            pesquisaAssociado("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesAssociado.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdAssociado.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesAssociado.Text = string.Empty;
                this.hfIdAssociado.Value = "0";
            }
        }

        public void carregaPortador()
        {
            pesquisaPortador("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesPortador.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdPortador.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesPortador.Text = string.Empty;
                this.hfIdPortador.Value = "0";
            }
        }


        public void carregaTipoDocumentos()
        {
            this.ddlTipoDocumento.DataTextField = "DESCRICAO";
            this.ddlTipoDocumento.DataValueField = "id";
            this.ddlTipoDocumento.DataSource = pesquisaTipoDocumento();
            this.ddlTipoDocumento.DataBind();            
        }


        public void carregaTitulos()
        {
            pesquisaTitulo("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesTitulo.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdTitulo.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesTitulo.Text = string.Empty;
                this.hfIdTitulo.Value = "0";
            }
        }
        #endregion carrega Informações

        
        #region botões de pesquisa
        protected void btnPesAssociado_Click(object sender, EventArgs e)
        {
            pesquisaAssociado(string.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtAssociado.ClientID + "&id=" + hfIdAssociado.ClientID + "&lbl=" + lblDesAssociado.ClientID + "','',600,500);", true);
        }

        protected void btnPesPortados_Click(object sender, EventArgs e)
        {
            pesquisaPortador(string.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtPortador.ClientID + "&id=" + hfIdPortador.ClientID + "&lbl=" + lblDesPortador.ClientID + "','',600,500);", true);
        }


        protected void btnPesTitulo_Click(object sender, EventArgs e)
        {
            pesquisaTitulo(string.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtTitulo.ClientID + "&id=" + hfIdTitulo.ClientID + "&lbl=" + lblDesTitulo.ClientID + "','',600,500);", true);
        }

        #endregion botões de pesquisa

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            TitulosBL titulosBL = new TitulosBL();
            Titulos titulos = new Titulos();

            titulos.Pessoaid = Convert.ToInt32(hfIdAssociado.Value);
            titulos.Portadorid = Convert.ToInt32(hfIdPortador.Value);
            titulos.Id = Convert.ToInt32(hfIdTitulo.Value);
            titulos.TipoDocumentoId = Convert.ToInt32(ddlTipoDocumento.SelectedValue);

            string tipoTitulo = string.Empty;
            if (rbApagar.Checked)
                tipoTitulo = "CP";
            else if (rbAreceber.Checked)
                tipoTitulo = "CR";

            Boolean blAtrasados = false;
            if (ckbAtrasados.Checked)
                blAtrasados = true;
            
            Session["ldsRel"] = titulosBL.PesquisarBuscaDataSetBL(titulos,tipoTitulo,blAtrasados,txtDataEmissaoIni.Text,txtDataEmissaoFim.Text,txtDataVencimentoIni.Text,txtDataVencimentoFim.Text, txtDataPagamentoIni.Text, txtDataPagamentoFim.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                string periodo = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelContasPagarReceber.aspx?periodo=" + periodo + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }
    }
}