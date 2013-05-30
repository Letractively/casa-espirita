<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadParametro.aspx.cs" Inherits="Admin.cadParametro" %>

	
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>
                    Parâmetros do Sistema</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>
                            <asp:TabContainer ID="tcParametros" runat="server" ActiveTabIndex="0">
                                <asp:TabPanel ID="tpBiblioteca" runat="server" HeaderText="Módulo Biblioteca">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblQtdMaxEmp" runat="server">
                                                Quantidade máxima de exemplares emprestado: 
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtQtdMaxEmp" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblQtdMaxRen" runat="server">
                                                Quantidade máxima de renovações:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtQtdMaxRen" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblTempoMinRetirada" runat="server">
                                                Tempo mínimo para retirada inicial de livros (dias): 
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtTempoMinRetirada" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblQtdMinRetirada" runat="server">
                                                Quantidade mínima para retirada inicial de livros:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtQtdMinRetirada" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpFinanceiro" runat="server" HeaderText="Módulo Financeiro">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblValorMulta" runat="server">
                                                Valor da multa por atraso nos empréstimos de livros:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtValorMulta" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblDiasVctoMulta" runat="server">
                                                Prazo (em dias) para vencimento da multa:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtDiasVctoMulta" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblPortadorMulta" runat="server">
                                                Portador que vai ser associado ao título gerado em multas:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:DropDownList ID="ddlPortadorMulta" runat="server" CssClass="dropdownlist" 
                                                        ToolTip="Selecione o portador">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblPerLucro" runat="server">
                                                Percentual de lucro na venda: 
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtPerLucro" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblDesconto" runat="server">
                                                Percentual máximo de desconto:
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:TextBox ID="txtDesconto" CssClass="inputboxRight" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTipoDoc" runat="server">
                                                        Tipo de documento associado a multa por atraso na bilbioteca:
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="dropdownlist" 
                                                        ToolTip="Selecione o tipo de documento">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="Módulo Eventos" ID="tpEvento">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 400px">
                                                    <asp:Label ID="lblCategoria" runat="server">
                                            Categoria definida como instrutor : 
                                                    </asp:Label>
                                                </td>
                                                <td style="width: 140px">
                                                    <asp:DropDownList ID="ddlCategoria" CssClass="dropdownlist" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                OnClick="btnVoltar_Click" ToolTip="Volta para página principal" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" CssClass="btn" Text="Salvar" 
                                OnClick="btnSalvar_Click" ToolTip="Valida e salva as informações" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
