<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadAcertoEstoque.aspx.cs" Inherits="FIBIESA.cadAcertoEstoque1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="content">
    <div id="Div1">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Acerto do Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 120px">
                           * Item:
                        </td>
                        <td style="width: 400px">
                            
                            <asp:TextBox ID="txtItem" runat="server" Width="75px" CssClass="inputboxRight" 
                                AutoPostBack="True" ontextchanged="txtItem_TextChanged" ></asp:TextBox>
                            <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." onclick="btnPesItem_Click" 
                                 />
                            &nbsp;
                            <asp:Label ID="lblDesItem" runat="server"></asp:Label>                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtItem" CssClass="validacao" ErrorMessage="*Informe o Item" 
                                ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                            
                        </td>
                    </tr>                                        
                    <tr>
                        <td style="width: 120px">
                           Quantidade Atual:
                        </td>
                        <td>                            
                            <asp:Label ID="lblQtdAtual" runat="server" ></asp:Label> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           <strong><em>Movimentação</em></strong></td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                           * Data:
                        </td>
                        <td style="width: 400px">
                            
                            <asp:TextBox ID="txtData" runat="server" Width="100px" CssClass="inputbox" 
                                AutoPostBack="True" ></asp:TextBox>                                             
                            
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtData">
                            </asp:CalendarExtender>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtData" CssClass="validacao" 
                                ErrorMessage="*Informe a data de implantação do estoque" 
                                ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                            
                        </td>                      
                    </tr>                 
                    <tr>                        
                        <td style="width: 120px">
                            Tipo Movimento:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblTipoMov" runat="server" RepeatColumns="2">
                                <asp:ListItem Value="E" Selected="True">Entrada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>                        
                    </tr>
                    <tr>
                        <td style="width: 120px">
                           Qtde :
                        </td>
                        <td>
                            <asp:TextBox ID="txtQtde" runat="server" Width="100px" CssClass="inputboxRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                CssClass="validacao" ErrorMessage="*Informe a quantidade do movimento" 
                                ValidationGroup="salvar" ControlToValidate="txtQtde">*</asp:RequiredFieldValidator>
                        </td>                        
                    </tr>
                    </table> 
                    <table>
                        <tr>
                            <td style="width: 120px">                                
                            </td>
                            <td style="width:400px">
                                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                    onclick="btnVoltar_Click" />  
                                &nbsp;&nbsp;&nbsp;                                
                                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                    onclick="btnSalvar_Click" ValidationGroup="salvar" />   
                            </td>
                        </tr>                   
                    </table>  
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    CssClass="validacao" ValidationGroup="salvar" />            
            </div>
             <asp:HiddenField ID="hfIdItem" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
           
        </div>
    </div>
</asp:Content>