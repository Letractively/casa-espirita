﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadCirculacaoLivros.aspx.cs" Inherits="FIBIESA.cadCirculacaoLivros" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>
                    Empréstimo, Devolução e Renovação
                </h2>
            </div>
            <div class="contentbox">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TabContainer ID="tcPrincipal" runat="server" ActiveTabIndex="1">
                                <asp:TabPanel ID="tpUsuario" runat="server" HeaderText="Cliente/Renovação">
                                    <ContentTemplate>
                                        <table width="800PX">
                                            <tr>
                                                <td style="width: 140px">
                                                    Cliente:
                                                </td>
                                                <td style="width: 800px">
                                                    <asp:TextBox ID="txtCliente" runat="server" CssClass="inputboxRight" Width="110px"
                                                        AutoPostBack="True" OnTextChanged="txtCliente_TextChanged" ToolTip="Informe o cliente"></asp:TextBox>
                                                    <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." OnClick="btnPesCliente_Click"
                                                        CausesValidation="False" />
                                                    <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Categoria:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Situação:
                                                </td>
                                                <td>
                                                    <asp:Label ID="LblSituacao" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td colspan="2">
                                                    <asp:CheckBox ID="chkReciboRenovacao" runat="server" Text="Imprimir Recibo"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="pnlExemplar" runat="server" GroupingText="Empréstimos Ativos"
                                                    Width="100%" Height="180px" ScrollBars="Auto" BorderColor="#CCCCCC">
                                                        <asp:GridView ID="dtgExemplar" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                            DataKeyNames="ID" AllowSorting="True" GridLines="None" OnRowDataBound="dtgExemplar_RowDataBound"
                                                            PageSize="5" Width="800px">
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                                <asp:BoundField DataField="TOMBO" HeaderText="Tombo" />
                                                                <asp:BoundField DataField="TITULO" HeaderText="Título" />
                                                                <asp:BoundField DataField="RENOVAR" HeaderText="Pode Renovar?" />
                                                                <asp:BoundField DataField="DEVOLUCAO" HeaderText="Prazo Devolução" />
                                                                <asp:BoundField DataField="SITUACAO" HeaderText="Situação" />
                                                                <asp:TemplateField HeaderText="Renovar">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnRenovar" runat="server" Text="Renovar" OnClick="btnRenovar_Click"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                            <tr>                                                
                                                <td colspan="2" valign="middle" style="text-align:center;">
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Voltar" onclick="btnVoltar_Click"
                                                    ToolTip="Volta para página de consulta" />
                                                    &nbsp&nbsp&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpEmprestimo" runat="server" HeaderText="Empréstimo">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cliente:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblClienteItens" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Exemplar:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtExemplar" runat="server" CssClass="inputboxRight" Width="110px" AutoPostBack="True"
                                                        OnTextChanged="txtExemplar_TextChanged"></asp:TextBox>
                                                    <asp:Button ID="btnExemplar" runat="server" Text="..." CssClass="btn" />
                                                    <asp:Label ID="lblDesExemplar" runat="server"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExemplar"
                                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Código de barras:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCodBarras" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Situação:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSituacaoItem" runat="server"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td style="width: 140px">
                                                    Dt. Devolução:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPrevDevolucao" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td colspan="2">
                                                    <asp:CheckBox ID="chkReciboEmprestimo" runat="server" Text="Imprimir Recibo"/>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="plnItens" runat="server" GroupingText="Empréstimos" Width="100%" Height="180px" ScrollBars="Auto"
                                                        BorderColor="#CCCCCC">
                                                        <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                            DataKeyNames="ID" AllowSorting="True" GridLines="None" 
                                                            PageSize="5" Width="800px">
                                                            <Columns>
                                                                <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                                    <HeaderStyle CssClass="grd_cmd_header" />
                                                                    <ItemStyle CssClass="grd_delete" />
                                                                </asp:CommandField>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                                <asp:BoundField DataField="TOMBO" HeaderText="Tombo" />
                                                                <asp:BoundField DataField="TITULO" HeaderText="Título" />
                                                                <asp:BoundField DataField="DEVOLUCAO" HeaderText="Prazo Devolução" />                                                               
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
                                            <tr>
                                                <td colspan="2" valign="middle" style="text-align:center;">
                                                    <asp:Button ID="btnVoltarEmp" runat="server" CssClass="btn" Text="Voltar" onclick="btnVoltar_Click"
                                                    ToolTip="Volta para página de consulta" />
                                                    &nbsp&nbsp&nbsp;
                                                    <asp:Button ID="btnFinOperacoes" runat="server" CssClass="btn" Text="Emprestar" 
                                                    ToolTip="Confirma o empréstimo do(s) exemplare(s)" 
                                                        onclick="btnFinOperacoes_Click"/>                                                                                                        
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpDevolucao" runat="server" HeaderText="Devolução">
                                    <ContentTemplate>
                                        <table>                                            
                                            <tr>
                                                <td style="width: 140px">
                                                    Exemplar:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtExemplarDev" runat="server" CssClass="inputboxRight" Width="110px" AutoPostBack="True"
                                                        ></asp:TextBox>
                                                    <asp:Button ID="btnExemplarDev" runat="server" Text="..." CssClass="btn" />
                                                    <asp:Label ID="lblExemplarDev" runat="server"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExemplarDev"
                                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Código de barras:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCodBarraDev" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Situação:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSitDev" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cliente:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblClienteDev" runat="server"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>                                                
                                                <td colspan="2">
                                                    <asp:CheckBox ID="chkReciboDevolucao" runat="server" Text="Imprimir Recibo"/>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="pnlExemplarDev" runat="server" GroupingText="Devoluções" Width="100%" Height="180px" ScrollBars="Auto"
                                                        BorderColor="#CCCCCC">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                            DataKeyNames="ID" AllowSorting="True" GridLines="None" 
                                                            PageSize="5" Width="800px">
                                                            <Columns>
                                                                <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                                    <HeaderStyle CssClass="grd_cmd_header" />
                                                                    <ItemStyle CssClass="grd_delete" />
                                                                </asp:CommandField>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                                <asp:BoundField DataField="TOMBO" HeaderText="Tombo" />
                                                                <asp:BoundField DataField="TITULO" HeaderText="Título" />
                                                                <asp:BoundField DataField="DEVOLUCAO" HeaderText="Prazo Devolução" />
                                                                <asp:BoundField DataField="SITUACAO" HeaderText="Situação" />
                                                                <asp:BoundField DataField="ACAO" HeaderText="Ação" />
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
                                            <tr>
                                                <td colspan="2" valign="middle" style="text-align:center;">                                                
                                                    <asp:Button ID="btnVoltarDev" runat="server" CssClass="btn" Text="Voltar" onclick="btnVoltar_Click"
                                                    ToolTip="Volta para página de consulta" />
                                                    &nbsp&nbsp&nbsp;
                                                    <asp:Button ID="btnFinOpeDev" runat="server" CssClass="btn" Text="Devolver" 
                                                    ToolTip="Confirma a devolução do(s) exemplare(s)"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>                
            </div>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdItem" runat="server" />
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
        <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisa" runat="server" TargetControlID="hfIdPessoa"
            PopupControlID="pnlCliente" BackgroundCssClass="modalBackground" DropShadow="true"
            OkControlID="btnCancel" Enabled="false" />
    </div>
</asp:Content>