<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><div id="content">
    
        		<div class="container med left" id="graphs">
                	<div class="conthead">
                		<h2>Atalhos</h2>

                    </div>
                 
                	<div class="contentbox">
                       <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgPessoas" runat="server" AlternateText="Vendas" 
                                        ImageUrl="~/images/users1.png" 
                                        ToolTip="Abre Página de Cadastro de Pessoas" onclick="imgPessoas_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgAtaVendas" runat="server" AlternateText="Vendas" 
                                        ImageUrl="~/images/money2.png" onclick="imgAtaVendas_Click" 
                                        ToolTip="Abre Página de Vendas de Livros" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgAtaEmprestimos" runat="server" 
                                        AlternateText="Empréstimos" ImageUrl="~/images/fancybox/books.png" 
                                        ToolTip="Abre Página de Empréstimos de Livros" 
                                        onclick="imgAtaEmprestimos_Click" />
                                </td>                           
                                <td>
                                    <asp:ImageButton ID="imgAtaFrequencia" runat="server" 
                                        AlternateText="Registro de Frequência" ImageUrl="~/images/paste.png" 
                                        ToolTip="Abre Página de Registro de Frequências" 
                                        onclick="imgAtaFrequencia_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgAtaEstoque" runat="server" AlternateText="Estoque" 
                                        ImageUrl="~/images/box.png" ToolTip="Abre Página de Controle de Estoque" 
                                        onclick="imgAtaEstoque_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="5">
                                    <img src="images/LOGOUM.png" />                                    
                                </td>
                            </tr>
                       </table>                      
                    </div>
                </div>
                
              
                <div class="container sml right">
                	<div class="conthead">
                		<h2>Calendário</h2>
                    </div>
                	<div class="contentbox">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                            BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                            ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                                Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>                    	
                    </div>
                </div>

               
                <div style="clear: both"></div>
        	</div>
</asp:Content>