<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewNotaEntrada.aspx.cs" Inherits="Admin.viewNotaEntrada" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Notas de Entrada</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCampo" runat="server" CssClass="dropdownlist">
                                <asp:ListItem Value="NUMERO">Número</asp:ListItem>
                                <asp:ListItem Value="SERIE">Série</asp:ListItem>
                                <asp:ListItem Value="DATA">Data</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                                onclick="btnBusca_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                                onclick="btnInserir_Click" />
                        </td>
                    </tr>
                </table>
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                       <tr>
                            <td>                       
                               <asp:GridView ID="dtgNotaEntrada" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                                   onrowdeleting="dtgNotaEntrada_RowDeleting" 
                                   onselectedindexchanged="dtgNotaEntrada_SelectedIndexChanged" 
                                    AllowSorting="True" GridLines="None" ShowHeaderWhenEmpty="True" 
                                    onpageindexchanging="dtgNotaEntrada_PageIndexChanging" 
                                    onrowdatabound="dtgNotaEntrada_RowDataBound">
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
                                       <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO" />
                                       <asp:BoundField DataField="SERIE" HeaderText="Série" SortExpression="SERIE"/>
                                       <asp:BoundField DataField="DATA" HeaderText="Data" SortExpression="DATA"/>
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
            </div>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
