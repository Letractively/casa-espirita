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
                                ControlToValidate="txtDescricao" ErrorMessage="*Informe a descrição do evento" 
                                ValidationGroup="salvar" CssClass="validacao" 
                                ToolTip="Informe a descrição do evento">*</asp:RequiredFieldValidator>
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
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*Data com formato errado" ToolTip="DD/MM/YYYY" SetFocusOnError="true" 
ControlToValidate="txtDtInicio" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="salvar" 
                                CssClass="validacao">*</asp:RegularExpressionValidator>                           
                        </td>
                        <td style="width: 100px">* Dt. Fim:</td>
                        <td>
                            <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe a data de fim" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtFim_CalendarExtender" runat="server" TargetControlID="txtDtFim"
                                        Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="*Data com formato errado" SetFocusOnError="true" 
ControlToValidate="txtDtFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                            ToolTip="DD/MM/YYYY" Display="Dynamic" validationgroup="salvar" 
                                CssClass="validacao">*</asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDtInicio" CssClass="validacao" 
                                ErrorMessage="*Informe a data inicial" ValidationGroup="salvar" 
                                ToolTip="Informe a data inicial">*</asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtDtFim" CssClass="validacao" 
                                ErrorMessage="*Informe a data final" ValidationGroup="salvar" 
                                ToolTip="Informe a data final">*</asp:RequiredFieldValidator>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                CssClass="validacao" ValidationGroup="salvar" />
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
