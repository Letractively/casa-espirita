using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using DataObjects;

namespace FIBIESA
{
    /// <summary>
    /// Carrega o logo da instituicao
    /// </summary>
    public class instituicoesLogo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["logoId"] != null)
            {
                InstituicoesBL ibl = new InstituicoesBL();
                int id = Convert.ToInt16(context.Request.QueryString["logoId"]);
                List<Instituicoes> lista = ibl.PesquisarBL(id);
                byte[] img = lista[0].InstituicaoLogo != null ? lista[0].InstituicaoLogo.Imagem : null;

                if (img != null)
                {
                    context.Response.ContentType = "image/" + lista[0].InstituicaoLogo.Extensao;
                    context.Response.OutputStream.Write(img, 0, img.Length);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}