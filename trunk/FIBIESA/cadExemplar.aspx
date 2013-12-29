<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadExemplar.aspx.cs" Inherits="Admin.cadExemplar" %>

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
                <div class="container">
                    <div class="conthead">
                        <h2>
                            Cadastro de Exemplares</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 130px">
                                    * Obra:
                                </td>
                                <td style="width: 300px">
                                    <asp:TextBox ID="txtObra" runat="server" CssClass="inputboxRight" Width="75px" OnTextChanged="txtObra_TextChanged"
                                        AutoPostBack="True" ToolTip="Informe a obra - Lista de valores disponível" 
                                        MaxLength="10"></asp:TextBox>
                                    <asp:Button ID="btnPesObra" runat="server" Text="..." CssClass="btn" OnClick="btnPesObra_Click" />
                                    <asp:Label ID="lblDesObra" runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtObra"
                                        CssClass="validacao" ErrorMessage="*" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Tombo:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtTombo" runat="server" CssClass="inputboxRight" AutoPostBack="True"
                                        OnTextChanged="txtTombo_TextChanged" ToolTip="Informe o tombo" 
                                        MaxLength="10" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valTombo" runat="server" ControlToValidate="txtTombo"
                                        ErrorMessage="*" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblInformacao" runat="server" CssClass="validacao"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Status:
                                </td>
                                <td style="width: 400px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist" ToolTip="Selecione o status">
                                        <asp:ListItem Value="A">Ativo</asp:ListItem>
                                        <asp:ListItem Value="I">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    Origem:
                                </td>
                                <td style="width: 120px">
                                    <asp:DropDownList ID="ddlOrigem" runat="server" CssClass="dropdownlist" ToolTip="Selecione a origem">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    OBS:
                                </td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txtObs" runat="server" CssClass="inputbox" 
                                        ToolTip="Informe a Observação" Height="122px" MaxLength="500" 
                                        TextMode="MultiLine" Width="324px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                </td>
                                <td style="width: 400px">
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
                    <asp:HiddenField ID="hfIdObra" runat="server" />
                </div>
                <div class="status">
                </div>
                <asp:ModalPopupExtender ID="ModalPopupExtenderPesItem" runat="server" TargetControlID="hfIdObra"
                    DropShadow="true" PopupControlID="pnlItem" BackgroundCssClass="modalBackground"
                    OkControlID="btnCanelItem" Enabled="false">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlItem" runat="server" Width="450px" Height="450px" CssClass="modalPopup" Style="display: none" ScrollBars="Auto">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesItem" runat="server" CssClass="inputbox" Width="200px"></asp:TextBox>
                                &nbsp;&nbsp;                                
                                <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                                    onclick="btnBusca_Click"/>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCanelItem" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCanelItem_Click" />
                           
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdPesquisaItem" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                    DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"  
                                    BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaItem_RowDataBound" >
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
                    </table>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
