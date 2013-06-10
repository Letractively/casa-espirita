<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTurmaParticipantes.aspx.cs" Inherits="Admin.cadTurmaAluno" %>

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
                            Cadastro de Participantes</h2>
                    </div>
                    <div class="contentbox">
                        <asp:Panel ID="pnParticipantes" runat="server" ScrollBars="Auto">
                            <table>
                                <tr>
                                    <td style="width: 140px">
                                        Turma:
                                    </td>
                                    <td style="width: 400px">
                                        <asp:Label ID="lblTurma" runat="server" Text=" "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 140px">
                                        * Participante:
                                    </td>
                                    <td style="width: 400px">
                                        <asp:TextBox ID="txtParticipante" runat="server" CssClass="inputbox" 
                                            ToolTip="Informe o participante" AutoPostBack="True" 
                                            ontextchanged="txtParticipante_TextChanged"></asp:TextBox>
                                        <asp:Button ID="btnPesParticipante" runat="server" CssClass="btn" Text="..." OnClick="btnPesParticipante_Click" />
                                        &nbsp;
                                        <asp:Label ID="lblDesParticipante" runat="server"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtParticipante"
                                            CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 140px">
                                    </td>
                                    <td style="width: 400px">
                                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                            ToolTip="Volta para página de cadastro de turmas" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" OnClick="btnInserir_Click"
                                            ValidationGroup="salvar" ToolTip="Inseri o participante selecionado" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="dtgParticipantes" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                            DataKeyNames="ID" PageSize="7" AllowSorting="True" OnRowDeleting="dtgParticipantes_RowDeleting"
                                            GridLines="None" OnRowDataBound="dtgParticipantes_RowDataBound" OnPageIndexChanging="dtgParticipantes_PageIndexChanging"
                                            OnSorting="dtgParticipantes_Sorting" Width="400px">
                                            <Columns>
                                                <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                    <HeaderStyle CssClass="grd_cmd_header" />
                                                    <ItemStyle CssClass="grd_delete" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO" />
                                                <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" />
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
                    </div>
                    <asp:HiddenField ID="hfIdParticipante" runat="server" />
                    <asp:HiddenField ID="hfIdTurma" runat="server" />
                    <asp:HiddenField ID="hfId" runat="server" />
                </div>
                <div class="status">
                </div>
                <asp:HiddenField ID="hfOrdem" runat="server" />
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisa" runat="server" TargetControlID="hfIdParticipante"
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
