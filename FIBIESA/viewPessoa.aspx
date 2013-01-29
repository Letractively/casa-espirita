<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewPessoa.aspx.cs" Inherits="Admin.viewPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Pessoas</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBuscas" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                    onclick="btnInserir_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                        <tr>
                            <td>                            
                                <asp:GridView ID="dtgPessoas" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" DataKeyNames="ID" onrowdeleting="dtgPessoas_RowDeleting" 
                                    onselectedindexchanged="dtgPessoas_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">                                            
                                            <ItemStyle CssClass="grd_edit" />
                                        </asp:CommandField>    
                                        <asp:CommandField ShowDeleteButton="True">
                                            <ItemStyle CssClass="grd_delete" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                        <asp:BoundField DataField="NOME" HeaderText="Nome" />
                                        <asp:BoundField DataField="CPFCNPJ" HeaderText="CPF/CNPJ" />
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                        <asp:BoundField DataField="CATEGORIAID" HeaderText="CATEGORIAID" 
                                            Visible="False" />
                                        <asp:BoundField DataField="DESCATEGORIA" HeaderText="Categoria" />
                                        <asp:BoundField DataField="DTCADASTRO" HeaderText="Dt. Cadastro" />
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
                <br />
                <br />
                <br />
            </div>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
