<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTurmaParticipantes.aspx.cs" Inherits="Admin.cadTurmaAluno" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>
                            Cadastro de Participantes</h2>
                    </div>
                    <center><p runat="server" id="mensagemErro" class="errortxt"></p></center>                    
                    <div class="contentbox">
                        <asp:Panel ID="pnParticipantes" runat="server" ScrollBars="Auto">
                            <table>
                                <tr>
                                    <td style="width: 140px">
                                        Turma:
                                    </td>
                                    <td style="width: 700px">
                                        <asp:Label ID="lblTurma" runat="server" Text=" "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 140px">
                                        Participante:
                                    </td>
                                    <td style="width: 500px; height:10px;">
                                        <table width="100%">
                                            <tr>
                                                <td style="width:40%;">
                                                    <asp:TextBox ID="txtParticipante" runat="server" CssClass="inputbox" 
                                                        ToolTip="Informe o participante" AutoPostBack="True" 
                                                        ontextchanged="txtParticipante_TextChanged"></asp:TextBox>
                                                    <asp:Button ID="btnPesParticipante" runat="server" CssClass="btn" Text="Buscar" OnClick="btnPesParticipante_Click" />                                        
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                                                        RepeatDirection="Horizontal" >
                                                        <asp:ListItem Selected>Não Participantes</asp:ListItem>
                                                        <asp:ListItem Selected>Participantes</asp:ListItem>
                                                        
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>                                                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 140px">
                                    </td>
                                    <td style="width: 400px">
                                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                            ToolTip="Volta para página de cadastro de turmas" />
                                        &nbsp;&nbsp;&nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width:400px;">
                                        <table>
                                            <tr>
                                                <td valign="top">Não Participantes
                                                </td>
                                                <td valign="top">Participantes
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:GridView ID="dtgParticipantesNotInTurma" runat="server" 
                                                        AutoGenerateColumns="False" BackColor="White" 
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                        DataKeyNames="ID_PES" PageSize="7" AllowSorting="True" OnRowDeleting="dtgParticipantesNotInTurma_RowDeleting"
                                                        GridLines="None" OnRowDataBound="dtgParticipantesNotInTurma_RowDataBound" OnPageIndexChanging="dtgParticipantesNotInTurma_PageIndexChanging"
                                                        OnSorting="dtgParticipantesNotInTurma_Sorting" Width="275px" EmptyDataText="Participante não encontrado ou ja cadastrado. Realize sua consulta."
                                                        Visible="true">
                                                        <Columns>
                                                            <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                                <HeaderStyle CssClass="grd_cmd_header" />
                                                                <ItemStyle CssClass="grd_select" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="ID_PES" HeaderText="ID" Visible="False" />
                                                            <asp:BoundField DataField="P_COD" HeaderText="Código" SortExpression="P_COD" />
                                                            <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME"  ControlStyle-Font-Size="Small"/>
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
                                                <td valign="top">
                                                    <asp:GridView ID="dtgParticipantes" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                                        DataKeyNames="ID" PageSize="7" AllowSorting="True" OnRowDeleting="dtgParticipantes_RowDeleting"
                                                        GridLines="None" OnRowDataBound="dtgParticipantes_RowDataBound" OnPageIndexChanging="dtgParticipantes_PageIndexChanging"
                                                        OnSorting="dtgParticipantes_Sorting" Width="370px" Visible="true" EmptyDataText="Participante não cadastrado. Realize sua consulta">
                                                        <Columns>
                                                            <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True">
                                                                <HeaderStyle CssClass="grd_cmd_header" />
                                                                <ItemStyle CssClass="grd_delete" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                            <asp:BoundField DataField="CODIGO" HeaderText="Cod" SortExpression="CODIGO" Visible="false" />
                                                            <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" />
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
                <asp:HiddenField ID="hfOrdem" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
