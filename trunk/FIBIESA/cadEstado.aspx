<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadEstado.aspx.cs" Inherits="Admin.cadEstado" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Cadastro de Estados</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            *
                           UF:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtUf" runat="server" CssClass="inputbox" MaxLength="2" 
                                Width="47px" Columns="2" ToolTip="Informe a UF" AutoPostBack="True" 
                                ontextchanged="txtUf_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUf" ErrorMessage="*Informe a UF" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                            <asp:Label ID="lblInformacao" runat="server" CssClass="validacao"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            *
                           Descrição:    
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" MaxLength="70" 
                                Width="335px" ToolTip="Informe a descrição da UF"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Informe a descrição" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style ="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                onclick="bntVoltar_Click" ToolTip="Volta para página de consulta" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                onclick="bntSalvar_Click" ValidationGroup="salvar" 
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
</asp:Content>
