using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;

namespace FIBIESA
{
    public partial class viewRelMovimentacaoEstoque : System.Web.UI.Page
    {
        #region funcoes
        private DataTable CriarTabelaPesquisa()
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
        #endregion

        #region pesquisas
        public void pesquisaUsuario(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas;
            if (this.txtUsuario.Text != string.Empty && lCampoPesquisa != string.Empty)
            {
                pessoas = pesBL.PesquisarBL(lCampoPesquisa, this.txtUsuario.Text);
            }
            else
            {
                pessoas = pesBL.PesquisarBL();
            }

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
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Usuário não encontrado.');", true);
            }

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;



        }

        public void pesquisaItem(string lCampoPesquisa)
        {

            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            ItensEstoqueBL itemBl = new ItensEstoqueBL();
            ItensEstoque item = new ItensEstoque();

            List<ItensEstoque> itens;

            if (txtItem.Text != string.Empty && lCampoPesquisa != string.Empty)
            {
                itens = itemBl.PesquisarBL(lCampoPesquisa, txtItem.Text);
            }
            else
            {
                itens = itemBl.PesquisarBL();
            }
            foreach (ItensEstoque pes in itens)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Obra.Codigo;
                linha["DESCRICAO"] = pes.Obra.Titulo;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Item não encontrado.');", true);
            }

            Session["objBLPesquisa"] = itemBl;
            Session["objPesquisa"] = item;
        }


        #endregion pesquisas


        #region carrega Informações
        public void carregaUsuario()
        {
            pesquisaUsuario("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesUsuario.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdUsuario.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesUsuario.Text = "Todos";
                this.hfIdUsuario.Value = "0";
            }
        }

        public void carregaItem()
        {
            pesquisaItem("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesItem.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdItem.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesItem.Text = "Todos";
                this.hfIdItem.Value = "0";
            }
        }

        #endregion carrega Informações

        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region eventos textBox

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            carregaItem();
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            carregaUsuario();
        }
        #endregion eventos textBox

        #region botões de pesquisa
        protected void btnPesUsuario_Click(object sender, EventArgs e)
        {
            pesquisaUsuario(string.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtUsuario.ClientID + "&id=" + hfIdUsuario.ClientID + "&lbl=" + lblDesUsuario.ClientID + "','',600,500);", true);
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            pesquisaItem(string.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);
        }

        #endregion botões de pesquisa

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            MovimentosEstoqueBL movimentosEstoqueBL = new MovimentosEstoqueBL();
            MovimentosEstoque movimentosEstoque = new MovimentosEstoque();

            movimentosEstoque.ItemEstoqueId = Convert.ToInt32(hfIdItem.Value);
            movimentosEstoque.UsuarioId = Convert.ToInt32(hfIdUsuario.Value);

            if (txtQuantidade.Text != string.Empty)
                movimentosEstoque.Quantidade = Convert.ToInt32(txtQuantidade.Text);

            if (rbSaida.Checked)
                movimentosEstoque.Tipo = "S";
            else if (rbEntrada.Checked)
                movimentosEstoque.Tipo = "E";

            Session["ldsRel"] = movimentosEstoqueBL.PesquisarDataSetBL(movimentosEstoque, txtDataIni.Text, txtDataFim.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                string periodo = "Todos";
                if ((txtDataIni.Text != string.Empty) && (txtDataFim.Text != string.Empty))
                {
                    periodo = txtDataIni.Text + " a " + txtDataFim.Text;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelMovimentacaoEstoque.aspx?periodo=" + periodo + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }

        }

    }
}