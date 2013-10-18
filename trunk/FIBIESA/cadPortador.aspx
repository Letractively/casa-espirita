<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadPortador.aspx.cs" Inherits="Admin.cadPortador" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Portadores</h2>
            </div>
            <div class="contentbox">
                <table>
                    
                    <tr>
                        <td style="width: 140px">* Código:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputboxRight" 
                                ToolTip="Informe o código do portador" Width="100px" AutoPostBack="True" 
                                ontextchanged="txtCodigo_TextChanged" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtCodigo" CssClass="validacao" 
                                ErrorMessage="*Informe o código do portador" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                            <asp:Label ID="lblInformacao" runat="server" CssClass="validacao"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Descrição:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="70" Width="300px" ToolTip="Informe a descrição do portador" 
                                ValidationGroup="salvar"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Informe a descrição" 
                                ValidationGroup="salvar" CssClass="validacao">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;Banco:</td>
                        <td style="width: 400px">
                             <asp:DropDownList ID="ddlBanco" runat="server" CssClass="dropdownlist" 
                                 AutoPostBack="True" onselectedindexchanged="ddlBanco_SelectedIndexChanged" 
                                 ToolTip="Selecione o banco">
                             </asp:DropDownList>                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;Agência:</td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlAgencia" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a agênica" AutoPostBack="True" 
                                onselectedindexchanged="ddlAgencia_SelectedIndexChanged">
                             </asp:DropDownList> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;Conta:</td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlConta" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a conta">
                             </asp:DropDownList> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;Nro. Convênio:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtNroConvenio" runat="server" CssClass="inputboxRight" 
                                MaxLength="14" Width="100px" ToolTip="Informe o número do convênio" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;Carteira:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtCarteira" runat="server" CssClass="inputbox"
                                MaxLength="1" Width="50px" ToolTip="Informe o tipo de carteira" ></asp:TextBox>
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
                                ToolTip="Salva as informações do portador" />
                            
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
