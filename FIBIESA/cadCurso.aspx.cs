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
    public partial class cadCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CursosBL curBL = new CursosBL();
            Cursos cursos = new Cursos();

            if (cursos.Id > 0)
            {
                curBL.EditarBL(cursos);
            }
            else
            {
                curBL.InserirBL(cursos);
            }
            Response.Redirect("viewCursos.aspx");
        }
    }
}