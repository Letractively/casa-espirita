<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadAcertoEstoque.aspx.cs" Inherits="FIBIESA.cadAcertoEstoque1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div id="Div1">
                    <div class="container half left">
                        <div class="conthead">
                            <h2>
                                Acerto do Estoque</h2>
                        </div>
                        <div class="contentbox">
                            <table>
                                <tr>
                                    <td style="width: 120px">
                                        * Item:
                                    </td>
                                    <td style="width: 400px">
                                        <asp:TextBox ID="txtItem" runat="server" Width="75px" CssClass="inputboxRight" AutoPostBack="True"
                                            OnTextChanged="txtItem_TextChanged" MaxLength="8"></asp:TextBox>
                                        <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                        &nbsp;
                                        <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItem"
                                            CssClass="validacao" ErrorMessage="*Informe o Item" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                        Quantidade Atual:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQtdAtual" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <strong><em>Movimentação</em></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                        * Data:
                                    </td>
                                    <td style="width: 400px">
                                        <asp:TextBox ID="txtData" runat="server" Width="100px" CssClass="inputbox" AutoPostBack="True"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtData">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtData"
                                            CssClass="validacao" ErrorMessage="*Informe a data de implantação do estoque"
                                            ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Data com formato errado"
                                        ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtData" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                        Display="Dynamic" ValidationGroup="salvar" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                        Tipo Movimento:
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rblTipoMov" runat="server" RepeatColumns="2">
                                            <asp:ListItem Value="E" Selected="True">Entrada</asp:ListItem>
                                            <asp:ListItem Value="S">Saída</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                        Qtde :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQtde" runat="server" Width="100px" CssClass="inputboxRight" 
                                            MaxLength="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validacao"
                                            ErrorMessage="*Informe a quantidade do movimento" ValidationGroup="salvar" ControlToValidate="txtQtde">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="width: 120px">
                                    </td>
                                    <td style="width: 400px">
                                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                            ValidationGroup="salvar" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;</div>
                        <asp:HiddenField ID="hfIdItem" runat="server" />
                    </div>
                    <div class="status">
                    </div>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesItem" runat="server" TargetControlID="hfIdItem"
                        DropShadow="true" PopupControlID="pnlItem" BackgroundCssClass="modalBackground"
                        OkControlID="btnCanelItem" Enabled="false">
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
                                            <asp:BoundField DataField="VALOR" HeaderText="Valor" />
                                            <asp:BoundField DataField="QUANTIDADE" HeaderText="Qtde. Estoque" />
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
