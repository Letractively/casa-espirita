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
        public string LimpaFormatacaoCNPJ(string pCNPJ)
        {
            pCNPJ = pCNPJ.Replace(".", "");
            pCNPJ = pCNPJ.Replace("-", "");
            pCNPJ = pCNPJ.Replace("/", "");
            return pCNPJ;
        }

        public static bool ValidaCPF(string cpf)
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

        public static bool ValidaCNPJ(string cnpj)
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
    }
       
}
