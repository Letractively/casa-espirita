<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadNotaEntrada.aspx.cs" Inherits="Admin.cadNotaEntrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Nota de Entrada</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 100px">
                            Número:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="_numero" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>                    
                        <td style="width: 100px">
                            Série:
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="_serie" runat="server" CssClass="inputbox" Width="71px"></asp:TextBox>
                        </td>                  
                        <td style="width: 100px">
                            Data:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="_data" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Item:
                        </td>
                        <td style="width: 400px" colspan="5">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox"></asp:TextBox> 
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click"/>
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                           
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Quantidade:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtQtde" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>                   
                        <td style="width: 100px">
                            Valor:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>                    
                        <td style="width: 160px">
                            Valor Venda:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtValorVenda" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 300px">
                            <input type="submit" value="Enviar" class="btn" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
