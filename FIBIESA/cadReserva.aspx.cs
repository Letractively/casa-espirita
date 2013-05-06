using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using BusinessLayer;
using DataObjects;

namespace Admin
{
    public partial class cadReserva : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";
        #region funcoes
        private void CarregarAtributos()
        {
            txtdataInicio.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtdataPrevisao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtExemplar.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtPessoa.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
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
        private void CarregarDados(int id_usu)
        {
            EmprestimosBL empBL = new EmprestimosBL();
            List<Emprestimos> lista = empBL.PesquisarBL(id_usu);

            foreach (Emprestimos laco in lista)
            {
                hfId.Value = laco.Id.ToString();
                hfIdPessoa.Value = laco.PessoaId.ToString();
                hfIdExemplar.Value = laco.ExemplarId.ToString();
                txtExemplar.Text = laco.ExemplarId.ToString();
                txtPessoa.Text = laco.PessoaId.ToString();

                EmprestimoMov oi = empBL.CarregaEmpNaoDevolvido(laco.Id);
                if (oi.Id > 0)
                {
                    txtdataInicio.Text = oi.DataEmprestimo.ToString("dd/MM/yyyy");
                    txtdataPrevisao.Text = oi.DataPrevistaEmprestimo.ToString("dd/MM/yyyy");
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_emprestimo = 0;
            CarregarAtributos();
            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];
                    if (v_operacao == "edit")
                        if (Request.QueryString["id_emp"] != null)
                            id_emprestimo = Convert.ToInt32(Request.QueryString["id_emp"].ToString());
                }
                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_emprestimo);
            }
        }

        protected void btnPesPessoa_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }
            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(),
                Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" 
                + txtPessoa.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesPessoa.ClientID + "','',600,500);", true);

        }

        protected void btnExemplar_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            ExemplaresBL exBL = new ExemplaresBL();
            Exemplares exx = new Exemplares();
            List<Exemplares> listao = exBL.PesquisarBL();

            foreach (Exemplares laco in listao)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = laco.Id;
                linha["CODIGO"] = laco.Obras.Codigo;
                linha["DESCRICAO"] = laco.Obras.Titulo;

                dt.Rows.Add(linha);
            }
            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            Session["objBLPesquisa"] = exBL;
            Session["objPesquisa"] = exx;

            ScriptManager.RegisterStartupScript(this, this.GetType(),
                Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa="
                + txtExemplar.ClientID + "&id=" + hfIdExemplar.ClientID + "&lbl=" + lblDesExemplar.ClientID + "','',600,500);", true);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();

            emp.Id = utils.ComparaIntComZero(hfId.Value);
            
            emp.ExemplarId = utils.ComparaIntComZero(hfIdExemplar.Value);
            emp.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);

            if (emp.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    empBL.EditarBL(emp);
                    //editar a movimentacao
                    EmprestimoMovBL emovBL = new EmprestimoMovBL();
                    EmprestimoMov mov = empBL.CarregaEmpNaoDevolvido(emp.Id);
                    mov.DataDevolucao = null;
                    mov.DataEmprestimo = Convert.ToDateTime(txtdataInicio.Text);
                    mov.DataPrevistaEmprestimo = Convert.ToDateTime(txtdataPrevisao.Text);
                    emovBL.EditarBL(mov);

                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    int meuid = empBL.InserirBL(emp); 
                    //inserir a movimentacao
                    EmprestimoMovBL emovBL = new EmprestimoMovBL();
                    EmprestimoMov mov = new EmprestimoMov();
                    mov.EmprestimoId = meuid;
                    mov.DataDevolucao = null;
                    mov.DataEmprestimo = Convert.ToDateTime(txtdataInicio.Text);
                    mov.DataPrevistaEmprestimo = Convert.ToDateTime(txtdataPrevisao.Text);
                    emovBL.InserirBL(mov);
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
        

            // usuarios.DtInicio = Convert.ToDateTime(txtDtInicio.Text);
            Response.Redirect("viewReserva.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewReserva.aspx");
        }
    }
}