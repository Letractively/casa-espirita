<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewContasApagar.aspx.cs" Inherits="FIBIESA.viewContasApagarReceber" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div id="content">
        <div class="container">            
            <div class="conthead">
                <h2>Cadastro de Títulos Contas a Pagar</h2>
            </div>
            <div class="contentbox">
                <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" 
                            ToolTip="Pesquisar por"></asp:TextBox>
                   </td>               
                   <td>
                        <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                            OnClick="btnBusca_Click" />                 
                    </td>
                    <td>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                            onclick="btnInserir_Click" />
                     </td>
                    <!-- grid modelo começa aqui -->
                </tr>
                </table>
                <div class="contentbox">
                    <table width="100%">
                       <tr>
                            <td>                       
                               <asp:GridView ID="dtgTitulos" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                                   onrowdeleting="dtgTitulos_RowDeleting" 
                                   onselectedindexchanged="dtgTitulos_SelectedIndexChanged" 
                                    AllowSorting="True" GridLines="None" 
                                    onpageindexchanging="dtgTitulos_PageIndexChanging" 
                                    onrowdatabound="dtgTitulos_RowDataBound" onsorting="dtgTitulos_Sorting">
                                   <Columns>
                                       <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_edit" />
                                       </asp:CommandField>
                                       <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                       </asp:CommandField>
                                       <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                       <asp:BoundField DataField="TIPODOC" HeaderText="Tipo Doc." 
                                           SortExpression="TIPODOC" />
                                       <asp:BoundField DataField="NUMERO" HeaderText="Título" 
                                           SortExpression="NUMERO" />
                                       <asp:BoundField DataField="PARCELA" HeaderText="Parcela" 
                                           SortExpression="PARCELA" />                                       
                                       <asp:BoundField DataField="DTEMISSAO" HeaderText="Dt. Emissão" 
                                           SortExpression="DTEMISSAO" />
                                       <asp:BoundField DataField="DTVENC" HeaderText="Dt. Vencimento" 
                                           SortExpression="DTVENC" />
                                       <asp:BoundField DataField="VALOR" HeaderText="Valor" SortExpression="VALOR" />
                                       <asp:BoundField DataField="DTPAGTO" HeaderText="Dt. Pagto" 
                                           SortExpression="DTPAGTO" />
                                       <asp:BoundField DataField="VALORPAG" HeaderText="Valor Pagto" SortExpression="VALORPAG" />
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
                </div>
                <!-- grid modelo finaliza aqui -->               
            </div>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
