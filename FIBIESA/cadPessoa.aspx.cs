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


namespace Admin
{
    public partial class cadPessoa : System.Web.UI.Page
    {
        #region variaveis
        Utils utils = new Utils();
        DataTable dtExcluidos = new DataTable();
        DataTable dtFone = new DataTable();
        string v_operacao = "";
        #endregion

        #region funcoes
        private void CarregarDDLCategoria()
        {
            CategoriasBL catBL = new CategoriasBL();
            List<Categorias> categorias = catBL.PesquisarBL();

            ddlCategoria.Items.Add(new ListItem("Selecione", ""));
            foreach (Categorias ltCat in categorias)
                ddlCategoria.Items.Add(new ListItem(ltCat.Descricao, ltCat.Id.ToString()));

            ddlCategoria.SelectedIndex = 0;
        }
        private void CarregarDdlUF(DropDownList ddl)
        {
            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            ddl.Items.Add(new ListItem("Selecione", ""));
            foreach (Estados ltUF in estados)
                ddl.Items.Add(new ListItem(ltUF.Uf + " - " + ltUF.Descricao, ltUF.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlCidade(DropDownList ddl, int id_uf)
        {
            CidadesBL cidBL = new CidadesBL();
            List<Cidades> cidades = cidBL.PesquisaCidUfDA(id_uf);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Selecione", ""));
            foreach (Cidades ltCid in cidades)
                ddl.Items.Add(new ListItem(ltCid.Descricao, ltCid.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlBairro(DropDownList ddl, int id_cid)
        {
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarCidBL(id_cid);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Selecione", ""));
            foreach (Bairros ltBai in bairros)
                ddl.Items.Add(new ListItem(ltBai.Descricao, ltBai.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDadosPessoas(int id_pes)
        {
            string[] v_pesquisa;
            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pessoas = pesBL.PesquisarBL(id_pes);

            foreach (Pessoas pes in pessoas)
            {
                hfId.Value = pes.Id.ToString();
                lblCodigo.Text = pes.Codigo.ToString();
                txtNome.Text = pes.Nome;

                if (pes.NomeFantasia.Trim() != "")
                    txtNome.Text = pes.NomeFantasia;

                txtCpfCnpj.Text = pes.CpfCnpj;
                txtRg.Text = pes.Rg;
                txtDataNascimento.Text = pes.DtNascimento != null ? Convert.ToDateTime(pes.DtNascimento).ToString("dd/MM/yyyy") : "";
                ddlEstadoCivil.SelectedValue = pes.EstadoCivil;
                txtNomeMae.Text = pes.NomeMae;
                txtNomePai.Text = pes.NomePai;
                txtCep.Text = pes.Cep;
                txtEndereco.Text = pes.Endereco;
                txtNumero.Text = pes.Numero;
                txtComplemento.Text = pes.Complemento;
                txtEmpresa.Text = pes.Empresa;
                txtEnderecoProf.Text = pes.EnderecoProf;
                txtNumeroProf.Text = pes.NumeroProf;
                txtComplementoProf.Text = pes.ComplementoProf;
                txtCepProf.Text = pes.CepProf;
                txtObservacao.Text = pes.Obs;
                txtDtCadastro.Text = pes.DtCadastro.ToString("dd/MM/yyyy");
                ddlSexo.SelectedValue = pes.Sexo;
                txtEmail.Text = pes.Email;
                rbTipoAssoc.SelectedValue = pes.TipoAssociado.ToString();
                txtRefNome.Text = pes.RefNome.ToString();
                txtRefTelefone.Text = pes.RefTelefone.ToString();

                if (pes.Cidade != null)
                {
                    ddlUF.SelectedValue = pes.Cidade.EstadoId.ToString();
                    CarregarDdlCidade(ddlCidades, pes.Cidade.EstadoId);
                    CarregarDdlBairro(ddlBairro, pes.CidadeId);
                    ddlCidades.SelectedValue = pes.CidadeId.ToString();
                    ddlBairro.SelectedValue = pes.BairroId.ToString();
                }

                if (pes.CidadeProf != null)
                {
                    ddlUfProf.SelectedValue = pes.CidadeProf.EstadoId.ToString();
                    CarregarDdlCidade(ddlCidadeProf, pes.CidadeProf.EstadoId);
                    CarregarDdlBairro(ddlBairroProf, utils.ComparaIntComZero(pes.CidadeProfId.ToString()));
                    ddlCidadeProf.SelectedValue = pes.CidadeProfId.ToString();
                    ddlBairroProf.SelectedValue = pes.BairroProf.ToString();
                }

                ddlCategoria.SelectedValue = pes.CategoriaId.ToString();

                if (pes.Tipo == "F")
                {
                    lblDesNome.Text = "* Nome";
                }
                else
                {
                    lblDesNome.Text = "* Nome Fantasia";
                }

            }

        }
        private void CarregarTabelaPesquisaCidade()
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();

            CidadesBL cidBL = new CidadesBL();
            Cidades ci = new Cidades();
            List<Cidades> cidades = cidBL.PesquisarBL();

            foreach (Cidades cid in cidades)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cid.Id;
                linha["CODIGO"] = cid.Codigo;
                linha["DESCRICAO"] = cid.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = cidBL;
            Session["objPesquisa"] = ci;
        }
        private void CarregarDadosTelefones(int id_pes)
        {
            int ordem = 0;

            TelefonesBL telBL = new TelefonesBL();
            List<Telefones> telefones = telBL.PesquisarBL(id_pes);

            foreach (Telefones tel in telefones)
            {
                ordem++;
                DataRow linha = dtFone.NewRow();

                linha["IDORDEM"] = ordem;
                linha["ID"] = tel.Id;
                linha["DESCRICAO"] = tel.Descricao;
                linha["NUMERO"] = tel.Numero;

                dtFone.Rows.Add(linha);
            }

            Session["tbfone"] = dtFone;
            dtgTelefones.DataSource = dtFone;
            dtgTelefones.DataBind();
            ordem++;
            hfOrdemFone.Value = ordem.ToString(); //proxima ordem 

        }
        private string[] RetornarCodigoDecricaoCidade(int id_cid)
        {
            string[] v_cidade = new string[2];
            CidadesBL cidBL = new CidadesBL();

            DataSet dsCid = cidBL.PesquisarBL(id_cid);

            if (dsCid.Tables[0].Rows.Count != 0)
            {
                v_cidade[0] = (string)dsCid.Tables[0].Rows[0]["codigo"].ToString();
                v_cidade[1] = (string)dsCid.Tables[0].Rows[0]["descricao"];

            }

            return v_cidade;
        }
        private string[] RetornarCodigoDecricaoBairro(int id_bai)
        {
            string[] v_bairro = new string[2];
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarBL(id_bai);

            if (bairros.Count > 0)
            {
                v_bairro[0] = bairros[0].Codigo.ToString();
                v_bairro[1] = bairros[0].Descricao;
            }

            return v_bairro;
        }
        private void CriaTabFone()
        {
            DataColumn[] keys = new DataColumn[1];

            if (dtFone.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("IDORDEM", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("ID", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("NUMERO", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

                dtFone.Columns.Add(coluna1);
                dtFone.Columns.Add(coluna2);
                dtFone.Columns.Add(coluna3);
                dtFone.Columns.Add(coluna4);

                keys[0] = coluna1;

                dtFone.PrimaryKey = keys;
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
        private DataTable CriarDtPesquisa()
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
        private void CarregarAtributos()
        {
            txtDtCadastro.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataNascimento.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtNumero.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtNumeroProf.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtTelefone.Attributes.Add("onkeypress", "mascara(this,'(00)0000-0000')");
            txtRefTelefone.Attributes.Add("onkeypress", "mascara(this,'(00)0000-0000')");
            txtCep.Attributes.Add("onkeypress", "mascara(this,'00000-000')");
            txtCepProf.Attributes.Add("onkeypress", "mascara(this,'00000-000')");
        }
        private void GravarTelefones(int idPes)
        {
            TelefonesBL telBL = new TelefonesBL();
            Telefones telefones = new Telefones();

            if (Session["tbfone"] != null)
                dtFone = (DataTable)Session["tbfone"];

            foreach (DataRow linha in dtFone.Rows)
            {
                telefones.Id = utils.ComparaIntComZero(linha["ID"].ToString());
                telefones.Numero = linha["NUMERO"].ToString();
                telefones.Descricao = linha["DESCRICAO"].ToString();
                telefones.PessoaId = idPes;

                if (telefones.Id > 0)
                    telBL.EditarBL(telefones);
                else
                    telBL.InserirBL(telefones);
            }
        }
        private void ExcluirTelefones()
        {
            TelefonesBL telBL = new TelefonesBL();
            Telefones telefones = new Telefones();

            if (Session["tbexcluidos"] != null)
            {
                dtExcluidos = (DataTable)Session["tbexcluidos"];
                foreach (DataRow row in dtExcluidos.Rows)
                {
                    switch (row["TIPO"].ToString().ToUpper())
                    {
                        case "T": //telefones
                            {
                                telefones.Id = utils.ComparaIntComZero(row["IDCODIGO"].ToString());
                                telBL.ExcluirBL(telefones);
                                break;
                            }
                    }
                }
            }

        }
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        private void LimparCampos()
        {
            hfId.Value = "";
            hfIdTelefone.Value = "";
            hfOrdemFone.Value = "";
            txtCep.Text = "";
            txtCepProf.Text = "";
            txtComplemento.Text = "";
            txtComplementoProf.Text = "";
            txtCpfCnpj.Text = "";
            txtDataNascimento.Text = "";
            txtDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEmail.Text = "";
            txtEmpresa.Text = "";
            txtEndereco.Text = "";
            txtEnderecoProf.Text = "";
            txtNome.Text = "";
            txtNomeMae.Text = "";
            txtNomePai.Text = "";
            txtNumero.Text = "";
            txtNumeroProf.Text = "";
            txtObservacao.Text = "";
            txtRefNome.Text = "";
            txtRefTelefone.Text = "";
            txtRg.Text = "";
            txtTelefone.Text = "";
            dtExcluidos.Clear();
            dtFone.Clear();
            dtgTelefones.DataSource = dtFone;
            dtgTelefones.DataBind();
            lblCodigo.Text = "Código gerado automaticamente.";
            lblDesNome.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlEstadoCivil.SelectedIndex = 0;
            ddlBairro.SelectedIndex = -1;
            ddlCidades.SelectedIndex = -1;
            ddlUF.SelectedIndex = 0;
            ddlBairroProf.SelectedIndex = -1;
            ddlCidadeProf.SelectedIndex = -1;
            ddlUfProf.SelectedIndex = 0;


            if (Request.QueryString["tipoPessoa"] != null)
            {
                if (Request.QueryString["tipoPessoa"].ToString() == "F")
                {
                    lblDesNome.Text = "* Nome";
                }
                else
                {
                    lblDesNome.Text = "* Nome Fantasia";
                }

            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_pes = 0;
            CarregarAtributos();
            this.CriaTabFone();
            this.CriaDtExcluidos();

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];
                    dtExcluidos.Clear();
                    dtFone.Clear();
                    Session["tbexcluidos"] = null;
                    Session["tbfone"] = null;

                    if (v_operacao == "edit")
                    {
                        if (Request.QueryString["id_pes"] != null)
                            id_pes = Convert.ToInt32(Request.QueryString["id_pes"].ToString());
                    }
                    else
                    {
                        lblCodigo.Text = "Código gerado automaticamente.";
                        if (Request.QueryString["tipoPessoa"] != null)
                        {
                            if (Request.QueryString["tipoPessoa"].ToString() == "F")
                            {
                                lblDesNome.Text = "* Nome";
                            }
                            else
                            {
                                lblDesNome.Text = "* Nome Fantasia";
                            }

                        }
                    }
                }


                txtDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

                CarregarDDLCategoria();
                CarregarDdlUF(ddlUF);
                CarregarDdlUF(ddlUfProf);

                if (v_operacao.ToLower() == "edit")
                {
                    CarregarDadosPessoas(id_pes);
                    CarregarDadosTelefones(id_pes);
                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewPessoa.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoas = new Pessoas();

            pessoas.Id = utils.ComparaIntComZero(hfId.Value);
            pessoas.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            pessoas.Nome = txtNome.Text;

            pessoas.CategoriaId = utils.ComparaIntComZero(ddlCategoria.SelectedValue);
            pessoas.CpfCnpj = txtCpfCnpj.Text;
            pessoas.Rg = txtRg.Text;
            pessoas.DtNascimento = utils.ComparaDataComNull(txtDataNascimento.Text);
            pessoas.EstadoCivil = ddlEstadoCivil.SelectedValue;
            pessoas.NomeMae = txtNomeMae.Text;
            pessoas.NomePai = txtNomePai.Text;
            pessoas.CidadeId = utils.ComparaIntComZero(ddlCidades.SelectedValue);
            pessoas.Cep = txtCep.Text;
            pessoas.Endereco = txtEndereco.Text;
            pessoas.Numero = txtNumero.Text;
            pessoas.BairroId = utils.ComparaIntComZero(ddlBairro.SelectedValue);
            pessoas.Complemento = txtComplemento.Text;
            pessoas.Empresa = txtEmpresa.Text;
            pessoas.EnderecoProf = txtEnderecoProf.Text;
            pessoas.NumeroProf = txtNumeroProf.Text;
            pessoas.CidadeProfId = utils.ComparaIntComNull(ddlCidadeProf.SelectedValue);
            pessoas.ComplementoProf = txtComplementoProf.Text;
            pessoas.BairroProf = utils.ComparaIntComNull(ddlBairroProf.SelectedValue);
            pessoas.CepProf = txtCepProf.Text;
            pessoas.Obs = txtObservacao.Text;
            pessoas.DtCadastro = DateTime.Now;
            pessoas.Sexo = ddlSexo.SelectedValue;
            pessoas.Email = txtEmail.Text;
            pessoas.TipoAssociado = rbTipoAssoc.SelectedValue;
            pessoas.RefNome = txtRefNome.Text;
            pessoas.RefTelefone = txtRefTelefone.Text;

            if (lblDesNome.Text == "* Nome")
                pessoas.Tipo = "F";
            else
                pessoas.Tipo = "J";

            int idPes = 0;

            if (pessoas.Id > 0)
            {
                idPes = pessoas.Id;
                if (pesBL.EditarBL(pessoas))
                {
                    ExcluirTelefones();
                    GravarTelefones(idPes);
                    ExibirMensagem("Pessoa atualizada com sucesso !");
                }
                else
                    ExibirMensagem("Não foi possível atualizar a pessoa. Revise as informações.");
            }
            else
            {
                idPes = pesBL.InserirBL(pessoas);
                ExcluirTelefones();
                GravarTelefones(idPes);
                if (idPes > 0)
                {
                    ExibirMensagem("Pessoa gravada com sucesso !");
                    LimparCampos();
                }
                else
                    ExibirMensagem("Não foi possível gravar a pessoa. Revise as informações.");

            }

            tcPessoa.ActiveTabIndex = 0;

        }

        protected void btnInserirTelefone_Click(object sender, EventArgs e)
        {
            if (Session["tbfone"] != null)
                dtFone = (DataTable)Session["tbfone"];

            DataRow linha = dtFone.NewRow();

            object key = new object();
            key = utils.ComparaIntComZero(hfOrdemFone.Value);

            linha["IDORDEM"] = key.ToString();
            linha["ID"] = utils.ComparaIntComZero(hfIdTelefone.ToString());
            linha["NUMERO"] = txtTelefone.Text;
            linha["DESCRICAO"] = ddlTipo.SelectedValue;

            dtFone.Rows.Add(linha);

            Session["tbfone"] = dtFone;
            dtgTelefones.DataSource = dtFone;
            dtgTelefones.DataBind();
            txtTelefone.Text = "";
            ddlTipo.SelectedIndex = 0;

            hfOrdemFone.Value = (utils.ComparaIntComZero(hfOrdemFone.Value) + 1).ToString(); //proxima ordem  

        }

        protected void dtgTelefones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object key = new object();
            object key2 = new object();
            key = dtgTelefones.DataKeys[e.RowIndex][0];
            key2 = dtgTelefones.DataKeys[e.RowIndex][1];

            if (Session["tbfone"] != null)
                dtFone = (DataTable)Session["tbfone"];

            if (dtFone.Rows.Contains(key))
                dtFone.Rows.Remove(dtFone.Rows.Find(key));

            Session["tbfone"] = dtFone;
            dtgTelefones.DataSource = dtFone;
            dtgTelefones.DataBind();

            if (utils.ComparaIntComZero(key2.ToString()) > 0)
            {
                if (Session["tbexcluidos"] != null)
                    dtExcluidos = (DataTable)Session["tbexcluidos"];

                DataRow row = dtExcluidos.NewRow();
                row["IDCODIGO"] = key2.ToString();
                row["TIPO"] = "T";
                dtExcluidos.Rows.Add(row);
                Session["tbexcluidos"] = dtExcluidos;
            }

        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlCidade(ddlCidades, utils.ComparaIntComZero(ddlUF.SelectedValue));
            ddlBairro.Items.Clear();
            ddlCidades.Focus();
        }

        protected void ddlCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlBairro(ddlBairro, utils.ComparaIntComZero(ddlCidades.SelectedValue));
            ddlBairro.Focus();
        }

        protected void dtgTelefones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void ddlUfProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlCidade(ddlCidadeProf, utils.ComparaIntComZero(ddlUfProf.SelectedValue));
            ddlCidadeProf.Focus();
        }

        protected void ddlCidadeProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlBairro(ddlBairroProf, utils.ComparaIntComZero(ddlCidadeProf.SelectedValue));
            ddlBairroProf.Focus();
        }




    }
}