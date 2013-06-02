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
                            Código:
                        </td>
                        <td style="width: 120px" colspan="3">
                           <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" >
                            * Título:
                        </td>
                        <td style="width: 120px"  colspan="3">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px" ToolTip="Informe o título"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                CssClass="validacao" ErrorMessage="Informe o Título da Obra" ValidationGroup="salvar"
                                ControlToValidate="txtTitulo">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            * Tipo de Obra:</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlTipoObra" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o tipo de obra">
                            </asp:DropDownList>                       
                            <asp:RequiredFieldValidator ID="valTipoObra" runat="server" 
                                ControlToValidate="ddlTipoObra" ErrorMessage="Informe o Tipo de Obra" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>                        
                        </td>                        
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Número Edição:
                        </td>
                        <td style="width: 180px" >
                            <asp:TextBox ID="txtNroEdicao" runat="server" CssClass="inputboxRight" 
                                Width="70px" ToolTip="Informe o número da edição"></asp:TextBox>
                        </td>                    
                        <td>
                            Editora:</td>
                        <td>
                            <asp:DropDownList ID="ddlEditora" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a editora">
                            </asp:DropDownList>                       
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            ISBN:
                        </td>
                        <td style="width: 150px">
                            <asp:TextBox ID="txtISBN" runat="server" CssClass="inputbox" 
                                ToolTip="Informe o ISBN"></asp:TextBox>
                        </td>
                        <td style="width: 140px">
                            Número de Páginas:
                        </td>
                        <td style="width: 120px">
                            <asp:TextBox ID="txtNroPags" runat="server" CssClass="inputboxRight" 
                                Width="70px" ToolTip="Informe o número de páginas"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Local Publicação:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtLocalPublic" runat="server" CssClass="inputbox" Width="204px" 
                                MaxLength="100"></asp:TextBox>
                        </td>                    
                        <td style="width: 120px">
                            Data Publicação:
                        </td>
                        <td style="width: 120px">
                            <asp:TextBox ID="txtDataPublicacao" runat="server" CssClass="inputbox" 
                                Width="110px" ToolTip="Informe a data de publicação"></asp:TextBox>                           
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtDataPublicacao">
                            </asp:CalendarExtender>                           
                        </td>  
                        </tr>                                                          
                    <tr>
                        <td style="width: 140px">
                            Data Reimpressão:
                        </td>
                        <td style="width: 180px">
                            <asp:TextBox ID="txtDataReimpressao" runat="server" CssClass="inputbox" 
                                Width="110px" ToolTip="Informe a data de reimpressão"></asp:TextBox>                           
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtDataReimpressao">
                            </asp:CalendarExtender>                           
                        </td>  
                        <td style="width: 120px">
                            Volume:
                        </td>
                        <td style="width: 120px">
                            <asp:TextBox ID="txtVolume" runat="server" CssClass="inputboxRight" 
                                Width="110px" ToolTip="Informe o volume"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Assuntos abordados:
                        </td>
                        <td style="width: 120px" colspan="3">
                            <asp:TextBox ID="txtAssuntosAborda" runat="server" CssClass="inputbox" 
                                MaxLength="1000" Width="485px" Height="79px" TextMode="MultiLine" 
                                ToolTip="Informe os assuntos abordados na obra"></asp:TextBox>
                        </td>
                    </tr>  
                    
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">                            
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" ToolTip="Volta para a página de consulta" />                             
                             &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                ToolTip="Valida e salva as informações" />   
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
