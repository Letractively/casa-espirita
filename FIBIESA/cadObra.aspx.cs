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
        DataTable dtAutores = new DataTable();
        DataTable dtExcluidos = new DataTable();
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

            ddlTipoObra.Items.Add(new ListItem("Selecione", ""));
            foreach (TiposObras lttpOb in tiposObras)
                ddlTipoObra.Items.Add(new ListItem(lttpOb.Descricao, lttpOb.Id.ToString()));

            ddlTipoObra.SelectedIndex = 0;
        }
        private void CarregarDdlEditora()
        {
            EditorasBL edBL = new EditorasBL();
            List<Editoras> editoras = edBL.PesquisarBL();

            ddlEditora.Items.Add(new ListItem("Selecione", ""));
            foreach (Editoras ltEd in editoras)
                ddlEditora.Items.Add(new ListItem(ltEd.Descricao, ltEd.Id.ToString()));

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
                txtCdu.Text = (string)dsOb.Tables[0].Rows[0]["cdu"].ToString();

            }

            CarregarDadosAutores(id_bai);
        }
        private void CarregarAtributos()
        {
            txtNroEdicao.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtNroPags.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtVolume.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtDataPublicacao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataReimpressao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }
        private void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                    upnlPesquisa,
                                    this.GetType(),
                                    "Alert",
                                    "window.alert(\"" + mensagem + "\");",
                                    true);
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
            LimparCamposAutor();
            dtAutores = null;
            Session["dtAutores"] = dtAutores;
            dtgAutores.DataSource = dtAutores;
            dtgAutores.DataBind();
            tcPrincipal.ActiveTabIndex = 0;
            txtCdu.Text = "";
        }
        private void LimparCamposAutor()
        {
            txtAutor.Text = "";
            lblDesAutor.Text = "";            
            hfIdAutor.Value = "";
        }
        private void CriarDtItens()
        {
            DataColumn[] keys = new DataColumn[2];

            if (dtAutores.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("TIPO", Type.GetType("System.String"));
                DataColumn coluna5 = new DataColumn("AUTORESID", Type.GetType("System.Int32"));
                DataColumn coluna6 = new DataColumn("OBRAID", Type.GetType("System.Int32"));

                dtAutores.Columns.Add(coluna1);
                dtAutores.Columns.Add(coluna2);
                dtAutores.Columns.Add(coluna3);
                dtAutores.Columns.Add(coluna4);
                dtAutores.Columns.Add(coluna5);
                dtAutores.Columns.Add(coluna6);

                keys[0] = coluna5;
                keys[1] = coluna6;

                dtAutores.PrimaryKey = keys;
            }
        }
        private void CriaDtExcluidos()
        {
            if (dtExcluidos.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("IDCODIGO", Type.GetType("System.String"));
                DataColumn coluna2 = new DataColumn("TIPO", Type.GetType("System.String"));

                dtExcluidos.Columns.Add(coluna1);
                dtExcluidos.Columns.Add(coluna2);
            }
        }
        public void CarregarPesquisaAutor(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("TIPO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);

            AutoresBL autBL = new AutoresBL();
            Autores autores = new Autores();

            List<Autores> ltAutores = autBL.PesquisarBuscaBL(conteudo);

            foreach (Autores ltAut in ltAutores)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = ltAut.Id;
                linha["CODIGO"] = ltAut.Codigo;
                linha["NOME"] = ltAut.Descricao;
                linha["TIPO"] = ltAut.Descricao;

                if (ltAut.TiposDeAutores != null)
                    linha["TIPO"] = ltAut.TiposDeAutores.Descricao;

                dt.Rows.Add(linha);

            }

            grdPesquisaAutor.DataSource = dt;
            grdPesquisaAutor.DataBind();
        }
        private void ExcluirAutores()
        {
            ObrasAutoresBL obAutBL = new ObrasAutoresBL();
            ObrasAutores obAut = new ObrasAutores();

            if (Session["tbexcluidos"] != null)
            {
                dtExcluidos = (DataTable)Session["tbexcluidos"];
                foreach (DataRow row in dtExcluidos.Rows)
                {
                    switch (row["TIPO"].ToString().ToUpper())
                    {
                        case "A":
                            {
                                obAut.Id = utils.ComparaIntComZero(row["IDCODIGO"].ToString());
                                obAutBL.ExcluirBL(obAut);
                                break;
                            }
                    }
                }
            }

        }
        private bool AutorJaIncluido(DataTable dtTable, string id, string id_autor, string sessao)
        {
            object[] keys = new object[2];
            keys[0] = utils.ComparaIntComZero(id_autor);
            keys[1] = utils.ComparaIntComZero(id);

            if (Session[sessao] != null)
                dtTable = (DataTable)Session[sessao];

            if (dtTable.Rows.Contains(keys))
                return true;
            else
                return false;
        }
        private void CarregarDadosAutores(int id_obra)
        {
            ObrasAutoresBL obAutBL = new ObrasAutoresBL();
            List<ObrasAutores> obAut = obAutBL.PesquisarBL(id_obra);

            foreach (ObrasAutores ltObAut in obAut)
            {
                DataRow linha = dtAutores.NewRow();

                linha["ID"] = ltObAut.Id;
                linha["CODIGO"] = ltObAut.CodAutor;
                linha["AUTORESID"] = ltObAut.AutoresId;
                linha["DESCRICAO"] = ltObAut.Autor;
                linha["TIPO"] = ltObAut.TipoAutor;
                linha["OBRAID"] = ltObAut.ObraId;

                dtAutores.Rows.Add(linha);
            }

            dtbPesquisa = dtAutores;
            Session["dtAutores"] = dtAutores;
            dtgAutores.DataSource = dtAutores;
            dtgAutores.DataBind();

        }
        private void GravarAutores(int id_obra)
        {
            ObrasAutoresBL obAutBL = new ObrasAutoresBL();
            ObrasAutores obAut = new ObrasAutores();

            if (Session["dtAutores"] != null)
                dtAutores = (DataTable)Session["dtAutores"];

            foreach (DataRow linha in dtAutores.Rows)
            {
                obAut.Id = utils.ComparaIntComZero(linha["ID"].ToString());
                obAut.AutoresId = utils.ComparaIntComZero(linha["AUTORESID"].ToString());
                obAut.ObraId = id_obra;

                if (obAut.Id > 0)
                    obAutBL.EditarBL(obAut);
                else
                    obAutBL.InserirBL(obAut);
            }
        }
        private void PesquisarAutor(string autor)
        {
            AutoresBL autBl = new AutoresBL();
            List<Autores> autores = autBl.PesquisarBL("CODIGO", autor);
            string tipo = "";
            foreach (Autores ltAut in autores)
            {
                hfIdAutor.Value = ltAut.Id.ToString();
                txtAutor.Text = ltAut.Codigo.ToString();
                lblDesAutor.Text = ltAut.Descricao;
                if (ltAut.TiposDeAutores != null)
                    tipo = ltAut.TiposDeAutores.Descricao;
            }

            if (hfIdAutor.Value == null || hfIdAutor.Value == string.Empty)
            {
                LimparCamposAutor();
                ExibirMensagem("Autor não cadastrado !");
                txtAutor.Focus();
            }
            else
                txtAutor.Focus();

            if (Session["dtAutores"] != null)
                dtAutores = (DataTable)Session["dtAutores"];

            if (utils.ComparaIntComZero(hfIdAutor.Value) > 0)
            {
                if (!AutorJaIncluido(dtAutores, hfId.Value, hfIdAutor.Value, "dtAutores"))
                {
                    DataRow linha = dtAutores.NewRow();

                    linha["ID"] = 0;
                    linha["CODIGO"] = txtAutor.Text;
                    linha["DESCRICAO"] = lblDesAutor.Text;
                    linha["TIPO"] = tipo;
                    linha["AUTORESID"] = hfIdAutor.Value;
                    linha["OBRAID"] = utils.ComparaIntComZero(hfId.Value);

                    dtAutores.Rows.Add(linha);

                    dtbPesquisa = dtAutores;
                    Session["dtAutores"] = dtAutores;
                    dtgAutores.DataSource = dtAutores;
                    dtgAutores.DataBind();
                    LimparCamposAutor();
                }
                else
                {
                    ExibirMensagem("Autor já incluído !");
                    LimparCamposAutor();
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

            CarregarAtributos();
            CriarDtItens();
            CriaDtExcluidos();

            if (!IsPostBack)
            {
                Session["dtAutores"] = null;
                Session["tbexcluidos"] = null;
                hfOrdem.Value = "1";

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
            ObrasAutoresBL obAutBL = new ObrasAutoresBL();
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
            obras.Cdu = txtCdu.Text;                


            if (obras.Id > 0)
            {

                if (obraBL.EditarBL(obras))
                {
                    ExcluirAutores();
                    GravarAutores(obras.Id);
                    ExibirMensagem("Obra atualizada com sucesso !");
                }
            }
            else
            {
                int id_obra;
                id_obra = obraBL.InserirBL(obras);
                if (id_obra > 0)
                {
                    ExcluirAutores();
                    GravarAutores(id_obra);
                    ExibirMensagem("Obra gravada com sucesso !");
                    LimparCampos();
                    txtTitulo.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar a obra. Revise as informações.");

            }
        }

        protected void dtgAutores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgAutores.DataSource = dtbPesquisa;
            dtgAutores.PageIndex = e.NewPageIndex;
            dtgAutores.DataBind();
        }

        protected void dtgAutores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 0, e);
        }

        protected void dtgAutores_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (dtbPesquisa != null)
            {
                string ordem = e.SortExpression;

                DataView m_DataView = new DataView(dtbPesquisa);

                if (ViewState["dtbPesquisa_sort"] != null)
                {
                    if (ViewState["dtbPesquisa_sort"].ToString() == e.SortExpression)
                    {
                        m_DataView.Sort = ordem + " DESC";
                        ViewState["dtbPesquisa_sort"] = null;
                    }
                    else
                    {
                        m_DataView.Sort = ordem;
                        ViewState["dtbPesquisa_sort"] = e.SortExpression;
                    }
                }
                else
                {
                    m_DataView.Sort = ordem;
                    ViewState["dtbPesquisa_sort"] = e.SortExpression;
                }

                dtbPesquisa = m_DataView.ToTable();
                dtgAutores.DataSource = m_DataView;
                dtgAutores.DataBind();
            }
        }

        protected void btnAutor_Click(object sender, EventArgs e)
        {
            CarregarPesquisaAutor(null);
            ModalPopupExtenderPesAutor.Enabled = true;
            ModalPopupExtenderPesAutor.Show();
        }

        protected void txtPesAutor_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaAutor(txtPesAutor.Text);
            ModalPopupExtenderPesAutor.Enabled = true;
            ModalPopupExtenderPesAutor.Show();
            txtPesAutor.Text = "";
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            

        }

        protected void dtgAutores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object[] keys = new object[2];

            keys[0] = dtgAutores.DataKeys[e.RowIndex][0];
            keys[1] = dtgAutores.DataKeys[e.RowIndex][1];


            if (Session["dtAutores"] != null)
                dtAutores = (DataTable)Session["dtAutores"];

            DataRow linha = dtAutores.Rows.Find(keys);
            string id = linha["id"].ToString();

            if (dtAutores.Rows.Contains(keys))
                dtAutores.Rows.Remove(dtAutores.Rows.Find(keys));

            Session["dtAutores"] = dtAutores;
            dtgAutores.DataSource = dtAutores;
            dtgAutores.DataBind();

            if (utils.ComparaIntComZero(id) > 0)
            {
                if (Session["tbexcluidos"] != null)
                    dtExcluidos = (DataTable)Session["tbexcluidos"];

                DataRow row = dtExcluidos.NewRow();
                row["IDCODIGO"] = id;
                row["TIPO"] = "A";
                dtExcluidos.Rows.Add(row);
                Session["tbexcluidos"] = dtExcluidos;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            LimparCamposAutor();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            PesquisarAutor(gvrow.Cells[2].Text);
            
            ModalPopupExtenderPesAutor.Enabled = false;
            ModalPopupExtenderPesAutor.Hide();
            txtAutor.Focus();

        }

        protected void grdPesquisaAutor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesAutor.Enabled = false;
        }

        protected void txtAutor_TextChanged(object sender, EventArgs e)
        {
            PesquisarAutor(txtAutor.Text);
        }

    }
}