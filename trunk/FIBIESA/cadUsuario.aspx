<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadUsuario.aspx.cs" Inherits="Admin.cadUsuario" Culture="auto" UICulture="auto" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlPesquisa" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container half3 left">
                    <div class="conthead">
                        <h2>
                            Cadastro de Usuários</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 130px">
                                    Pessoa:
                                </td>
                                <td style="width: 300px">
                                    <asp:TextBox ID="txtPessoa" runat="server" CssClass="inputbox" Width="75px" ToolTip="Informe a pessoa"
                                        AutoPostBack="True" OnTextChanged="txtPessoa_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnPesPessoa" runat="server" Text="..." CssClass="btn" OnClick="btnPesPessoa_Click" />
                                    <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80px">
                                    * Categoria:
                                </td>
                                <td style="width: 300px">
                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdownlist" ToolTip="Selecione a categoria">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCategoria"
                                        CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px">
                                    Nome:
                                </td>
                                <td style="width: 300px">
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="inputbox" MaxLength="70" Width="300px"
                                        ToolTip="Informe o nome da pessoa"></asp:TextBox>
                                </td>
                                <td style="width: 80px">
                                    * Status:
                                </td>
                                <td style="width: 250px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="95px" CssClass="dropdownlist"
                                        ToolTip="Selecione o status">
                                        <asp:ListItem Value="A">Ativo</asp:ListItem>
                                        <asp:ListItem Value="I">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; height: 62px;">
                                    E-mail:
                                </td>
                                <td style="width: 300px; height: 62px;" colspan="5">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" Width="300px"
                                        ToolTip="Informe o e-mail"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*E-mail com formato errado"
                                        ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="Dynamic" ValidationGroup="salvar" CssClass="validacao"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px">
                                    * Login:
                                </td>
                                <td style="width: 300px" colspan="5">
                                    <asp:TextBox ID="txtLogin" runat="server" CssClass="inputbox" MaxLength="20" ToolTip="Informe o login"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin"
                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px">
                                    * Senha:
                                </td>
                                <td style="width: 300px" colspan="3">
                                    <asp:TextBox ID="txtSenha" runat="server" CssClass="inputbox" MaxLength="100" Width="300px"
                                        TextMode="Password" ToolTip="Informe a senha"></asp:TextBox>
                                    <asp:Label ID="lblInformacao" runat="server" CssClass="validacao" 
                                                        Font-Size="Smaller"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px">
                                    * Confirmar Senha:
                                </td>
                                <td style="width: 300px" colspan="3">
                                    <asp:TextBox ID="txtConfirmarSenha" runat="server" CssClass="inputbox" MaxLength="100"
                                        Width="300px" TextMode="Password" ToolTip="Confirmar a senha"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSenha"
                                        ControlToValidate="txtConfirmarSenha" ErrorMessage="Os valores dos campo Senha e Confirmar Senha devem ser iguais"
                                        ValidationGroup="salvar" CssClass="validacao"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px">
                                    * Data Início:
                                </td>
                                <td style="width: 300px">
                                    <asp:TextBox ID="txtDtInicio" runat="server" CssClass="inputbox" Width="110px" ToolTip="Informe a data de início"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDtInicio_CalendarExtender" runat="server" TargetControlID="txtDtInicio" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Data inválida"
                                        ToolTip="Não Válido" SetFocusOnError="true" 
                                        ControlToValidate="txtDtInicio" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                        Display="Dynamic" ValidationGroup="salvar" 
                                        CssClass="validacao"></asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 80px">
                                    * Data Fim:
                                </td>
                                <td style="width: 250px">
                                    <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" Width="110px" ToolTip="Informe da data de fim"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDtFim_CalendarExtender" runat="server" TargetControlID="txtDtFim" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Data inválida"
                                        ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtDtFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                        Display="Dynamic" ValidationGroup="salvar" CssClass="validacao"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDtInicio"
                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDtFim"
                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                </td>
                                
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 130px">
                                </td>
                                <td style="width: 300px">
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                        ToolTip="Volta para página de consulta" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                        ValidationGroup="salvar" ToolTip="Valida e salva as informações" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:HiddenField ID="hfIdPessoa" runat="server" />
                </div>
                <div class="status">
                </div>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPessoa" runat="server" PopupControlID="pnlUsuario"
                    TargetControlID="hfIdPessoa" DropShadow="true" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCanel">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlUsuario" runat="server" Width="400px" CssClass="modalPopup" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesPessoa" runat="server" CssClass="inputbox" Width="200px" OnTextChanged="txtPesPessoa_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdPesquisa" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisa_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                    OnClick="btnSelect_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                        <asp:BoundField DataField="NOME" HeaderText="Nome" />
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
                                <asp:Button ID="btnCanel" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCanel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
