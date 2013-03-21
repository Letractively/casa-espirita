﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewAgencia.aspx.cs" Inherits="Admin.viewAgencia" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Agências</h2>
            </div>
            <div class="contentbox">
                <table>
                <tr>
                <td>
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" 
                    ToolTip="Pesquisar por"></asp:TextBox>
                </td>
                <td>
                <asp:DropDownList ID="ddlCampo" runat="server" CssClass="dropdownlist">
                    <asp:ListItem Value="CODIGO">Código</asp:ListItem>
                    <asp:ListItem Value="DESCRICAO">Descrição</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>                
                <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                    onclick="btnBusca_Click" />
                </td>
                <td>
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                    onclick="btnInserir_Click" />
                </td>
                </tr>
                </table>
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                   <table width="100%">
                       <tr>
                            <td>                       
                               <asp:GridView ID="dtgAgencia" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                                   onrowdeleting="dtgAgencia_RowDeleting" 
                                   onselectedindexchanged="dtgAgencia_SelectedIndexChanged" 
                                    AllowSorting="True" GridLines="None" 
                                    onpageindexchanging="dtgAgencia_PageIndexChanging" 
                                    onrowdatabound="dtgAgencia_RowDataBound" onsorting="dtgAgencia_Sorting" 
                                    ShowHeaderWhenEmpty="True">
                                   <Columns>
                                       <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_edit" />
                                       </asp:CommandField>
                                       <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                       </asp:CommandField>
                                       <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                       <asp:BoundField DataField="CODIGO" HeaderText="Código" SortExpression="CODIGO"/>
                                       <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" SortExpression="DESCRICAO" />
                                       <asp:BoundField DataField="CODBANCO" HeaderText="Cód. Banco" SortExpression="CODBANCO"/>
                                       <asp:BoundField DataField="DESBANCO" HeaderText="Desc. Banco" SortExpression="DESBANCO"/>
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
            </div>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
