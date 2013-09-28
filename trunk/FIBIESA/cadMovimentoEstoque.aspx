<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadMovimentoEstoque.aspx.cs" Inherits="Admin.cadMovimentoEstoque" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container half3 left">
                    <div class="conthead">
                        <h2>
                            Movimentos do Estoque</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 80px">
                                    Item:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputboxRight" Width="75px" AutoPostBack="True"
                                        OnTextChanged="txtItem_TextChanged" ToolTip="Informe o item" MaxLength="8"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                    &nbsp;
                                    <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80px">
                                    Data:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="110px" ToolTip="Informe a data"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtData" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Data com formato errado"
                                        ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtData" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                        Display="Dynamic" ValidationGroup="salvar" ForeColor="Red"></asp:RegularExpressionValidator>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnPesquisar" runat="server" CssClass="btn" Text="Pesquisar" OnClick="btnPesquisar_Click"
                                        ToolTip="Realiza a pesquisa conforme o filtro"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="pnlGrid" ScrollBars="Auto" Width="100%" Height="350px"
                                        BorderColor="Silver" BorderWidth="1px">
                                        <asp:GridView ID="dtgMovItem" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="None"
                                            OnRowDataBound="dtgMovItem_RowDataBound" AllowPaging="True" AllowSorting="True"
                                            OnPageIndexChanging="dtgMovItem_PageIndexChanging" OnSorting="dtgMovItem_Sorting">
                                            <Columns>
                                                <asp:BoundField DataField="CODITEM" HeaderText="Cód. Item" SortExpression="CODITEM" />
                                                <asp:BoundField DataField="DESCITEM" HeaderText="Descrição" SortExpression="DESCITEM" />
                                                <asp:BoundField DataField="DATA" HeaderText="Data" SortExpression="DATA" />
                                                <asp:BoundField DataField="TIPO" HeaderText="Tipo" SortExpression="TIPO" />
                                                <asp:BoundField DataField="QTDE" HeaderText="Qtde" SortExpression="QTDE" />
                                                <asp:BoundField DataField="VLRCUSTO" HeaderText="Vlr. Custo" SortExpression="VLRCUSTO" />
                                                <asp:BoundField DataField="VLRVENDA" HeaderText="Vlr. Venda" SortExpression="VLRVENDA" />
                                                <asp:BoundField DataField="USUNOME" HeaderText="Usuário" SortExpression="USUNOME" />
                                                <asp:BoundField DataField="VENDANUM" HeaderText="Venda" SortExpression="VENDANUM" />
                                                <asp:BoundField DataField="NOTAENT" HeaderText="Nota " SortExpression="NOTAENT" />
                                                <asp:BoundField DataField="NOTAENTSERIE" HeaderText="Série" SortExpression="NOTAENTSERIE" />
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
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                </td>
                                <td style="width: 180px">
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" OnClick="btnVoltar_Click"
                                        ToolTip="Volta para página principal"></asp:Button>
                                </td>
                                <td>
                                    <strong>Quantidade Total:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQtdTotal" runat="server" CssClass="inputboxRight" Font-Bold="True"
                                        ForeColor="Red" ReadOnly="True" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hfIdItem" runat="server" />
                </div>
                <div class="status">
                </div>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesItem" runat="server" PopupControlID="pnlItem"
                    TargetControlID="hfIdItem" DropShadow="true" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCanelItem">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlItem" runat="server" Width="400px" CssClass="modalPopup" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesItem" runat="server" CssClass="inputbox" Width="200px" OnTextChanged="txtPesItem_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdPesquisaItem" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaItem_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                    OnClick="btnSelectItem_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                        <asp:BoundField DataField="TITULO" HeaderText="Título" />
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
                                <asp:Button ID="btnCanelItem" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCanelItem_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
