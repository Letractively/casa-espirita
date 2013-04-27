<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadManVenda.aspx.cs" Inherits="FIBIESA.cadManVenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Manutenção de Vendas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 80px">
                            Número:
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lblNumero" runat="server"></asp:Label>
                        </td>
                        <td style="width: 80px">
                            Data:
                        </td>
                        <td style="width: 300px">
                            <asp:Label ID="lblData" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px">
                            Cliente:
                        </td>
                        <td style="width: 150px" colspan="3">
                            <asp:Label ID="lblCliente" runat="server"></asp:Label>                            
                        </td>
                    </tr>                    
                    <tr>
                        <td style="width: 80px" colspan="4">
                            Itens
                         </td>                         
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Panel ID="pnlItens" runat="server">
                            <asp:GridView ID="dtgItens" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                    BorderWidth="1px" CellPadding="3" GridLines="None" 
                                    onrowdatabound="dtgItens_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_delete.png"
                                                  OnClick="btnSelect_Click"  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                    <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                    <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade" />
                                    <asp:BoundField DataField="DESCONTO" HeaderText="Desconto" />
                                    <asp:BoundField DataField="VALOR" HeaderText="Valor " />
                                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />  
                                    <asp:BoundField DataField="SITUACAO" HeaderText="Sit." />
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
                    
                </table>
                <table>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" />                             
                             &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Venda" CssClass="btn" 
                                 ValidationGroup="salvar" />   
                        </td>
                    </tr>                   
                </table>                
            </div>
            <asp:HiddenField ID="hfIdVenda" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
