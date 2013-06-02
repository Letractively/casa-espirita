<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadItemEstoque.aspx.cs" Inherits="Admin.cadItemEstoque" %>

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
                            Implantação do Estoque</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 120px">
                                    * Item:
                                </td>
                                <td style="width: 180px" colspan="3">
                                    <asp:TextBox ID="txtItem" runat="server" Width="75px" CssClass="inputboxRight" AutoPostBack="True"
                                        OnTextChanged="txtItem_TextChanged" 
                                        ToolTip="Informe o item - Lista de valores disponível"></asp:TextBox>
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                                    &nbsp;
                                    <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItem"
                                        CssClass="validacao" ErrorMessage="*Informe o Item" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    * Data:
                                </td>
                                <td style="width: 180px">
                                    <asp:TextBox ID="txtData" runat="server" Width="100px" CssClass="inputbox" 
                                        AutoPostBack="True" ToolTip="Informe a data"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtData">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtData"
                                        CssClass="validacao" ErrorMessage="*Informe a data de implantação do estoque"
                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 120px">
                                    * Status:
                                </td>
                                <td style="width: 180px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist" 
                                        ToolTip="Selecione o status do item">
                                        <asp:ListItem Value="A" Selected="True">Ativo</asp:ListItem>
                                        <asp:ListItem Value="I">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    Qtd. Mínima:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQtdMin" runat="server" Width="100px" 
                                        CssClass="inputboxRight" 
                                        ToolTip="Informe a quantidade mínima do item no estoque"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="chkControlaEstoque" runat="server" Text="Controla Estoque" 
                                        ToolTip="Indica se o item controla estoque" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    Custo Médio:
                                </td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtVlrMedio" runat="server" Width="100px" 
                                        CssClass="inputboxValor" ToolTip="Informe o custo médio"></asp:TextBox>
                                </td>
                                <td style="width: 120px">
                                    Valor Venda:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVlrVenda" runat="server" Width="100px" 
                                        CssClass="inputboxValor" ToolTip="Informe o valor de venda"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 120px">
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                        OnClick="btnVoltar_Click" ToolTip="Volta para página principal" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                        ValidationGroup="salvar" ToolTip="Valida e salva as informações" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hfIdItem" runat="server" />
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                        EnableScriptLocalization="true">
                    </asp:ScriptManager>
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
