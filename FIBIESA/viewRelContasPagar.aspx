<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelContasPagar.aspx.cs" Inherits="FIBIESA.viewRelContasPagar" %>
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
                        <h2>Relatório de Contas a Pagar</h2>
                    </div>
                    <div class="contentbox">
                        <table>                            
                            <tr>
                                <td style="width: 140px">
                                    Nro. Título(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputbox" Width="260px" 
                                        AutoPostBack="true" ontextchanged="txtTitulo_TextChanged" 
                                        ToolTip="Informe o(s)  número(s)  do(s) título(s)"></asp:TextBox>
                                    <asp:Button ID="btnPesTitulo" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesTitulo_Click"  />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtTitulo" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Associado(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtAssociado" runat="server" CssClass="inputbox" 
                                        MaxLength="10" Width="260px" AutoPostBack="true" 
                                        ontextchanged="txtAssociado_TextChanged" 
                                        ToolTip="Informe o(s) associado(s)"></asp:TextBox>
                                    <asp:Button ID="btnPesAssociado" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesAssociado_Click"  />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtAssociado" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Tipo Documento:
                                </td>
                                <td style="width: 530px">
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" 
                                        AppendDataBoundItems="True" CssClass="dropdownlist" 
                                        ToolTip="Selecione o tipo de documento">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>                                            
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
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                        ToolTip="Volta para página principal" onclick="btnVoltar_Click"
                                         />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        ValidationGroup="grupo" onclick="btnRelatorio_Click" 
                                        ToolTip="Imprime o relatório" />
                                </td>                                    
                            </tr>
                        </table>
                    </div>
                </div>
                     <asp:Panel runat="server" ID="pnlAssociado" Width="400px" CssClass="modalPopup" Style="display: none">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPesquisaAssociado" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisaAssociado_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdPesquisaAssociado" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                        DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaAssociado_RowDataBound"
                                        Width="300px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSelectAssociado" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                        OnClick="btnSelectAssociado_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                            <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnCancelAssociado" runat="server" Text="Cancelar" OnClick="btnCancelAssociado_Click"
                                        CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaAssociado" runat="server" TargetControlID="hfIdAssociado"
                        PopupControlID="pnlAssociado" BackgroundCssClass="modalBackground" DropShadow="true"
                        OkControlID="btnCancelAssociado" Enabled="false" />
                    <asp:Panel runat="server" ID="pnlTitulo" Width="400px" CssClass="modalPopup" Style="display: none">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPesquisaTitulo" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisaTitulo_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdPesquisaTitulo" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                        DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaTitulo_RowDataBound"
                                        Width="300px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSelectTitulo" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                        OnClick="btnSelectTitulo_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                            <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnCancelTitulo" runat="server" Text="Cancelar" OnClick="btnCancelTitulo_Click"
                                        CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaTitulo" runat="server" TargetControlID="hfIdTitulo"
                        PopupControlID="pnlTitulo" BackgroundCssClass="modalBackground" DropShadow="true"
                        OkControlID="btnCancelTitulo" Enabled="false" />                    
                <asp:HiddenField ID="hfIdTitulo" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdAssociado" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdPortador" runat="server" Value="0" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>