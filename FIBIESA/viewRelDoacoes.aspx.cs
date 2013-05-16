using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;


namespace FIBIESA
{
    public partial class viewRelDoacoes : System.Web.UI.Page
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
            //txtValorFim.Attribute.Add("onKeyDown");
            txtValorFim.Attributes.Add("onKeyDown", "return(FormataMoeda(this,10,event,2))");
            txtValorIni.Attributes.Add("onKeyDown", "return(FormataMoeda(this,10,event,2))");
            if (this.txtCodPessoa.Text != string.Empty)
            {
                carregaPessoa();
            }            
        }

        public void carregaPessoa()
        {
            pesquisaPessoa("CODIGO");
            if (Session["tabelaPesquisa"] != null)
            {
                dtGeral = (DataTable)Session["tabelaPesquisa"];
                this.lblDesPessoa.Text = dtGeral.Rows[0].ItemArray[2].ToString();
                this.hfIdPessoa.Value = dtGeral.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                this.lblDesPessoa.Text = string.Empty;
                this.hfIdPessoa.Value = string.Empty;
            }
        }

        public void pesquisaPessoa(string lCampoPesquisa)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas;
            if(this.txtCodPessoa.Text != string.Empty)
            {
               pessoas = pesBL.PesquisarBL(lCampoPesquisa,this.txtCodPessoa.Text);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALERTA", "alert('Doador não encontrado.');", true);
            }

            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            

        }

        protected void btnPesNome_Click(object sender, EventArgs e)
        {
            pesquisaPessoa("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCodPessoa.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesPessoa.ClientID + "','',600,500);", true);
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {

            DoacoesBL doacoesBL = new DoacoesBL();


            Session["ldsRel"] = doacoesBL.PesquisarDataset(hfIdPessoa.Value, txtValorIni.Text, txtValorFim.Text, txtDataIni.Text, txtDataFim.Text).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                string periodo = "Todos";
                if((txtDataIni.Text != string.Empty) && (txtDataFim.Text != string.Empty))
                {
                    periodo = txtDataIni.Text + " a " + txtDataFim.Text;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelDoacoes.aspx?periodo=" + periodo + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }

        }
    }
}