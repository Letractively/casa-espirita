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
    <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upnlPrincipal">
        <ContentTemplate>--%>
    <div id="content">
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
                                AutoPostBack="True"></asp:TextBox>
                            <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click" />                           
                            <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCliente"
                                CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Data:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" TargetControlID="txtData"
                                Enabled="True">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtData"
                                CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Valor:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxRight" Width="110px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValor"
                                CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
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
            <%--<iframe id="ifPesquisaGeral" runat="server" src="" >--%>
            
               
                <table>
                  
                       <tr>
                            <td>
                                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisa_TextChanged"
                                    AutoPostBack="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"<>
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
                OkControlID="btnCancel" Enabled="false"/>
        <%--  <div class="window" id="janela1">
            <a href="#" class="fechar">X Fechar</a>
            <h4>Primeira janela moda</h4>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis auctor tempus. Lorem ipsum dolor sit amet,</p>
            <p>Morbi dui lacus, placerat eget pretium vehicula, mollis id ligula. Nulla facilisi. </p>
        </div>
            <!-- mascara para cobrir o site -->
        </div>--%>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
