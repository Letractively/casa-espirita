<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelMovimentacaoEstoque.aspx.cs" Inherits="FIBIESA.viewRelMovimentacaoEstoque" %>
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
                        <h2>Relatório de Movimentação do Estoque</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Item:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" Width="110px" 
                                        AutoPostBack="true" ontextchanged="txtItem_TextChanged" ToolTip="Digite o código do Item."></asp:TextBox>                                                                                   
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesItem_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesItem" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Usuário:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="inputbox" Width="110px" 
                                        AutoPostBack="true" ontextchanged="txtUsuario_TextChanged" ToolTip="Digite o código do Usuário"></asp:TextBox>
                                    <asp:Button ID="btnPesUsuario" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesUsuario_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesUsuario" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Quantidade:
                                </td>
                                <td style="width: 530px" colspan="2" >                            
                                    <asp:TextBox ID="txtQuantidade" runat="server" CssClass="inputbox"></asp:TextBox>                                                                
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="true"
ControlToValidate="txtQuantidade" ValidationExpression="^\d+$" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 530px" colspan="2" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbEntrada" GroupName="Estoque" runat="server" CssClass="input" value="1" Text="   Entrada">                                                                                                                                
                                        </asp:RadioButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="rbSaida" GroupName="Estoque" runat="server" CssClass="input" value="0" Text="   Saída">
                                        </asp:RadioButton>
                                    </center>
                                </td>                                                                      
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Data:
                                </td>
                                <td style="width: 400px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataIni_CalendarExtender" runat="server" TargetControlID="txtDataIni"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true" 
ControlToValidate="txtDataIni" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                &nbsp;a&nbsp;&nbsp;
                                            </td>
                                            <td>    
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                                    ID="txtDataFim_CalendarExtender" runat="server" TargetControlID="txtDataFim" 
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="REVdataFim" runat="server" ErrorMessage="*" ToolTip="Não Válido" SetFocusOnError="true"
ControlToValidate="txtDataFim" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="grupo" ForeColor="Red"></asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                    </table>
                                </td>                                    
                            </tr>
                            <tr>
                                <td colspan="2" valign="middle" style="text-align:center;">
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        onclick="btnRelatorio_Click" validationgroup="grupo" />
                                </td>                                    
                            </tr>                                        
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="hfIdUsuario" runat="server" Value="0"/>
                <asp:HiddenField ID="hfIdItem" runat="server" Value="0"/>
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>