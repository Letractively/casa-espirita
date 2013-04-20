<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadVenda.aspx.cs" Inherits="FIBIESA.cadVenda" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Vendas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 150px">
                            Cliente:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="inputboxRight" 
                                Width="75px" AutoPostBack="True" ontextchanged="txtCliente_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." 
                                onclick="btnPesCliente_Click" />
                            &nbsp;
                            <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*Informe o cliente" ControlToValidate="txtCliente" 
                                CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            *
                            Item:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputboxRight" 
                                ontextchanged="txtItem_TextChanged" Width="75px" AutoPostBack="True"></asp:TextBox> 
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click" 
                                 />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="*Informe o item" ControlToValidate="txtItem" 
                                CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            *
                            Valor Unitário:
                        </td>
                        <td style="width: 400px" >
                            <asp:TextBox ID="txtValorUni" runat="server" CssClass="inputboxRight" Width="110px"></asp:TextBox>   
                        </td>                         
                        <td style="width: 150px">
                            Desconto:
                        </td>
                        <td style="width: 400px"> 
                            <asp:TextBox ID="txtDesconto" runat="server" CssClass="inputboxRight" Width="110px"></asp:TextBox>   
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            *
                            Quantidade:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="inputboxRight" 
                                Width="110px"></asp:TextBox>   
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="*Informe a quantidade do item" 
                                ControlToValidate="txtQuantidade" CssClass="validacao" 
                                ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>                          
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            *
                            Valor:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxRight" Width="110px"></asp:TextBox>   
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ErrorMessage="*Informe o valor do item" ControlToValidate="txtValor" 
                                CssClass="validacao" ValidationGroup="inserir">*</asp:RequiredFieldValidator>
                        </td>   
                        <td colspan="2">
                            <asp:Button ID="btnInserir" runat="server" CssClass="btn" Text="Inserir" 
                                onclick="btnInserir_Click" ValidationGroup="inserir" />
                        </td>                       
                    </tr>
                    <tr>
                        <td colspan ="4">  
                            <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="IDORDEM" onrowdeleting="dtgItens_RowDeleting">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True">
                                     <HeaderStyle CssClass="grd_cmd_header" />
                                     <ItemStyle CssClass="grd_delete" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="ITEMESTQOUEID" HeaderText="ITEMESTQOUEID" 
                                        Visible="False" />
                                    <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                    <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                    <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade" />
                                    <asp:BoundField DataField="VALORUNI" HeaderText="Valor Uni." />
                                    <asp:BoundField DataField="DESCONTO" HeaderText="Desconto" />
                                    <asp:BoundField DataField="VALOR" HeaderText="Valor " />
                                    <asp:BoundField DataField="IDORDEM" HeaderText="IDORDEM" Visible="False" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 250px">
                            <strong>Qtd. Itens:</strong>                            
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtQtdItens" runat="server" CssClass="inputboxRight" 
                                Font-Bold="True" ForeColor="Red" Width="110px"></asp:TextBox>    
                        </td>
                        <td style="width: 250px">
                            <strong>Valor Total:</strong>
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtValorTotal" runat="server" CssClass="inputboxRight" 
                                Font-Bold="True" ForeColor="Red" Width="110px"></asp:TextBox>    
                        </td>
                        <td style="width: 280px">
                            <asp:Button ID="btnFinalizar" runat="server" CssClass="btn" Text="Finalizar" 
                                onclick="btnFinalizar_Click" />
                        </td>
                    </tr>
                </table>     
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    CssClass="validacao" ValidationGroup="inserir" />           
            </div>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdItem" runat="server" />
        </div>
        <div class="status">
        </div>
        <asp:HiddenField ID="hfOrdem" runat="server" />
    </div>    
</asp:Content>
