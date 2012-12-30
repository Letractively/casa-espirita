<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadJuroMulta.aspx.cs" Inherits="Admin.cadJuroMulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
<div id="content">
        		<div class="container half left">
                	<div class="conthead">
                    	<h2>Juro - Multa</h2>
                    </div>
                	<div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">Mês / Ano:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_mesAno" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Juro Dia:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_juroDia" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Juro Mês:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_juroMes" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Multa Dia:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_multaDia" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Multa Mês:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="_multaMes" runat="server" CssClass="inputbox"></asp:TextBox>
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
