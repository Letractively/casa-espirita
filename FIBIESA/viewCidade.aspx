<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewCidade.aspx.cs" Inherits="Admin.viewCidade" %>
     <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Cidades</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" 
                    ToolTip="Pesquisar por" />
                <asp:DropDownList ID="ddlCampo" runat="server" CssClass="dropdownlist">
                    <asp:ListItem Value="CODIGO">Código</asp:ListItem>
                    <asp:ListItem Value="DESCRICAO">Descrição</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" OnClick="Busca_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                    onclick="btnInserir_Click" /> 
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                        <tr>
                            <td>
                            
                                <asp:GridView ID="dtgCidades" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                    DataKeyNames="ID" onrowdeleting="dtgCidades_RowDeleting" 
                                    onselectedindexchanged="dtgCidades_SelectedIndexChanged" GridLines="None" 
                                    onpageindexchanging="dtgCidades_PageIndexChanging" 
                                    onrowdatabound="dtgCidades_RowDataBound" onsorting="dtgCidades_Sorting" 
                                    ShowHeaderWhenEmpty="True" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header"/>
                                            <ItemStyle CssClass="grd_edit" />
                                        </asp:CommandField>                                        
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="id" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO" />
                                        <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" SortExpression="DESCRICAO" />
                                        <asp:BoundField DataField="ESTADOID" Visible="False" />
                                        <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
                                        <asp:BoundField DataField="DESESTADO" HeaderText="Estado"  
                                            SortExpression="DESESTADO"/>
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
