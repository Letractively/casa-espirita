<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadDoacao.aspx.cs" Inherits="Admin.cadDoacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Doação</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">Pessoa:</td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_pessoa" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Usuário:</td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_usuario" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Data:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_data" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Valor:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_valor" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <input type="submit" value="Enviar" class="btn" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>
    </form>
</asp:Content>
