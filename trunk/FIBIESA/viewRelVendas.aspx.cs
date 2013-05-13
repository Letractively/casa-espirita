using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using System.Data;

namespace FIBIESA
{
    public partial class viewRelVendas : System.Web.UI.Page
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
        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.txtCliente.Text != string.Empty)
            {
                carregaCliente();
            }
            if (this.txtItem.Text != string.Empty)
            {
                carregaItem();
            }
        }

        public void carregaCliente()
        {
            pesquisaAssociado("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesCliente.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdCliente.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesCliente.Text = "";
                this.hfIdCliente.Value = "";
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
                this.lblDesItem.Text = "";
                this.hfIdItem.Value = "";
            }
        }

        public void pesquisaAssociado(string lCampoPesquisa)
        {

            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas;
            if (this.txtCliente.Text != string.Empty)
            {
                pessoas = pesBL.PesquisarBL(lCampoPesquisa, this.txtCliente.Text);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Cliente não encontrado.');", true);
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

            if (txtItem.Text != string.Empty)
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


        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            pesquisaAssociado("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCliente.ClientID + "&id=" + hfIdCliente.ClientID + "&lbl=" + lblDesCliente.ClientID + "','',600,500);", true);
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            pesquisaItem("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            VendaItensBL vendaItemBL = new VendaItensBL();

            if (rbMaisVendidos.Checked)
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(hfIdCliente.Value, hfIdItem.Value, txtDataIni.Text, txtDataFim.Text, "desc").Tables[0];
            }
            else if (rbMenosVendidos.Checked)
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(hfIdCliente.Value, hfIdItem.Value, txtDataIni.Text, txtDataFim.Text, "asc").Tables[0];
            }
            else
            {
                Session["ldsRel"] = vendaItemBL.PesquisarBLRelDataSet(hfIdCliente.Value, hfIdItem.Value, txtDataIni.Text, txtDataFim.Text, string.Empty).Tables[0];
            }

            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelVendas.aspx?DtIni=" + txtDataIni.Text + "&DtFim=" + txtDataFim.Text + "','',600,1125);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }


            //emp. txtDataRetiradaIni.Text



        }        

    }
}