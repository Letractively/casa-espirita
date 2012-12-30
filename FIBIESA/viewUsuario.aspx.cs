using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using DataObjects;
//using BussinesLayer;

namespace Admin
{
    public partial class viewUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Busca_Click(object sender, EventArgs e)
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
    }
}