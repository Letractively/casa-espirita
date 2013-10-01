using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
namespace FG
{
    public class Utils
    {
        public int ComparaIntComZero(string prm_Int)
        {
            try
            {
                if (prm_Int.Trim() != string.Empty)
                {
                    if (prm_Int.Trim() == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(prm_Int.Trim());
                    }
                }
                else
                {
                    return Convert.ToInt32(prm_Int.Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        public int? ComparaIntComNull(string prm_Int)
        {
            try
            {
                if (prm_Int.Trim() != string.Empty)
                {
                    if (prm_Int.Trim() == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(prm_Int.Trim());
                    }
                }
                else
                {
                    return Convert.ToInt32(prm_Int.Trim());
                }
            }
            catch
            {
                return null;
            }
        }
        public short? ComparaShortComNull(string prm_Int)
        {
            try
            {
                if (prm_Int.Trim() != string.Empty)
                {
                    if (prm_Int.Trim() == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt16(prm_Int.Trim());
                    }
                }
                else
                {
                    return Convert.ToInt16(prm_Int.Trim());
                }
            }
            catch
            {
                return null;
            }
        }
        public short ComparaShortComZero(string prm_Int)
        {
            try
            {
                if (prm_Int.Trim() != string.Empty)
                {
                    if (prm_Int.Trim() == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt16(prm_Int.Trim());
                    }
                }
                else
                {
                    return Convert.ToInt16(prm_Int.Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        public DateTime? ComparaDataComNull(string prm_Data)
        {
            if (prm_Data == "" || prm_Data == null)
                return null;
            else
            {
                DateTime? date;
                try
                {
                    date = Convert.ToDateTime(prm_Data);
                    return date;
                }
                catch (FormatException)
                {
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
        /// <summary>
        /// Formata a data caso tenha retorno, no formato estipulado dentro da variavel formato
        /// caso formato não seja informado padrão será dd/MM/yyyy
        /// </summary>
        /// <param name="prm_Data"></param>
        /// <returns></returns>
        public string ComparaDataComNull(DateTime? prm_Data)
        {
            if (prm_Data == null)
                return "";
            else
            {
                try
                {
                    return Convert.ToDateTime(prm_Data).ToString("dd/MM/yyyy");
                }
                catch
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Formata a data caso tenha retorno, no formato estipulado dentro da variavel formato
        /// caso formato não seja informado padrão será dd/MM/yyyy
        /// </summary>
        /// <param name="prm_Data"></param>
        /// <param name="formato"></param>
        /// <returns></returns>
        public string ComparaDataComNull(string prm_Data, string formato)
        {
            if (prm_Data == "" || prm_Data == null)
                return "";
            else
            {
                if (formato == "")
                    return Convert.ToDateTime(prm_Data).ToString("dd/MM/yyyy");
                else
                    return Convert.ToDateTime(prm_Data).ToString(formato);
            }
        }
        public string ComparaDataComNull(DateTime? prm_Data, string formato)
        {
            if (prm_Data == null)
                return "";
            else
            {
                if (formato == "")
                    return Convert.ToDateTime(prm_Data).ToString("dd/MM/yyyy");
                else
                    return Convert.ToDateTime(prm_Data).ToString(formato);
            }
        }
        public bool CriaImagemPeloByte(byte[] Binary, ImageFormat imgFor, string pCaminho)
        {
            Stream strm = null;
            Bitmap original = null;

            try
            {
                if (File.Exists(pCaminho))
                    File.Delete(pCaminho);

                //File.SetLastWriteTime(pCaminho, DateTime.Now);

                strm = this.ConvertByteArrayToStream(Binary);
                original = (Bitmap)System.Drawing.Image.FromStream(strm);
                original.Save(pCaminho, imgFor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (strm != null)
                    strm.Close();
                if (original != null)
                    original.Dispose();
            }
        }
        public Stream ConvertByteArrayToStream(byte[] input)
        {
            Stream str = new MemoryStream(input);
            return str;
        }
        public string ComparaDecimalComZero(decimal prm_Dec)
        {
            if (prm_Dec == 0)
            {
                return string.Empty;
            }
            else
            {
                return prm_Dec.ToString();
            }
        }
        public decimal ComparaDecimalComZero(string prm_Dec)
        {
            try
            {
                if (prm_Dec.Trim() != string.Empty)
                {
                    if (prm_Dec.Trim() == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToDecimal(prm_Dec.Trim());
                    }
                }
                else
                {
                    return Convert.ToDecimal(prm_Dec.Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        public void CarregarEfeitoGrid(string prm_cor_in, string prm_cor_out, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + prm_cor_in + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='" + prm_cor_out + "'");
            e.Row.Style.Add("cursor", "pointer");
        }
        /// <summary>
        /// Remove os acentos de uma string os caracteres especiais sao substituidos por _ e @ por A
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string RemoveAcentos(string str)
        {
            string C_acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç!#$%¨&*@ºª°";
            string S_acentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc_______A___";

            for (int i = 0; i < C_acentos.Length; i++)
                str = str.Replace(C_acentos[i].ToString(), S_acentos[i].ToString()).Trim();

            return str;
        }
        public string ConvertHtmlToString(string pTexto)
        {
            byte[] car = new byte[pTexto.Length];

            car = ASCIIEncoding.Unicode.GetBytes(pTexto);

            string str;
            str = System.Text.ASCIIEncoding.UTF8.GetString(car);

            return str;
        }
        public void CarregarJsExclusao(string prm_mensagem, int int_coluna, GridViewRowEventArgs e)
        {
            e.Row.Cells[int_coluna].Attributes.Add("onclick", "javascript:return " +
                "confirm('\\n" + prm_mensagem + "')");
        }
        /// <summary>
        /// Gerar hash de strings (encriptacao via unica - one way crypt)
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public string OneWayCrypt(string valor)
        {
            if (valor != null && valor != string.Empty)
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] hashValue;
                byte[] message = UE.GetBytes(valor);

                SHA512Managed hashString = new SHA512Managed();
                StringBuilder hex = new StringBuilder();
                hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex.Append(String.Format("{0:x2}", x));
                }
                return hex.ToString();
            }
            else
                return null;
        }
        public string LimpaFormatacaoCNPJCPF(string pCNPJ)
        {
            pCNPJ = pCNPJ.Replace(".", "");
            pCNPJ = pCNPJ.Replace("-", "");
            pCNPJ = pCNPJ.Replace("/", "");
            return pCNPJ;
        }
        public bool ValidaCPF(string cpf)
        {
            int[] multiplic1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplic2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int remainder;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplic1[i];

            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = remainder.ToString();

            tempCpf = tempCpf + digit;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplic2[i];

            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = digit + remainder.ToString();

            return cpf.EndsWith(digit);
        }
        public bool ValidaCNPJ(string cnpj)
        {
            int[] multiplic1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplic2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int remainder;
            string digit;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplic1[i];

            remainder = (sum % 11);
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = remainder.ToString();

            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplic2[i];

            remainder = (sum % 11);
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = digit + remainder.ToString();

            return cnpj.EndsWith(digit);

        }
        public string Criptografar(string texto)
        {

            string aux = "";

            aux = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(texto));

            return aux;
        }
        public string DesCriptografar(string texto)
        {
            string aux = "";
            byte[] toDecodeByte = Convert.FromBase64String(texto);

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            int charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);

            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
            aux = DesCriptografar(new String(decodedChar));

            return aux;
        }
        public string FormataCPF(string pCPF)
        {
            pCPF = pCPF.Replace(".", "");
            pCPF = pCPF.Replace("-", "");

            pCPF = pCPF.Insert(3, ".");
            pCPF = pCPF.Insert(7, ".");
            pCPF = pCPF.Insert(11, "-");

            return pCPF;
        }
        public string FormataCNPJ(string pCNPJ)
        {
            pCNPJ = pCNPJ.Replace(".", "");
            pCNPJ = pCNPJ.Replace("-", "");
            pCNPJ = pCNPJ.Replace("/", "");

            pCNPJ = pCNPJ.Insert(2, ".");
            pCNPJ = pCNPJ.Insert(6, ".");
            pCNPJ = pCNPJ.Insert(10, "/");
            pCNPJ = pCNPJ.Insert(15, "-");

            return pCNPJ;
        }
        /// <summary>
        /// Retorna CNPJ somente com números
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public string LimpaCNPJ(string cnpj)
        {
            return RemoveAcentos(cnpj).Trim().Replace(".", "").Replace("/", "").Replace("-", "");
        }
        /// <summary>
        /// Retorna CNPJ somente com números
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public string LimpaCPF(string cpf)
        {
            return RemoveAcentos(cpf).Trim().Replace(".", "").Replace("-", "").Replace("-", "").Replace("/", "").Trim();
        }
        /// <summary>
        /// Retorna True se o item informado for um CNPJ
        /// a variavel formatada e se o CNPJ for passado com os . e /
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public bool eCnpj(string cnpj, bool formatado)
        {
            if (formatado == true)
                if (cnpj.Length == 18)
                    return true;
                else
                    return false;
            else
                if (cnpj.Length == 14)
                    return true;
                else
                    return false;
        }
        /// <summary>
        /// Retorna True se o item informado for um CPF
        /// a variavel formatada e se o CPF for passado com os . e -
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="formatado"></param>
        /// <returns></returns>
        public bool eCpf(string cpf, bool formatado)
        {
            if (formatado == true)
                if (cpf.Length == 14)
                    return true;
                else
                    return false;
            else
                if (cpf.Length == 11)
                    return true;
                else
                    return false;
        }
        public string FormataCNPJouCPF(string pCPFouCNPJ)
        {
            pCPFouCNPJ = LimpaCNPJ(pCPFouCNPJ);
            pCPFouCNPJ = LimpaCPF(pCPFouCNPJ);

            if (eCnpj(pCPFouCNPJ, false))
                return pCPFouCNPJ.Substring(0, 2) + "." + pCPFouCNPJ.Substring(2, 3) + "." + pCPFouCNPJ.Substring(5, 3) + "/" + pCPFouCNPJ.Substring(8, 4) + "-" + pCPFouCNPJ.Substring(12, 2);
            else
                if (eCpf(pCPFouCNPJ, false))
                    return pCPFouCNPJ.Substring(0, 3) + "." + pCPFouCNPJ.Substring(3, 3) + "." + pCPFouCNPJ.Substring(6, 3) + "-" + pCPFouCNPJ.Substring(9, 2);
                else
                    return pCPFouCNPJ;
        }
        /// <summary>
        /// Cria um arquivo txt com o texto de entrada e retorna o caminho do arquivo
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        //public string CriaArqTXT(string texto)
        //{
        //    string arq;// = CriaNomeArqTemporario("txt");

        //   // StreamWriter SW;
        //   //// SW = File.CreateText(arq);
        //   // SW.WriteLine(texto);
        //   // SW.Close();

        //   // return arq;

        //}
        /// <summary>
        /// Cria um arquivo txt com o texto de entrada conforme o nome do arquivo passado o nome deve conter o caminho para criacao
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="NomeArquivo">Informe o caminho o nome e estensao do arquivo</param>
        /// <returns></returns>
        public string CriaArqTXT(string texto, string NomeArquivo)
        {
            if (File.Exists(NomeArquivo))
            {
                File.Delete(NomeArquivo);
            }

            StreamWriter SW;
            SW = File.CreateText(NomeArquivo);
            SW.WriteLine(texto);
            SW.Close();

            return NomeArquivo;
        }

        //public void CriarArqTXT()
        //{
        //    string FILE_NAME = "c:\TesteNEt.txt";

        //    if (File.Exists(FILE_NAME))
        //    {
        //        File.Delete(FILE_NAME);
        //    }
 
        //    using (StreamWriter sw = File.CreateText(FILE_NAME))
        //    {
        //        sw.WriteLine ("Teste de arquivo texto...");
        //        sw.Close();
        //    }

        //}

        //public void downlad
        //{

        //     System.IO.FileInfo arquivo = new System.IO.FileInfo(Request.ServerVariables[“APPL_PHYSICAL_PATH”] + @”\IMAGES\” + DropDownList1.SelectedValue);
        //      Response.Clear();
        //      Response.AddHeader(“Content-Disposition”, “attachment; filename=” + arquivo.Name);
        //      Response.AddHeader(“Content-Length”, arquivo.Length.ToString());
        //      Response.ContentType = “application/octet-stream”;|
        //      Response.WriteFile(arquivo.FullName);
        //      Response.End();

        //Leia mais em: Download de arquivos com ASP.Net http://www.devmedia.com.br/download-de-arquivos-com-asp-net/7076#ixzz2ck34ZBIv

        //    string txt = "line1";
        //    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(txt));

        //    Response.Charset = "iso-8859-1";
        //    Response.ContentType = "application/octet-stream";
        //    Response.AddHeader("Content-Disposition:", "attachment; filename=Senhas.txt");
        //    ms.WriteTo(Context.Response.OutputStream);
        //    ms.Close();

        //    Response.Flush();
        //    Response.Clear();
        //    Response.End();

        //}       
        public static void Download(string fName)
        {
            FileInfo fInfo = new FileInfo(fName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fInfo.Name + "\"");
            HttpContext.Current.Response.AddHeader("Content-Length", fInfo.Length.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.WriteFile(fInfo.FullName);
            fInfo = null;
        }

        public void IncluirCampoNumerico(StringBuilder stringbuilder, string conteudo, int tamanho)
        {
            for (int i = 0; i < tamanho - conteudo.Length; i++)
            {
                stringbuilder.Append("0");
            }

            stringbuilder.Append(conteudo);
        }

        public void IncluirCampoAlfanumerico(StringBuilder stringbuilder, string conteudo, int tamanho)
        {
            stringbuilder.Append(conteudo);

            for (int i = 0; i < tamanho - conteudo.Length; i++)
            {
                stringbuilder.Append(" ");
            }
            
        }

        /// <summary>
        /// Passa de um stream read nome do arquiv passando para o write geralmente a
        /// entrada do Stream vai ser Response.OutputStream
        /// se houver exception não irá mostrar
        /// </summary>
        /// <param name="nomearquivo">nome do arquivo para o Read</param>
        /// <param name="stream">geralmente Response.OutputStream</param>
        public void LeStreamReadPassaStreamWrite(string nomearquivo, Stream stream)
        {
            try
            {
                StreamReader read = new StreamReader(nomearquivo);
                StreamWriter write = new StreamWriter(stream);

                string input = "";
                while ((input = read.ReadLine()) != null)
                {
                    write.WriteLine(input);
                }
                read.Close();
                write.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Passa de um stream read nome do arquiv passando para o write geralmente a
        /// entrada do Stream vai ser Response.OutputStream
        /// se houver exception não irá mostrar
        /// </summary>
        /// <param name="nomearquivo">nome do arquivo para o Read</param>
        /// <param name="stream">geralmente Response.OutputStream</param>
        public void LeStreamReadPassaStreamWrite(string nomearquivo, Stream stream, Encoding enc)
        {
            try
            {
                StreamReader read = new StreamReader(nomearquivo, enc);
                StreamWriter write = new StreamWriter(stream, enc);

                string input = "";
                while ((input = read.ReadLine()) != null)
                {
                    write.WriteLine(input);
                }
                read.Close();
                write.Close();
            }
            catch
            {

            }
        }

    }    
       
}
