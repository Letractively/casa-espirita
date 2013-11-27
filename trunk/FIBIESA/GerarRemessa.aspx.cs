using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessLayer;
using System.Data;
using System.Text;
using DataObjects;
using FG;

namespace FIBIESA
{
    public partial class GerarRemessa : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void CarregarDdlPortador()
        {
            PortadoresBL porDBL = new PortadoresBL();
            List<Portadores> port = porDBL.PesquisarBL();

            ddlPortador.Items.Add(new ListItem());
            foreach (Portadores ltPort in port)
                ddlPortador.Items.Add(new ListItem(ltPort.Codigo + " - " + ltPort.Descricao, ltPort.Id.ToString()));

            ddlPortador.SelectedIndex = 1;
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
        public string Nomedoarquivo
        {
            get { return ViewState["nomedoarquivo"].ToString(); }
            set { ViewState["nomedoarquivo"] = value; }
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
            List<Titulos> titulos = titBL.PesquisarBuscaBL("R", conteudo);

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
        private void CarregarAtributos()
        {
            txtDtVencIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtVencFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtEmiIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtEmiFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDiasUm.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDdlInstrucao(ddlInstrucao1);
                CarregarDdlInstrucao(ddlInstrucao2);
                CarregarDdlPortador();
                CarregarAtributos();
                lkbDownload.Visible = false;
                Session["IntTitulos"] = null;
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }              

        protected void btnCancelTit_Click(object sender, EventArgs e)
        {
            pnlTitulos_ModalPopupExtender.Enabled = false;
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            //UTF-8 ISO-8859-1 verificar qual utilizar
            Remessa remessa = new Remessa();

            Nomedoarquivo = Path.Combine(Path.GetTempPath(), System.IO.Path.GetRandomFileName() + ".txt");
            StreamWriter sw = new StreamWriter(Nomedoarquivo, true, System.Text.Encoding.GetEncoding("UTF-8"));

            PortadoresBL portadoresBL = new PortadoresBL();
            TitulosBL titulosBL = new TitulosBL();
            SelecaoTitulos selTitulos = new SelecaoTitulos();

            selTitulos.CodTitulos = txtIntTitulos.Text;
            selTitulos.PortadorId = ddlPortador.SelectedValue;
            selTitulos.DataEmissaoIni = txtDtEmiIni.Text;
            selTitulos.DataEmissaoFim = txtDtEmiFim.Text;
            selTitulos.DataVencimentoIni = txtDtVencIni.Text;
            selTitulos.DataVencimentoFim = txtDtVencFim.Text;
            selTitulos.Tipo = "R";

            remessa.DiasProtesto = txtDiasUm.Text;
            remessa.Instrucao1 = ddlInstrucao1.SelectedValue;
            remessa.Instrucao2 = ddlInstrucao2.SelectedValue;
            remessa.CodOcorrencia = ddlRemessa.SelectedValue;
            remessa.JuroMora = ddlJuroMora.SelectedValue;
            
            StringBuilder arquivo = new StringBuilder();
            int v_seq = 1;
            string codCedente = "";

            List<Portadores> portadores = portadoresBL.PesquisarBL(utils.ComparaIntComZero(ddlPortador.SelectedValue));

            foreach (Portadores ltPor in portadores)
            {
                titulosBL.ArquivoRemessaMontarHeader(arquivo, ltPor, v_seq.ToString());
                sw.WriteLine(arquivo);
                codCedente = ltPor.CodCedente.ToString();
            }

            List<Titulos> titulos = titulosBL.PesquisarBuscaBL(selTitulos);
                        
            foreach (Titulos ltTit in titulos)
            {
                v_seq++;
                arquivo.Clear();
                titulosBL.ArquivoRemessaMontarTransacao(arquivo, ltTit, remessa, v_seq.ToString(), codCedente);
                sw.WriteLine(arquivo);                
            }

            arquivo.Clear();
            titulosBL.ArquivoRemessaMontarTrailler(arquivo, "300", v_seq.ToString());
            sw.WriteLine(arquivo);


            sw.Close();
            lkbDownload.Visible = true;
            lkbDownload.Text = "remessa_" + ddlPortador.SelectedItem.Text.Replace(" ", "_") + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
            btnGerar.Visible = false;

        }
        
        protected void btnPesTitulo_Click(object sender, EventArgs e)
        {
            //CarregarPesquisaTitulos(null);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
        }

        protected void txtPesTitulo_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaTitulos(txtPesTitulo.Text);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
            txtPesTitulo.Text = "";
        }

        protected void btnSelectTit_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntTitulos"] != null)
                txtIntTitulos.Text = Session["IntTitulos"].ToString() + ",";

            txtIntTitulos.Text = txtIntTitulos.Text + gvrow.Cells[2].Text + " - " + gvrow.Cells[3].Text;
            Session["IntTitulos"] = txtIntTitulos.Text;
            pnlTitulos_ModalPopupExtender.Hide();
            pnlTitulos_ModalPopupExtender.Enabled = false;
        }

        protected void grdPesquisaTit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void lkbDownload_Click(object sender, EventArgs e)
        {
            utils. LeStreamReadPassaStreamWrite(Nomedoarquivo, Response.OutputStream, System.Text.Encoding.GetEncoding("UTF-8"));
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lkbDownload.Text);
            Response.ContentType = "text/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.Charset = "UTF-8";
            Response.End();
          
        }

        protected void btnPesTitulo_Click1(object sender, EventArgs e)
        {
            CarregarPesquisaTitulos(null);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
        }
       
    }
}