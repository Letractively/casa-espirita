﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelCursos.aspx.cs" Inherits="FIBIESA.viewRelCursos" %>

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
                <h2>Relatório de Eventos</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Evento(s):
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtcurso" runat="server" CssClass="inputbox" Width="260px" 
                                ontextchanged="txtcurso_TextChanged" 
                                ToolTip="Informe o(s) evento(s) - Lista de valores disponível"></asp:TextBox>
                            <asp:Button ID="btnPesCurso" runat="server" CssClass="btn" Text="..." 
                                onclick="btnPesCurso_Click"  />
                            <asp:Label ID="lblDesCodigo" runat="server"></asp:Label>
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
                                        <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox" Width="100px" 
                                            ToolTip="Informe a data inicial do evento"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataIni_CalendarExtender" runat="server" TargetControlID="txtDataIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>    
                                        <asp:TextBox ID="txtDataIniF" runat="server" CssClass="inputbox" Width="100px" 
                                            ToolTip="Informe a data inicial do evento"></asp:TextBox><asp:CalendarExtender
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
                            Data Fim:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox" Width="100px" 
                                            ToolTip="Informe a data final do evento"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataFim_CalendarExtender" runat="server" TargetControlID="txtDataFim"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>     
                                        <asp:TextBox ID="txtDataFimF" runat="server" CssClass="inputbox" Width="100px" 
                                            ToolTip="Informe a data final do evento"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataFimF_CalendarExtender" runat="server" TargetControlID="txtDataFimF"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                onclick="btnVoltar_Click" ToolTip="Volta para página principal"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                onclick="btnRelatorio_Click" ToolTip="Imprime o relatório" />
                        </td>                                    
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="hfIdCodigo" runat="server" />                
        <div class="status">
        </div>
    </div>
</asp:Content>
