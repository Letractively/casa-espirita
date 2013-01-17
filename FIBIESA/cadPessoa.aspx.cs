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
        #endregion

        #region funcoes
        private void CarregarTabelaPesquisaCidade()
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

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

        private void PesquisarTelefones(int id_pes)
        {
            DataTable dt = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("DDD", Type.GetType("System.Int16"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("PESSOAID", Type.GetType("System.Int32"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);

            TelefonesBL telBL = new TelefonesBL();

            List<Telefones> telefones = telBL.PesquisarBL(id_pes);

            foreach (Telefones tel in telefones)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = tel.Id;
                linha["DDD"] = tel.Ddd;
                linha["DESCRICAO"] = tel.Descricao;
                linha["PESSOAID"] = tel.PessoaId;
            }

            dtgTelefones.DataSource = dt;
            dtgTelefones.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PesquisarTelefones();
            }

        }

        protected void btnPesCategoria_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

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
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

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

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if(Session["dtTelefone"] != null)
                dtTelefones = (DataTable)Session["dtTelefone"];

            DataRow linha = dtTelefones.NewRow(); 

            linha["DDD"] = 
            linha["NUMERO"] = txtTelefone.Text;
            linha["DESCRICAO"] = ddlTipo.SelectedValue;

            dtTelefones.Rows.Add(linha);

            Session["dtTelefone"] = dtTelefones;
            dtgTelefones.DataSource = dtgTelefones;
            dtgTelefones.DataBind();

            txtTelefone.Text = "";
            ddlTipo.SelectedIndex = 1;

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
            //pessoas.Codigo = 
            pessoas.Nome = txtNome.Text;
            pessoas.NomeFantasia = txtNomeFantasia.Text;
            pessoas.CategoriaId = utils.ComparaIntComZero(hfIdCategoria.Value);
            pessoas.CpfCnpj = txtCpfCnpj.Text;
            pessoas.Rg = txtRg.Text;
            pessoas.DtNascimento = utils.ComparaDataComNull(txtDataNascimento.Text);
            pessoas.EstadoCivil = ddlEstadoCivil.SelectedValue;
            pessoas.NomeMae = txtNomeMae.Text;
            pessoas.NomePai = txtNomePai.Text;
            pessoas.Naturalidade = utils.ComparaIntComZero(hfIdNaturalidade.Value);
            pessoas.CidadeId = utils.ComparaIntComZero(hfIdCidade.Value);
            pessoas.Cep = txtCep.Text;
            pessoas.Endereco = txtEndereco.Text;
            pessoas.Numero = txtNumero.Text;
            pessoas.BairroId = utils.ComparaIntComZero(hfIdBairro.Value);
            pessoas.Complemento = txtComplemento.Text;
            pessoas.Empresa = txtEmpresa.Text;
            pessoas.EnderecoProf = txtEnderecoProf.Text;
            pessoas.NumeroProf = txtNumeroProf.Text;
            pessoas.CidadeProfId = utils.ComparaIntComZero(hfIdCidProf.Value);
            pessoas.ComplementoProf = txtComplementoProf.Text;
            pessoas.BairroProf = utils.ComparaIntComZero(hfIdBairroProf.Value);
            pessoas.CepProf = txtCepProf.Text;
            pessoas.Obs = txtObservacao.Text;
            pessoas.DtCadastro = DateTime.Now;


            if (pessoas.Id > 0)
                pesBL.EditarBL(pessoas);
            else
                pesBL.InserirBL(pessoas);

            Response.Redirect("viewPessoa.aspx");
        }      
       
    }
}