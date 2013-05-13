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
                txttelefone.Text = ltIns.telefone;
                txtRanking.Text = ltIns.Ranking.ToString();

                if (ltIns.Cidades != null)
                {
                    ddlUF.SelectedValue = ltIns.Cidades.EstadoId.ToString();
                    CarregarDdlCidade(ddlCidades, ltIns.Cidades.EstadoId);
                    CarregarDdlBairro(ddlBairro, ltIns.CidadeId != null ? Convert.ToInt32(ltIns.CidadeId.ToString()) : 0);
                    ddlCidades.SelectedValue = ltIns.CidadeId.ToString();
                    ddlBairro.SelectedValue = ltIns.BairroId.ToString();
                }               
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");         
            txtCep.Attributes.Add("onkeypress", "mascara(this,'00000-000')");
            txttelefone.Attributes.Add("onkeypress", "mascara(this,'(00)0000-0000')");
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
        private void CarregarDdlUF(DropDownList ddl)
        {
            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            ddl.Items.Add(new ListItem());
            foreach (Estados ltUF in estados)
                ddl.Items.Add(new ListItem(ltUF.Uf + " - " + ltUF.Descricao, ltUF.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlCidade(DropDownList ddl, int id_uf)
        {
            CidadesBL cidBL = new CidadesBL();
            List<Cidades> cidades = cidBL.PesquisaCidUfDA(id_uf);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem());
            foreach (Cidades ltCid in cidades)
                ddl.Items.Add(new ListItem(ltCid.Codigo + " - " + ltCid.Descricao, ltCid.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlBairro(DropDownList ddl, int id_cid)
        {
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarCidBL(id_cid);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem());
            foreach (Bairros ltBai in bairros)
                ddl.Items.Add(new ListItem(ltBai.Codigo + " - " + ltBai.Descricao, ltBai.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtComplemento.Text = "";
            txtCnpj.Text = "";
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtNomeFantasia.Text = "";
            txtRazao.Text = "";
            txtNumero.Text = "";
            txtEmail.Text = "";
            ddlUF.SelectedIndex = -1;
            ddlCidades.SelectedIndex = -1;
            ddlBairro.SelectedIndex = -1;
            txttelefone.Text = "";
            txtRanking.Text = "";
        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_ins = 0;
            
            if (!IsPostBack)
            {
                CarregarAtributos();

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_ins"] != null)
                            id_ins = Convert.ToInt32(Request.QueryString["id_ins"].ToString());
                }

                CarregarDdlUF(ddlUF);

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_ins);

                txtCodigo.Focus();
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
            instituicoes.CidadeId = utils.ComparaIntComNull(ddlCidades.SelectedValue);
            instituicoes.Cep = txtCep.Text;
            instituicoes.BairroId = utils.ComparaIntComNull(ddlBairro.SelectedValue);
            instituicoes.Endereco = txtEndereco.Text;
            instituicoes.Numero = txtNumero.Text;
            instituicoes.Complemento = txtComplemento.Text;            
            instituicoes.telefone = txttelefone.Text;
            instituicoes.Ranking = utils.ComparaIntComZero(txtRanking.Text);

            int idIns = 0;

            if (instituicoes.Id > 0)
            { 
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    idIns = instituicoes.Id;

                    if (insBL.EditarBL(instituicoes))
                    {
                        VerificarImagem();
                        ExibirMensagem("Instituição atualizada com sucesso !");
                    }
                    else
                        ExibirMensagem("Não foi possível atualizar a instituição. Revise as informações.");
                    
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else            
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    if (insBL.InserirBL(instituicoes))
                    {
                        VerificarImagem();
                        ExibirMensagem("Instituição gravada com sucesso !");
                        LimparCampos();
                    }                                     
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewInstituicao.aspx");
        }
        
        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlCidade(ddlCidades, utils.ComparaIntComZero(ddlUF.SelectedValue));
            ddlBairro.Items.Clear();
        }

        protected void ddlCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlBairro(ddlBairro, utils.ComparaIntComZero(ddlCidades.SelectedValue));
        }

                
    }
}