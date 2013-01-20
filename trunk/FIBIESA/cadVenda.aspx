﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadVenda.aspx.cs" Inherits="FIBIESA.cadVenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Vendas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Cliente:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." 
                                onclick="btnPesCliente_Click" />
                            &nbsp;
                            <asp:Label ID="lblDesCliente" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Item:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox"></asp:TextBox> 
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click" 
                                 />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                           
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Valor Unitário:
                        </td>
                        <td style="width: 400px" >
                            <asp:TextBox ID="txtValorUni" runat="server" CssClass="inputbox"></asp:TextBox>   
                        </td>                         
                        <td style="width: 140px">
                            Desconto:
                        </td>
                        <td style="width: 400px" colspan="2"> 
                            <asp:TextBox ID="txtDesconto" runat="server" CssClass="inputbox"></asp:TextBox>   
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Quantidade:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="inputbox"></asp:TextBox>   
                        </td>                          
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Valor:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputbox"></asp:TextBox>   
                        </td>   
                        <td colspan="2">
                            <asp:Button ID="btnInserir" runat="server" CssClass="btn" Text="Inserir" />
                        </td>                       
                    </tr>
                    <tr>
                        <td colspan ="4">
                            <asp:GridView ID="dtgItens" runat="server">
                            <EmptyDataTemplate>NO data found</EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 200px">
                            <strong>Qtd. Itens:</strong>
                        </td>
                        <td style="width: 350px">
                            <asp:TextBox ID="txtQtdItens" runat="server" CssClass="inputbox"></asp:TextBox>    
                        </td>
                        <td style="width: 200px">
                            <strong>Valor Total:</strong>
                        </td>
                        <td style="width: 350px">
                            <asp:TextBox ID="txtValorTotal" runat="server" CssClass="inputbox"></asp:TextBox>    
                        </td>
                        <td style="width: 350px">
                            <asp:Button ID="btnFinalizar" runat="server" CssClass="btn" Text="Finalizar" />
                        </td>
                    </tr>
                </table>                
            </div>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdItem" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
    </form>
</asp:Content>
