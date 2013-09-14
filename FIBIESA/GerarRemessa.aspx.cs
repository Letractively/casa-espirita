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
        public string Nomedoarquivo
        {
            get { return ViewState["nomedoarquivo"].ToString(); }
            set { ViewState["nomedoarquivo"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDdlInstrucao(ddlInstrucao1);
                CarregarDdlInstrucao(ddlInstrucao2);
                CarregarDdlPortador();
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //CarregarPesquisa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
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

            TitulosBL titulosBL = new TitulosBL();
            List<Titulos> titulos = titulosBL.PesquisarBuscaBL("R",null);

            StringBuilder arquivo = new StringBuilder(); 

            foreach (Titulos ltTit in titulos)
            {
                titulosBL.ArquivoRemessaMontarHeader(arquivo, ltTit);
                sw.WriteLine(arquivo);

                titulosBL.ArquivoRemessaMontarTransacao(arquivo, ltTit, remessa);
                sw.WriteLine(arquivo);

                titulosBL.ArquivoRemessaMontarHeader(arquivo, ltTit);
                sw.WriteLine(arquivo);
            }
            
            sw.Close();
            lkbDownload.Visible = true;
            lkbDownload.Text = "remessa_" + ddlPortador.SelectedItem.Text.Replace(" ", "_") + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
            btnGerar.Visible = false;

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            //if (Session["IntClientes"] != null)
            //    txtIntClientes.Text = Session["IntClientes"].ToString() + ",";

            //txtIntClientes.Text = txtIntClientes.Text + gvrow.Cells[2].Text;
            //Session["IntClientes"] = txtIntClientes.Text;
            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void btnPesTitulo_Click(object sender, EventArgs e)
        {
            //CarregarPesquisaTitulos(null);
            pnlTitulos_ModalPopupExtender.Enabled = true;
            pnlTitulos_ModalPopupExtender.Show();
        }

        protected void txtPesTitulo_TextChanged(object sender, EventArgs e)
        {
           // CarregarPesquisaTitulos(txtPesquisa.Text);
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

       
    }
}