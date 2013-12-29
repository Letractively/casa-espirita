using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using FG;

namespace FIBIESA
{
    public partial class viewRelMovimentacaoEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
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
                linha["CODIGO"] = pes.Obra.Codigo;
                linha["DESCRICAO"] = pes.Obra.Titulo;

                dt.Rows.Add(linha);
            }


            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
        }

        public void CarregarPesquisaUsuario(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            UsuariosBL usuBL = new UsuariosBL();
            Usuarios usu = new Usuarios();
            List<Usuarios> lUsuarios = usuBL.PesquisarBuscaBL(conteudo);

            foreach (Usuarios pes in lUsuarios)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Id;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisaUsuario.DataSource = dt;
            grdPesquisaUsuario.DataBind();
        }

        private void CarregarAtributos()
        {
            txtDataIni.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtQuantidade.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        #region Click

        protected void btnPesItem_Click(object sender, EventArgs e)
        {

            CarregarPesquisaItem(null);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntItem"] != null && Session["IntItem"] != string.Empty)
                txtItem.Text = Session["IntItem"].ToString() + ",";

            txtItem.Text = txtItem.Text + gvrow.Cells[2].Text;
            Session["IntItem"] = txtItem.Text;
            ModalPopupExtenderPesquisaItem.Hide();
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnPesUsuario_Click(object sender, EventArgs e)
        {

            CarregarPesquisaUsuario(null);
            ModalPopupExtenderPesquisaUsuario.Enabled = true;
            ModalPopupExtenderPesquisaUsuario.Show();

        }

        protected void btnSelectUsuario_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntUsuario"] != null && Session["IntUsuario"] != string.Empty)
                txtUsuario.Text = Session["IntUsuario"].ToString() + ",";

            txtUsuario.Text = txtUsuario.Text + gvrow.Cells[2].Text;
            Session["IntUsuario"] = txtUsuario.Text;
            ModalPopupExtenderPesquisaUsuario.Hide();
            ModalPopupExtenderPesquisaUsuario.Enabled = false;
        }

        protected void btnCancelUsuario_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaUsuario.Enabled = false;
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            MovimentosEstoqueBL movimentosEstoqueBL = new MovimentosEstoqueBL();
            MovimentosEstoque movimentosEstoque = new MovimentosEstoque();


            if (txtQuantidade.Text != string.Empty)
                movimentosEstoque.Quantidade = Convert.ToInt32(txtQuantidade.Text);

            if (utils.ComparaIntComZero(ddlTipoMov.SelectedValue) == 2 )
                movimentosEstoque.Tipo = "S";
            else if (utils.ComparaIntComZero(ddlTipoMov.SelectedValue) == 1 )
                movimentosEstoque.Tipo = "E";

            Session["ldsRel"] = movimentosEstoqueBL.PesquisarDataSetBL(movimentosEstoque, txtItem.Text, txtUsuario.Text, txtDataIni.Text, txtDataFim.Text).Tables[0];
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

        #endregion


        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarAtributos();
                Session["IntItem"] = null;
                Session["IntUsuario"] = null;
            }
        }


        #region eventos textBox
        
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (txtItem.Text == "")
                Session["IntItem"] = null;
            Session["IntItem"] = txtItem.Text;
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                Session["IntUsuario"] = null;
            Session["IntUsuario"] = txtUsuario.Text;
        }
        #endregion eventos textBox

        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void grdPesquisaUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisa.Text);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();
            txtPesquisa.Text = "";
        }

        protected void btnBuscarUsu_Click(object sender, EventArgs e)
        {
            CarregarPesquisaUsuario(txtPesquisaUsuario.Text);
            ModalPopupExtenderPesquisaUsuario.Enabled = true;
            ModalPopupExtenderPesquisaUsuario.Show();
            txtPesquisaUsuario.Text = "";
        }

    }
}