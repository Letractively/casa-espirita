using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class cadCirculacaoLivros : System.Web.UI.Page
    {
        Utils utils = new Utils();
        DataTable dtItensEmp = new DataTable();
        DataTable dtItensDev = new DataTable();

        #region funcoes
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

        private DataTable CriarDtItensEmp()
        {
            if (dtItensEmp.Rows.Count <= 0)
            {
                DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("DEVOLUCAO", Type.GetType("System.String"));

                dtItensEmp.Columns.Add(coluna1);
                dtItensEmp.Columns.Add(coluna2);
                dtItensEmp.Columns.Add(coluna3);
                dtItensEmp.Columns.Add(coluna4);
            }

            return dtItensEmp;
        }

        private DataTable CriarDtItensDev()
        {
            DataColumn[] keys = new DataColumn[1];

            if (dtItensDev.Rows.Count <= 0)
            {
                DataColumn coluna1 = new DataColumn("MOVID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("ID", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
                DataColumn coluna4 = new DataColumn("TITULO", Type.GetType("System.String"));
                DataColumn coluna5 = new DataColumn("DEVOLUCAO", Type.GetType("System.String"));
                DataColumn coluna6 = new DataColumn("SITUACAO", Type.GetType("System.String"));

                dtItensDev.Columns.Add(coluna1);
                dtItensDev.Columns.Add(coluna2);
                dtItensDev.Columns.Add(coluna3);
                dtItensDev.Columns.Add(coluna4);
                dtItensDev.Columns.Add(coluna5);
                dtItensDev.Columns.Add(coluna6);

                keys[0] = coluna1;

                dtItensDev.PrimaryKey = keys;
            }

            return dtItensDev;
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
                      
            ItensEstoqueBL itemBl = new ItensEstoqueBL();
            ItensEstoque item = new ItensEstoque();

            List<ItensEstoque> lItens = itemBl.PesquisarBuscaBL(conteudo);

            foreach (ItensEstoque pes in lItens)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Obra;
                linha["DESCRICAO"] = pes.Obra.Titulo;

                dt.Rows.Add(linha);
            }


            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
        }

        public void CarregarPesquisaItemEmp(string tombo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ExemplaresBL exeBL = new ExemplaresBL();
            Exemplares exemplares = new Exemplares();
            List<Exemplares> ltExe = exeBL.PesquisarDisponiveis(tombo);

            foreach (Exemplares exemp in ltExe)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = exemp.Id;
                linha["CODIGO"] = exemp.Tombo;
                linha["DESCRICAO"] = exemp.Obras.Titulo;

                dt.Rows.Add(linha);
                
            }
                                  
            grdPesquisaEmp.DataSource = dt;
            grdPesquisaEmp.DataBind();
        }

        public void CarregarPesquisaCliente(string conteudo)
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

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void PesquisarEmprestimosAtivo(Int32 id_pessoa)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("EMPRESTIMOID", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("RENOVAR", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("SITUACAO", Type.GetType("System.String"));
            DataColumn coluna7 = new DataColumn("DEVOLUCAO", Type.GetType("System.String"));
            DataColumn coluna8 = new DataColumn("QTDDIAS", Type.GetType("System.String"));



            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);

            EmprestimoMovBL empMovBL = new EmprestimoMovBL();
            List<EmprestimoMov> empMov;

            empMov = empMovBL.PesquisarMovAtivosDA(id_pessoa);

            foreach (EmprestimoMov ltEmpMov in empMov)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltEmpMov.Id;
                linha["EMPRESTIMOID"] = ltEmpMov.EmprestimoId;
                linha["SITUACAO"] = ltEmpMov.Situacao;
                linha["DEVOLUCAO"] = ltEmpMov.DataPrevistaEmprestimo != null ? Convert.ToDateTime(ltEmpMov.DataPrevistaEmprestimo).ToString("dd/MM/yyyy") : "";
                linha["QTDDIAS"] = ltEmpMov.QtdeDias;

                if (ltEmpMov.Obras != null)
                    linha["TITULO"] = ltEmpMov.Obras.Titulo;
                else
                    linha["TITULO"] = "";

                if (ltEmpMov.Exemplares != null)
                    linha["TOMBO"] = ltEmpMov.Exemplares.Tombo;
                else
                    linha["TOMBO"] = 0;

                if (ltEmpMov.Situacao == "Emprestado")
                    linha["RENOVAR"] = "Sim";
                else
                    linha["RENOVAR"] = "Não";

                if (empMovBL.RetornaSituacaoTitulo((int)ltEmpMov.EmprestimoId) != null)
                    linha["RENOVAR"] = "Não";

                tabela.Rows.Add(linha);
            }

            dtgExemplar.DataSource = tabela;
            dtgExemplar.DataBind();
        }

        private void PesquisarCliente(string cod_cliente)
        {
            hfIdPessoa.Value = "";
            string situacao = null;
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO", cod_cliente);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdPessoa.Value = ltpessoa.Id.ToString();
                txtCliente.Text = ltpessoa.Codigo.ToString();
                lblDesCliente.Text = ltpessoa.Nome;
                lblClienteItens.Text = ltpessoa.Nome;
                lblCategoria.Text = ltpessoa.Categorias.Descricao;
                
                situacao = pesBL.VerificaSituacaoPessoa(utils.ComparaIntComZero(hfIdPessoa.Value),true,true);
                
                if (situacao != null && situacao != string.Empty)
                    LblSituacao.Text = situacao;                
                else
                    LblSituacao.Text = "OK";

                PesquisarEmprestimosAtivo(utils.ComparaIntComZero(hfIdPessoa.Value));
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Cliente não cadastrado !");
                txtCliente.Text = "";
                lblDesCliente.Text = "";
                txtCliente.Focus();
            }
        }

        private void PesquisarExemplar(string cod_exemplar)
        {
            hfIdItem.Value = "";
            ExemplaresBL exeBL = new ExemplaresBL();
            Exemplares exemplares = new Exemplares();
            DataSet dsExe = exeBL.PesquisarExemplaresEmprestimo(cod_exemplar);

            if (dsExe.Tables[0].Rows.Count != 0)
            {
                hfIdItem.Value = (string)dsExe.Tables[0].Rows[0]["id"].ToString();
                lblCodBarras.Text = "11222";
                lblDesExemplar.Text = (string)dsExe.Tables[0].Rows[0]["titulo"].ToString();

                if ((string)dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"].ToString() == ""
                    || (string)dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"].ToString() == null)
                {
                    lblSituacaoItem.Text = "Disponível";
                    lblPrevDevolucao.Text = "";
                    IncluirExemplarEmprestimo(dsExe);
                }
                else
                {
                    lblSituacaoItem.Text = "Emprestado";
                    lblPrevDevolucao.Text = ((DateTime)(dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"])).ToString("dd/MM/yyyy");
                }
            }

            if (utils.ComparaIntComZero(hfIdItem.Value) <= 0)
            {
                ExibirMensagem("Item não cadastrado !");
                LimparCamposEmprestimo();
                txtExemplar.Focus();
            }
        }

        private void PesquisarExemplarDev(string cod_exemplar)
        {
            ExemplaresBL exeBL = new ExemplaresBL();
            Exemplares exemplares = new Exemplares();
            DataSet dsExe = exeBL.PesquisarExemplaresDevolucao(cod_exemplar);

            if (dsExe.Tables[0].Rows.Count != 0)
            {
                lblExemplarDev.Text = (string)dsExe.Tables[0].Rows[0]["TITULO"].ToString();
                lblClienteDev.Text = (string)dsExe.Tables[0].Rows[0]["NOME"].ToString();
                lblSitDev.Text = "";

                IncluirExemplarDevolucao(dsExe);
            }
            else
            {
                dsExe = exeBL.PesquisarExemplaresEmprestimo(cod_exemplar);
                if (dsExe.Tables[0].Rows.Count != 0)
                {
                    if ((string)dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"].ToString() == ""
                    || (string)dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"].ToString() == null)
                    {
                        lblSitDev.Text = "Disponível";

                    }

                    lblExemplarDev.Text = (string)dsExe.Tables[0].Rows[0]["TITULO"].ToString();
                    txtExemplarDev.Focus();
                }
                else
                    ExibirMensagem("Exemplar não cadastrado !");
            }

        }

        private void LimparCamposEmprestimo()
        {
            hfIdItem.Value = "";
            lblDesExemplar.Text = "";
            lblSituacaoItem.Text = "";
            lblCodBarras.Text = "";
            lblPrevDevolucao.Text = "";
            lblClienteItens.Text = "";
            txtExemplar.Text = "";
            lblDesExemplar.Text = "";
            chkReciboEmprestimo.Checked = false;
            Session["dtItensEmp"] = null;
            dtgItens.DataSource = null;
            dtgItens.DataBind();
        }

        private void LimparCamposRenovacao()
        {
            hfIdPessoa.Value = "";
            txtCliente.Text = "";
            lblDesCliente.Text = "";
            lblCategoria.Text = "";
            LblSituacao.Text = "";
            chkReciboRenovacao.Checked = false;
            dtgExemplar.DataSource = null;
            dtgExemplar.DataBind();
        }

        private void LimparCamposDevolucao()
        {
            txtExemplarDev.Text = "";
            lblExemplarDev.Text = "";
            lblSitDev.Text = "";
            lblClienteDev.Text = "";
            chkReciboDevolucao.Checked = false;
            dtgExemplarDev.DataSource = null;
            dtgExemplarDev.DataBind();
        }

        private void IncluirExemplarEmprestimo(DataSet dsExe)
        {
            if (Session["dtItensEmp"] != null)
                dtItensEmp = (DataTable)Session["dtItensEmp"];

            if (dsExe.Tables[0].Rows.Count != 0)
            {
                DataRow linha = dtItensEmp.NewRow();

                linha["ID"] = dsExe.Tables[0].Rows[0]["id"].ToString();
                linha["TOMBO"] = dsExe.Tables[0].Rows[0]["tombo"].ToString();
                linha["TITULO"] = dsExe.Tables[0].Rows[0]["titulo"].ToString();
                linha["DEVOLUCAO"] = DateTime.Now.AddDays((Int16)dsExe.Tables[0].Rows[0]["QTDDIAS"]).ToString("dd/MM/yyyy");


                dtItensEmp.Rows.Add(linha);
            }

            Session["dtItensEmp"] = dtItensEmp;
            dtgItens.DataSource = dtItensEmp;
            dtgItens.DataBind();

        }

        private void IncluirExemplarDevolucao(DataSet dsExe)
        {
            if (Session["dtItensDev"] != null)
                dtItensEmp = (DataTable)Session["dtItensEmp"];

            if (dsExe.Tables[0].Rows.Count != 0)
            {
                DataRow linha = dtItensDev.NewRow();

                linha["MOVID"] = dsExe.Tables[0].Rows[0]["movid"].ToString();
                linha["ID"] = dsExe.Tables[0].Rows[0]["id"].ToString();
                linha["TOMBO"] = dsExe.Tables[0].Rows[0]["tombo"].ToString();
                linha["TITULO"] = dsExe.Tables[0].Rows[0]["titulo"].ToString();
                linha["DEVOLUCAO"] = Convert.ToDateTime(dsExe.Tables[0].Rows[0]["DATAPREVISTAEMPRESTIMO"]).ToString("dd/MM/yyyy");
                linha["SITUACAO"] = dsExe.Tables[0].Rows[0]["SITUACAO"].ToString();

                dtItensDev.Rows.Add(linha);
            }

            Session["dtItensDev"] = dtItensDev;
            dtgExemplarDev.DataSource = dtItensDev;
            dtgExemplarDev.DataBind();

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

        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarDtItensEmp();
            CriarDtItensDev();
            CriarDtPesquisa();
            if (!IsPostBack)
            {
                dtItensEmp = null;
                dtItensDev = null;
            }
        }
        
        #region renovacao
        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            CarregarPesquisaCliente(null);

            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
        }
        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            PesquisarCliente(txtCliente.Text);
        }        
        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCliente.Text = gvrow.Cells[2].Text;
            lblDesCliente.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;
            PesquisarCliente(txtCliente.Text);

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }
        protected void btnRenovar_Click(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string empMov_id;
            string emp_id;
            string renovar;
            string qtdeDias;
            string erro;
            empMov_id = dtgExemplar.DataKeys[gvrow.RowIndex][0].ToString();
            emp_id = dtgExemplar.DataKeys[gvrow.RowIndex][1].ToString();
            renovar = gvrow.Cells[4].Text;
            qtdeDias = gvrow.Cells[5].Text;

            //renovar
            if (renovar == "Sim")
            {
                EmprestimoMovBL empMovBL = new EmprestimoMovBL();
                EmprestimoMov empMov = new EmprestimoMov();
                empMov.Id = utils.ComparaIntComZero(empMov_id);
                empMov.EmprestimoId = utils.ComparaIntComZero(emp_id);
                empMov.DataDevolucao = DateTime.Now;
                empMov.DataEmprestimo = null;
                empMov.DataPrevistaEmprestimo = null;

                erro = empMovBL.RenovarEmprestimoBL(empMov, utils.ComparaIntComZero(qtdeDias));

                if (erro == null || erro == string.Empty)
                {
                    if (chkReciboRenovacao.Checked)
                        ExibirMensagem("Imprimir recibo");

                    PesquisarCliente(txtCliente.Text);
                }
                else
                    ExibirMensagem(erro);
            }
            else
                ExibirMensagem("Não é possível renovar esse exemplar");


        }
        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
        #endregion

        #region emprestimo
        protected void txtExemplar_TextChanged(object sender, EventArgs e)
        {
            if (hfIdPessoa.Value != null && hfIdPessoa.Value != string.Empty)
                PesquisarExemplar(txtExemplar.Text);
            else
            {
                ExibirMensagem("Informe o cliente");
                tcPrincipal.ActiveTabIndex = 0;
            }
        }        
        protected void btnExemplar_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItemEmp(null);
            ModalPopupExtenderPesquisaEmp.Enabled = true;
            ModalPopupExtenderPesquisaEmp.Show();
        }        
        protected void btnAbreEmp_Click(object sender, EventArgs e)
        {
            tcPrincipal.ActiveTabIndex = 1;
        }
        protected void btnVoltarEmp_Click(object sender, EventArgs e)
        {
            tcPrincipal.ActiveTabIndex = 0;
        }
        protected void btnSelectItemEmp_Click(object sender, EventArgs e)
        {

            if (hfIdPessoa.Value != null && hfIdPessoa.Value != String.Empty)
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

                hfIdItem.Value = grdPesquisaEmp.DataKeys[gvrow.RowIndex].Value.ToString();
                txtExemplar.Text = gvrow.Cells[2].Text;
                lblDesExemplar.Text = gvrow.Cells[3].Text;

                ModalPopupExtenderPesquisaEmp.Hide();
                ModalPopupExtenderPesquisaEmp.Enabled = false;
                PesquisarExemplar(txtExemplar.Text);
            }
            else
            {
                ExibirMensagem("Informe o cliente");
                tcPrincipal.ActiveTabIndex = 0;
            }

        }
        protected void btnCancelEmp_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaEmp.Enabled = false;
        }
        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
        protected void btnFinOperacoes_Click(object sender, EventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {

                ////Quantidade máxima de exemplares emprestado:
                //int param = this.LerParametro(1, "B");
                //if (param >= 0)
                //{
                //    if (empBL.QuantosLivrosEmprestados(emp.PessoaId) > param)
                //    {

                //        ExibirMensagem(lblDesPessoa.Text + " já atingiu o limite máximo de empréstimos simultâneos.");
                //        txtPessoa.Focus();
                //        return; //                            throw new Exception(); //tem um jeito melhor de sair do metodo?
                //    }
                //}

                if (Session["dtItensEmp"] != null)
                    dtItensEmp = (DataTable)Session["dtItensEmp"];


                EmprestimosBL empBL = new EmprestimosBL();
                EmprestimoMovBL emovBL = new EmprestimoMovBL();

                foreach (DataRow linha in dtItensEmp.Rows)
                {
                    Emprestimos emp = new Emprestimos();
                    emp.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
                    emp.ExemplarId = utils.ComparaIntComZero((linha["ID"].ToString()));

                    emp.Id = empBL.InserirBL(emp);

                    if (emp.Id > 0)
                    {
                        EmprestimoMov mov = new EmprestimoMov();
                        mov.EmprestimoId = emp.Id;
                        mov.DataEmprestimo = DateTime.Now;
                        mov.DataPrevistaEmprestimo = Convert.ToDateTime((linha["DEVOLUCAO"].ToString()));
                        if (!emovBL.InserirBL(mov))
                        {
                            if (empBL.ExcluirBL(emp))
                            {
                                ExibirMensagem("Não foi possível concluir o empréstimo. Contate o administrador do sistema.");
                                return;
                            }

                        }
                    }
                    if (emp.Id > 0)
                    {
                        LimparCamposEmprestimo();
                        LimparCamposRenovacao();
                        ExibirMensagem("Empréstimo realizado com sucesso!");
                    }
                }
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
        protected void dtgExemplar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }               
        #endregion

        #region devolucao
        protected void txtExemplarDev_TextChanged(object sender, EventArgs e)
        {
            PesquisarExemplarDev(txtExemplarDev.Text);
        }                
        protected void btnExemplarDev_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();
        }
        protected void btnSelectItemDev_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdItem.Value = grdPesquisaItem.DataKeys[gvrow.RowIndex].Value.ToString();
            txtExemplarDev.Text = gvrow.Cells[2].Text;
            lblExemplarDev.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPesquisaItem.Hide();
            ModalPopupExtenderPesquisaItem.Enabled = false;

        }
        protected void btnCancelDev_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }        
        protected void btnDevolver_Click(object sender, EventArgs e)
        {

        }
        protected void btnFinOpeDev_Click(object sender, EventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {

                if (Session["dtItensDev"] != null)
                    dtItensDev = (DataTable)Session["dtItensDev"];

                EmprestimoMovBL emovBL = new EmprestimoMovBL();

                foreach (DataRow linha in dtItensDev.Rows)
                {

                    EmprestimoMov mov = new EmprestimoMov();
                    mov.Id = utils.ComparaIntComZero(linha["MOVID"].ToString());
                    mov.DataDevolucao = DateTime.Now;

                    if (emovBL.EditarBL(mov))
                    {
                        LimparCamposDevolucao();
                        ExibirMensagem("Devolução realizada com sucesso!");
                    }
                    else
                        ExibirMensagem("Não foi possível realizar a devolução. Contate o administrador do sistema.");
                }
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
        protected void btnVoltarDev_Click(object sender, EventArgs e)
        {
            tcPrincipal.ActiveTabIndex = 0;
        }
        protected void dtgExemplarDev_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object key = new object();
            key = dtgExemplarDev.DataKeys[e.RowIndex][0];

            if (Session["dtItensDev"] != null)
                dtItensDev = (DataTable)Session["dtItensDev"];

            if (dtItensDev.Rows.Contains(key))
                dtItensDev.Rows.Remove(dtItensDev.Rows.Find(key));

            Session["dtItensDev"] = dtItensDev;
            dtgExemplarDev.DataSource = dtItensDev;
            dtgExemplarDev.DataBind();

        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
        #endregion


        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
        }
        
        
                
    }
}