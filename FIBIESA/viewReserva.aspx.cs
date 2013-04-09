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
    public partial class viewReserva : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTipoAutor"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTipoAutor"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTipoAutor"] = value; }
        }
        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");
            
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);



            EmprestimosBL reservas = new EmprestimosBL();
            List<Emprestimos> emprestimo;

            if (campo != null && valor.Trim() != "")
                emprestimo = reservas.PesquisarBL(); //campo, valor);
            else
                emprestimo = reservas.PesquisarBL();

            foreach (Emprestimos tipA in emprestimo)
            {
                
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = tipA.Id;
                linha["CODIGO"] = tipA.PesCodigo;
                linha["DESCRICAO"] = tipA.PesDescricao;
               
                tabela.Rows.Add(linha);
            }
            
            dtbPesquisa = tabela;
            dtgReservas.DataSource = tabela;
            dtgReservas.DataBind();
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Busca_Click(object sender, EventArgs e)
        {
            
        }
    }
}