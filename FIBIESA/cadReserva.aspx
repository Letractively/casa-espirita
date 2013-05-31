<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadReserva.aspx.cs" Inherits="Admin.cadReserva" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <div id="content">
        <div class="container left">
            <div class="conthead">
                <h2>
                    Emprestar</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Pessoa:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtPessoa" runat="server" CssClass="inputbox" AutoPostBack="True"
                                Width="75px" OnTextChanged="txtPessoa_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnPesPessoa" runat="server" Text="..." CssClass="btn" OnClick="btnPesPessoa_Click" />
                            <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPessoa"
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Exemplar:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtExemplar" runat="server" CssClass="inputbox" Width="75px" AutoPostBack="True"
                                OnTextChanged="txtExemplar_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnExemplar" runat="server" Text="..." CssClass="btn" OnClick="btnExemplar_Click" />
                            <asp:Label ID="lblDesExemplar" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExemplar"
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data empréstimo:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtdataInicio" runat="server" CssClass="inputbox" AutoPostBack="True"
                                OnTextChanged="txtdataInicio_TextChanged"  Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtdataInicio_CalendarExtender" runat="server" TargetControlID="txtdataInicio"
                                Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdataInicio"
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Prevista Devolução:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtdataPrevisao" runat="server" CssClass="inputbox" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtdataPrevisao_CalendarExtender" runat="server" TargetControlID="txtdataPrevisao"
                                Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdataPrevisao"
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkRecibo" runat="server"  Checked="false" Text="Imprimir Recibo"
                                ToolTip="Imprimir o receibo do empréstimo."/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlHistorico" runat="server" Width="650px" Height="126px" ScrollBars="Auto"
                                BorderColor="#CCCCCC" GroupingText="Histórico de empréstimos">
                                <asp:GridView ID="dtgHistorico" runat="server" AutoGenerateColumns="False" DataKeyNames="PESSOAID"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" GridLines="None" OnRowDataBound="dtgHistorico_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="TOMBO" HeaderText="Tombo" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" HtmlEncode="False" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TITULO" HeaderText="Título" />
                                        <asp:BoundField DataField="DATAEMPRESTIMO" HeaderText="Data Empréstimo" 
                                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                        <asp:BoundField DataField="DATAPREVISTAEMPRESTIMO" HeaderText="Data Devolução" 
                                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                        <asp:BoundField DataField="SITUACAO" HeaderText="Situação" />
                                        <asp:BoundField DataField="EMPRESTIMOID" HeaderText="EMPRESTIMOID" Visible="False" />
                                        <asp:BoundField DataField="EXEMPLARID" HeaderText="EXEMPLARID" Visible="False" />
                                        <asp:BoundField DataField="PESSOAID" HeaderText="PESSOAID" Visible="False" />
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
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                ValidationGroup="salvar" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRenovar" runat="server" Text="Renovar" CssClass="btn" ValidationGroup="salvar"
                                OnClick="btnRenovar_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdExemplar" runat="server" />
        </div>
        <div class="status">
        </div>
        <asp:ModalPopupExtender ID="ModalPopupExtenderPessoas" runat="server" PopupControlID="pnlPessoa"
            TargetControlID="hfIdPessoa" DropShadow="true" BackgroundCssClass="modalBackground"
            OkControlID="btnCancel">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlPessoa" runat="server" Width="400px" CssClass="modalPopup" Style="display: none">
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
        <asp:ModalPopupExtender ID="ModalPopupExtenderExemplares" runat="server" PopupControlID="pnlExemplar"
            TargetControlID="hfIdExemplar" DropShadow="true" BackgroundCssClass="modalBackground"
            OkControlID="btnCancel">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlExemplar" runat="server" Width="400px" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPesquisaEx" runat="server" CssClass="inputbox" Width="180px"
                            OnTextChanged="txtPesquisaEx_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdPesquisaEx" runat="server" CellPadding="3" AutoGenerateColumns="False"
                            DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaEx_RowDataBound"
                            Width="300px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelectEx" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                            OnClick="btnSelectEx_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="CODIGO" HeaderText="Tombo" />
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
                        <asp:Button ID="btnCancelEx" runat="server" Text="Cancelar" OnClick="btnCancelEx_Click"
                            CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
