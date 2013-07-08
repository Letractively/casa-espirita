using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BoletoNetGerandoPDF;

namespace FIBIESA
{
    public partial class criapdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gerando pdf
            string imagePath = GerarImagem();
            string pdfPath = @"c:\temp\boleto.pdf";
            Document doc = new Document();

            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
            doc.Open();
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagePath);
            gif.ScaleAbsolute(520f, 624f);
            doc.Add(gif);
            doc.Close();
        }

        private string GerarImagem()
        {
            int width = 670;
            int height = 948;
            int webBrowserWidth = 670;
            int webBrowserHeight = 948;

            System.Drawing.Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail("http://localhost:54771/WebForm1.aspx", webBrowserWidth, webBrowserHeight, width, height);
            bmp.Save(@"c:\temp\boleto.bmp");
            return @"c:\temp\boleto.bmp";
        }

    }
}