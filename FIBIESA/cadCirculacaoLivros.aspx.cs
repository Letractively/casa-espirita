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

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void PesquisarEmprestimosAtivo(Int32 id_pessoa)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("RENOVAR", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("SITUACAO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DEVOLUCAO", Type.GetType("System.String"));


            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            EmprestimoMovBL empMovBL = new EmprestimoMovBL();
            List<EmprestimoMov> empMov;

            empMov = empMovBL.PesquisarMovAtivosDA(id_pessoa);

            foreach (EmprestimoMov ltEmpMov in empMov)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = ltEmpMov.Id;
                linha["SITUACAO"] = ltEmpMov.Situacao;
                linha["DEVOLUCAO"] = ltEmpMov.DataPrevistaEmprestimo.ToString("dd/MM/yyyy");

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

                tabela.Rows.Add(linha);
            }

            dtgExemplar.DataSource = tabela;
            dtgExemplar.DataBind();
        }

        private void PesquisarCliente(string cod_cliente)
        {
            hfIdPessoa.Value = "";
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
            CriarDtPesquisa();

        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);

            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
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

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            PesquisarCliente(txtCliente.Text);
        }

        protected void btnRenovar_Click(object sender, EventArgs e)
        {
            EmprestimosBL empBL = new EmprestimosBL();
            Emprestimos emp = new Emprestimos();

            //emp.Id = utils.ComparaIntComZero(hfId.Value);

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
                    lol = DateTime.Now.AddDays(param);
                mov.DataPrevistaEmprestimo = lol;
                mov.DataDevolucao = null;
                emovBL.InserirBL(mov);
            }

        }

        protected void dtgExemplar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void txtExemplar_TextChanged(object sender, EventArgs e)
        {
            PesquisarExemplar(txtExemplar.Text);
        }

        protected void btnDevolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
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
    }
}