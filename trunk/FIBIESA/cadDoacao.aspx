<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadDoacao.aspx.cs" Inherits="Admin.cadDoacao" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlPesquisa" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(formatarValor);
            </script>
            <div id="content">
                <!-- Atenção -->
                <div class="status warning">
                    <p class="closestatus">
                        <a href="" title="Close">x</a></p>
                    <p>
                        <img src="images/icons/icon_warning.png" alt="Warning" /><span>Atenção!</span> Mensagem.</p>
                </div>
                <!-- Atenção final -->
                <!-- Sucesso -->
                <div class="status success">
                    <p class="closestatus">
                        <a href="" title="Close">x</a></p>
                    <p>
                        <img src="images/icons/icon_success.png" alt="Success" /><span>Sucesso!</span> Mensagem.</p>
                </div>
                <!-- Sucesso Final -->
                <!-- Erro -->
                <div class="status error">
                    <p class="closestatus">
                        <a href="" title="Close">x</a></p>
                    <p>
                        <img src="images/icons/icon_error.png" alt="Error" /><span>Erro!</span> Mensagem.</p>
                </div>
                <!-- Erro Final -->
                <!-- Informação -->
                <div class="status info">
                    <p class="closestatus">
                        <a href="" title="Close">x</a></p>
                    <p>
                        <img src="images/icons/icon_info.png" alt="Information" /><span>Informação:</span>
                        Mensagem.</p>
                </div>
                <!-- Blue Status Bar End -->
                <div class="container half left">
                    <div class="conthead">
                        <h2>
                            Cadastro de Doações</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    * Cliente:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <asp:TextBox ID="txtCliente" runat="server" CssClass="inputboxRight" Width="110px"
                                        AutoPostBack="True" OnTextChanged="txtCliente_TextChanged" ToolTip="Informe o cliente"></asp:TextBox>
                                    <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click"
                                        CausesValidation="False" />
                                    <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCliente"
                                        CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Data:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="110px" ToolTip="Informe a data"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtData"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtData"
                                        CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Data com formato errado"
                                        ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtData" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                        Display="Dynamic" ValidationGroup="salvar" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Valor:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxValor" Width="110px"
                                        ToolTip="Informe o valor da doação" AutoPostBack="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValor"
                                        CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 400px" colspan="2">
                                    <asp:CheckBox ID="chkImprimirRecibo" runat="server" Text="Imprimir Recibo" Checked="false"
                                        ToolTip="Imprimir o recibo de doação" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                </td>
                                <td style="width: 400px">
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                        ToolTip="Volta para página principal" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                        ValidationGroup="salvar" ToolTip="Confirma e finaliza a doação" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hfIdPessoa" runat="server" />
                    <asp:HiddenField ID="hfPesquisa" runat="server" />
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
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisa" runat="server" TargetControlID="hfPesquisa"
                    PopupControlID="pnlCliente" BackgroundCssClass="modalBackground" DropShadow="true"
                    OkControlID="btnCancel" Enabled="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
