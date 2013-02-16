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
    public partial class viewPortador : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("AGENCIAID", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("BANCOID", Type.GetType("System.Int32"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            PortadoresBL porBL = new PortadoresBL();
            List<Portadores> portadores = porBL.PesquisarBL();

            foreach (Portadores ltPor in portadores)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltPor.Id;
                linha["CODIGO"] = ltPor.Codigo;
                linha["DESCRICAO"] = ltPor.Descricao;
                linha["AGENCIAID"] = ltPor.AgenciaId;
                linha["BANCOID"] = ltPor.BancoId;

                tabela.Rows.Add(linha);                
            }

            dtgPortadores.DataSource = tabela;
            dtgPortadores.DataBind();
 
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar();
        }
           

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPortador.aspx?operacao=new");
        }

        protected void dtgPortadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                PortadoresBL porBL = new PortadoresBL();
                Portadores por = new Portadores();
                por.Id = utils.ComparaIntComZero(dtgPortadores.DataKeys[e.RowIndex][0].ToString());
                porBL.ExcluirBL(por);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgPortadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_por = 0;
            str_por = utils.ComparaIntComZero(dtgPortadores.SelectedDataKey[0].ToString());
            Response.Redirect("cadPortador.aspx?id_por=" + str_por.ToString() + "&operacao=edit");
        }
    }
}