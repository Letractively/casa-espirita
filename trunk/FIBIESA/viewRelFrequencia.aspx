<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelFrequencia.aspx.cs" Inherits="FIBIESA.viewRelFrequencia" %>
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
                <h2>Relatório de Frequência</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Evento:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtEvento" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesEvento" runat="server" CssClass="btn" Text="..."  />
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
                            Instrutor:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtInstrutor" runat="server" CssClass="inputbox" MaxLength="10" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesInstrutor" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Participante:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtParticipante" runat="server" CssClass="inputbox" MaxLength="10" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesParticipante" runat="server" CssClass="btn" Text="..."  />
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
                                <asp:RadioButton ID="rbComPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" value="1" Text="Com Preenchimento">                                                                                    
                                </asp:RadioButton>
                                <asp:RadioButton ID="rbSemPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" value="0" Text="Sem Preenchimento">
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
