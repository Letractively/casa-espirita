<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="GerarRemessa.aspx.cs" Inherits="FIBIESA.GerarRemessa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>
                            Gerar Arquivos de Remessa de Títulos</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Download:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <asp:LinkButton ID="lkbDownload" runat="server" ForeColor="Blue" Text="Arquivo para Download"
                                        OnClick="lkbDownload_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Portador:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <asp:DropDownList ID="ddlPortador" runat="server" CssClass="dropdownlist" ToolTip="Selecione o portador"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="ddlPortador" CssClass="validacao" 
                                        ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="gerar">*Preenchimento obrigatório</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Título(s):
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <asp:TextBox ID="txtIntTitulos" runat="server" CssClass="inputbox" Width="300px"
                                        AutoPostBack="True" ToolTip="Intervalo Selecionado. Use ',' ou '|' ou '%'. Ex:1,2; 1|8; 1,20% "></asp:TextBox>
                                    <asp:Button ID="btnPesTitulo" runat="server" CssClass="btn" Text="..." 
                                        CausesValidation="False" onclick="btnPesTitulo_Click1" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Data Emissão:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDtEmiIni" runat="server" CssClass="inputbox" Width="100px" 
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtDtEmiIni_CalendarExtender" runat="server" TargetControlID="txtDtEmiIni">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Data com formato errado"
                                                    ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtDtEmiIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                    Display="Dynamic" ValidationGroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDtEmiFim" runat="server" CssClass="inputbox" Width="110px" 
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtDtEmiFim_CalendarExtender" runat="server" TargetControlID="txtDtEmiFim">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Data com formato errado"
                                                    ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtDtEmiFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                    Display="Dynamic" ValidationGroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Data Vencimento:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDtVencIni" runat="server" CssClass="inputbox" Width="100px" 
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDtVencIni">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Data com formato errado"
                                                    ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtDtVencIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                    Display="Dynamic" ValidationGroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDtVencFim" runat="server" CssClass="inputbox" Width="110px" 
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDtVencFim">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Data com formato errado"
                                                    ToolTip="Não Válido" SetFocusOnError="true" ControlToValidate="txtDtVencFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                    Display="Dynamic" ValidationGroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Aceite:
                                </td>
                                <td style="width: 400px">
                                    <asp:DropDownList ID="ddlAceite" runat="server" CssClass="dropdownlist" ToolTip="Selecione a opção de Aceite"
                                        AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="A">Aceite</asp:ListItem>
                                        <asp:ListItem Value="N">Não Aceite</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 140px">
                                    Juros de Mora:
                                </td>
                                <td style="width: 400px">
                                    <asp:DropDownList ID="ddlJuroMora" runat="server" CssClass="dropdownlist" ToolTip="Selecione o Tipo de Juro de Mora"
                                        AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="0">Diário</asp:ListItem>
                                        <asp:ListItem Value="1">Mensal</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Instrução 1:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInstrucao1" runat="server" CssClass="dropdownlist" ToolTip="Selecione a instrução um"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                Dias protesto/devolução :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiasUm" CssClass="inputboxRight" runat="server" 
                                                    Width="50px" MaxLength="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Instrução 2:
                                </td>
                                <td style="width: 400px" colspan="3">
                                    <table>
                                        <tr>
                                            <td colspan = 3>
                                                <asp:DropDownList ID="ddlInstrucao2" runat="server" CssClass="dropdownlist" ToolTip="Selecione a instrução dois"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>                                          
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Remessa:
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlRemessa" runat="server" CssClass="dropdownlist" ToolTip="Selecione o código da remessa">
                                        <asp:ListItem Value="01">01 - Remessa</asp:ListItem>
                                        <asp:ListItem Value="02">02 - Pedido Baixa</asp:ListItem>
                                        <asp:ListItem Value="04">04 - Concessão de Abatimento</asp:ListItem>
                                        <asp:ListItem Value="05">05 - Cancelamento de Abatimento</asp:ListItem>
                                        <asp:ListItem Value="06">06 - Alteração de Vencimento</asp:ListItem>
                                        <asp:ListItem Value="07">07 - Alteração de Uso Empresa</asp:ListItem>
                                        <asp:ListItem Value="08">08 - Alteração do Seu Número</asp:ListItem>
                                        <asp:ListItem Value="09">09 - Protestar Imediatamento</asp:ListItem>
                                        <asp:ListItem Value="10">10 - Sustação de Protesto</asp:ListItem>
                                        <asp:ListItem Value="11">11 - Não Cobrar Juros de Mora</asp:ListItem>
                                        <asp:ListItem Value="12">12 - Reembolso e Transferência Desconto e Vendor</asp:ListItem>
                                        <asp:ListItem Value="13">13 - Reembolso e Devolução Desconto e Vendor</asp:ListItem>
                                        <asp:ListItem Value="16">16 - Alteração do número de dias para protesto</asp:ListItem>
                                        <asp:ListItem Value="17">17 - Protestar Imediatamente para Fins de Falência</asp:ListItem>
                                        <asp:ListItem Value="18">18 - Alteração de nome do Sacodo</asp:ListItem>
                                        <asp:ListItem Value="19">19 - Alteração de endereço do Sacado</asp:ListItem>
                                        <asp:ListItem Value="20">20 - Alteração da cidade do Sacado</asp:ListItem>
                                        <asp:ListItem Value="21">21 - Alteração do CEP do Sacado (Mudança de Portador)</asp:ListItem>
                                        <asp:ListItem Value="68">68 - Acerto dos dados do rateio de crédito</asp:ListItem>
                                        <asp:ListItem Value="69">69 - Cancelamento dos dados do rateiro</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Button ID="btnGerar" runat="server" Text="Gerar Remessa" CssClass="btn" OnClick="btnGerar_Click"
                                        ValidationGroup="gerar" ToolTip="Gera o arquivo de remessa" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hfIdPessoa" runat="server" />
                </div>
                <div class="status">
                </div>               
                <asp:Panel runat="server" ID="pnlTitulos" Width="450px" Height="450px" CssClass="modalPopup" ScrollBars="Auto" Style="display: none">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPesTitulo" runat="server" CssClass="inputbox" Width="180px"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnBuscarTit" runat="server" Text="Buscar" CssClass="btn" 
                                    onclick="btnBuscarTit_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancelTit" runat="server" Text="Cancelar" OnClick="btnCancelTit_Click"
                                    CssClass="btn" />
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
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender ID="pnlTitulos_ModalPopupExtender" runat="server" TargetControlID="hfIdPessoa"
                    PopupControlID="pnlTitulos" BackgroundCssClass="modalBackground" DropShadow="true"
                    OkControlID="btnCancelTit" Enabled="false">
                </asp:ModalPopupExtender>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGerar" EventName="Click" />
            <asp:PostBackTrigger ControlID="lkbDownload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
