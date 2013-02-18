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
    public partial class viewCurso : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        private void Pesquisar()
        {
            DataTable tabela = new DataTable("cursos");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            EventosBL eveBL = new EventosBL();

            List<Eventos> eventos = eveBL.PesquisarBL();

            foreach (Eventos cur in eventos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = cur.Id;
                linha["CODIGO"] = cur.Codigo;
                linha["DESCRICAO"] = cur.Descricao;


                tabela.Rows.Add(linha);
            }

            dtgEventos.DataSource = tabela;
            dtgEventos.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar();
        }


        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadEvento.aspx?operacao=new");
        }


        protected void btnBusca_Click(object sender, EventArgs e)
        {

        }

        protected void dtgCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_eve = 0;
            str_eve = utils.ComparaIntComZero(dtgEventos.SelectedDataKey[0].ToString());
            Response.Redirect("cadEvento.aspx?id_eve=" + str_eve.ToString() + "&operacao=edit");
        }

        protected void dtgCursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EventosBL eveBL = new EventosBL();
            Eventos eventos = new Eventos();
            eventos.Id = utils.ComparaIntComZero(dtgEventos.DataKeys[e.RowIndex][0].ToString());
            eveBL.ExcluirBL(eventos);
            Pesquisar();
        }


    }
}