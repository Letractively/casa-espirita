<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadObra.aspx.cs" Inherits="Admin.cadObra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Obra</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">Tipo de Obra:</td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_tipoObra" runat="server">
                                <asp:ListItem>Ativo</asp:ListItem>
                                <asp:ListItem>Desativado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 140px">Código:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_codigo" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Título:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_titulo" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Número da Edição:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_numeroEdicao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Local da Publicação:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_localPublicacao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Data da Publicação:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_dataPublicacao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Número de Página:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_numeroPagina" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">ISBN:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_isbn" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Assunto Aborda:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_assuntoAborda" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Data Reimpressão:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_dataReimpressao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Imagem:</td>
                        <td style="width: 400px">
                            <input name="" type="file" /> <img src="images/loading.gif" alt="Loading" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Volume:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_volume" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Origem:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_origem" runat="server" CssClass="inputbox"></asp:TextBox>
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
</asp:Content>
