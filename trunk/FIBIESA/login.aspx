<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
                <div class="inputcontainer">
                    <img src="images/icons/icon_username.png" alt="Username" />
                    <label for="username">Usuário:</label>
                    <asp:TextBox ID="txtLogin" runat="server" MaxLength="20" 
                        ontextchanged="txtLogin_TextChanged"></asp:TextBox>  
                </div>
                <div class="inputcontainer">
                    <img src="images/icons/icon_locked.png" alt="Password" />

                    <label for="password">Senha:</label>
                    <asp:TextBox ID="txtSenha" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>                   
                </div>                  
                <asp:Button ID="btnAcessar" Text="Acessar" CssClass="loginsubmit" 
                    runat="server" onclick="btnAcessar_Click" ValidationGroup="salvar" />            
                <p><asp:Label ID="lblMensagem" runat="server" ForeColor="#CC0000"></asp:Label> </p>
                <p><a href="recuperacaoLogin.aspx">Esqueceu sua senha?</a></p>
            </form>
</asp:Content>
