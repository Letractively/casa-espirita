using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;


namespace Admin
{
    public partial class cadObra : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadObras"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadObras"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadObras"] = value; }
        }

        private void CarregarDdlTiposObra()
        {
            TiposObrasBL tpObBL = new TiposObrasBL();
            List<TiposObras> tiposObras = tpObBL.PesquisarBL();

            ddlTipoObra.Items.Add(new ListItem());
            foreach (TiposObras lttpOb in tiposObras)
                ddlTipoObra.Items.Add(new ListItem(lttpOb.Codigo + " - " + lttpOb.Descricao, lttpOb.Id.ToString()));

            ddlTipoObra.SelectedIndex = 0;
        }

        private void CarregarDdlEditora()
        {
            EditorasBL edBL = new EditorasBL();
            List<Editoras> editoras = edBL.PesquisarBL();

            ddlEditora.Items.Add(new ListItem());
            foreach (Editoras ltEd in editoras)
                ddlEditora.Items.Add(new ListItem(ltEd.Codigo + " - " + ltEd.Descricao, ltEd.Id.ToString()));

            ddlEditora.SelectedIndex = 0;
        }

        private void CarregarDdlOrigem()
        {
            OrigensBL oriBL = new OrigensBL();
            List<Origens> origens = oriBL.PesquisarBL();

            ddlOrigem.Items.Add(new ListItem());
            foreach (Origens ltOri in origens)
                ddlOrigem.Items.Add(new ListItem(ltOri.Codigo + " - " + ltOri.Descricao, ltOri.Id.ToString()));

            ddlOrigem.SelectedIndex = 0;
        }

        private void CarregarDados(int id_bai)
        {
            ObrasBL obraBL = new ObrasBL();
            List<Obras> obras = obraBL.PesquisarBL(id_bai);

            foreach (Obras ltObra in obras)
            {
                hfId.Value = ltObra.Id.ToString();
                txtCodigo.Text = ltObra.Codigo.ToString();
                txtTitulo.Text = ltObra.Titulo;
                txtISBN.Text = ltObra.Isbn.ToString();
                txtLocalPublic.Text = ltObra.LocalPublicacao.ToString();
                txtNroEdicao.Text = ltObra.NroEdicao.ToString();
                txtNroPags.Text = ltObra.NroPaginas.ToString();
                txtVolume.Text = ltObra.Volume.ToString();
                txtDataReimpressao.Text = ltObra.DataReimpressao != null? Convert.ToDateTime(ltObra.DataReimpressao).ToString("dd/MM/yyyy") : "";
                txtDataPublicacao.Text = ltObra.DataPublicacao != null ? Convert.ToDateTime(ltObra.DataPublicacao).ToString("dd/MM/yyyy") : "";
                txtAssuntosAborda.Text = ltObra.AssuntosAborda.ToString();
                ddlEditora.SelectedValue = ltObra.EditoraId.ToString();
                ddlOrigem.SelectedValue = ltObra.OrigemId.ToString();
                ddlTipoObra.SelectedValue = ltObra.TiposObraId.ToString();
                
            }

        }


        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_bai"] != null)
                            id_bai = Convert.ToInt32(Request.QueryString["id_bai"].ToString());
                }

                CarregarDdlEditora();
                CarregarDdlTiposObra();
                CarregarDdlOrigem();

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_bai);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewObra.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            ObrasBL obraBL = new ObrasBL();
            Obras obras = new Obras();
            obras.Id = utils.ComparaIntComZero(hfId.Value);
            obras.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            obras.Titulo = txtTitulo.Text;
            obras.NroEdicao = utils.ComparaIntComNull(txtNroEdicao.Text);
            obras.EditoraId = utils.ComparaIntComNull(ddlEditora.SelectedValue);
            obras.NroPaginas = utils.ComparaIntComNull(txtNroPags.Text);
            obras.Volume = utils.ComparaIntComNull(txtVolume.Text);
            obras.Isbn = txtISBN.Text;
            obras.AssuntosAborda = txtAssuntosAborda.Text;
            obras.DataPublicacao = utils.ComparaDataComNull(txtDataPublicacao.Text);
            obras.DataReimpressao = utils.ComparaDataComNull(txtDataReimpressao.Text);
            obras.TiposObraId = utils.ComparaIntComNull(ddlTipoObra.SelectedValue);
            obras.LocalPublicacao = txtLocalPublic.Text;
            obras.OrigemId = utils.ComparaIntComNull(ddlOrigem.SelectedValue);


            if (obras.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    obraBL.EditarBL(obras);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    obraBL.InserirBL(obras);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewObra.aspx");
        }

      
        
    }
}