using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class cadDoacao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void CarregarAtributos()
        {
            txtValor.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        public void LimparCampos()
        {
            txtCliente.Text = "";
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtValor.Text = "";
        }

        public void CarregarPesquisaItem(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();

            if (!IsPostBack)
            {
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CarregarPesquisaItem(null);
            }
        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);
           // ModalPopupExtenderPesquisa.Show();            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewDoacao.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DoacoesBL doaBL = new DoacoesBL();
            Doacoes doacoes = new Doacoes();

            doacoes.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
            doacoes.Valor = utils.ComparaDecimalComZero(txtValor.Text);
            doacoes.Data = Convert.ToDateTime(txtData.Text);

            if (Session["usuario"] != null)
            {
                List<Usuarios> usuarios = (List<Usuarios>)Session["usuario"];
                foreach (Usuarios ltUsu in usuarios)
                    doacoes.UsuarioId = ltUsu.Id;

            }

            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {
                if(doaBL.InserirBL(doacoes))
                {
                    ExibirMensagem("Doação gravada com sucesso!");
                    LimparCampos();
                }
                else
                    ExibirMensagem("Não foi possível gravar a doação.");
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            
        }
               
        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

             
        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisa.Text);
        }
                              
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();            
            txtCliente.Text = gvrow.Cells[2].Text;            
            lblDesCliente.Text = gvrow.Cells[3].Text;            
            //ModalPopupExtenderPesquisa.Hide();
                       
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           //ModalPopupExtenderPesquisa.Hide();
        }       


    }
}