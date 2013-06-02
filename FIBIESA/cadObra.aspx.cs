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

            ddlTipoObra.Items.Add(new ListItem("Selecione",""));
            foreach (TiposObras lttpOb in tiposObras)
                ddlTipoObra.Items.Add(new ListItem(lttpOb.Codigo + " - " + lttpOb.Descricao, lttpOb.Id.ToString()));

            ddlTipoObra.SelectedIndex = 0;
        }

        private void CarregarDdlEditora()
        {
            EditorasBL edBL = new EditorasBL();
            List<Editoras> editoras = edBL.PesquisarBL();

            ddlEditora.Items.Add(new ListItem("Selecione",""));
            foreach (Editoras ltEd in editoras)
                ddlEditora.Items.Add(new ListItem(ltEd.Codigo + " - " + ltEd.Descricao, ltEd.Id.ToString()));

            ddlEditora.SelectedIndex = 0;
        }        

        private void CarregarDados(int id_bai)
        {
            ObrasBL obraBL = new ObrasBL();
            DataSet dsOb = obraBL.PesquisarBL(id_bai);

            if (dsOb.Tables[0].Rows.Count != 0)
            {
                hfId.Value = (string)dsOb.Tables[0].Rows[0]["id"].ToString();
                lblCodigo.Text = (string)dsOb.Tables[0].Rows[0]["codigo"].ToString();
                txtTitulo.Text = (string)dsOb.Tables[0].Rows[0]["titulo"].ToString();
                txtISBN.Text = (string)dsOb.Tables[0].Rows[0]["isbn"].ToString();
                txtLocalPublic.Text = (string)dsOb.Tables[0].Rows[0]["localpublicacao"].ToString();
                txtNroEdicao.Text = (string)dsOb.Tables[0].Rows[0]["nroedicao"].ToString();
                txtNroPags.Text = (string)dsOb.Tables[0].Rows[0]["nropaginas"].ToString();
                txtVolume.Text = (string)dsOb.Tables[0].Rows[0]["volume"].ToString();
                txtDataReimpressao.Text = dsOb.Tables[0].Rows[0]["datareimpressao"].ToString() != string.Empty ? Convert.ToDateTime(dsOb.Tables[0].Rows[0]["datareimpressao"]).ToString("dd/MM/yyyy") : "";
                txtDataPublicacao.Text = dsOb.Tables[0].Rows[0]["datapublicacao"].ToString() != string.Empty ? Convert.ToDateTime(dsOb.Tables[0].Rows[0]["datapublicacao"]).ToString("dd/MM/yyyy") : "";
                txtAssuntosAborda.Text = (string)dsOb.Tables[0].Rows[0]["assuntosaborda"].ToString();
                ddlEditora.SelectedValue = (string)dsOb.Tables[0].Rows[0]["editoraid"].ToString();               
                ddlTipoObra.SelectedValue = (string)dsOb.Tables[0].Rows[0]["tiposobraid"].ToString();
                
            }           
        }

        private void CarregarAtributos()
        {   
            txtNroEdicao.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtNroPags.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtVolume.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtDataPublicacao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataReimpressao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");           
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            lblCodigo.Text = "Código gerado automaticamente.";
            txtTitulo.Text = "";
            txtVolume.Text = "";
            txtNroPags.Text = "";
            txtNroEdicao.Text = "";
            txtLocalPublic.Text = "";
            txtISBN.Text = "";
            txtDataReimpressao.Text = "";
            txtDataPublicacao.Text = "";
            txtAssuntosAborda.Text = "";
            ddlEditora.SelectedIndex = 0;
            ddlTipoObra.SelectedIndex = 0;
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

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_bai);
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtTitulo.Focus();
                
                    
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
            obras.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
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
            
            if (obras.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    if(obraBL.EditarBL(obras))
                        ExibirMensagem("Obra atualizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar a obra. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if(obraBL.InserirBL(obras))
                    {
                        ExibirMensagem("Obra gravada com sucesso !");
                        LimparCampos();
                        txtTitulo.Focus();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar a obra. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
        }
    }
}