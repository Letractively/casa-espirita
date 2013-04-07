using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using FG;
using System.IO;

namespace FIBIESA
{
    public partial class cadInstituicao : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";
        string fileType = string.Empty;
        #region funcoes
        private void CarregarDados(int id_ins)
        {
            string[] v_pesquisa;
            InstituicoesBL insBL = new InstituicoesBL();
            List<Instituicoes> intituicoes = insBL.PesquisarBL(id_ins);

            foreach (Instituicoes ltIns in intituicoes)
            {
                hfId.Value = ltIns.Id.ToString();
                txtCodigo.Text = ltIns.Codigo.ToString();
                txtRazao.Text = ltIns.Razao;
                txtNomeFantasia.Text = ltIns.NomeFantasia.ToString();
                txtEmail.Text = ltIns.Email;
                txtCnpj.Text = ltIns.Cnpj;
                txtCep.Text = ltIns.Cep;
                txtEndereco.Text = ltIns.Endereco;
                txtNumero.Text = ltIns.Numero.ToString();
                txtComplemento.Text = ltIns.Complemento;
                txtDDD.Text = ltIns.DDD;
                txttelefone.Text = ltIns.telefone;

                hfIdCidade.Value = ltIns.CidadeId.ToString();
                if (utils.ComparaIntComZero(hfIdCidade.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoCidade(utils.ComparaIntComZero(hfIdCidade.Value));
                    txtCidade.Text = v_pesquisa[0];
                    lblDesCidade.Text = v_pesquisa[1];
                }

                hfIdBairro.Value = ltIns.BairroId.ToString();
                if (utils.ComparaIntComZero(hfIdBairro.Value) > 0)
                {
                    v_pesquisa = RetornarCodigoDecricaoBairro(utils.ComparaIntComZero(hfIdBairro.Value));
                    txtBairro.Text = v_pesquisa[0];
                    lblDesBairro.Text = v_pesquisa[1];
                }

            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtCidade.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtBairro.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtCep.Attributes.Add("onkeypress", "mascara(this,'00000-000')");
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
        private string[] RetornarCodigoDecricaoCidade(int id_cid)
        {
            string[] v_cidade = new string[2];
            CidadesBL cidBL = new CidadesBL();

            DataSet dsCid = cidBL.PesquisarBL(id_cid);

            if (dsCid.Tables[0].Rows.Count != 0)
            {               
                v_cidade[0] = Convert.ToString(dsCid.Tables[0].Rows[0]["codigo"]);
                v_cidade[1] = (string)dsCid.Tables[0].Rows[0]["descricao"];

            }

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
        private void SalvarImagem(bool bRetorno)
        {
            if (bRetorno)
            {
                InstituicoesLogoBL insLBL = new InstituicoesLogoBL();
                InstituicoesLogo instituicoesLogo = new InstituicoesLogo();
                byte[] imagemBytes = new byte[fupImgLogo.PostedFile.InputStream.Length + 1];
                fupImgLogo.PostedFile.InputStream.Read(imagemBytes, 0, imagemBytes.Length);

                instituicoesLogo.Id = utils.ComparaIntComZero(hfIdInstLogo.Value);
                instituicoesLogo.InstituicoesId = utils.ComparaIntComZero(hfId.Value);
                instituicoesLogo.Extensao = fileType;
                instituicoesLogo.Imagem = imagemBytes;

                if (instituicoesLogo.Id > 0)
                    insLBL.EditarBL(instituicoesLogo);
                else
                    insLBL.InserirBL(instituicoesLogo);
            }
            else
            { 
            }
        }
        private void VerificarImagem()
        {
            bool bRetorno = false;
            string extension = Path.GetExtension(fupImgLogo.PostedFile.FileName).ToLower();
            switch (extension)
            {
                case ".gif":
                    fileType = "gif";
                    bRetorno = true;
                    break;

                case ".jpg":
                    fileType = "jpg";
                    bRetorno = true;
                    break;
                case ".jpeg":
                    fileType = "jpeg";
                    bRetorno = true;
                    break;
                case ".png":
                    fileType = "png";
                    bRetorno = true;
                    break;

                default:
                   // lblMsg.text = "Tipo de arquivo inválido."
                    bRetorno = false;
                    break;
            }

            SalvarImagem(bRetorno);

        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_ins = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_ins"] != null)
                            id_ins = Convert.ToInt32(Request.QueryString["id_ins"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_ins);
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            InstituicoesBL insBL = new InstituicoesBL();
            Instituicoes instituicoes = new Instituicoes();

            instituicoes.Id = utils.ComparaIntComZero(hfId.Value);
            instituicoes.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            instituicoes.Razao = txtRazao.Text;
            instituicoes.NomeFantasia = txtNomeFantasia.Text;
            instituicoes.Email = txtEmail.Text;
            instituicoes.Cnpj = txtCnpj.Text;
            instituicoes.CidadeId = utils.ComparaIntComNull(hfIdCidade.Value);
            instituicoes.Cep = txtCep.Text;
            instituicoes.BairroId = utils.ComparaIntComNull(hfIdBairro.Value);
            instituicoes.Endereco = txtEndereco.Text;
            instituicoes.Numero = txtNumero.Text;
            instituicoes.Complemento = txtComplemento.Text;
            instituicoes.DDD = txtDDD.Text;
            instituicoes.telefone = txttelefone.Text;

            int idIns = 0;

            if (instituicoes.Id > 0)
            { 
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    idIns = instituicoes.Id;
                    insBL.EditarBL(instituicoes);
                    VerificarImagem();
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else            
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    insBL.InserirBL(instituicoes);
                    VerificarImagem();
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }

            Response.Redirect("~/viewInstituicao.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewInstituicao.aspx");
        }

        protected void btnPesCidade_Click(object sender, EventArgs e)
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

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = cidBL;
            Session["objPesquisa"] = ci;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCidade.ClientID + "&id=" + hfIdCidade.ClientID + "&lbl=" + lblDesCidade.ClientID + "','',600,500);", true);
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

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = baiBL;
            Session["objPesquisa"] = ba;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtBairro.ClientID + "&id=" + hfIdBairro.ClientID + "&lbl=" + lblDesBairro.ClientID + "','',600,500);", true);
        }

                
    }
}