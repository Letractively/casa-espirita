<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadPessoa.aspx.cs" Inherits="Admin.cadPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Pessoa</h2>
            </div>
            <div class="contentbox">
                <table>
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
                            Nome Fantasia:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_nomeFantasia" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            CPF/CNPJ:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_cpfCnpj" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            RG:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_rg" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Nome da Mãe:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_nomeMae" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Nome do Pai:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_nomePai" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data de Nascimento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_dataNascimento" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Estado Civil:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_estadoCivil" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Naturalidade:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_naturalidade" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Endereço:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_endeeco" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Número:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_numero" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Bairro:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_bairro" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            CEP:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_cep" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Cidade:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_cidade" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Complemento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_complemento" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Endereço Profissional:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_enderecoProfissional" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Número Profissional:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_numeroProfissional" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            CEP Profissional:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_cepProfissional" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Cidade Profissional:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_cidadeProfissional" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Complemento Profissional:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_complementoProfissional" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Empresa:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_empresa" runat="server" CssClass="inputbox"></asp:TextBox>
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
                </table>
                <table>
                    <tr>
                        <td style="width: 540px; height: 54px;">
                            <strong><em>Observação:</em></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 540px; height: 54px;">
                            <asp:TextBox ID="_observacao" runat="server" CssClass="text-input textarea" Rows="10"
                                Columns="75" TextMode="MultiLine" Width="440px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                            Categoria:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="_categoria" runat="server">
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
