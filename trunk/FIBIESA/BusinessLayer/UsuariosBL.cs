using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;
using FG;
using System.Net;
using System.Net.Mail;

namespace BusinessLayer
{
    public class UsuariosBL
    {
        Utils utils = new Utils();

        private bool IsValid(Usuarios usu)
        {
            bool valido;
            valido = usu.Nome.Length <= 70 && usu.Email.Length <= 100 && usu.Status.Length <= 1 && usu.Senha.Length <= 500;
            valido = valido && usu.CategoriaId > 0;
            valido = valido && usu.DtFim != null && usu.DtInicio != null && usu.Senha != null && usu.Login != null && usu.Status != null;
            return valido;
        }

        public string EnviarEmailSenha(DataSet dsUsu)
        {
            try
            {
                InstituicoesBL insBL = new InstituicoesBL();
                List<Instituicoes> instituicoes = insBL.PesquisarBL(true);

                StringBuilder msg = new StringBuilder();
                msg.Append("Olá ");
                msg.Append(dsUsu.Tables[0].Rows[0]["nome"]);
                msg.Append(", \n");
                msg.Append("Segue seus dados de login: \n");
                msg.Append("Usuário: ");
                msg.Append(dsUsu.Tables[0].Rows[0]["login"]);
                msg.Append("Senha: ");
                msg.Append(dsUsu.Tables[0].Rows[0]["senha"]);

                MailMessage Msg = new MailMessage();

                foreach (Instituicoes inst in instituicoes)
                {
                    // Sender e-mail address. 
                    Msg.From = new MailAddress(inst.Email);
                    // Recipient e-mail address. 
                    Msg.To.Add(dsUsu.Tables[0].Rows[0]["email"].ToString());
                    Msg.Subject = inst.Razao;
                    Msg.Body = msg.ToString();
                    Msg.IsBodyHtml = true;
                    Msg.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                    Msg.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                    // your remote SMTP server IP. 
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = inst.ServidorSMTP;
                    
                    if (utils.ComparaIntComZero(inst.Porta.ToString()) > 0)
                        smtp.Port = utils.ComparaIntComZero(inst.Porta.ToString());
                    
                    if(inst.Login != null || inst.Senha != null)
                        smtp.Credentials = new System.Net.NetworkCredential(inst.Login, inst.Senha);
                    
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool InserirBL(Usuarios usu)
        {
            if (IsValid(usu))
            {
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.InserirDA(usu);
            }
            return false;
        }

        public bool EditarBL(Usuarios usu)
        {
            if (usu.Id > 0 && IsValid(usu))
            {
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.EditarDA(usu);
            }
            else
                return false;
        }

        public bool ExcluirBL(Usuarios usu)
        {
            if (usu.Id > 0)
            {
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.ExcluirDA(usu);
            }
            else
                return false;
        }

        public List<Usuarios> PesquisarBL()
        {
            /*criar as regras de negocio*/
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA();
        }

        public List<Usuarios> PesquisarBL(int id_usu)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(id_usu);
        }

        public List<Usuarios> PesquisarBL(string campo, string valor)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(campo, valor);
        }

        public List<Usuarios> PesquisarBuscaBL(string valor)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarBuscaDA(valor);
        }

        public List<Usuarios> PesquisarBL(string login, string senha, DateTime data)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(login, senha, data);
        }

        public DataSet PesquisarDAEmail(string email)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDAEmail(email);
        }

    }
}
