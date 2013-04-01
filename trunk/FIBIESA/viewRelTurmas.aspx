﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelTurmas.aspx.cs" Inherits="FIBIESA.viewRelTurmas" %>

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
                <h2>Relatório de Turmas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Curso:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtCurso" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesCurso" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Turma:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtTurma" runat="server" CssClass="inputbox" MaxLength="10" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesTurma" runat="server" CssClass="btn" Text="..."  />
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
                                        <asp:TextBox ID="txtDataIniF" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataIniF_CalendarExtender" runat="server" TargetControlID="txtDataIniF"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Final:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataFimI" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataFimI_CalendarExtender" runat="server" TargetControlID="txtDataFimI"
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
                                <asp:CheckBox ID="ckbLivrosMenos" GroupName="Livros" runat="server" CssClass="input" value="1" Text="Listar somente turmas em aberto.">                                                                                    
                                </asp:CheckBox>                                
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