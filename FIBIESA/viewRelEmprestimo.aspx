﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelEmprestimo.aspx.cs" Inherits="FIBIESA.viewRelEmprestimo" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlPesquisa" runat="server" UpdateMode="Always">
        <ContentTemplate>
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
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox" Width="110px" ></asp:TextBox>
                                    <asp:Button ID="btnPesCodigo" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesCodigo_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesCodigo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Associado:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtAssociado" runat="server" CssClass="inputbox" MaxLength="10" Width="110px"></asp:TextBox>
                                    <asp:Button ID="btnPesAssociado" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesAssociado_Click"  />
                                        &nbsp;
                                    <asp:Label ID="lblDesAssociado" runat="server"></asp:Label>
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
                                        <asp:ListItem Text="Selecione" Value="" Selected="True"></asp:ListItem>                                            
                                        <asp:ListItem Text="D - Devolvido" Value="D" ></asp:ListItem>                                            
                                        <asp:ListItem Text="E - Emprestado" Value="E" ></asp:ListItem>                                            
                                        <asp:ListItem Text="A - Atrasado" Value="A" ></asp:ListItem>                                            
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 530px" colspan="2" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbLivrosMenos" GroupName="Livros" runat="server" CssClass="input" Text="  Livros Menos Retirados">                                                                                    
                                        </asp:RadioButton>
                                        &nbsp;
                                        <asp:RadioButton ID="rbLivrosMais" GroupName="Livros" runat="server" CssClass="input" Text="  Livros Mais Retirados">
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
                <asp:HiddenField ID="hfIdAssociado" runat="server" />
                <asp:HiddenField ID="hfIdCodigo" runat="server" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>