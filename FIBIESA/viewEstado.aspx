<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewEstado.aspx.cs" Inherits="Admin.viewEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Estado</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="Busca" runat="server" Text="Buscar" CssClass="btn" OnClick="Busca_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                       <tr>
                            <td>
                                <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Auto">
                                    <asp:GridView ID="grdEstados" runat="server" AutoGenerateColumns="False" 
                                        onselectedindexchanged="grdEstados_SelectedIndexChanged" 
                                        AllowSorting="True" DataKeyNames="ID">
                                        <Columns>                                   
                                            <asp:CommandField SelectText="clique aqui para selecionar o registro." ShowSelectButton="True"
                                                AccessibleHeaderText="4546">                                      
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_select" />
                                            </asp:CommandField>                                                                                       
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                            <asp:BoundField DataField="UF" HeaderText="UF" />
                                            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
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
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/icons/icon_edit.png" />
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
