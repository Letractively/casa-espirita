<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewPesqEvento.aspx.cs" Inherits="Admin.viewPesqEvento" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upnlPrincipal" UpdateMode="Always">
        <ContentTemplate>        
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>Pesquisa Eventos</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox" MaxLength="70" 
                                    ToolTip="Pesquisar por" Width="352px" ontextchanged="txtBusca_TextChanged"></asp:TextBox>
                            </td>               
                            <td>
                            <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn" 
                                OnClick="btnBusca_Click" />
                            </td>                    
                        </tr>
                        </table>
                        <!-- grid modelo começa aqui -->
                        <div class="contentbox">
                            <table width="100%">
                               <tr>
                                    <td>                       
                                       <asp:GridView ID="dtgEventos" runat="server" AutoGenerateColumns="False" 
                                           BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                           CellPadding="3" AllowPaging="True" DataKeyNames="ID" 
                                            AllowSorting="True" GridLines="None"
                                            onpageindexchanging="dtgEventos_PageIndexChanging" PageSize="2"
                                            onrowdatabound="dtgEventos_RowDataBound" 
                                            Width="450px">
                                           <Columns>                                       
                                               <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                               <asp:BoundField DataField="codEvento" HeaderText="Código" SortExpression="codEvento" />
                                               <asp:BoundField DataField="EVENTO" HeaderText="Evento" SortExpression="EVENTO" />
                                               <asp:BoundField DataField="dtInicio" HeaderText="Dt. Inicio" SortExpression="dtInicio" />
                                               <asp:BoundField DataField="dtFimEvento" HeaderText="Dt. Fim" SortExpression="dtFimEvento" />
                                               <asp:BoundField DataField="TURMA" HeaderText="Turma" SortExpression="TURMA" />
                                               <asp:BoundField DataField="nroMax" HeaderText="Num. Máximo Alunos" SortExpression="nroMax" />
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
        </ContentTemplate>
    </asp:UpdatePanel>   
</asp:Content>
