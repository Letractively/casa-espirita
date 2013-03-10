<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadItemEstoque.aspx.cs" Inherits="Admin.cadItemEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Entrada / Saída de Itens no Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 141px">
                            Item:
                        </td>
                        <td style="width: 400px">
                            
                            <asp:TextBox ID="txtItem" runat="server" Width="181px"></asp:TextBox>
                            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 141px">
                            
                            <asp:RadioButton ID="btnEntrada" runat="server" Text="Entrada" />
                        </td>
                        <td>
                           <asp:RadioButton ID="btnSaida" runat="server" Text="Saída" />    
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            Quantidade:
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="67px"></asp:TextBox>
                        </td>
                        <td>
                            Valor:
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="67px"></asp:TextBox>
                        </td>
                        <td style="width: 84px">
                            Valor Venda:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Width="67px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnIncluir" runat="server" Text="Incluir" class="btn" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            Movimentações:
                        </td>
                        <td>
                        &nbsp;<asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
