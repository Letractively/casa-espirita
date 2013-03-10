<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelContasPagarReceber.aspx.cs" Inherits="FIBIESA.viewRelContasPagarReceber" %>
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
                <h2>Relatório de Contas a Pagar/Receber</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 530px" colspan="2" style="text-align:center;">
                            <center>
                                <asp:RadioButton ID="rbApagar" GroupName="Contas" runat="server" CssClass="input" value="1" Text="  A Pagar">                                                                                    
                                </asp:RadioButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rbAreceber" GroupName="Contas" runat="server" CssClass="input" value="0" Text="  A Receber">
                                </asp:RadioButton>
                            </center>
                        </td>                                                                      
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Documento:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtDocumento" runat="server" CssClass="inputbox" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesDocumento" runat="server" CssClass="btn" Text="..."  />
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
                            Portador:
                        </td>
                        <td style="width: 530px" colspan="2">
                            <asp:TextBox ID="txtPortador" runat="server" CssClass="inputbox" MaxLength="10" Width="410px"></asp:TextBox>
                            <asp:Button ID="btnPesPortados" runat="server" CssClass="btn" Text="..."  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo Documento:
                        </td>
                        <td style="width: 530px">
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Text="Selecione" Value="0" Selected="True"></asp:ListItem>                                            
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="ckbAtrasados" GroupName="Livros" runat="server" CssClass="input" value="1" Text="Listar somente documentos atrasados">                                                                                    
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Emissão:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataEmissaoIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataEmissaoIni_CalendarExtender" runat="server" TargetControlID="txtDataEmissaoIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>    
                                        <asp:TextBox ID="txtDataEmissaoFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataEmissaoFim_CalendarExtender" runat="server" TargetControlID="txtDataEmissaoFim"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Vencimento:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataVencimentoIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataVencimentoIni_CalendarExtender" runat="server" TargetControlID="txtDataVencimentoIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>    
                                        <asp:TextBox ID="txtDataVencimentoFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataVencimentoFim_CalendarExtender" runat="server" TargetControlID="txtDataVencimentoFim"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>                                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Pagamento:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDataPagamentoIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataPagamentoIni_CalendarExtender" runat="server" TargetControlID="txtDataPagamentoIni"
                                            Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>    
                                        <asp:TextBox ID="txtDataPagamentoFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                            ID="txtDataPagamentoFim_CalendarExtender" runat="server" TargetControlID="txtDataPagamentoFim"
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