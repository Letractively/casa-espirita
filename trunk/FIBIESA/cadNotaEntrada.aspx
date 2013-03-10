<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadNotaEntrada.aspx.cs" Inherits="Admin.cadNotaEntrada" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Nota de Entrada</h2>
            </div>
            <div class="contentbox">
                <table style="width: 80%">
                    <tr>
                        <td style="width: 120px">
                            * Número:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtNumero" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>                    
                        <td style="width: 120px">
                            * Série:
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtSerie" runat="server" CssClass="inputbox" Width="71px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtSerie" ErrorMessage="*Preenchimento Obrigatório" 
                                CssClass="validacao" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>                  
                        <td style="width: 200px">
                            * Data:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                           
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtData">
                            </asp:CalendarExtender>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="*Preenchimento Obrigatório" CssClass="validacao" 
                                ControlToValidate="txtData" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            * Item:
                        </td>
                        <td  colspan="5">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox"></asp:TextBox> 
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click"/>
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtItem" CssClass="validacao" 
                                ErrorMessage="* Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            * Qtde:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtQtde" runat="server" CssClass="inputbox" Width="91px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtQtde" CssClass="validacao" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>                   
                        <td style="width: 100px">
                            Valor:
                        </td>
                        <td style="width: 200px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputbox" Width="111px"></asp:TextBox>
                        </td>                    
                        <td style="width: 180px">
                            Valor Venda:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtValorVenda" runat="server" CssClass="inputbox" 
                                Width="111px"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnInserir" CssClass="btn" Text="Inserir" runat="server" 
                                onclick="btnInserir_Click" />
                        </td>                      
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Panel ID="pnlItens" runat="server" ScrollBars="Auto" >
                                <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" 
                                    onselectedindexchanged="dtgItens_SelectedIndexChanged" GridLines="None" 
                                    ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="IDITEM" HeaderText="IDITEM" Visible="False" />
                                        <asp:BoundField DataField="DESCITEM" HeaderText="Item" />
                                        <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade" />
                                        <asp:BoundField DataField="VALOR" HeaderText="Valor Uni." />
                                        <asp:BoundField DataField="VALORTOTAL" HeaderText="Valor Total" />
                                        <asp:BoundField DataField="VALORVENDA" HeaderText="Valor Venda" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 80px">
                            Total Itens: 
                        </td>
                        <td style="width: 150px">
                            <asp:TextBox ID="txtTotItens" runat="server" CssClass="inputbox" 
                                Font-Bold="True" ForeColor="#CC0000"></asp:TextBox>
                        </td>
                        <td style="width: 80px">
                            Valor Total: 
                        </td>
                        <td style="width: 200px">
                            <asp:TextBox ID="txtTotal" runat="server" CssClass="inputbox" Font-Bold="True" 
                                ForeColor="#CC0000"></asp:TextBox>
                        </td>
                        <td  style="width: 100px">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar"  CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfIdItem" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
