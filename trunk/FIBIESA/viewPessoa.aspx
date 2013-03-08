<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewPessoa.aspx.cs" Inherits="Admin.viewPessoa" %>
    <%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Pessoas</h2>
            </div>
            <div class="contentbox">
                <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" 
                         ToolTip="Pesquisar por"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="dropdownlist">
                        <asp:ListItem Value="CODIGO">Código</asp:ListItem>
                        <asp:ListItem Value="NOME">Nome</asp:ListItem>
                        </asp:DropDownList> 
                    </td>
                    <td>
                        <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                         onclick="btnBusca_Click" />
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblPesJurFis" runat="server" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="F">Física</asp:ListItem>
                            <asp:ListItem Value="J">Jurídica</asp:ListItem>
                       
                        </asp:RadioButtonList>
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
                                <asp:GridView ID="dtgPessoas" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" DataKeyNames="ID" onrowdeleting="dtgPessoas_RowDeleting" 
                                    onselectedindexchanged="dtgPessoas_SelectedIndexChanged" GridLines="None" 
                                    ShowHeaderWhenEmpty="True" AllowPaging="True" AllowSorting="True" 
                                    onpageindexchanging="dtgPessoas_PageIndexChanging" 
                                    onrowdatabound="dtgPessoas_RowDataBound" onsorting="dtgPessoas_Sorting">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">                                            
                                            <ItemStyle CssClass="grd_edit" />
                                        </asp:CommandField>    
                                        <asp:CommandField ShowDeleteButton="True">
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO" />
                                        <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" />
                                        <asp:BoundField DataField="CPFCNPJ" HeaderText="CPF/CNPJ" SortExpression="CPFCNPJ" />
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" SortExpression="TIPO" />
                                        <asp:BoundField DataField="CATEGORIAID" HeaderText="CATEGORIAID" 
                                            Visible="False" />
                                        <asp:BoundField DataField="DESCATEGORIA" HeaderText="Categoria" SortExpression="DESCATEGORIA" />
                                        <asp:BoundField DataField="DTCADASTRO" HeaderText="Dt. Cadastro" SortExpression="DTCADASTRO" />
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
