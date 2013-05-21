using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail; 

namespace FIBIESA
{
    public partial class recuperacaoLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
              try 
        { 
                DataSet ds = new DataSet(); 
                using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Integrated Security=true;Initial Catalog=MySampleDB"))
                { 
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT login, senha FROM usuarios Where Email = '" + txtSenha.Text.Trim() + "'", con); 
                        SqlDataAdapter da = new SqlDataAdapter(cmd); 
                        da.Fill(ds); 
                        con.Close(); 
                } 
                if(ds.Tables[0].Rows.Count>0) 
                { 

                    MailMessage Msg = new MailMessage(); 
                    // Sender e-mail address. 
                    Msg.From = new MailAddress(txtSenha.Text); 
                    // Recipient e-mail address. 
                    Msg.To.Add(txtSenha.Text); 
                    Msg.Subject = "Your Password Details"; 
                    Msg.Body = "Hi, \n"
                        + "Please check your Login Details \n\n"
                        + "Your Username: " + ds.Tables[0].Rows[0]["login"]
                        + "Your Password: " + ds.Tables[0].Rows[0]["senha"]; 
                    Msg.IsBodyHtml = true; 
                    // your remote SMTP server IP. 
                    SmtpClient smtp = new SmtpClient(); 
                    smtp.Host = "smtp.gmail.com"; 
                    smtp.Port = 587; 
                    smtp.Credentials = new System.Net.NetworkCredential ("yourusername@gmail.com", "yourpassword"); 
                    smtp.EnableSsl = true; 
                    smtp.Send(Msg); 
                    //Msg = null; 
                    lblMensagem.Text = "Your Password Details Sent to your mail"; 
                    // Clear the textbox valuess 
                    txtSenha.Text = ""; 
                } 
                else 
                {
                    lblMensagem.Text = "The Email you entered not exists."; 
                } 
        } 
        catch (Exception ex) 
        { 
                Console.WriteLine("{0} Exception caught.", ex); 
        } 
        }

    }
}