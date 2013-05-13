using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;
using System.Data.SqlClient;

namespace Admin
{
    public partial class cadPermicao : System.Web.UI.Page
    {
        Utils utils = new Utils();
        int id_cat;

        #region funcoes
        private void Pesquisar(int id_cat, string modulo)
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CONSULTAR", Type.GetType("System.Boolean"));
            DataColumn coluna3 = new DataColumn("EDITAR", Type.GetType("System.Boolean"));
            DataColumn coluna4 = new DataColumn("INSERIR", Type.GetType("System.Boolean"));
            DataColumn coluna5 = new DataColumn("EXCLUIR", Type.GetType("System.Boolean"));
            DataColumn coluna6 = new DataColumn("FORMULARIOID", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("CODFORMULARIO", Type.GetType("System.Int32"));
            DataColumn coluna8 = new DataColumn("DESCFORMULARIO", Type.GetType("System.String"));
            DataColumn coluna9 = new DataColumn("TIPO", Type.GetType("System.String"));
            DataColumn coluna10 = new DataColumn("CATEGORIAID", Type.GetType("System.Int32"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);
            tabela.Columns.Add(coluna10);

            FormulariosBL forBL = new FormulariosBL();            
            List<Formularios> formularios = forBL.PesquisarBL(modulo);

            PermissoesBL perBL = new PermissoesBL();
            List<Permissoes> permissoes;

            foreach (Formularios formu in formularios)
            {
                DataRow linha = tabela.NewRow();

                linha["FORMULARIOID"] = formu.Id;
                linha["CODFORMULARIO"] = formu.Codigo;
                linha["DESCFORMULARIO"] = formu.Descricao;
                linha["CATEGORIAID"] = id_cat;

                switch (formu.Tipo.ToUpper())
                {
                    case "C":
                        {
                            linha["TIPO"] = "Edição";
                            break;
                        }
                    case "V":
                        {
                            linha["TIPO"] = "Consulta";
                            break;
                        } 
                }                             
                
                permissoes = perBL.PesquisarBL(id_cat, formu.Id);

                if (permissoes.Count > 0)
                {
                    foreach (Permissoes per in permissoes)
                    {
                        linha["Id"] = per.Id;
                        linha["CONSULTAR"] = per.Consultar;
                        linha["EDITAR"] = per.Editar;
                        linha["INSERIR"] = per.Inserir;
                        linha["EXCLUIR"] = per.Excluir;
                    }
                }
                else
                {
                    linha["Id"] = 0;
                    linha["CONSULTAR"] = false;
                    linha["EDITAR"] = false;
                    linha["INSERIR"] = false;
                    linha["EXCLUIR"] = false; 
                }

                tabela.Rows.Add(linha);
            }
                        
            repPermissao.DataSource = tabela;
            repPermissao.DataBind();
 
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
            {
                if (Session["descategoria"] != null)
                    lblDesCategoria.Text = Server.UrlDecode(Session["descategoria"].ToString());
            }
           
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewPermissao.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            PermissoesBL perBL = new PermissoesBL();
            Permissoes permissao = new Permissoes();
            
            foreach (RepeaterItem item in repPermissao.Items)
            {
                permissao.Id = utils.ComparaIntComZero(((TextBox)item.FindControl("txtId")).Text);
                permissao.CategoriaId = utils.ComparaIntComZero(((TextBox)item.FindControl("txtCategoriaId")).Text);
                permissao.FormularioId = utils.ComparaIntComZero(((TextBox)item.FindControl("txtFormularioId")).Text);
                permissao.Consultar = ((CheckBox)item.FindControl("chkConsultar")).Checked;
                permissao.Editar = ((CheckBox)item.FindControl("chkEditar")).Checked;
                permissao.Inserir = ((CheckBox)item.FindControl("chkInserir")).Checked;
                permissao.Excluir = ((CheckBox)item.FindControl("chkExcluir")).Checked;

                if (permissao.CategoriaId > 0 && permissao.FormularioId > 0)
                {
                    if (permissao.Id > 0)
                    {
                        if (perBL.EditarBL(permissao))
                            ExibirMensagem("Permissões atualizadas com sucesso !");
                        else
                            ExibirMensagem("Não foi possível gravar as permissões. Revise as informações.");
                    }
                    else
                    {
                        if (perBL.InserirBL(permissao))
                            ExibirMensagem("Permissões gravadas com sucesso !");
                        else
                            ExibirMensagem("Não foi possível gravar as permissões. Revise as informações.");
                    }
                }
            }      
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id_per_cat"] != null)
            {
                id_cat = utils.ComparaIntComZero(Request.QueryString["id_per_cat"].ToString());
                Pesquisar(id_cat, ddlModulo.SelectedValue);
            }
              
        }
    }
}