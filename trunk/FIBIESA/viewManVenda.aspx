<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewManVenda.aspx.cs" Inherits="Admin.viewVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>
                    Manutenção de Vendas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" ToolTip="Pesquisar por"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBusca_Click" />
                        </td>
                    </tr>
                </table>
                <div class="contentbox">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="dtgVendas" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                    DataKeyNames="ID" OnSelectedIndexChanged="dtgVendas_SelectedIndexChanged" AllowSorting="True"
                                    GridLines="None" OnPageIndexChanging="dtgVendas_PageIndexChanging" OnRowDataBound="dtgVendas_RowDataBound"
                                    OnSorting="dtgVendas_Sorting">
                                    <Columns>
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" >
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_select" />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_printer.png"
                                                    OnClick="btnSelect_Click" ToolTip="Imprime o recibo de venda" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO" />
                                        <asp:BoundField DataField="DATA" HeaderText="Data" SortExpression="DATA" />
                                        <asp:BoundField DataField="SITUACAO" HeaderText="Situação" SortExpression="SITUACAO" />
                                        <asp:BoundField DataField="NOMEPESSOA" HeaderText="Cliente" SortExpression="NOMEPESSOA" />
                                        <asp:BoundField DataField="NOMEUSUARIO" HeaderText="Vendedor" SortExpression="NOMEUSUARIO" />
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
