<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelDoacoes.aspx.cs" Inherits="FIBIESA.viewRelDoacoes" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type='text/javascript' src='Scripts/formatacao.js'></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>        
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>Relatório de Doações</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Nome:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCodPessoa" runat="server" CssClass="inputbox" Width="110px" AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnPesNome" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesNome_Click"  />
                                        &nbsp;
                                    <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Valor:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtValorIni" runat="server" CssClass="inputbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtValorFim" runat="server" CssClass="inputbox"   ></asp:TextBox>
                                       
                                             </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Data:
                                </td>
                                <td style="width: 400px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataIni_CalendarExtender" runat="server" TargetControlID="txtDataIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataFim_CalendarExtender" runat="server" TargetControlID="txtDataFim"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>                                    
                            </tr>
                            <tr>
                                <td colspan="2" valign="middle" style="text-align:center;">
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        onclick="btnRelatorio_Click" />
                                </td>                                    
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdPessoa" runat="server" />
                <asp:HiddenField ID="hfIdItem" runat="server" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>