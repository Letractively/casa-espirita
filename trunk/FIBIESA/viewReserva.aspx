<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewReserva.aspx.cs" Inherits="Admin.viewReserva" %>

    <%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">            
            <div class="conthead">
                <h2>Cadastro de Empréstimos</h2>
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
                            onclick="btnBusca_Click" />                 
                    </td>
                    <td>
                        <asp:Button ID="btnInserir" runat="server" Text="Emprestar" CssClass="btn" 
                            onclick="btnInserir_Click" />
                     </td>
                    <!-- grid modelo começa aqui -->
                </tr>
                </table>
                <div class="contentbox">
                    <table width="100%">
                       <tr>
                            <td>        
                            
                            <asp:GridView ID="dtgReservas" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID"                                    
                                   onselectedindexchanged="dtgReservas_SelectedIndexChanged" 
                                    AllowSorting="True" GridLines="None" 
                                    onpageindexchanging="dtgReservas_PageIndexChanging" 
                                    onrowdatabound="dtgReservas_RowDataBound" onsorting="dtgReservas_Sorting" 
                                    Width="350px">
                                   <Columns>
                                       <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_edit" />
                                       </asp:CommandField>
                                       <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                       <asp:BoundField DataField="TOMBO" HeaderText="Tombo"  SortExpression="TOMBO" />
                                       <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="CODIGO" />
                                       <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="DESCRICAO" />
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
