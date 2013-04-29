<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadVenda.aspx.cs" Inherits="FIBIESA.cadVenda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Vendas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 150px">
                            Cliente:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="inputboxRight" Width="75px"
                                AutoPostBack="True" OnTextChanged="txtCliente_TextChanged" ToolTip="Informe o cliente."></asp:TextBox>
                            <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click" />
                            &nbsp;
                            <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Informe o cliente"
                                ControlToValidate="txtCliente" CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            * Item:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputboxRight" OnTextChanged="txtItem_TextChanged"
                                Width="75px" AutoPostBack="True" ToolTip="Informe o item a ser vendido."></asp:TextBox>
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." OnClick="btnPesItem_Click" />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Informe o item"
                                ControlToValidate="txtItem" CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            * Valor Unitário:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValorUni" runat="server" CssClass="inputboxRight" Width="110px"
                                ToolTip="Informe o valor unitário do item."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtValorUni"
                                CssClass="validacao" ErrorMessage="*Informe o valor unitário" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 150px">
                            Desconto:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDesconto" runat="server" CssClass="inputboxRight" Width="110px"
                                ToolTip="Informe o valor de desconto."></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            * Quantidade:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="inputboxRight" Width="110px"
                                ToolTip="Informe a quantidade de itens a ser vendido." AutoPostBack="True" OnTextChanged="txtQuantidade_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Informe a quantidade do item"
                                ControlToValidate="txtQuantidade" CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 150px">
                            Valor:
                        </td>
                        <td style="width: 400px">
                            <asp:Label ID="lblValor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 400px" colspan="2">
                            <asp:CheckBox ID="chkImprimirRec" runat="server" Checked="false" Text="Imprimir Recibo"
                                ToolTip="Imprimir o receibo de venda" />
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnInserir" runat="server" CssClass="btn" Text="Inserir Item" OnClick="btnInserir_Click"
                                ValidationGroup="inserir" ToolTip="Confirma a seleção do item e valores." />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Panel ID="pnlDtgItens" runat="server" Width="550px" Height="180px" ScrollBars="Auto"
                                BorderColor="#CCCCCC" GroupingText="Itens">
                                <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" DataKeyNames="IDORDEM"
                                    OnRowDeleting="dtgItens_RowDeleting" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="None" OnRowDataBound="dtgItens_RowDataBound">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ITEMESTQOUEID" HeaderText="ITEMESTQOUEID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                        <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                        <asp:BoundField DataField="QUANTIDADE" HeaderText="Qtde." />
                                        <asp:BoundField DataField="VALORUNI" HeaderText="Valor Uni." />
                                        <asp:BoundField DataField="DESCONTO" HeaderText="Desconto" />
                                        <asp:BoundField DataField="VALOR" HeaderText="Valor " />
                                        <asp:BoundField DataField="IDORDEM" HeaderText="IDORDEM" Visible="False" />
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
                        <td style="width: 250px">
                            <strong>Qtd. Itens:</strong>
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtQtdItens" runat="server" CssClass="inputboxRight" Font-Bold="True"
                                ForeColor="Red" Width="110px" ReadOnly="True" ToolTip="Quantidade total de itens."></asp:TextBox>
                        </td>
                        <td style="width: 250px">
                            <strong>Valor Total:</strong>
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtValorTotal" runat="server" CssClass="inputboxRight" Font-Bold="True"
                                ForeColor="Red" Width="110px" ReadOnly="True" ToolTip="Valor total da venda."></asp:TextBox>
                        </td>
                        <td style="width: 280px">
                            <asp:Button ID="btnFinalizar" runat="server" CssClass="btn" Text="Finalizar" OnClick="btnFinalizar_Click"
                                ToolTip="Confirma e finaliza a venda." />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdItem" runat="server" />
        </div>
        <div class="status">
        </div>
        <asp:HiddenField ID="hfOrdem" runat="server" />
         <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisa" runat="server" TargetControlID="hfIdPessoa"
            PopupControlID="pnlVenda" BackgroundCssClass="modalBackground" DropShadow="true"
            OkControlID="btnCancel" Enabled="false" />

        <asp:Panel runat="server" ID="pnlVenda" Width="400px" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisa_TextChanged"
                            AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdPesquisa" runat="server" CellPadding="3" AutoGenerateColumns="False"
                            DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisa_RowDataBound"
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
</asp:Content>
