﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadContasReceber.aspx.cs" Inherits="FIBIESA.cadContasReceber" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Cadastro de Títulos Contas a Pagar</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            * Tipo de Documento:
                        </td>
                        <td style="width: 400px" colspan="3">
                          <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="dropdownlist" 
                                ToolTip="Informe o tipo de documento">                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="ddlTipoDoc" CssClass="validacao" 
                                ErrorMessage="*Informe o tipo de documento" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Título:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputboxRight" 
                                Width="100px" ToolTip="Informe o número do título"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtTitulo" CssClass="validacao" 
                                ErrorMessage="* Informe o número do título" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                        
                        <td style="width: 140px">
                            * Parcela:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtParcela" runat="server" CssClass="inputboxRight" 
                                Width="50px" ToolTip="Informe a parcela"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtParcela" CssClass="validacao" 
                                ErrorMessage="* Informe o número da parcela" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                   
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Cliente:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtFornecedor" runat="server" CssClass="inputboxRight" Width="70px"
                                AutoPostBack="True" OnTextChanged="txtFornecedor_TextChanged" 
                                ToolTip="Informe o fornecedor"></asp:TextBox>
                            <asp:Button ID="btnPesFornecedor" runat="server" CssClass="btn" Text="..." 
                                CausesValidation="False" onclick="btnPesFornecedor_Click" />
                            <asp:Label ID="lblDesFornecedor" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFornecedor"
                                CssClass="validacao" ErrorMessage="*Informe o cliente" 
                                ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>                                        
                    <tr>
                        <td style="width: 140px">
                            * Valor:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxRight" 
                                Width="100px" ToolTip="Informe o valor do título"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="txtValor" CssClass="validacao" 
                                ErrorMessage="* Informe o valor do título" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Data Emissão:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataEmissao" runat="server" CssClass="inputbox" 
                                Width="100px" ToolTip="Informe a data de emissão"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDataEmissao_CalendarExtender" runat="server" 
                                TargetControlID="txtDataEmissao">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtDataEmissao" CssClass="validacao" 
                                ErrorMessage="* Informe a data de emissão" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                    
                        <td style="width: 140px">
                            * Data Vencimento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataVencimento" runat="server" CssClass="inputbox" 
                                Width="100px" ToolTip="Informe a data de vencimento"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDataVencimento_CalendarExtender" runat="server" 
                                TargetControlID="txtDataVencimento">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtDataVencimento" CssClass="validacao" 
                                ErrorMessage="* Informe a data de vencimento" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>    
                    <tr>
                        <td style="width: 140px">
                            Data Pagamento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDtPagamento" runat="server" CssClass="inputbox" 
                                Width="100px" ToolTip="Informe a data de pagamento"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDtPagamento_CalendarExtender" runat="server" 
                                TargetControlID="txtDtPagamento">
                            </asp:CalendarExtender>
                        </td>
                        <td style="width: 140px">
                            Valor Pago:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtVlrPago" runat="server" CssClass="inputboxRight" 
                                Width="100px" ToolTip="Informe o valor pago"></asp:TextBox>
                        </td>
                    </tr> 
                     <tr>
                        <td style="width: 140px">
                            Obs:
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtObs" runat="server" CssClass="inputbox" Height="42px" 
                                MaxLength="200" TextMode="MultiLine" Width="421px" 
                                ToolTip="Informe a observação"></asp:TextBox>
                        </td>
                    </tr>                                  
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text ="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" ToolTip="Volta para página de consulta" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text ="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                ToolTip="Salva o título contas a receber" />
                            
                        </td>
                    </tr>                   
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
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
