<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewUsuario.aspx.cs" Inherits="Admin.viewUsuario" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Usuários</h2>
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
                                <asp:GridView ID="dtgUsuarios" runat="server" AutoGenerateColumns="False" 
                                    AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                    BorderWidth="1px" CellPadding="3" onrowdeleting="dtgUsuarios_RowDeleting" 
                                    onselectedindexchanged="dtgUsuarios_SelectedIndexChanged" 
                                    DataKeyNames="ID" AllowSorting="True" GridLines="None" 
                                    onpageindexchanging="dtgUsuarios_PageIndexChanging" onrowdatabound="dtgUsuarios_RowDataBound" 
                                    onsorting="dtgUsuarios_Sorting">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle  CssClass="grd_cmd_header"/>
                                            <ItemStyle CssClass="grd_edit" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle  CssClass="grd_cmd_header"/>
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="PESSOAID" HeaderText="PESSOAID" Visible="False" />
                                        <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" />
                                        <asp:BoundField DataField="CODCAT" HeaderText="Cód. Cat." SortExpression="CODCAT" />
                                        <asp:BoundField DataField="DESCAT" HeaderText="Desc. Categoria" SortExpression="DESCAT"/>
                                        <asp:BoundField DataField="EMAIL" HeaderText="E-mail" SortExpression="EMAIL" />                                     
                                        <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"/>
                                        <asp:BoundField DataField="DTINICIO" HeaderText="Dt. Inicio" SortExpression="DTINICIO" />
                                        <asp:BoundField DataField="DTFIM" HeaderText="Dt. Fim" SortExpression="DTFIM" />
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
