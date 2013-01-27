using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;

namespace Admin
{
    public partial class cadTurma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TurmasBL turBL = new TurmasBL();
            Turmas turmas = new Turmas();

            if (turmas.Id > 0)
            {
                turBL.EditarBL(turmas);
            }
            else
            {
                turBL.InserirBL(turmas);
            }
            Response.Redirect("viewTurmas.aspx");
        }
    }
}