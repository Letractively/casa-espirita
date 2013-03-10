<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadItemEstoque.aspx.cs" Inherits="Admin.cadItemEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Acerto de Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 141px">
                           * Item:
                        </td>
                        <td style="width: 400px">
                            
                            <asp:TextBox ID="txtItem" runat="server" Width="75px" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click" 
                                 />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                         
                            
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
                           * Quantidade:
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="67px" CssClass="inputbox"></asp:TextBox>
                        </td>
                        <td>
                            Valor:
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="67px" CssClass="inputbox"></asp:TextBox>
                        </td>
                        <td style="width: 84px">
                            Valor Venda:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Width="67px" CssClass="inputbox"></asp:TextBox>
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
             <asp:HiddenField ID="hfIdItem" runat="server" />
        </div>
        <div class="status">
           
        </div>
    </div>    
</asp:Content>
