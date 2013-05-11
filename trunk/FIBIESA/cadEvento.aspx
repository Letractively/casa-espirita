<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadEvento.aspx.cs" Inherits="Admin.cadCurso" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Eventos</h2>
            </div>
            <div class="contentbox">
                <table>
                    
                    <tr>
                        <td style="width: 140px">Código:</td>
                        <td style="width: 400px" colspan="3">
                            <asp:Label ID="lblCodigo" runat="server"></asp:Label>                           
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Descrição:</td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="70" Width="335px" ToolTip="Informe a descrição do evento"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Dt. Início:</td>
                        <td>
                            <asp:TextBox ID="txtDtInicio" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe a data de início" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtInicio_CalendarExtender" runat="server" TargetControlID="txtDtInicio"
                                    Enabled="True">
                            </asp:CalendarExtender>                           
                        </td>
                        <td style="width: 100px">* Dt. Fim:</td>
                        <td>
                            <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe a data de fim" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtFim_CalendarExtender" runat="server" TargetControlID="txtDtFim"
                                        Enabled="True">
                            </asp:CalendarExtender>
                            
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDtInicio" CssClass="validacao" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtDtFim" CssClass="validacao" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" ToolTip="Volta para página de consulta" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                ToolTip="Valida e salva as informações" />                            
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
