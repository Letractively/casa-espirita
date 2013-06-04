using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using BusinessLayer;
using DataObjects;
using System.Collections.Generic;

namespace FIBIESA.Relatorios
{
    public partial class RelCodigoBarras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.geraRelatorio();
            }
        }

        DataTable lDtPesquisa;

        private void geraRelatorio()
        {
            if (Session["ldsRel"] != null)
            {
                lDtPesquisa = (DataTable)Session["ldsRel"];
                if (lDtPesquisa.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataColumn coluna1 = new DataColumn("col1", Type.GetType("System.String"));
                    DataColumn coluna2 = new DataColumn("col2", Type.GetType("System.String"));
                    DataColumn coluna3 = new DataColumn("col3", Type.GetType("System.String"));
                    DataColumn coluna4 = new DataColumn("col4", Type.GetType("System.String"));
                    //DataColumn coluna5 = new DataColumn("col5", Type.GetType("System.String"));

                    dt.Columns.Add(coluna1);
                    dt.Columns.Add(coluna2);
                    dt.Columns.Add(coluna3);
                    dt.Columns.Add(coluna4);
                    //dt.Columns.Add(coluna5);
                    int total = lDtPesquisa.Rows.Count -1;
                    while ((lDtPesquisa.Rows.Count != 0) && (lDtPesquisa.Rows[total].RowState.ToString() != "Deleted"))
                    {
                        int countItem = 1;
                        DataRow linha;
                        linha = dt.NewRow();
                        foreach (DataRow row in lDtPesquisa.Rows)
                        {
                            if (row.RowState.ToString() != "Deleted")
                            {
                                if (countItem < 4)
                                {
                                    linha["col" + countItem] = row["tombo"];
                                    row.Delete();
                                }
                                else
                                {
                                    linha["col" + countItem] = row["tombo"];
                                    row.Delete();
                                    break;
                                }
                                countItem += 1;
                            }
                        }
                        dt.Rows.Add(linha);
                    }
                    lDtPesquisa = null;
                    
                    ReportDataSource rptDatasourceEmprestimos = new ReportDataSource("DataSet_CodigoBarras", dt);
                    dt = null;                    
                    rpvCodigoBarras.LocalReport.DataSources.Add(rptDatasourceEmprestimos);

                    rpvCodigoBarras.LocalReport.Refresh();
                    //Session["ldsRel"] = null;
                }
                else
                {
                    divRelatorio.Visible = false;
                    divMensagem.Visible = true;
                    lblMensagem.Text = "Este relatorio não possui dados.";
                }
            }

        }
    }
}