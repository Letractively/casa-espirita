<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelContasPagarReceber.aspx.cs" Inherits="FIBIESA.viewRelContasPagarReceber" %>
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
                        <h2>Relatório de Contas a Pagar/Receber</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 530px" colspan="2" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbApagar" GroupName="Contas" runat="server" 
                                            CssClass="input" value="1" Text="  A Pagar" 
                                            ToolTip="Imprime o relatório de contas a pagar">                                                                                    
                                        </asp:RadioButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="rbAreceber" GroupName="Contas" runat="server" 
                                            CssClass="input" value="0" Text="  A Receber" 
                                            ToolTip="Imprime o relatório de contas a receber">
                                        </asp:RadioButton>
                                    </center>
                                </td>                                                                      
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Nro. Título:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputboxRight" Width="110px" 
                                        AutoPostBack="true" ontextchanged="txtTitulo_TextChanged" 
                                        ToolTip="Informe o número do título"></asp:TextBox>
                                    <asp:Button ID="btnPesTitulo" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesTitulo_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesTitulo" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Cliente/Fornecedor:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtAssociado" runat="server" CssClass="inputboxRight" 
                                        MaxLength="10" Width="110px" AutoPostBack="true" 
                                        ontextchanged="txtAssociado_TextChanged" 
                                        ToolTip="Informe o cliente/fornecedor"></asp:TextBox>
                                    <asp:Button ID="btnPesAssociado" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesAssociado_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesAssociado" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Portador:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtPortador" runat="server" CssClass="inputboxRight" MaxLength="10" 
                                        Width="110px" AutoPostBack="true" ontextchanged="txtPortador_TextChanged" 
                                        ToolTip="Informe o portador"></asp:TextBox>
                                    <asp:Button ID="btnPesPortados" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesPortados_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesPortador" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Tipo Documento:
                                </td>
                                <td style="width: 530px">
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" 
                                        AppendDataBoundItems="True" CssClass="dropdownlist" 
                                        ToolTip="Informe o tipo de documento">
                                        <asp:ListItem Text="Todos" Value="0" Selected="True" ></asp:ListItem>                                            
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
                                                <asp:TextBox ID="txtDataEmissaoIni" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de emissão"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataEmissaoIni_CalendarExtender" runat="server" TargetControlID="txtDataEmissaoIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataEmissaoIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtDataEmissaoFim" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de emissão"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataEmissaoFim_CalendarExtender" runat="server" TargetControlID="txtDataEmissaoFim"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataEmissaoFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
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
                                                <asp:TextBox ID="txtDataVencimentoIni" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de vencimento"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataVencimentoIni_CalendarExtender" runat="server" TargetControlID="txtDataVencimentoIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataVencimentoIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtDataVencimentoFim" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de vencimento"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataVencimentoFim_CalendarExtender" runat="server" TargetControlID="txtDataVencimentoFim"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataVencimentoFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
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
                                                <asp:TextBox ID="txtDataPagamentoIni" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de pagamento"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataPagamentoIni_CalendarExtender" runat="server" TargetControlID="txtDataPagamentoIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataPagamentoIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtDataPagamentoFim" runat="server" CssClass="inputbox" 
                                                    Width="100px" ToolTip="Informe a data de pagamento"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataPagamentoFim_CalendarExtender" runat="server" TargetControlID="txtDataPagamentoFim"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataPagamentoFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>                                    
                            </tr>
                            <tr>
                                <td colspan="2" valign="middle" style="text-align:center;">
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" ToolTip="Volta para página principal"
                                        OnClick="btnVoltar_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        ValidationGroup="grupo" onclick="btnRelatorio_Click" 
                                        ToolTip="Imprime o relatório" />
                                </td>                                    
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdTitulo" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdAssociado" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdPortador" runat="server" Value="0" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>