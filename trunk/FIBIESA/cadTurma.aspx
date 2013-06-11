<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTurma.aspx.cs" Inherits="Admin.cadTurma" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>
                    Cadastro de Turmas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">                           
                            Código:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:Label ID="lblcodigo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            *
                            Descrição:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="300px" ToolTip="Informe a descrição"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="Informe da descrição" 
                                ValidationGroup="salvar" CssClass="validacao" Enabled="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 140px">
                            * Evento:
                        </td>
                        <td style="width: 400px" colspan="3">   
                            <asp:DropDownList ID="ddlEvento" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o evento">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlEvento" ErrorMessage="Informe o evento" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Instrutor:
                        </td>
                        <td style="width: 400px" colspan="3">                            
                            <asp:DropDownList ID="ddlInstrutor" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o instrutor">
                            </asp:DropDownList>                         
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Dt. Início:</td>
                        <td>
                            <asp:TextBox ID="txtDtInicio" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Selecione a data de início" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtInicio_CalendarExtender" runat="server" TargetControlID="txtDtInicio"
                                    Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtDtInicio" CssClass="validacao" 
                                ErrorMessage="Informe da data de início" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*Data com formato errado" SetFocusOnError="true" 
ControlToValidate="txtDtInicio" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                            ToolTip="DD/MM/YYYY" Display="Dynamic" validationgroup="salvar" 
                                CssClass="validacao">*</asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 140px">* Dt. Fim:</td>
                        <td>
                            <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Selecione a data de fim" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtFim_CalendarExtender" runat="server" TargetControlID="txtDtFim"
                                        Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtDtFim" CssClass="validacao" 
                                ErrorMessage="Informe da data final" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="*Data com formato errado" SetFocusOnError="true" 
ControlToValidate="txtDtFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                            ToolTip="DD/MM/YYYY" Display="Dynamic" validationgroup="salvar" 
                                CssClass="validacao">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Hora Início:</td>
                        <td>
                            <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="inputbox" 
                                Width="80px" ToolTip="Selecione a hora de início" ></asp:TextBox>                          
                        </td>
                        <td style="width: 140px">Hora Fim:</td>
                        <td>
                            <asp:TextBox ID="txtHoraFim" runat="server" CssClass="inputbox" Width="80px" 
                                ToolTip="Selecione a hora de fim" ></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Sala:</td>
                        <td>
                            <asp:TextBox ID="txtSala" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe a sala" ></asp:TextBox>                          
                        </td>
                        <td style="width: 140px">* Nro. Máximo:</td>
                        <td style="width: 400px" colspan="3"> 
                            <asp:TextBox ID="txtNroMax" runat="server" CssClass="inputbox" Width="80px" 
                                ToolTip="Informe o número máximo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtNroMax" CssClass="validacao" 
                                ErrorMessage="Informe o número máximo de alunos" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                        
                    </tr>
                    <tr>                        
                        <td style="width: 140px">Dias da Semana:</td>
                        <td colspan="3">
                            <asp:CheckBoxList ID="ckbDiasSemana" runat="server" Width="317px" Height="16px" 
                                RepeatDirection="Horizontal" TextAlign="Left">
                                <asp:ListItem Text="Domingo" Value="DOMINGO" />
                                <asp:ListItem Text="Segunda" Value="SEGUNDA" />
                                <asp:ListItem Text="Terça" Value="TERÇA" />
                                <asp:ListItem Text="Quarta" Value="QUARTA" />
                                <asp:ListItem Text="Quinta" Value="QUINTA" />
                                <asp:ListItem Text="Sexta" Value="SEXTA" />
                                <asp:ListItem Text="Sábado" Value="SÁBADO" />                                
                            </asp:CheckBoxList>                                                    
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
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnParticipantes" runat="server" Text="Participantes" 
                                CssClass="btn" onclick="btnParticipantes_Click" 
                                ToolTip="Abre a página para incluir os participantes" /> 
                        </td>
                    </tr>
                </table>                                                
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    CssClass="validacao" ValidationGroup="salvar" />
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
        
    </div>
</asp:Content>
