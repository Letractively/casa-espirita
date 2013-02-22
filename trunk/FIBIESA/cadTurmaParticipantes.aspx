<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTurmaParticipantes.aspx.cs" Inherits="Admin.cadTurmaAluno" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Participantes</h2>
            </div>
            <div class="contentbox">
                <asp:Panel ID="pnParticipantes" runat="server" ScrollBars="Auto">
                <table>
                    <tr>
                        <td style="width: 140px">Turma:</td>
                        <td style="width: 400px">
                            <asp:Label ID="lblTurma" runat="server" Text=" "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                           * Participante:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtParticipante" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesParticipante" runat="server" CssClass="btn" Text="..." onclick="btnPesParticipante_Click" 
                                />
                            &nbsp;
                            <asp:Label ID="lblDesParticipante" runat="server"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="width: 140px">       
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn" 
                                onclick="btnInserir_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="dtgParticipantes" runat="server" AutoGenerateColumns="False" 
                                   BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                   CellPadding="3" AllowPaging="True" DataKeyNames="ID"                                    
                                    PageSize="7" AllowSorting="True" 
                                onrowdeleting="dtgParticipantes_RowDeleting">
                                   <Columns>
                                       <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                            <HeaderStyle CssClass="grd_cmd_header" />
                                            <ItemStyle CssClass="grd_delete" />
                                       </asp:CommandField>
                                       <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                       <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                       <asp:BoundField DataField="NOME" HeaderText="Nome" />
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
               </asp:Panel>           
            </div>
            <asp:HiddenField ID="hfIdParticipante" runat="server" />
            <asp:HiddenField ID="hfIdTurma" runat="server" />
            <asp:HiddenField ID="hfId" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
