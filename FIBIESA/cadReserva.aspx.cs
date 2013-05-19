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

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private int LerParametro(int codigo, string modulo)
        {
            ParametrosBL parBL = new ParametrosBL();
            DataSet dsPar = parBL.PesquisarBL(codigo, modulo);
            int valor = -1;

            if (dsPar.Tables[0].Rows.Count != 0)
                valor = utils.ComparaIntComZero(dsPar.Tables[0].Rows[0]["VALOR"].ToString());

            return valor;
        }

        //paineis modal
        public void CarregarPesquisaPessoa(string conteudo)
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
        public void CarregarPesquisaExemplar(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ExemplaresBL exBL = new ExemplaresBL(); 
            Exemplares ex = new Exemplares(); 
            List<Exemplares> listao = exBL.PesquisarDisponiveis(conteudo);

            foreach (Exemplares laco in listao)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = laco.Id;
                linha["CODIGO"] = laco.Tombo;
                linha["DESCRICAO"] = laco.Obras.Titulo;

                dt.Rows.Add(linha);
            }

            grdPesquisaEx.DataSource = dt;
            grdPesquisaEx.DataBind();
        }

        private void CarregaHistorico(int pessoaId)
        {
            EmprestimosBL emp = new EmprestimosBL();
            DataTable tabela = emp.BuscaHistorico(pessoaId);
            if (tabela.Rows.Count > 0)
            {
                dtgHistorico.DataSource = tabela;
                
            }
            else
                dtgHistorico.DataSource = null;
            dtgHistorico.DataBind();
           // pnlHistorico.Height = new Unit(pnlHistorico.Height.Value + 10);
            dtgHistorico.Visible = (tabela.Rows.Count > 0);
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
                    {
                        btnSalvar.Text = "Devolver";
                        btnRenovar.Visible = true;
                        if (Request.QueryString["id_emp"] != null)
                        {
                            id_emprestimo = Convert.ToInt32(Request.QueryString["id_emp"].ToString());
                            txtdataInicio.ReadOnly = true;
                            txtdataPrevisao.ReadOnly = true;
                            pnlHistorico.Visible = false;
                            txtdataInicio_CalendarExtender.Enabled = false;
                            txtdataPrevisao_CalendarExtender.Enabled = false;
                            txtPessoa.ReadOnly = true;
                            txtExemplar.ReadOnly = true;
                        }
                    }
                    else
                    {
                        //inserindo
                        txtdataInicio.ReadOnly = false;
                        txtdataPrevisao.ReadOnly = false;
                        pnlHistorico.Visible = true;
                        txtdataInicio_CalendarExtender.Enabled = true;
                        txtdataPrevisao_CalendarExtender.Enabled = true;
                        txtPessoa.ReadOnly = false;
                        txtExemplar.ReadOnly = false;

                        btnRenovar.Visible = false;
                        btnSalvar.Text = "Emprestar";
                        txtdataInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        int param = this.LerParametro(4, "B");
                        if (param > 0)
                        {
                            DateTime lol = DateTime.Now.AddDays(param);
                            txtdataPrevisao.Text = lol.ToString("dd/MM/yyyy");
                        }
                        dtgHistorico.Visible = false;

                    }
                }
                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_emprestimo);
            }
        }

        protected void btnPesPessoa_Click(object sender, EventArgs e)
        {
            v_operacao = Request.QueryString["operacao"];
            if (v_operacao != "edit")
            {
                CarregarPesquisaPessoa(null);
                ModalPopupExtenderPessoas.Enabled = true;
                ModalPopupExtenderPessoas.Show();
            }
        }

        protected void btnExemplar_Click(object sender, EventArgs e)
        {
            v_operacao = Request.QueryString["operacao"];
            if (v_operacao != "edit")
            {
                CarregarPesquisaExemplar(null);
                ModalPopupExtenderExemplares.Enabled = true;
                ModalPopupExtenderExemplares.Show();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();

            emp.Id = utils.ComparaIntComZero(hfId.Value);
            
            emp.ExemplarId = utils.ComparaIntComZero(hfIdExemplar.Value);
            emp.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);


            if (emp.Id > 0)
            { //editando == devolvendo
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    empBL.EditarBL(emp);
                    //editar a movimentacao
                    EmprestimoMovBL emovBL = new EmprestimoMovBL();
                    EmprestimoMov mov = empBL.CarregaEmpNaoDevolvido(emp.Id);
                    if (mov.Id > 0)
                    {
                        mov.DataDevolucao = DateTime.Now;
                        //mov.DataEmprestimo = Convert.ToDateTime(txtdataInicio.Text);
                        //mov.DataPrevistaEmprestimo = Convert.ToDateTime(txtdataPrevisao.Text);
                        emovBL.EditarBL(mov);
                    }
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            else
            { //inserindo == emprestando
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {

                    //Quantidade máxima de exemplares emprestado:
                    int param = this.LerParametro(1, "B");
                    if (param >= 0)
                    {
                        if (empBL.QuantosLivrosEmprestados(emp.PessoaId) > param)
                        {
                            
                            ExibirMensagem(lblDesPessoa.Text + " já atingiu o limite máximo de empréstimos simultâneos.");                            
                            txtPessoa.Focus();
                            return; //                            throw new Exception(); //tem um jeito melhor de sair do metodo?
                        }
                    }

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

        protected void btnRenovar_Click(object sender, EventArgs e)
        {
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();

            emp.Id = utils.ComparaIntComZero(hfId.Value);


            //Quantidade máxima de renovações:
            int param = this.LerParametro(2, "B");
            if (param >= 0)
            {
                if (empBL.QtdRenovacoes(emp.Id) > param)
                {
                    ExibirMensagem("Este exemplar não pode mais ser renovado para esta pessoa!");
                    txtExemplar.Focus();
                    return;  //throw new Exception(); //tem um jeito melhor de sair do metodo?
                }
            }

            //chegou aqui? vamos renovar!
            //renovar consiste em editar o atual e setar a data de devolucao, e inserir um novo
            EmprestimoMovBL emovBL = new EmprestimoMovBL();
            EmprestimoMov mov = empBL.CarregaEmpNaoDevolvido(emp.Id);
            if (mov.Id > 0)
            {
                mov.DataDevolucao = DateTime.Now;
                emovBL.EditarBL(mov);
                mov = new EmprestimoMov();
                mov.EmprestimoId = emp.Id;
                mov.DataEmprestimo = DateTime.Now;  
                param = this.LerParametro(4, "B");
                DateTime lol = DateTime.Now;
                if (param > 0)
                    lol =  DateTime.Now.AddDays(param);
                mov.DataPrevistaEmprestimo = lol; 
                mov.DataDevolucao = null;
                emovBL.InserirBL(mov);
            }
            Response.Redirect("viewReserva.aspx");
        }

        #region Modal pessoas
        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(txtPesquisa.Text);
            ModalPopupExtenderPessoas.Enabled = true;
            ModalPopupExtenderPessoas.Show();
            txtPesquisa.Text = string.Empty;
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPessoas.Enabled = false;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtPessoa.Text = gvrow.Cells[2].Text;
            lblDesPessoa.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPessoas.Enabled = false;
            ModalPopupExtenderPessoas.Hide();

            //carrega emprestimos ativos da pessoa selecionada
            CarregaHistorico(int.Parse(grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString()));
        }
        
        protected void txtPessoa_TextChanged(object sender, EventArgs e)
        {
            hfIdPessoa.Value = "";
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO", txtPessoa.Text);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdPessoa.Value = ltpessoa.Id.ToString();
                txtPessoa.Text = ltpessoa.Codigo.ToString();
                lblDesPessoa.Text = ltpessoa.Nome;
                txtExemplar.Focus();
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Cliente não cadastrado !");
                txtPessoa.Text = "";
                lblDesPessoa.Text = "";
                txtPessoa.Focus();
            }
        }
        #endregion

        #region Modal Exemplares
        protected void txtPesquisaEx_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaExemplar(txtPesquisaEx.Text);
            ModalPopupExtenderExemplares.Enabled = true;
            ModalPopupExtenderExemplares.Show();
            txtPesquisaEx.Text = string.Empty;
        }

        protected void grdPesquisaEx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCancelEx_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderExemplares.Enabled = false;
        }

        protected void txtExemplar_TextChanged(object sender, EventArgs e)
        {
            hfIdExemplar.Value = string.Empty;
            ExemplaresBL exBL = new ExemplaresBL();
            Exemplares ex = new Exemplares();
            List<Exemplares> listao = exBL.PesquisarBL("ID", txtExemplar.Text);
            foreach (Exemplares laco in listao)
            {
                hfIdExemplar.Value = laco.Id.ToString();
                txtExemplar.Text = laco.Id.ToString();
                lblDesExemplar.Text = laco.Obras.Titulo;
            }

            if (utils.ComparaIntComZero(hfIdExemplar.Value) < 1)
            {
                ExibirMensagem("Exemplar não cadastrado!");
                txtExemplar.Text = string.Empty;
                lblDesExemplar.Text = string.Empty;
                txtExemplar.Focus();
            }

        }

        protected void btnSelectEx_Click(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdExemplar.Value = grdPesquisaEx.DataKeys[gvrow.RowIndex].Value.ToString();
            txtExemplar.Text = gvrow.Cells[1].Text;
            lblDesExemplar.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderExemplares.Enabled = false;
            ModalPopupExtenderExemplares.Hide();
        }
        #endregion

        protected void txtdataInicio_TextChanged(object sender, EventArgs e)
        {
            DateTime data;
            if (DateTime.TryParse(txtdataInicio.Text, out data))
            {
                int param = this.LerParametro(4, "B");
                DateTime lol = data;
                if (param > 0)
                    lol = data.AddDays(param);
                txtdataPrevisao.Text = lol.ToString("dd/MM/yyyy");
            }
        }

        protected void dtgHistorico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

       
    }
}