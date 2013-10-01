<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelCodigoBarras.aspx.cs" Inherits="FIBIESA.viewRelCodigoBarras" %>
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
                <div class="container half left">
                    <div class="conthead">
                        <h2>
                            Relatório de Código de Barras</h2>
                    </div>
                    <div class="contentbox">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upnlPesquisa">
                            <ProgressTemplate>
                                <center>
                                    <img id="imgCarregando" runat="server" src="~/images/loading.gif"  />
                                </center>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Exemplar(es):
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox" Width="260px" 
                                        AutoPostBack="True" ontextchanged="txtCodigo_TextChanged"  
                                        ToolTip="Intervalo Selecionado. Use ','"></asp:TextBox>
                                    <asp:Button ID="btnPesCodigo" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesCodigo_Click"  />                       
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtCodigo" ValidationExpression="^\d+(,\d+)*$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                        onclick="btnVoltar_Click" ToolTip="Volta para página principal" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        onclick="btnRelatorio_Click" ToolTip="Imprime o relatório" ValidationGroup="grupo" />
                                </td>                                    
                            </tr>
                        </table>
                    </div>
                </div>                
                <div class="status">
                </div>
                    <asp:Panel runat="server" ID="pnlExemplar" Width="400px" CssClass="modalPopup" Style="display: none">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPesquisaExemplar" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisaExemplar_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdPesquisaExemplar" runat="server" CellPadding="3" AutoGenerateColumns="False"
                                        DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaExemplar_RowDataBound"
                                        Width="400px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSelectExemplar" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                                        OnClick="btnSelectExemplar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                            <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                            <asp:BoundField DataField="TOMBO" HeaderText="Tombo" />
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
                                    <asp:Button ID="btnCancelExemplar" runat="server" Text="Cancelar" OnClick="btnCancelExemplar_Click"
                                        CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisaExemplar" runat="server" TargetControlID="hfIdExemplar"
                        PopupControlID="pnlExemplar" BackgroundCssClass="modalBackground" DropShadow="true"
                        OkControlID="btnCancelExemplar" Enabled="false" />
                <asp:HiddenField ID="hfIdAssociado" runat="server" />
                <asp:HiddenField ID="hfIdExemplar" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
