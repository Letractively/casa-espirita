<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadObra.aspx.cs" Inherits="Admin.cadObra" %>
    <%@ MasterType VirtualPath="~/home.Master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Obra</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            * Código:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valCodigo" runat="server" 
                                ControlToValidate="txtCodigo" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Título:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valTitulo" runat="server" 
                                ControlToValidate="txtTitulo" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Número Edição:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtNroEdicao" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valNroEdicao" runat="server" 
                                ControlToValidate="txtNroEdicao" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            * Editora:</td>
                        <td>
                            <asp:DropDownList ID="ddlEditora" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>                       
                            <asp:RequiredFieldValidator ID="valEditora" runat="server" 
                                ControlToValidate="ddlEditora" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>                        
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Local Publicação:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtNroEdicao" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            * Data Publicação:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtDataPublicacao" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                           
                            <asp:CalendarExtender ID="txtData_CalendarExtender" runat="server" 
                                TargetControlID="txtDataPublicacao">
                            </asp:CalendarExtender>                           
                            <asp:RequiredFieldValidator ID="valDataPublicacao" runat="server" 
                                ErrorMessage="*Preenchimento Obrigatório" CssClass="validacao" 
                                ControlToValidate="txtDataPublicacao" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Número de Páginas:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtNroPags" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valNroPags" runat="server" 
                                ControlToValidate="txtNroPags" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * ISBN:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtISBN" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valISBN" runat="server" 
                                ControlToValidate="txtISBN" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Assuntos abordados:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtAssuntosAborda" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valAssuntosAborda" runat="server" 
                                ControlToValidate="txtAssuntosAborda" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            * Tipo de Obra:</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoObra" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>                       
                            <asp:RequiredFieldValidator ID="valTipoObra" runat="server" 
                                ControlToValidate="ddlTipoObra" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>                        
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            * Data Reimpressão:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtDataReimpressao" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>                           
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtDataReimpressao">
                            </asp:CalendarExtender>                           
                            <asp:RequiredFieldValidator ID="valDataReimpressao" runat="server" 
                                ErrorMessage="*Preenchimento Obrigatório" CssClass="validacao" 
                                ControlToValidate="txtDataReimpressao" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>                    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Volume:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtVolume" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valVolume" runat="server" 
                                ControlToValidate="txtVolume" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Origem:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtOrigem" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valOrigem" runat="server" 
                                ControlToValidate="txtOrigem" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
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
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
