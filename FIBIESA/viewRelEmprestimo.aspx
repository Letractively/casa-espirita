﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelEmprestimo.aspx.cs" Inherits="FIBIESA.viewRelEmprestimo" %>
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
                <h2>
                    Relatório de Empréstimos</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Codigo:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesCodigo" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Associado:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtAssociado" runat="server" CssClass="inputbox" MaxLength="10" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesAssociado" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Retirada:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataRetiradaIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataRetiradaIni_CalendarExtender" runat="server" TargetControlID="txtDataRetiradaIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>    
                                        <asp:TextBox ID="txtDataRetiradaFin" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataRetiradaFin_CalendarExtender" runat="server" TargetControlID="txtDataRetiradaFin"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Devolução:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDevolucaoIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDevolucaoIni_CalendarExtender" runat="server" TargetControlID="txtDevolucaoIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>     
                                        <asp:TextBox ID="txtDevolucaoFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDevolucaoFim_CalendarExtender" runat="server" TargetControlID="txtDevolucaoFim"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Status:
                        </td>
                        <td style="width: 530px">
                            <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Text="Selecione" Value="0" Selected="True"></asp:ListItem>                                            
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 530px" colspan="2" style="text-align:center;">
                            <center>
                                <asp:RadioButton ID="rbLivrosMenos" GroupName="Livros" runat="server" CssClass="input" value="1" Text="Livros Mais Retirados">                                                                                    
                                </asp:RadioButton>
                                <asp:RadioButton ID="rbLivrosMais" GroupName="Livros" runat="server" CssClass="input" value="0" Text="Livros Menos Retirados">
                                </asp:RadioButton>
                            </center>
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