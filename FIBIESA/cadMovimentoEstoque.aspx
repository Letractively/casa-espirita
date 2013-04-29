<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadMovimentoEstoque.aspx.cs" Inherits="Admin.cadMovimentoEstoque" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>
                    Movimentos do Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 80px">
                            Item:
                        </td>
                        <td style="width: 400px">
                           <asp:TextBox ID="txtItem" runat="server" CssClass="inputboxRight" Width="75px" 
                                AutoPostBack="True" ontextchanged="txtItem_TextChanged"></asp:TextBox>
                           <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click" 
                                 />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>
                        </td>                  
                        <td style="width: 80px">
                            Data:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtData" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                        
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtData">
                            </asp:CalendarExtender>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnPesquisar" runat="server" CssClass="btn" Text="Pesquisar" 
                                onclick="btnPesquisar_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="4">   
                            <asp:Panel runat="server" ID="pnlGrid" ScrollBars="Auto" Width="100%" 
                                Height="350px" BorderColor="Silver" BorderWidth="1px">                         
                            <asp:GridView ID="dtgMovItem" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" GridLines="None" onrowdatabound="dtgMovItem_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="CODITEM" HeaderText="Cód. Item" />
                                    <asp:BoundField DataField="DESCITEM" HeaderText="Descrição" />
                                    <asp:BoundField DataField="DATA" HeaderText="Data" />
                                    <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                    <asp:BoundField DataField="QTDE" HeaderText="Qtde" />
                                    <asp:BoundField DataField="VLRCUSTO" HeaderText="Vlr. Custo" />
                                    <asp:BoundField DataField="VLRVENDA" HeaderText="Vlr. Venda" />
                                    <asp:BoundField DataField="USUNOME" HeaderText="Usuário" />
                                    <asp:BoundField DataField="VENDANUM" HeaderText="Venda" />
                                    <asp:BoundField DataField="NOTAENT" HeaderText="Nota " />
                                    <asp:BoundField DataField="NOTAENTSERIE" HeaderText="Série" />
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
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 180px">
                            <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                onclick="btnVoltar_Click"></asp:Button>
                        </td>
                        <td>
                            Quantidade Total:     
                        </td>
                        <td>
                            <asp:TextBox ID="txtQtdTotal" runat="server" CssClass="inputboxRight"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
             <asp:HiddenField ID="hfIdItem" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
           
        </div>
    </div>    
</asp:Content>
