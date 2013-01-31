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
    public partial class viewUsuario : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("PESSOAID", Type.GetType("System.String"));                                                 
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("EMAIL", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("STATUS", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DTINICIO", Type.GetType("System.DateTime"));
            DataColumn coluna7 = new DataColumn("DTFIM", Type.GetType("System.DateTime"));
            DataColumn coluna8 = new DataColumn("LOGIN", Type.GetType("System.String"));
            DataColumn coluna9 = new DataColumn("SENHA", Type.GetType("System.String"));
            
            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);

            UsuariosBL usuBL = new UsuariosBL();           
            List<Usuarios> usuarios = usuBL.PesquisarBL();

            foreach (Usuarios usu in usuarios)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = usu.Id;
                linha["PESSOAID"] = usu.PessoaId;
                linha["NOME"] = usu.Nome;
                linha["EMAIL"] = usu.Email;
                linha["STATUS"] = usu.Status;
                linha["DTINICIO"] = usu.DtInicio;
                linha["DTFIM"] = usu.DtFim;
                linha["LOGIN"] = usu.Login;
                linha["SENHA"] = usu.Senha;

                tabela.Rows.Add(linha);
            }

            dtgUsuarios.DataSource = tabela;
            dtgUsuarios.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            //ProdutoBL BL = new ProdutoBL();
            //List<Produto> PRODUTO = BL.ConsultarProduto(txtBusca.Text);

            //DataTable tabela = new DataTable("PRODUTO");            

            //DataColumn coluna1 = new DataColumn("Código", Type.GetType("System.String"));
            //tabela.Columns.Add(coluna1);

            //DataColumn coluna2 = new DataColumn("Nome", Type.GetType("System.String"));
            //tabela.Columns.Add(coluna2);

            //DataColumn coluna3 = new DataColumn("Tipo", Type.GetType("System.String"));
            //tabela.Columns.Add(coluna3);

            //DataColumn coluna4 = new DataColumn("Preço", Type.GetType("System.String"));
            //tabela.Columns.Add(coluna4);

            //DataColumn coluna5 = new DataColumn("Preço de Custo", Type.GetType("System.String"));
            //tabela.Columns.Add(coluna5);

            //foreach (Produto liv in PRODUTO)
            //{
            //    DataRow linha = tabela.NewRow();
            //    linha["Código"] = liv.Codigo;
            //    linha["Nome"] = liv.Nome;
            //    linha["Tipo"] = liv.Tipo;
            //    linha["Preço"] = liv.Preco;
            //    linha["Preço de Custo"] = liv.PrecoCusto;


            //    tabela.Rows.Add(linha);
            //}

            //GridProduto.DataSource = tabela;
            //GridProduto.DataBind();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadUsuario.aspx?operacao=new");
        }

        protected void dtgUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                UsuariosBL usuBL = new UsuariosBL();
                Usuarios usuarios = new Usuarios();

                usuarios.Id = utils.ComparaIntComZero(dtgUsuarios.DataKeys[e.RowIndex][0].ToString());
                usuBL.ExcluirBL(usuarios);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_usu = 0;
            str_usu = utils.ComparaIntComZero(dtgUsuarios.SelectedDataKey[0].ToString());
            Response.Redirect("cadUsuario.aspx?id_usu=" + str_usu.ToString() + "&operacao=edit");
        }

    

        
    }
}