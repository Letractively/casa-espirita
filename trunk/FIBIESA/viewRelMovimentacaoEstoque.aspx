<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelMovimentacaoEstoque.aspx.cs" Inherits="FIBIESA.viewRelMovimentacaoEstoque" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Relatório de Movimentação de Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Item:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Usuário:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesUsuario" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Quantidade:
                        </td>
                        <td style="width: 530px" colspan="2">                            
                            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="inputbox"></asp:TextBox>                                                                
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 530px" colspan="2" style="text-align:center;">
                            <center>
                                <asp:RadioButton ID="rbEntrada" GroupName="Estoque" runat="server" CssClass="input" value="1" Text="   Entrada">                                                                                    
                                </asp:RadioButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rbSaida" GroupName="Estoque" runat="server" CssClass="input" value="0" Text="   Saída">
                                </asp:RadioButton>
                            </center>
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
                            <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" />
                        </td>                                    
                    </tr>                                        
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>