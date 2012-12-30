<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadUsuario.aspx.cs" Inherits="Admin.cadUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Usuário</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Login:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_login" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Senha:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_senha" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Nome:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_nome" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Status:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_status" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Início:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_dtInicio" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Fim:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_dtFim" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_tipo" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            E-mail:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_email" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Pessoa:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_pessoa" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
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
