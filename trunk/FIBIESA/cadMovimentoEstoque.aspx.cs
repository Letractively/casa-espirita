using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;

namespace Admin
{
    public partial class cadMovimentoEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar(int item_id, DateTime? data)
        {
            /*MovimentosEstoqueBL movEst = new MovimentosEstoqueBL();
            List<MovimentosEstoque> movEstoque = movEst.PesquisarBL(item_id,data);
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            DataSet ldsItem;*/
           
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("CODITEM", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("DESCITEM", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DATA", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("USUNOME", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("QTDE", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("NOTAENT", Type.GetType("System.Int32"));
            DataColumn coluna8 = new DataColumn("VENDANUM", Type.GetType("System.Int32"));
            DataColumn coluna9 = new DataColumn("NOTAENTSERIE", Type.GetType("System.Int16"));
            DataColumn coluna10 = new DataColumn("TIPO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);
            tabela.Columns.Add(coluna10);

            /*foreach (MovimentosEstoque ltMovEst in movEstoque)
            {
                DataRow linha = tabela.NewRow();
                              
                linha["DATA"] = ltMovEst.Data.ToString("dd/MM/yyyy");
                linha["VALOR"] = ltMovEst.Valor;
                linha["USUNOME"] = ltMovEst.Usuarios.Nome;
                linha["QTDE"] = ltMovEst.Quantidade;
                linha["NOTAENT"] = ltMovEst.NotaEntrada.Numero;
                linha["NOTAENTSERIE"] = ltMovEst.NotaEntrada.Serie;
                linha["VENDANUM"] = ltMovEst.Vendas.Numero;
                
                ldsItem = itEstBL.PesquisarItensEstoqueBL(ltMovEst.Id);
                if (ldsItem.Tables[0].Rows.Count != 0)
                {
                    linha["CODITEM"] = (int)ldsItem.Tables[0].Rows[0]["CODIGO"];
                    linha["DESCITEM"] = (string)ldsItem.Tables[0].Rows[0]["TITULO"]; 
                }

                tabela.Rows.Add(linha);
                       
            */

            DataRow linha = tabela.NewRow();

            linha["DATA"] = DateTime.Now.ToString("dd/MM/yyyy");
            linha["VALOR"] = 10;
            linha["USUNOME"] = "carina";
            linha["QTDE"] = 15;
            linha["NOTAENT"] = 32;
            linha["NOTAENTSERIE"] = 1;
            linha["VENDANUM"] = 0;
            linha["TIPO"] = "E";

           
                linha["CODITEM"] = 12;
                linha["DESCITEM"] = "O Amor Venceu";
           

            tabela.Rows.Add(linha);

            linha = tabela.NewRow();

            linha["DATA"] = DateTime.Now.ToString("dd/MM/yyyy");
            linha["VALOR"] = 20;
            linha["USUNOME"] = "carina";
            linha["QTDE"] = 1;
            linha["NOTAENT"] = 0;
            linha["NOTAENTSERIE"] = 0;
            linha["VENDANUM"] = 123;
            linha["TIPO"] = "S";


            linha["CODITEM"] = 12;
            linha["DESCITEM"] = "O Amor Venceu";
           

            tabela.Rows.Add(linha);

            dtgMovItem.DataSource = tabela;
            dtgMovItem.DataBind();


        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/PesquisarItens.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar(utils.ComparaIntComZero(hfIdItem.Value), utils.ComparaDataComNull(txtData.Text));
        }

       
    }
}