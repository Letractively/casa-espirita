<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewTurma.aspx.cs" Inherits="Admin.viewTurma" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Turmas</h2>
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
                                <asp:GridView ID="dtgTurmas" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" DataKeyNames="ID" onrowdeleting="dtgTurmas_RowDeleting" 
                                    onselectedindexchanged="dtgTurma_SelectedIndexChanged" GridLines="None" 
                                    onpageindexchanging="dtgTurmas_PageIndexChanging" 
                                    onrowdatabound="dtgTurmas_RowDataBound" onsorting="dtgTurmas_Sorting" 
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">                                            
                                            <ItemStyle CssClass="grd_edit" />
                                        </asp:CommandField>    
                                        <asp:CommandField ShowDeleteButton="True">
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO"/>
                                        <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" SortExpression="DESCRICAO"/>
                                        <asp:BoundField DataField="EVENTOID" HeaderText="EVENTOID" 
                                            Visible="False" />
                                        <asp:BoundField DataField="CODEVENTO" HeaderText="Cód. Evento" SortExpression="CODEVENTO"/>
                                        <asp:BoundField DataField="DESCEVENTO" HeaderText="Descrição" SortExpression="DESCEVENTO"/>
                                        <asp:BoundField DataField="DTINICIAL" HeaderText="Dt. Inicial" SortExpression="DTINICIAL" />
                                        <asp:BoundField DataField="DTFINAL" HeaderText="Dt. Final" SortExpression="DTFINAL" />
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