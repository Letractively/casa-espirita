using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;
using System.Globalization;
//using PdfSharp.Drawing;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using BoletoNetGerandoPDF;

namespace FIBIESA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void ImprimirBoleto(BoletoBancario boleto)
        {
            this.Panel1.Controls.Add(boleto);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["boleto"] != null)
            //    {
            //        BoletoBancario boletoBan = new BoletoBancario();
            //        boletoBan = (BoletoBancario)Session["boleto"];
            //        ImprimirBoleto(boletoBan);
            //    }
            //}



            string vencimento = "01/01/2013";
            String valorBoleto = "110,50";
            String numeroDocumento = "B20005446";

            //cedente
            String cedente_codigo = "13000";
            String cedente_nossoNumeroBoleto = "22222222";
            String cedente_cpfCnpj = "123.456.789-01";
            String cedente_nome = "PAULO FREIRE - FOUR FREIRES INF.";
            String cedente_agencia = "1000";
            String cedente_conta = "22507";
            String cedente_digitoConta = "6";

            //sacado
            String sacado_cpfCnpj = "000.000.000-00";
            String sacado_nome = "eu caralho";
            String sacado_endereco = "xxxxxxxxxxxx";
            String sacado_bairro = "ffffffffffffff";
            String sacado_cidade = "caxias";
            String sacado_cep = "95070200";
            String sacado_uf = "rs";

            Cedente cedente = new Cedente(cedente_cpfCnpj,
            cedente_nome,
            cedente_agencia,
            cedente_conta,
            cedente_digitoConta);
            cedente.Codigo = Convert.ToInt32(cedente_codigo);

            Boleto boleto = new Boleto(Convert.ToDateTime(vencimento), Convert.ToDecimal(valorBoleto), "341", cedente_nossoNumeroBoleto, cedente);

            boleto.NumeroDocumento = numeroDocumento;

            Sacado sacado = new Sacado(sacado_cpfCnpj, sacado_nome);
            boleto.Sacado = sacado;
            boleto.Sacado.Endereco.End = sacado_endereco;
            boleto.Sacado.Endereco.Bairro = sacado_bairro;
            boleto.Sacado.Endereco.Cidade = sacado_cidade;
            boleto.Sacado.Endereco.CEP = sacado_cep;
            boleto.Sacado.Endereco.UF = sacado_uf;

            Instrucao_Banrisul instrucao = new Instrucao_Banrisul(999, 1);
            Instrucao_Banrisul item1 = new Instrucao_Banrisul(9, 5);
            Instrucao_Banrisul item2 = new Instrucao_Banrisul(81, 10);
            boleto.Instrucoes.Add(instrucao);
            boleto.Instrucoes.Add(item1);
            boleto.Instrucoes.Add(item2);

            BoletoBancario boleto_bancario = new BoletoBancario();
            boleto_bancario.CodigoBanco = 041;
            boleto_bancario.Boleto = boleto;
            boleto_bancario.MostrarCodigoCarteira = true;
            boleto_bancario.Boleto.Valida();

            boleto_bancario.MostrarComprovanteEntrega = true;
            this.Panel1.Controls.Add(boleto_bancario);
            

            



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/criaPDF.aspx");
        //    //gerando pdf
        //    string imagePath = GerarImagem();
        //    string pdfPath = @"c:\temp\boleto.pdf";
        //    Document doc = new Document();

        //    PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
        //    doc.Open();
        //    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagePath);
        //    gif.ScaleAbsolute(520f, 624f);
        //    doc.Add(gif);
        //    doc.Close();
        }


        //private string GerarImagem()
        //{
        //    int width = 670;
        //    int height = 948;
        //    int webBrowserWidth = 670;
        //    int webBrowserHeight = 948;

        //    //System.Drawing.Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail("http://localhost:54771/WebForm1.aspx", webBrowserWidth, webBrowserHeight, width, height);
        //    //bmp.Save(@"c:\temp\boleto.bmp");
        //    return @"c:\temp\boleto.bmp";
        //}


    }
}