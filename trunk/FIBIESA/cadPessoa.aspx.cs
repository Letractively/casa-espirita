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
        DataTable dtTelefones = new DataTable();
        DataTable dtExcluidos = new DataTable();
        string v_operacao = "";
        private bool inserir = false;
        private bool excluir = false;
        private bool editar = false;
        #endregion

        #region funcoes
        private void CarregarDadosPessoas(int id_pes)
        {
            string[] v_pesquisa;
            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pessoas = pesBL.PesquisarBL(id_pes);

            foreach (Pessoas pes in pessoas)
            {
                hfId.Value = pes.Id.ToString();
                txtCodigo.Text = pes.Codigo.ToString();
                txtNome.Text = pes.Nome;
                txtNomeFantasia.Text = pes.NomeFantasia;                
                txtCpfCnpj.Text =  pes.CpfCnpj;
                txtRg.Text = pes.Rg;
                txtDataNascimento.Text =  pes.DtNascimento.ToString();
                ddlEstadoCivil.SelectedValue =  pes.EstadoCivil;
                txtNomeMae.Text =  pes.NomeMae;
                txtNomePai.Text = pes.NomePai;                
                txtCep.Text = pes.Cep;
                txtEndereco.Text =  pes.Endereco;
                txtNumero.Text = pes.Numero;                
                txtComplemento.Text = pes.Complemento;
                txtEmpresa.Text = pes.Empresa;
                txtEnderecoProf.Text = pes.EnderecoProf;
                txtNumeroProf.Text = pes.NumeroProf;                
                txtComplementoProf.Text = pes.ComplementoProf;                
                txtCepProf.Text = pes.CepProf;
                txtObservacao.Text = pes.Obs;
                txtDtCadastro.Text = pes.DtCadastro.ToString();
                               
                hfIdCidade.Value = pes.CidadeId.ToString();
                if (utils.ComparaIntComZero(hfIdCidade.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoCidade(utils.ComparaIntComZero(hfIdCidade.Value));
                    txtCidade.Text = v_pesquisa[0];
                    lblDesCidade.Text = v_pesquisa[1];
                }

                hfIdNaturalidade.Value = pes.Naturalidade.ToString();
                if (utils.ComparaIntComZero(hfIdNaturalidade.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoCidade(utils.ComparaIntComZero(hfIdNaturalidade.Value));
                    txtNaturalidade.Text = v_pesquisa[0];
                    lblDesNaturalidade.Text = v_pesquisa[1];
                }

                hfIdCidProf.Value = pes.CidadeProfId.ToString();
                if (utils.ComparaIntComZero(hfIdCidProf.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoCidade(utils.ComparaIntComZero(hfIdCidProf.Value));
                    txtCidadeProf.Text = v_pesquisa[0];
                    lblDesCidProf.Text = v_pesquisa[1];
                }
                
                hfIdBairro.Value = pes.BairroId.ToString();
                if (utils.ComparaIntComZero(hfIdBairro.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoBairro(utils.ComparaIntComZero(hfIdBairro.Value));
                    txtBairro.Text = v_pesquisa[0];
                    lblDesBairro.Text = v_pesquisa[1];
                }
                
                hfIdBairroProf.Value = pes.BairroProf.ToString();
                if (utils.ComparaIntComZero(hfIdBairroProf.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoBairro(utils.ComparaIntComZero(hfIdBairroProf.Value));
                    txtBairroProf.Text = v_pesquisa[0];
                    lblDesBairroProf.Text = v_pesquisa[1];
                }

                hfIdCategoria.Value = pes.CategoriaId.ToString();
                if (utils.ComparaIntComZero(hfIdCategoria.Value) > 0)
                {
                    CategoriasBL catBL = new CategoriasBL();
                    List<Categorias> categorias = catBL.PesquisarBL(utils.ComparaIntComZero(hfIdCategoria.Value));
                                        
                    txtCategoria.Text = categorias[0].Codigo.ToString();
                    lblDesCategoria.Text = categorias[0].Descricao;
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
            DataTable dt = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));           
            DataColumn coluna2 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("PESSOAID", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("NUMERO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);
            dt.Columns.Add(coluna5);
            
            TelefonesBL telBL = new TelefonesBL();

            List<Telefones> telefones = telBL.PesquisarBL(id_pes);

            foreach (Telefones tel in telefones)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = tel.Id;                
                linha["DESCRICAO"] = tel.Descricao;
                linha["PESSOAID"] = tel.PessoaId;
                linha["CODIGO"] = tel.Codigo;
                linha["NUMERO"] = tel.Numero;

                dt.Rows.Add(linha);
            }
            
            dtgTelefones.DataSource = dt;
            dtgTelefones.DataBind();
            hfCodTel.Value = telBL.RetornarMaxCodigoBL().ToString();
                           
        }
        private void CarregarPermissoes()
        {
            if (Session["usuPermissoes"] != null)
            {
                Permissoes permissoes = (Permissoes)Session["usuPermissoes"];
                inserir = permissoes.Inserir;
                excluir = permissoes.Excluir;
                editar = permissoes.Editar;
            }
        }
        private string[] RetornarCodigoDecricaoCidade(int id_cid)
        {
            string[] v_cidade = new string[2];
            CidadesBL cidBL = new CidadesBL();
            List<Cidades> cidades =  cidBL.PesquisarBL(id_cid);

            v_cidade[0] = cidades[0].Codigo.ToString();
            v_cidade[1] = cidades[0].Descricao;		 
	        
            return v_cidade;
        }
        private string[] RetornarCodigoDecricaoBairro(int id_bai)
        {
            string[] v_bairro = new string[2];
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarBL(id_bai);

            v_bairro[0] = bairros[0].Codigo.ToString();
            v_bairro[1] = bairros[0].Descricao;
           
            return v_bairro;
        }
        private void CriarDtTelefones()
        {  
            if (dtTelefones.Columns.Count == 0)
            {
                DataColumn[] keys = new DataColumn[1];
                DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("CODIGO",Type.GetType("System.Int32"));                
                DataColumn coluna3 = new DataColumn("NUMERO", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

                dtTelefones.Columns.Add(coluna1);
                dtTelefones.Columns.Add(coluna2);
                dtTelefones.Columns.Add(coluna3);
                dtTelefones.Columns.Add(coluna4);
                keys[0] = coluna2;                        

                dtTelefones.PrimaryKey = keys;
            }
        }
        private void CriaDtExcluidos()
        {
            if (dtExcluidos.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
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
            txtCategoria.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtNaturalidade.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtCidade.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtCidadeProf.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtBairro.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtBairroProf.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtNumero.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtNumeroProf.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtTelefone.Attributes.Add("onkeypress", "mascara(this,'(00)0000-0000')");
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        private void GravarTelefones(int idPes)
        {
            TelefonesBL telBL = new TelefonesBL();
            Telefones telefones = new Telefones();

            if (Session["dtTelefone"] != null)
                dtTelefones = (DataTable)Session["dtTelefone"];

            foreach (DataRow linha in dtTelefones.Rows)
            {
                telefones.Id = utils.ComparaIntComZero(linha["ID"].ToString());
                telefones.Codigo = utils.ComparaIntComZero(linha["CODIGO"].ToString());
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
                                telefones.Id = utils.ComparaIntComZero(row["ID"].ToString());
                                telBL.ExcluirBL(telefones);
                                break;
                            }  
                    }
                }
            }
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_pes = 0;           
            CarregarAtributos();
            CriarDtTelefones();
            CriaDtExcluidos();
            
            if (!IsPostBack)
            {                
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_pes"] != null)
                            id_pes = Convert.ToInt32(Request.QueryString["id_pes"].ToString());
                }

                txtDtCadastro.Text = DateTime.Now.ToString();

                if (v_operacao.ToLower() == "edit")
                {
                    CarregarDadosPessoas(id_pes);
                    CarregarDadosTelefones(id_pes);
                }
            }

        }

        protected void btnPesCategoria_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            
            CategoriasBL catBL = new CategoriasBL();
            Categorias ca = new Categorias();
            List<Categorias> categorias = catBL.PesquisarBL();

            foreach (Categorias cat in categorias)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = catBL;
            Session["objPesquisa"] = ca;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCategoria.ClientID + "&id=" + hfIdCategoria.ClientID + "&lbl=" + lblDesCategoria.ClientID + "','',600,500);", true);
        }

        protected void btnPesBairro_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            
            BairrosBL baiBL = new BairrosBL();
            Bairros ba = new Bairros();
            List<Bairros> bairros = baiBL.PesquisarBL();

            foreach (Bairros cat in bairros)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = baiBL;
            Session["objPesquisa"] = ba;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtBairro.ClientID + "&id=" + hfIdBairro.ClientID + "&lbl=" + lblDesBairro.ClientID + "','',600,500);", true);
        }

        protected void btnPesNaturalidade_Click(object sender, EventArgs e)
        {
            CarregarTabelaPesquisaCidade();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtNaturalidade.ClientID + "&id=" + hfIdNaturalidade.ClientID + "&lbl=" + lblDesNaturalidade.ClientID + "','',600,500);", true);
        }

        protected void btnPesCidade_Click(object sender, EventArgs e)
        {
            CarregarTabelaPesquisaCidade();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCidade.ClientID + "&id=" + hfIdCidade.ClientID + "&lbl=" + lblDesCidade.ClientID + "','',600,500);", true);
        }

        protected void btnPesCidProf_Click(object sender, EventArgs e)
        {
            CarregarTabelaPesquisaCidade();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCidadeProf.ClientID + "&id=" + hfIdCidProf.ClientID + "&lbl=" + lblDesCidProf.ClientID + "','',600,500);", true);
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
            pessoas.Codigo = utils.ComparaIntComZero(txtCodigo.Text); 
            pessoas.Nome = txtNome.Text;
            pessoas.NomeFantasia = txtNomeFantasia.Text;
            pessoas.CategoriaId = utils.ComparaIntComZero(hfIdCategoria.Value);
            pessoas.CpfCnpj = txtCpfCnpj.Text;
            pessoas.Rg = txtRg.Text;
            pessoas.DtNascimento = utils.ComparaDataComNull(txtDataNascimento.Text);
            pessoas.EstadoCivil = ddlEstadoCivil.SelectedValue;
            pessoas.NomeMae = txtNomeMae.Text;
            pessoas.NomePai = txtNomePai.Text;
            pessoas.Naturalidade = utils.ComparaIntComNull(hfIdNaturalidade.Value);
            pessoas.CidadeId = utils.ComparaIntComZero(hfIdCidade.Value);
            pessoas.Cep = txtCep.Text;
            pessoas.Endereco = txtEndereco.Text;
            pessoas.Numero = txtNumero.Text;
            pessoas.BairroId = utils.ComparaIntComZero(hfIdBairro.Value);
            pessoas.Complemento = txtComplemento.Text;
            pessoas.Empresa = txtEmpresa.Text;
            pessoas.EnderecoProf = txtEnderecoProf.Text;
            pessoas.NumeroProf = txtNumeroProf.Text;
            pessoas.CidadeProfId = utils.ComparaIntComNull(hfIdCidProf.Value);
            pessoas.ComplementoProf = txtComplementoProf.Text;
            pessoas.BairroProf = utils.ComparaIntComNull(hfIdBairroProf.Value);
            pessoas.CepProf = txtCepProf.Text;
            pessoas.Obs = txtObservacao.Text;
            pessoas.DtCadastro = DateTime.Now;

            int idPes = 0;

            if (pessoas.Id > 0)
            {                
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    idPes = pessoas.Id;
                    pesBL.EditarBL(pessoas);
                    ExcluirTelefones();
                    GravarTelefones(idPes);
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
                
            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    idPes = pesBL.InserirBL(pessoas);
                    ExcluirTelefones();
                    GravarTelefones(idPes);
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
                
            
            Response.Redirect("viewPessoa.aspx");
        }

        protected void btnInserirTelefone_Click(object sender, EventArgs e)
        {
            bool altera = false;
            int codigo = 0;
            TelefonesBL telBL = new TelefonesBL();

            if (Session["dtTelefone"] != null)
                dtTelefones = (DataTable)Session["dtTelefone"];

            DataRow linha = dtTelefones.NewRow();

            if (hfCodTelAlt.Value != "")
                codigo = utils.ComparaIntComZero(hfCodTelAlt.Value);
            else
                codigo = utils.ComparaIntComZero(hfCodTel.Value);
                   
            
            if (dtTelefones.Rows.Contains(codigo))
            {
                linha = dtTelefones.Rows.Find(codigo);
                linha.BeginEdit();
                altera = true;
            }
            else
                altera = false;

            linha["ID"] = utils.ComparaIntComZero(hfIdTelefone.ToString());
            linha["CODIGO"] = codigo.ToString();          
            linha["NUMERO"] = txtTelefone.Text;
            linha["DESCRICAO"] = ddlTipo.SelectedValue;

            if (altera)
                linha.EndEdit();
            else
                dtTelefones.Rows.Add(linha);

            Session["dtTelefone"] = dtTelefones;
            dtgTelefones.DataSource = dtTelefones;
            dtgTelefones.DataBind();

            txtTelefone.Text = "";         
            ddlTipo.SelectedIndex = 0;
            hfCodTel.Value = (utils.ComparaIntComZero(hfCodTel.Value) + 1).ToString();

            if (utils.ComparaIntComZero(hfIdTelefone.Value) > 0)
            {
                if (Session["tbexcluidos"] != null)
                    dtExcluidos = (DataTable)Session["tbexcluidos"];

                DataRow row = dtExcluidos.NewRow();
                row["ID"] = hfIdTelefone.Value;
                row["TIPO"] = "T";
                dtExcluidos.Rows.Add(row);
                Session["tbexcluidos"] = dtExcluidos;
            }
        }

        protected void dtgTelefones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dtgTelefones.SelectedRow;

            hfCodTelAlt.Value = dtgTelefones.SelectedDataKey[0].ToString();
            hfIdTelefone.Value = row.Cells[1].Text;
            ddlTipo.SelectedValue = row.Cells[3].Text;          
            txtTelefone.Text = row.Cells[4].Text;          
        }

        protected void dtgTelefones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = 0;
            codigo = utils.ComparaIntComZero(dtgTelefones.DataKeys[e.RowIndex][0].ToString());

            if (Session["dtTelefone"] != null)
                dtTelefones = (DataTable)Session["dtTelefone"];

            if (dtTelefones.Rows.Contains(codigo))
                dtTelefones.Rows.Remove(dtTelefones.Rows.Find(codigo));

            Session["dtTelefone"] = dtTelefones;
            dtgTelefones.DataSource = dtTelefones;
            dtgTelefones.DataBind();
          
        }

                            
    }
}