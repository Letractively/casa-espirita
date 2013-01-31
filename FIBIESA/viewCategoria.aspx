<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewCategoria.aspx.cs" Inherits="Admin.viewCategoria" %>
     <%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Categorias</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                    OnClick="btnBusca_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                    onclick="btnInserir_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="dtgCategorias" runat="server" AllowPaging="True" 
                                    AllowSorting="True" AutoGenerateColumns="False" 
                                    DataKeyNames="ID" onrowdeleting="dtgCategorias_RowDeleting" 
                                    onselectedindexchanged="dtgCategorias_SelectedIndexChanged" PageSize="7" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3">
                                    <Columns>
                                       <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_select" />
                                       </asp:CommandField>
                                       <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                       </asp:CommandField>
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
                    </table>
                    <div class="extrabottom">
                        <ul class="pagination">
                            <li class="text">Anterior</li>
                            <li class="page"><a href="#" title="">1</a></li>
                            <li><a href="#" title="">2</a></li>
                            <li><a href="#" title="">3</a></li>
                            <li><a href="#" title="">4</a></li>
                            <li class="text"><a href="#" title="">Próximo</a></li>
                        </ul>
                    </div>
                </div>
                <!-- grid modelo finaliza aqui -->
                <br />
                <br />
                <asp:GridView ID="GridProduto" runat="server">
                </asp:GridView>
                <br />
                <br />
                <br />
            </div>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
