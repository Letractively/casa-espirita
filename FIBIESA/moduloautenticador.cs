using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public class moduloautenticador : IHttpModule
    {
        HttpApplication application;
        HttpContext context;
        //evento pre-definido
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += (new EventHandler(this.PreRequestHandlerExecute));
        }

        //evento pre-definido
        private void PreRequestHandlerExecute(Object source, EventArgs e)
        {
            //obtem dados da aplicacao http (site)
            application = (HttpApplication)source;
            context = application.Context;
            //obtem o nome do arquivo que está sendo acessado
            string origem = context.Request.FilePath;
            if (!origem.Contains("aspx") || origem.Contains("WebForm1") || origem.Contains("Rel") || origem.Contains("default.aspx") || origem.Contains("Pesquisar.aspx") || origem.Contains("PesquisarItens.aspx") || origem.Contains("recuperacaoLogin.aspx") || origem.Contains("ops.aspx"))
            {
                return;
            }
            //se houver usuario logado, e o site já estiver carregado
            //verifica qual é o usuario para definir permissoes de acesso
            //se nao houver usuário logado, sempre direciona para a tela de login
            if (context.Session != null && context.Session["usuario"] == null)
            {
                //somente chama a tela de login se a origem nao for a propria tela
                //faz isso, pois no primeira acesso é solicitada a tela de login
                if (!origem.Contains("login.aspx"))
                {
                    //chama a tela de login
                    context.Response.Redirect("~/login.aspx", true);
                }
            }
            else
            {
                //exemplo
                //Cria objeto usuario local, baseado no objeto da sessao
                List<Usuarios> usuarios = (List<Usuarios>)context.Session["usuario"];
                PermissoesBL perBL = new PermissoesBL();                

                foreach (Usuarios ltUsu in usuarios)
                {
                    List<Permissoes> permissoes = perBL.PesquisarBL(ltUsu.CategoriaId, origem);

                    if (permissoes.Count == 0 && !origem.Contains("erroPermissao.aspx"))
                    {
                        context.Session["usuPermissoes"] = null;
                        context.Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ltUsu.Nome, true);                        
                    }
                    else
                        if (!origem.Contains("erroPermissao.aspx"))
                        {
                            Permissoes per = new Permissoes();

                            per.Editar = permissoes[0].Editar;
                            per.Excluir = permissoes[0].Excluir;
                            per.Inserir = permissoes[0].Inserir;

                            context.Session["usuPermissoes"] = per;
                        }
                }
                   
            }
        }

        //metodo padrao para descarregar a classe
        public void Dispose()
        { }
    
    }
     
}