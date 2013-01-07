<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewBairro.aspx.cs" Inherits="Admin.viewBairro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Bairros</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="Busca" runat="server" Text="Buscar" CssClass="btn" OnClick="Busca_Click" />
                &nbsp;&nbsp;&nbsp
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                    onclick="btnInserir_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                       <tr>
                       <td>
                       
                           <asp:GridView ID="grdBairros" runat="server" AutoGenerateColumns="False" 
                               BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                               CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                               onrowdeleting="grdBairros_RowDeleting" 
                               onselectedindexchanged="grdBairros_SelectedIndexChanged" PageSize="7">
                               <Columns>
                                   <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                   <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True" />
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
    </form>
</asp:Content>
