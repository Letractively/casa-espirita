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
    public partial class viewPesqEvento : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_pesqEve"] != null)
                    return (DataTable)Session["_dtbPesquisa_pesqEve"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_pesqEve"] = value; }
        }

        private void Pesquisar(string valor)
        {

            EventosBL eveBL = new EventosBL();

            DataSet eventos;

            eventos = eveBL.PesquisarDataset(valor);
            Session["_dtbPesquisa_pesqEve"] = eventos;
            dtgEventos.DataSource = eventos;
            dtgEventos.DataBind();
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }
                
        protected void dtgEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dtgEventos.DataSource = (DataSet)Session["_dtbPesquisa_pesqEve"];
            dtgEventos.PageIndex = e.NewPageIndex;
            dtgEventos.DataBind();
        }

        protected void dtgEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }        
    }
}