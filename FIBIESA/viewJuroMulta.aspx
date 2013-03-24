<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewJuroMulta.aspx.cs" Inherits="Admin.viewJuroMulta" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Juros e Multas</h2>
            </div>
            <div class="contentbox">
                <table>
                <tr>
                <td>
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:CalendarExtender ID="txtBusca_CalendarExtender" runat="server" 
                    TargetControlID="txtBusca">
                </asp:CalendarExtender>
                </td>
                <td>
                <asp:DropDownList ID="ddlCampo" runat="server" CssClass="dropdownlist">
                    <asp:ListItem Value="MESANO">Mês/Ano</asp:ListItem>                   
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
                               <asp:GridView ID="dtgJurosMultas" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                                   onrowdeleting="dtgJurosMultas_RowDeleting" 
                                   onselectedindexchanged="dtgJurosMultas_SelectedIndexChanged" 
                                    AllowSorting="True" GridLines="None" 
                                    onpageindexchanging="dtgJurosMultas_PageIndexChanging" 
                                    onrowdatabound="dtgJurosMultas_RowDataBound" onsorting="dtgJurosMultas_Sorting">
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
                                       <asp:BoundField DataField="MESANO" HeaderText="Mês/Ano" SortExpression="MESANO" />
                                       <asp:BoundField DataField="PERCJUROSDIA" HeaderText="% Juros Dia" SortExpression="PERCJUROSDIA" />
                                       <asp:BoundField DataField="PERCJUROSMES" HeaderText="% Juros Mês" SortExpression="PERCJUROSMES"/>
                                       <asp:BoundField DataField="PERCMULTADIA" HeaderText="Valor Multa Dia" SortExpression="PERCMULTADIA"/>
                                       <asp:BoundField DataField="PERCMULTAMES" HeaderText="Valor Multa Mês" SortExpression="PERCMULTAMES"/>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" >
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
