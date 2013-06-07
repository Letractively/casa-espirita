<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadBairro.aspx.cs" Inherits="Admin.cadBairro" %>
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
                <div class="container half left">
                    <div class="conthead">
                        <h2>
                            Cadastro de Bairros</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Código:
                                </td>
                                <td style="width: 400px">
                                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>                            
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Descrição:
                                </td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                        MaxLength="40" Width="335px" ToolTip="Informe a descrição do bairro"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtDescricao" ErrorMessage="*Informe a descrição" 
                                        ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * UF:
                                </td>  
                                <td style="width: 400px">
                                   <asp:DropDownList ID="ddlUf" runat="server" CssClass="dropdownlist" 
                                        AutoPostBack="True" onselectedindexchanged="ddlUf_SelectedIndexChanged" 
                                        ToolTip="Selecione a UF"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="ddlUf" CssClass="validacao" 
                                        ErrorMessage="*Selecione a UF" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td> 
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    * Cidade:
                                </td>  
                                <td style="width: 400px">
                                   <asp:DropDownList ID="ddlCidade" runat="server" CssClass="dropdownlist" 
                                        ToolTip="Selecione a cidade"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="ddlCidade" CssClass="validacao" 
                                        ErrorMessage="*Selecione a cidade" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                </td> 
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 140px">
                                </td>
                                <td style="width: 400px">
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                        onclick="btnVoltar_Click" ToolTip="Volta para página de consulta" />                             
                                     &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                        onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                        ToolTip="Valida e salva as informações" />                               
                                </td>
                            </tr>                   
                        </table>                
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        CssClass="validacao" ValidationGroup="salvar" />
                    <asp:HiddenField ID="hfId" runat="server" />
                </div>
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
