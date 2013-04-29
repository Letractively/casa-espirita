<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewTitulo.aspx.cs" Inherits="Admin.viewTitulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Título</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="Busca" runat="server" Text="Buscar" CssClass="btn" OnClick="Busca_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlTitulos">
                                    <Columns>
                                        <asp:BoundField DataField="numero" HeaderText="numero" 
                                            SortExpression="numero" />
                                        <asp:BoundField DataField="parcela" HeaderText="parcela" 
                                            SortExpression="parcela" />
                                        <asp:BoundField DataField="pessoaid" HeaderText="pessoaid" 
                                            SortExpression="pessoaid" />
                                        <asp:BoundField DataField="portadorid" HeaderText="portadorid" 
                                            SortExpression="portadorid" />
                                        <asp:BoundField DataField="dataVencimento" HeaderText="dataVencimento" 
                                            SortExpression="dataVencimento" />
                                        <asp:BoundField DataField="tipoDocumentoid" HeaderText="tipoDocumentoid" 
                                            SortExpression="tipoDocumentoid" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlTitulos" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                    SelectCommand="SELECT [numero], [parcela], [pessoaid], [portadorid], [dataVencimento], [tipoDocumentoid] FROM [Titulos]">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTitulo" runat="server"></asp:SqlDataSource>
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