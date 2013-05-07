<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="emissaoBloqBan.aspx.cs" Inherits="FIBIESA.emissaoBloqBan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Emissão de Bloquetos Bancários</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Cliente(s):
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtIntClientes" runat="server" CssClass="inputbox" Width="300px"
                                AutoPostBack="True" 
                                ToolTip="Intervalo Selecionado. Use ',' ou '|' ou '%'. Ex:1,2; 1|8; 1,20% " 
                                ontextchanged="txtIntClientes_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnPesCliente" runat="server" CssClass="btn" Text="..." 
                                CausesValidation="False" onclick="btnPesCliente_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Título(s):
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtIntTitulos" runat="server" CssClass="inputbox" 
                                Width="300px" AutoPostBack="True"
                                 
                                ToolTip="Intervalo Selecionado. Use ',' ou '|' ou '%'. Ex:1,2; 1|8; 1,20% " 
                                ontextchanged="txtIntTitulos_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnPesTitulo" runat="server" CssClass="btn" Text="..." 
                                CausesValidation="False" onclick="btnPesTitulo_Click"
                                 />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Portador:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlPortador" runat="server" CssClass="dropdownlist" ToolTip="Selecione o portador"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo de Documento:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="dropdownlist" ToolTip="Selecione o tipo de documento">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Emissão:
                        </td>
                        <td style="width: 400px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDtEmiIni" runat="server" CssClass="inputbox" Width="100px"></asp:TextBox>                                        
                                        <asp:CalendarExtender ID="txtDtEmiIni_CalendarExtender" runat="server" 
                                            TargetControlID="txtDtEmiIni">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;a&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDtEmiFim" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                                      
                                        <asp:CalendarExtender ID="txtDtEmiFim_CalendarExtender" runat="server" 
                                            TargetControlID="txtDtEmiFim">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                    
                    <tr>
                        <td style="width: 140px">
                            Instrução 1:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtInstrucaoum" runat="server" CssClass="inputbox" 
                                ToolTip="Informe a instrução 1" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Instrução 2:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtInstrucaoDois" runat="server" CssClass="inputbox" 
                                ToolTip="Informe a instrução 2" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                         <td style="width: 140px">
                            Descrição livre:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstrucoes" runat="server" CssClass="inputbox" 
                                Height="78px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                ToolTip="Volta para página principal" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnGerar" runat="server" Text="Imprimir" CssClass="btn" OnClick="btnGerar_Click"
                                ValidationGroup="salvar" ToolTip="Gera e Imprimi os bloquetos bancários" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
        </div>
        <div class="status">
        </div>
        <asp:Panel runat="server" ID="pnlCliente" Width="400px" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPesquisa" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesquisa_TextChanged"
                            AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdPesquisa" runat="server" CellPadding="3" AutoGenerateColumns="False"
                            DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisa_RowDataBound"
                            Width="300px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                            OnClick="btnSelect_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
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
                <tr>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"
                            CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtenderPesquisa" runat="server" TargetControlID="hfIdPessoa"
            PopupControlID="pnlCliente" BackgroundCssClass="modalBackground" DropShadow="true"
            OkControlID="btnCancel" Enabled="false" />
        <asp:Panel runat="server" ID="pnlTitulos" Width="400px" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPesTitulo" runat="server" CssClass="inputbox" Width="180px" OnTextChanged="txtPesTitulo_TextChanged"
                            AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdPesquisatit" runat="server" CellPadding="3" AutoGenerateColumns="False"
                            DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" GridLines="None" OnRowDataBound="grdPesquisaTit_RowDataBound"
                            Width="300px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelectTit" runat="server" ImageUrl="~/images/icons/icon_tick.png"
                                            OnClick="btnSelectTit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                <asp:BoundField DataField="CODIGO" HeaderText="Título" />
                                <asp:BoundField DataField="DESCRICAO" HeaderText="Parcela" />
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
                <tr>
                    <td>
                        <asp:Button ID="btnCancelTit" runat="server" Text="Cancelar" OnClick="btnCancelTit_Click"
                            CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:ModalPopupExtender ID="pnlTitulos_ModalPopupExtender" runat="server" 
            TargetControlID="hfIdPessoa" PopupControlID="pnlTitulos"
            BackgroundCssClass="modalBackground" DropShadow="true"
            OkControlID="btnCancelTit" Enabled="false">
        </asp:ModalPopupExtender>

    </div>
</asp:Content>
