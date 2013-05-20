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
    public partial class viewRelItensEstoque : System.Web.UI.Page
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
            if (!IsPostBack)
            {
            }
        }

        #region pesquisas
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

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            carregaItem();
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            pesquisaItem("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            ItensEstoqueBL itensEstoqueBL = new ItensEstoqueBL();
            ItensEstoque itensEstoque = new ItensEstoque();

            itensEstoque.Id = Convert.ToInt32(hfIdItem.Value);

            byte? controlaestoque = null;
            if (rbControlaEstoque.Checked)
                controlaestoque = 1;
            else if (rbNaoControlaEstoque.Checked)
                controlaestoque = 0;

            byte? blStatus = null;
            string status = "Todos";                
            if (ddlStatus.SelectedValue != string.Empty)
            {
                blStatus = Convert.ToByte(ddlStatus.SelectedValue);
                status = ddlStatus.SelectedItem.Text;
            }
            
            Session["ldsRel"] = itensEstoqueBL.PesquisarItensEstoqueDataSetBL(itensEstoque,controlaestoque,blStatus).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelItensEstoque.aspx?status=" + status + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }

    }
}