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
    }
}
