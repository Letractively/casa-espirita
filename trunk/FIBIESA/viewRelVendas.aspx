<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewRelVendas.aspx.cs" Inherits="FIBIESA.viewRelVendas" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container half left">
                    <div class="conthead">
                        <h2>
                            Relatório de Vendas</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Cliente:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCliente" runat="server" CssClass="inputbox" Width="110px" AutoPostBack="true"
                                        ToolTip="Informe o cliente"></asp:TextBox>
                                    <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click" />
                                    &nbsp;
                                    <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Item:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" MaxLength="10" Width="110px"
                                        AutoPostBack="true" ToolTip="Informe o item"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                    &nbsp;
                                    <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Data Inicial:
                                </td>
                                <td style="width: 400px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox" ToolTip="Informe a data da venda"
                                                    Width="100px"></asp:TextBox><asp:CalendarExtender ID="txtDataIni_CalendarExtender"
                                                        runat="server" TargetControlID="txtDataIni" Enabled="True">
                                                    </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox" ToolTip="Informe a data de venda"
                                                    Width="100px"></asp:TextBox><asp:CalendarExtender ID="txtDataFim_CalendarExtender"
                                                        runat="server" TargetControlID="txtDataFim" Enabled="True">
                                                    </asp:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbMaisVendidos" GroupName="Vendidos" runat="server" CssClass="input"
                                        value="1" Text="Mais Vendidos" ToolTip="Imprime os itens mais vendidos"></asp:RadioButton>
                                    &nbsp;&nbsp;
                                    <asp:RadioButton ID="rbMenosVendidos" GroupName="Vendidos" runat="server" CssClass="input"
                                        value="0" Text="Menos Vendidos" ToolTip="Imprime os itens menos vendidos"></asp:RadioButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" ToolTip="Volta para página principal"
                                        OnClick="btnVoltar_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" OnClick="btnRelatorio_Click"
                                        ToolTip="Imprime o relatório" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="status">
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                    EnableScriptLocalization="true">
                </asp:ScriptManager>
                <asp:HiddenField ID="hfIdCliente" runat="server" />
                <asp:HiddenField ID="hfIdItem" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
