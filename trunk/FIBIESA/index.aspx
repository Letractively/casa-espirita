<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form action="home.aspx">
                <div class="inputcontainer">
                    <img src="images/icons/icon_username.png" alt="Username" />
                    <label for="username">Usuário:</label>
                    <input type="text" id="username" />
                </div>
                <div class="inputcontainer">
                    <img src="images/icons/icon_locked.png" alt="Password" />

                    <label for="password">Senha:</label>
                    <input type="password" id="password" />
                </div>
                <input type="submit" value="Entrar" class="loginsubmit" />
                <p><a href="#">Esqueceu sua senha?</a></p>
            </form>
</asp:Content>
