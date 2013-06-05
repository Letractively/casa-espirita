<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewRelVendas.aspx.cs" Inherits="FIBIESA.viewRelVendas" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container half left">
                    <div class="conthead">
                        <h2>
                            Relatório de Vendas</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Cliente(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCliente" runat="server" CssClass="inputbox" Width="260px" AutoPostBack="true"
                                        ToolTip="Informe o(s) cliente(s) - Lista de valores disponível" 
                                        ontextchanged="txtCliente_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtCliente" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Item(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" MaxLength="10" Width="260px"
                                        AutoPostBack="true" 
                                        ToolTip="Informe o(s) item(s) - Lista de valores disponível" 
                                        ontextchanged="txtItem_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtItem" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
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
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox" ToolTip="Informe a data da venda"
                                                    Width="100px"></asp:TextBox><asp:CalendarExtender ID="txtDataIni_CalendarExtender"
                                                        runat="server" TargetControlID="txtDataIni" Enabled="True">
                                                    </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox" ToolTip="Informe a data de venda"
                                                    Width="100px"></asp:TextBox><asp:CalendarExtender ID="txtDataFim_CalendarExtender"
                                                        runat="server" TargetControlID="txtDataFim" Enabled="True">
                                                    </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tipo de Relatório:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server"  ID="ddlTipoRel" CssClass="dropdownlist" ToolTip="Selecione o tipo de relatório">
                                        <asp:ListItem>Selecione</asp:ListItem>
                                        <asp:ListItem Value="1">Mais Vendidos</asp:ListItem>
                                        <asp:ListItem Value="0">Menos Vendidos</asp:ListItem>
                                    </asp:DropDownList>                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                 
                                </td>
                                <td>
                                    <asp:CheckBox ID="ckbCancelado" runat="server" Text="  Listar Vendas Canceladas" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" ToolTip="Volta para página principal"
                                        OnClick="btnVoltar_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" OnClick="btnRelatorio_Click"
                                        ToolTip="Imprime o relatório" ValidationGroup="grupo" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="status">
                </div>
                    <asp:Panel runat="server" ID="pnlCliente" Width="400px" CssClass="modalPopup" Style="display: none">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisa_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdPesquisaCliente" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                        DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaCliente_RowDataBound"
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
                            <tr>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"
                                        CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaCliente" runat="server" TargetControlID="hfIdCliente"
                        PopupControlID="pnlCliente" BackgroundCssClass="modalBackground" DropShadow="true"
                        OkControlID="btnCancel" Enabled="false" />
                    <asp:Panel runat="server" ID="pnlItem" Width="400px" CssClass="modalPopup" Style="display: none">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPesquisaItem" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisaItem_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdPesquisaItem" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                        DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaItem_RowDataBound"
                                        Width="300px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSelectItem" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                        OnClick="btnSelectItem_Click" />
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
                                    <asp:Button ID="btnCancelItem" runat="server" Text="Cancelar" OnClick="btnCancelItem_Click"
                                        CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaItem" runat="server" TargetControlID="hfIdItem"
                        PopupControlID="pnlItem" BackgroundCssClass="modalBackground" DropShadow="true"
                        OkControlID="btnCancelItem" Enabled="false" />
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                    EnableScriptLocalization="true">
                </asp:ScriptManager>
                <asp:HiddenField ID="hfIdCliente" runat="server" />
                <asp:HiddenField ID="hfIdItem" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
