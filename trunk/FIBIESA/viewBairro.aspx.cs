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
    public partial class viewBairro : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("tabela");
            
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            
            BairrosBL baiBL = new BairrosBL();
            
            List<Bairros> bairros = baiBL.PesquisarBL();
                       
            foreach (Bairros bai in bairros)
            {
                
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = bai.Id;
                linha["CODIGO"] = bai.Codigo;
                linha["DESCRICAO"] = bai.Descricao;

               
                tabela.Rows.Add(linha);
            }
            
            dtgBairros.DataSource = tabela;           
            dtgBairros.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar();
        }

     
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadBairro.aspx?operacao=new");
        }

            
        protected void btnBusca_Click(object sender, EventArgs e)
        {

        }

        protected void dtgBairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = utils.ComparaIntComZero(dtgBairros.SelectedDataKey[0].ToString());
            Response.Redirect("cadBairro.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }

        protected void dtgBairros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                BairrosBL baiBL = new BairrosBL();
                Bairros bairros = new Bairros();
                bairros.Id = utils.ComparaIntComZero(dtgBairros.DataKeys[e.RowIndex][0].ToString());
                baiBL.ExcluirBL(bairros);
                Pesquisar();
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
               
      
    }
}