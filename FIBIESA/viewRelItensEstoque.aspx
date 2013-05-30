<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewRelItensEstoque.aspx.cs" Inherits="FIBIESA.viewRelItensEstoque" %>

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
                        <h2>
                            Relatório de Itens em Estoque</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Item(s):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" Width="260px" AutoPostBack="true"
                                        OnTextChanged="txtItem_TextChanged" 
                                        ToolTip="Informe o(s) iten(s) - Lista de valores disponível"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                        ToolTip="Não Válida" SetFocusOnError="true" ControlToValidate="txtItem" ValidationExpression="^\d+(,\d+)*$"
                                        Display="Dynamic" ValidationGroup="grupo" ForeColor="Red" CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Controla Estoque:
                                </td>
                                <td style="width: 530px">
                                    <asp:DropDownList ID="ddlControlaEst" runat="server" AppendDataBoundItems="True"
                                        CssClass="dropdownlist" 
                                        ToolTip="Selecione se o(s) iten(s) controla estoque">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Controla Estoque" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Não Controla Estoque" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Status:
                                </td>
                                <td style="width: 530px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True" 
                                        CssClass="dropdownlist" ToolTip="Selecione o status do(s) item(s)">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Ativos" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inativos" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" OnClick="btnVoltar_Click"
                                        ToolTip="Volta para página principal" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" OnClick="btnRelatorio_Click"
                                        ValidationGroup="grupo" ToolTip="Imprime o relatório" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdItem" runat="server" Value="0" />
                <div class="status">
                </div>
                <asp:Panel runat="server" ID="pnlItem" Width="400px" CssClass="modalPopup" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisa_TextChanged"
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
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaItem" runat="server" TargetControlID="hfIdItem"
                    PopupControlID="pnlItem" BackgroundCssClass="modalBackground" DropShadow="true"
                    OkControlID="btnCancel" Enabled="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
