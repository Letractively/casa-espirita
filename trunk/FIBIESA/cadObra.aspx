<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadObra.aspx.cs" Inherits="Admin.cadObra" %>
    <%@ MasterType VirtualPath="~/home.Master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>Cadastro de Obras</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            * Código:
                        </td>
                        <td style="width: 180px" colspan="3">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valCodigo" runat="server" 
                                ControlToValidate="txtCodigo" ErrorMessage="Informe o Código da Obra" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" >
                            * Título:
                        </td>
                        <td style="width: 180px"  colspan="3">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                CssClass="validacao" ErrorMessage="Informe o Título da Obra" ValidationGroup="salvar"
                                ControlToValidate="txtTitulo">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Tipo de Obra:</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoObra" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>                       
                            <asp:RequiredFieldValidator ID="valTipoObra" runat="server" 
                                ControlToValidate="ddlTipoObra" ErrorMessage="Informe o Tipo de Obra" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>                        
                        </td>
                        <td style="width: 140px">
                            &nbsp;Origem:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtOrigem" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Número Edição:
                        </td>
                        <td style="width: 180px" >
                            <asp:TextBox ID="txtNroEdicao" runat="server" CssClass="inputbox" Width="70px"></asp:TextBox>
                        </td>                    
                        <td>
                            &nbsp;Editora:</td>
                        <td>
                            <asp:DropDownList ID="ddlEditora" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>                       
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Local Publicação:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>                    
                        <td style="width: 140px">
                            &nbsp;Data Publicação:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtDataPublicacao" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                           
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtDataPublicacao">
                            </asp:CalendarExtender>                           
                        </td>  
                        </tr>
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Número de Páginas:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtNroPags" runat="server" CssClass="inputbox" Width="70px"></asp:TextBox>
                        </td>
                    
                        <td style="width: 140px">
                            &nbsp;ISBN:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtISBN" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>                                      
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Data Reimpressão:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtDataReimpressao" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                           
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtDataReimpressao">
                            </asp:CalendarExtender>                           
                        </td>  
                        <td style="width: 140px">
                            &nbsp;Volume:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtVolume" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Assuntos abordados:
                        </td>
                        <td style="width: 180px" colspan="3">
                            <asp:TextBox ID="txtAssuntosAborda" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px"></asp:TextBox>
                        </td>
                    </tr>  
                    
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">                            
                        </td>
                        <td style="width: 400px">
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
                     <asp:HiddenField ID="hfId" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>         
            </div>
            
        </div>
       
        <div class="status">
        </div>
    </div>
</asp:Content>
