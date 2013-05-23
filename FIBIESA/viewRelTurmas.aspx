<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewRelTurmas.aspx.cs" Inherits="FIBIESA.viewRelTurmas" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>
                            Relatório de Turmas</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Evento(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCurso" runat="server" CssClass="inputbox" Width="260px" 
                                        AutoPostBack="true" ToolTip="Informe o(s) evento(s)"></asp:TextBox>
                                    <asp:Button ID="btnPesCurso" runat="server" CssClass="btn" Text="..." OnClick="btnPesCurso_Click" />
                                    <asp:Label ID="lblDesCurso" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Turma(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtTurma" runat="server" CssClass="inputbox" MaxLength="10" Width="260px"
                                        AutoPostBack="true" ToolTip="Informe a(s) turma(s)"></asp:TextBox>
                                    <asp:Button ID="btnPesTurma" runat="server" CssClass="btn" Text="..." OnClick="btnPesTurma_Click" />
                                    <asp:Label ID="lblDesTurma" runat="server"></asp:Label>
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
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data inicial" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataIni_CalendarExtender" runat="server" TargetControlID="txtDataIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataIniF" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data inicial" Width="100px"></asp:TextBox><asp:CalendarExtender
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
                                                <asp:TextBox ID="txtDataFimI" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data final" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataFimI_CalendarExtender" runat="server" TargetControlID="txtDataFimI"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data final" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataFim_CalendarExtender" runat="server" TargetControlID="txtDataFim"
                                                    Enabled="True">
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
                                    <asp:CheckBox ID="ckbTurmasAbertos" runat="server" CssClass="input" 
                                        Text="Listar somente turmas em aberto." 
                                        ToolTip="Lista somente turmas em aberto">
                                    </asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                        OnClick="btnVoltar_Click" ToolTip="Volta para página principal" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        OnClick="btnRelatorio_Click" ToolTip="Imprime o relatório" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdCurso" runat="server" />
                <asp:HiddenField ID="hfIdTurma" runat="server" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
