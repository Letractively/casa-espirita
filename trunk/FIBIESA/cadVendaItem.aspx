<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadVendaItem.aspx.cs" Inherits="Admin.cadVendaItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
<div id="content">
        		<div class="container half left">
                	<div class="conthead">
                    	<h2>Venda de Ítem</h2>
                    </div>
                	<div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">Venda:</td>
                                <td style="width: 400px">
                                    <asp:DropDownList ID="_venda" runat="server">
                                        <asp:ListItem>Ativo</asp:ListItem>
                                        <asp:ListItem>Desativado</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Quantidade:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_quantidade" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Valor:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_valor" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Desconto:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_desconto" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>

                            </table>
                        <table>
                           <tr>
                                <td style="width: 140px"></td>
                                <td style="width: 400px"><input type="submit" value="Enviar" class="btn" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="status"></div>  
        	</div>
    </form>
</asp:Content>
