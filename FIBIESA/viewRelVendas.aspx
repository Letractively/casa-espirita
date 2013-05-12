<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelVendas.aspx.cs" Inherits="FIBIESA.viewRelVendas" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &#39;&#39;<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:updatepanel id="updPrincipal" runat="server" UpdateMode="Always" >
        <ContentTemplate>
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>Relatório de Vendas</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Cliente:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCliente" runat="server" CssClass="inputbox" Width="110px" 
                                         AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesCliente_Click"  />
                                        &nbsp;
                                            <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Item:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" MaxLength="10" 
                                        Width="110px" AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesItem_Click"  />
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
                                <td style="width: 530px" colspan="2" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbMaisVendidos" GroupName="Vendidos" runat="server" CssClass="input" value="1" Text="Mais Vendidos">                                                                                    
                                        </asp:RadioButton>
                                        <asp:RadioButton ID="rbMenosVendidos" GroupName="Vendidos" runat="server" CssClass="input" value="0" Text="Menos Vendidos">
                                        </asp:RadioButton>
                                    </center>
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
                <asp:HiddenField ID="hfIdCliente" runat="server" />
                <asp:HiddenField ID="hfIdItem" runat="server" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</asp:Content>