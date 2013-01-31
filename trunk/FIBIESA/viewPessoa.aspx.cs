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
    public partial class viewPessoa : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CPFCNPJ", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("TIPO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("CATEGORIAID", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("DTCADASTRO", Type.GetType("System.DateTime"));
            DataColumn coluna8 = new DataColumn("DESCATEGORIA", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);

            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pessoas = pesBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["NOME"] = pes.Nome;
                linha["CPFCNPJ"] = pes.CpfCnpj;
                linha["TIPO"] = pes.Tipo;
                linha["CATEGORIAID"] = pes.CategoriaId;
                linha["DTCADASTRO"] = pes.DtCadastro;

                CategoriasBL catBL = new CategoriasBL();
                List<Categorias> categorias = catBL.PesquisarBL(pes.CategoriaId);
                foreach (Categorias cat in categorias)
                {
                    linha["DESCATEGORIA"] = cat.Descricao;
                }

                tabela.Rows.Add(linha);                
            }

            dtgPessoas.DataSource = tabela;
            dtgPessoas.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPessoa.aspx?operacao=new");
        }

        protected void dtgPessoas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                PessoasBL pesBL = new PessoasBL();
                Pessoas pessoas = new Pessoas();

                pessoas.Id = utils.ComparaIntComZero(dtgPessoas.DataKeys[e.RowIndex][0].ToString());
                pesBL.ExcluirBL(pessoas);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_pes = 0;
            str_pes = utils.ComparaIntComZero(dtgPessoas.SelectedDataKey[0].ToString());
            Response.Redirect("cadPessoa.aspx?id_pes=" + str_pes.ToString() + "&operacao=edit");
        }

       
    }
}