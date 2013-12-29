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
                <div class="container half left">
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
                                    <asp:TextBox ID="txtEvento" runat="server" CssClass="inputbox" Width="260px" 
                                        AutoPostBack="true" ToolTip="Informe o(s) evento(s)" 
                                        ontextchanged="txtEvento_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnPesEvento" runat="server" CssClass="btn" Text="..." OnClick="btnPesEvento_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
        ControlToValidate="txtEvento" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Turma(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtTurma" runat="server" CssClass="inputbox" MaxLength="10" Width="260px"
                                        AutoPostBack="true" ToolTip="Informe a(s) turma(s)" 
                                        ontextchanged="txtTurma_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnPesTurma" runat="server" CssClass="btn" Text="..." OnClick="btnPesTurma_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
        ControlToValidate="txtTurma" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
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
                                                    ToolTip="Informe a data inicial" Width="100px"></asp:TextBox><asp:CalendarExtender Format="dd/MM/yyyy"
                                                    ID="txtDataIni_CalendarExtender" runat="server" TargetControlID="txtDataIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
        ControlToValidate="txtDataIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                                    Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataIniF" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data inicial" Width="100px"></asp:TextBox><asp:CalendarExtender Format="dd/MM/yyyy"
                                                    ID="txtDataIniF_CalendarExtender" runat="server" TargetControlID="txtDataIniF"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
        ControlToValidate="txtDataIniF" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                                    Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
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
                                                    ToolTip="Informe a data final" Width="100px"></asp:TextBox><asp:CalendarExtender Format="dd/MM/yyyy"
                                                    ID="txtDataFimI_CalendarExtender" runat="server" TargetControlID="txtDataFimI"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
        ControlToValidate="txtDataFimI" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                                    Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox" 
                                                    ToolTip="Informe a data final" Width="100px"></asp:TextBox><asp:CalendarExtender Format="dd/MM/yyyy"
                                                    ID="txtDataFim_CalendarExtender" runat="server" TargetControlID="txtDataFim"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
        ControlToValidate="txtDataFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
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
                                        OnClick="btnRelatorio_Click" ToolTip="Imprime o relatório" validationgroup="grupo" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdEvento" runat="server" />
                <asp:HiddenField ID="hfIdTurma" runat="server" />
                <div class="status">
                </div>
                <asp:Panel runat="server" ID="pnlEvento" Width="450px" Height="450px" CssClass="modalPopup" ScrollBars="Auto" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" 
                                    onclick="btnBuscar_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"
                                    CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grdPesquisaEvento" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaEvento_RowDataBound"
                                    Width="300px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                    OnClick="btnSelect_Click" />
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
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaEvento" runat="server" TargetControlID="hfIdEvento"
                    PopupControlID="pnlEvento" BackgroundCssClass="modalBackground" DropShadow="true"
                    OkControlID="btnCancel" Enabled="false" />
                <asp:Panel runat="server" ID="pnlTurma" Width="450px" Height="450px" CssClass="modalPopup" ScrollBars="Auto" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesquisaTurma" runat="server" CssClass="inputbox" Width="180px"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnBuscarTurma" runat="server" Text="Buscar" 
                                    CssClass="btn" onclick="btnBuscarTurma_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancelTurma" runat="server" Text="Cancelar" OnClick="btnCancelTurma_Click"
                                    CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grdPesquisaTurma" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaTurma_RowDataBound"
                                    Width="300px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelectTurma" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                    OnClick="btnSelectTurma_Click" />
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
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaTurma" runat="server" TargetControlID="hfIdTurma"
                    PopupControlID="pnlTurma" BackgroundCssClass="modalBackground" DropShadow="true"
                    OkControlID="btnCancel" Enabled="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
