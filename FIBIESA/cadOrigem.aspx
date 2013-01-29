<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadOrigem.aspx.cs" Inherits="Admin.cadOrigem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
<div id="content">
        		<div class="container half left">
                	<div class="conthead">
                    	<h2>Origem</h2>
                    </div>
                	<div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">Código:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_codigo" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Descrição:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_descricao" runat="server" CssClass="inputbox"></asp:TextBox>
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
</asp:Content>
