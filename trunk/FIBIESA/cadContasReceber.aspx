<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadContasReceber.aspx.cs" Inherits="FIBIESA.cadContasReceber" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Cadastro de Títulos Contas a Receber</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Tipo de Documento:
                        </td>
                        <td style="width: 400px" colspan="3">
                          <asp:DropDownList ID="ddlTipoDoc" runat="server">                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Título:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputboxRight"></asp:TextBox>
                        </td>                        
                        <td style="width: 140px">
                            Parcela:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtParcela" runat="server" CssClass="inputboxRight" 
                                Width="50px"></asp:TextBox>
                        </td>                   
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Fornecedor:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtFornecedor" runat="server" CssClass="inputboxRight" Width="110px"
                                AutoPostBack="True" OnTextChanged="txtFornecedor_TextChanged" 
                                ToolTip="Informe o cliente"></asp:TextBox>
                            <asp:Button ID="btnPesFornecedor" runat="server" CssClass="btn" Text="..." 
                                CausesValidation="False" />
                            <asp:Label ID="lblDesFornecedor" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFornecedor"
                                CssClass="validacao" ErrorMessage="*Informe o fornecedor" 
                                ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>                                        
                    <tr>
                        <td style="width: 140px">
                            Valor:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputboxRight"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Emissão:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataEmissao" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDataEmissao_CalendarExtender" runat="server" 
                                TargetControlID="txtDataEmissao">
                            </asp:CalendarExtender>
                        </td>                    
                        <td style="width: 140px">
                            Data Vencimento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataVencimento" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDataVencimento_CalendarExtender" runat="server" 
                                TargetControlID="txtDataVencimento">
                            </asp:CalendarExtender>
                        </td>
                    </tr>                                       
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text ="Voltar" CssClass="btn" 
                                ValidationGroup="salvar" onclick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text ="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
