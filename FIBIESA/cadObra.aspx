<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadObra.aspx.cs" Inherits="Admin.cadObra" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlPesquisa" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container half3 left">
                    <div class="conthead">
                        <h2>
                            Cadastro de Obras</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td>
                                    <asp:TabContainer ID="tcPrincipal" runat="server" ActiveTabIndex="0">
                                        <asp:TabPanel ID="tpGeral" HeaderText="Geral" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            Código:
                                                        </td>
                                                        <td style="width: 120px" colspan="3">
                                                            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            * Título:
                                                        </td>
                                                        <td style="width: 120px" colspan="3">
                                                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputbox" MaxLength="100" Width="335px"
                                                                ToolTip="Informe o título"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                    runat="server" CssClass="validacao" ErrorMessage="Informe o Título da Obra" ValidationGroup="salvar"
                                                                    ControlToValidate="txtTitulo">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            * Tipo de Obra:
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:DropDownList ID="ddlTipoObra" runat="server" CssClass="dropdownlist" ToolTip="Selecione o tipo de obra">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="valTipoObra" runat="server" ControlToValidate="ddlTipoObra"
                                                                ErrorMessage="Informe o Tipo de Obra" ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            &nbsp;Número Edição:
                                                        </td>
                                                        <td style="width: 180px">
                                                            <asp:TextBox ID="txtNroEdicao" runat="server" CssClass="inputboxRight" Width="70px"
                                                                ToolTip="Informe o número da edição" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            Editora:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEditora" runat="server" CssClass="dropdownlist" ToolTip="Selecione a editora">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 120px">
                                                            ISBN:
                                                        </td>
                                                        <td style="width: 150px">
                                                            <asp:TextBox ID="txtISBN" runat="server" CssClass="inputbox" ToolTip="Informe o ISBN"
                                                                MaxLength="20"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 140px">
                                                            Número de Páginas:
                                                        </td>
                                                        <td style="width: 120px">
                                                            <asp:TextBox ID="txtNroPags" runat="server" CssClass="inputboxRight" Width="70px"
                                                                ToolTip="Informe o número de páginas" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            Local Publicação:
                                                        </td>
                                                        <td style="width: 180px">
                                                            <asp:TextBox ID="txtLocalPublic" runat="server" CssClass="inputbox" Width="204px"
                                                                MaxLength="100"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 120px">
                                                            Data Publicação:
                                                        </td>
                                                        <td style="width: 120px">
                                                            <asp:TextBox ID="txtDataPublicacao" runat="server" CssClass="inputbox" Width="110px"
                                                                ToolTip="Informe a data de publicação" MaxLength="10"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                                                ToolTip="Não Válido" SetFocusOnError="True" ControlToValidate="txtDataPublicacao"
                                                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                                Display="Dynamic" ValidationGroup="salvar" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtDataPublicacao"
                                                                Enabled="True" Format="dd/MM/yyyy">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            Data Reimpressão:
                                                        </td>
                                                        <td style="width: 180px">
                                                            <asp:TextBox ID="txtDataReimpressao" runat="server" CssClass="inputbox" Width="110px"
                                                                ToolTip="Informe a data de reimpressão" MaxLength="10"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*"
                                                                ToolTip="Não Válido" SetFocusOnError="True" ControlToValidate="txtDataReimpressao"
                                                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                                Display="Dynamic" ValidationGroup="salvar" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDataReimpressao"
                                                                Enabled="True" Format="dd/MM/yyyy">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td style="width: 120px">
                                                            Volume:
                                                        </td>
                                                        <td style="width: 120px">
                                                            <asp:TextBox ID="txtVolume" runat="server" CssClass="inputboxRight" Width="110px"
                                                                ToolTip="Informe o volume" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px">
                                                            Assuntos abordados:
                                                        </td>
                                                        <td style="width: 120px" colspan="3">
                                                            <asp:TextBox ID="txtAssuntosAborda" runat="server" CssClass="inputbox" MaxLength="4000"
                                                                Width="485px" Height="79px" TextMode="MultiLine" 
                                                                ToolTip="Informe os assuntos abordados na obra"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpAutores" runat="server" HeaderText="Autores">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Autor:
                                                        </td>
                                                        <td style="width: 400px">
                                                            <asp:TextBox ID="txtAutor" runat="server" CssClass="inputboxRight" ToolTip="Informe o código do autor - Lista de valores disponível"
                                                                Width="75px" MaxLength="10" AutoPostBack="True" 
                                                                ontextchanged="txtAutor_TextChanged"></asp:TextBox><asp:Button ID="btnAutor" runat="server" CssClass="btn"
                                                                    Text="..." OnClick="btnAutor_Click" /><asp:Label ID="lblDesAutor" runat="server"></asp:Label>
                                                        </td>                                                      
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="dtgAutores" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                                DataKeyNames="AUTORESID,OBRAID,ID" OnRowDeleting="dtgAutores_RowDeleting" AllowSorting="True"
                                                                GridLines="None" OnPageIndexChanging="dtgAutores_PageIndexChanging" OnRowDataBound="dtgAutores_RowDataBound"
                                                                OnSorting="dtgAutores_Sorting" Width="400px">
                                                                <Columns>
                                                                    <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                                        <HeaderStyle CssClass="grd_cmd_header" />
                                                                        <ItemStyle CssClass="grd_delete" />
                                                                    </asp:CommandField>
                                                                    <asp:BoundField DataField="ID" HeaderText="ID" visible="false" />                                                                
                                                                    <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO" />
                                                                    <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" SortExpression="DESCRICAO" />
                                                                    <asp:BoundField DataField="TIPO" HeaderText="Tipo" SortExpression="TIPO" />
                                                                    <asp:BoundField DataField="AUTORESID" HeaderText="AUTORESID" Visible="False" />
                                                                    <asp:BoundField DataField="OBRAID" HeaderText="OBRAID" Visible="False" />
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
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                </td>
                                <td style="width: 400px">
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                        ToolTip="Volta para a página de consulta" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                        ValidationGroup="salvar" ToolTip="Valida e salva as informações" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfId" runat="server" />
                        <asp:HiddenField ID="hfIdAutor" runat="server" />
                        <asp:HiddenField ID="hfOrdem" runat="server" />
                    </div>
                </div>
                <div class="status">
                </div>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesAutor" runat="server" TargetControlID="hfIdAutor"
                    DropShadow="true" PopupControlID="pnlAutor" BackgroundCssClass="modalBackground"
                    OkControlID="btnCanel" Enabled="false">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlAutor" runat="server" Width="400px" CssClass="modalPopup" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesAutor" runat="server" CssClass="inputbox" Width="200px" OnTextChanged="txtPesAutor_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdPesquisaAutor" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaAutor_RowDataBound">
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
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
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
