<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadItemEstoque.aspx.cs" Inherits="Admin.cadItemEstoque" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Implantação do Estoque</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 120px">
                           * Item:
                        </td>
                        <td style="width: 180px" colspan="3">
                            
                            <asp:TextBox ID="txtItem" runat="server" Width="75px" CssClass="inputboxRight" 
                                AutoPostBack="True" ontextchanged="txtItem_TextChanged"></asp:TextBox>
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
                           * Data:
                        </td>
                        <td style="width: 180px">
                            
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
                        <td style="width: 120px">
                            * Status:
                        </td>
                        <td style="width: 180px">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist">
                                <asp:ListItem Value="A" Selected="True">Ativo</asp:ListItem>
                                <asp:ListItem Value="I">Inativo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>                    
                    <tr>
                        <td style="width: 120px">
                            Qtd. Mínima:
                        </td>
                        <td>
                            <asp:TextBox ID="txtQtdMin" runat="server" Width="100px" CssClass="inputboxRight"></asp:TextBox>
                        </td> 
                        <td colspan="2">
                            <asp:CheckBox ID="chkControlaEstoque" runat="server" Text="Controla Estoque" />
                        </td>                       
                    </tr>                                  
                    <tr>                        
                        <td style="width: 120px">
                            Custo Médio:
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtVlrMedio" runat="server" 
                                Width="100px" CssClass="inputboxRight"></asp:TextBox>
                        </td>                    
                        <td style="width: 120px">
                            Valor Venda:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVlrVenda" runat="server" Width="100px" CssClass="inputboxRight"></asp:TextBox>
                        </td>                        
                    </tr>
                    </table> 
                    <table>
                        <tr>
                            <td style="width: 120px">                                
                            </td>
                            <td style="width:400px" colspan="3">
                                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                    onclick="btnVoltar_Click" />  
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnExcluir" runat="server" Text="Apagar" CssClass="btn" 
                                     ValidationGroup="salvar" onclick="btnExcluir_Click" />                           
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
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
           
        </div>
    </div>    
</asp:Content>
