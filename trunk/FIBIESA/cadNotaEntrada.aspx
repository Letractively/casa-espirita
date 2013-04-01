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
                <h2>Cadastro de Nota de Entrada</h2>
            </div>
            <div class="contentbox">
                <table style="width: 75%">
                    <tr>
                        <td style="width: 120px">
                            * Número:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="inputboxRight" Width="100px" 
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtNumero" ErrorMessage="Informe o número da nota" 
                                ValidationGroup="salvar" CssClass="validacao" EnableViewState="False">*</asp:RequiredFieldValidator>
                        </td>                    
                        <td style="width: 120px">
                            * Série:
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtSerie" runat="server" CssClass="inputboxRight" Width="50px" 
                                MaxLength="2"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtSerie" ErrorMessage="Informe o número de série" 
                                CssClass="validacao" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                  
                        <td style="width: 200px">
                            * Data:
                        </td>
                        <td style="width: 300px" colspan="2">
                            <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="100px" 
                                MaxLength="10"></asp:TextBox>                           
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtData">
                            </asp:CalendarExtender>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Informe a data da nota" CssClass="validacao" 
                                ControlToValidate="txtData" ValidationGroup="salvar">*</asp:RequiredFieldValidator>  
                        </td>
                    </tr>           
                    <tr>
                        <td style="width: 100px">
                            * Item:
                        </td>
                        <td  colspan="7">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputboxRight" Width="60px" 
                                AutoPostBack="True" ontextchanged="txtItem_TextChanged"></asp:TextBox> 
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click"/>
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtItem" CssClass="validacao" 
                                ErrorMessage="Informe o item" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            * Qtde:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtQtde" runat="server" CssClass="inputboxRight" Width="80px" 
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtQtde" CssClass="validacao" 
                                ErrorMessage="Informe a quantidade do item" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                   
                        <td style="width: 100px">
                            Valor:
                        </td>
                        <td style="width: 200px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxRight" Width="100px" 
                                MaxLength="10" AutoPostBack="True" ontextchanged="txtValor_TextChanged"></asp:TextBox>
                        </td>                    
                        <td style="width: 180px">
                            Valor Venda:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtValorVenda" runat="server" CssClass="inputboxRight" 
                                Width="100px" MaxLength="10"></asp:TextBox>                            
                        </td> 
                        <td>
                            <asp:Button ID="btnInserir" CssClass="btn" Text="Inserir" runat="server" 
                                onclick="btnInserir_Click" ValidationGroup="salvar" />
                        </td>                     
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Panel ID="pnlItens" runat="server" ScrollBars="Auto" >
                                <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" GridLines="None" 
                                    ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ITEMESTOQUEID" HeaderText="ITEMESTOQUEID" 
                                            Visible="False" />
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="IDITEM" HeaderText="Código" />
                                        <asp:BoundField DataField="DESCITEM" HeaderText="Desc. Item" />
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
                                Font-Bold="True" ForeColor="#CC0000" Width="120px" MaxLength="10"></asp:TextBox>
                        </td>
                        <td style="width: 80px">
                            Valor Total: 
                        </td>
                        <td style="width: 140px">
                            <asp:TextBox ID="txtTotal" runat="server" CssClass="inputbox" Font-Bold="True" 
                                ForeColor="#CC0000" Width="120px" MaxLength="10"></asp:TextBox>
                        </td>
                        <td  style="width: 100px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar"  CssClass="btn" onclick="btnVoltar_Click" 
                                />
                        </td>
                        <td  style="width: 100px">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar"  CssClass="btn" 
                                onclick="btnSalvar_Click" />
                        </td>
                    </tr>
                </table>
            </div>
             <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                CssClass="validacao" ValidationGroup="salvar" />
            <asp:HiddenField ID="hfIdItem" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:HiddenField ID="hfOrdem" runat="server" />
        </div>
        <div class="status">
           
        </div>
    </div>   
</asp:Content>
