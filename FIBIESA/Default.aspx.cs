using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BairrosBL bairrosBl = new BairrosBL();
            Bairros bairros = new Bairros();

            bairros.Codigo = Int32.Parse(TextBox1.Text);
            bairros.Descricao = TextBox2.Text;
            bairrosBl.InserirBL(bairros);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BairrosBL bairrosBL = new BairrosBL();
            Bairros bairros = new Bairros();

            bairros.Id = Int32.Parse(TextBox1.Text);

            bairrosBL.ExcluirBL(bairros);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BairrosBL bairrosBL = new BairrosBL();
            Bairros bairros = new Bairros();

            bairros.Id = Int32.Parse(TextBox1.Text);
            bairros.Codigo = Int32.Parse(TextBox2.Text);
            bairros.Descricao = TextBox3.Text;

            bairrosBL.EditarBL(bairros);
        }
    }
}
