<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadParametro.aspx.cs" Inherits="Admin.cadParametro" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Parâmetros do Sistema</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>                            
                            <asp:TabContainer ID="tcParametros" runat="server" ActiveTabIndex="0" >
                                <asp:TabPanel runat="server" HeaderText="Geral" ID="tpGeral">
                                    <ContentTemplate>
                                        <table>
                                        
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="Módulo Acadêmico" ID="tpAcademico">
                                <ContentTemplate>
                                    <table>
                                    </table>
                                </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpBiblioteca" runat="server" HeaderText="Módulo Biblioteca">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:Label ID="lblQtdMaxEmp" runat="server" >
                                                Quantidade máxima de exemplares emprestado: 
                                                </asp:Label>                                                
                                             </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtQtdMaxEmp" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:Label ID="lblQtdMaxRen" runat="server" >
                                                Quantidade máxima de renovações:
                                                </asp:Label>
                                            </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtQtdMaxRen" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:label ID="lblTempoMinRetirada" runat="server">
                                                Tempo mínimo para retirada inicial de livros: 
                                                </asp:label>                                                 
                                            </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtTempoMinRetirada" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:Label ID="lblQtdMinRetirada" runat="server">
                                                Quantidade mínima para retirada inicial de livros:
                                                </asp:Label>                                             
                                            </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtQtdMinRetirada" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpEstoque" runat="server" HeaderText="Módulo Estoque">
                                <ContentTemplate>
                                    <table>
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
                                                <asp:TextBox ID="txtValorMulta" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:Label ID="lblPerLucro" runat="server">
                                                Percentual de lucro na venda: 
                                                </asp:Label>
                                            </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtPerLucro" CssClass="inputbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px"> 
                                                <asp:Label ID="lblDesconto" runat="server">
                                                Valor máximo de desconto:
                                                </asp:Label>                                             
                                            </td>
                                            <td style="width: 140px">
                                                <asp:TextBox ID="txtDesconto" CssClass="inputbox" runat="server"></asp:TextBox>
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
                                onclick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" CssClass="btn" Text="Salvar" 
                                onclick="btnSalvar_Click" />
                        </td>
                    </tr>
                </table>                
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
                </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>
    </form>
</asp:Content>
