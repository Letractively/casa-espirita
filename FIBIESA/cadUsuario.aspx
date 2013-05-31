<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadUsuario.aspx.cs" Inherits="Admin.cadUsuario" Culture="auto" UICulture="auto" %>    
<%@ MasterType VirtualPath="~/home.Master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>
                    Cadastro de Usuários</h2>
            </div>
            <div class="contentbox">
                <table>
                     <tr>
                        <td style="width: 130px">
                            Pessoa:
                        </td>
                        <td style="width: 300px">                      
                            <asp:TextBox ID="txtPessoa" runat="server" CssClass="inputbox" Width="75px" 
                                ToolTip="Informe a pessoa" AutoPostBack="True" 
                                ontextchanged="txtPessoa_TextChanged"></asp:TextBox>
                            <asp:Button ID="btnPesPessoa" runat="server" Text="..." CssClass="btn" 
                                onclick="btnPesPessoa_Click" />
                            <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                        </td>                    
                        <td style="width: 80px">
                            *
                            Categoria:
                        </td>
                        <td style="width: 300px" >
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a categoria" >
                            </asp:DropDownList>                                    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="ddlCategoria" CssClass="validacao" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 130px">
                            Nome:
                        </td>
                        <td style="width: 300px">
                            <asp:TextBox ID="txtNome" runat="server" CssClass="inputbox" MaxLength="70" 
                                Width="300px" ToolTip="Informe o nome da pessoa"></asp:TextBox>
                        </td>
                        <td style="width: 80px">
                            *
                            Status:
                        </td>
                        <td style="width: 250px">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="95px" 
                                CssClass="dropdownlist" ToolTip="Selecione o status">
                                <asp:ListItem Value="A">Ativo</asp:ListItem>
                                <asp:ListItem Value="I">Inativo</asp:ListItem>
                            </asp:DropDownList>
                        </td> 
                    </tr>
                    <tr>
                        <td style="width: 130px; height: 62px;">
                            E-mail:
                        </td>
                        <td style="width: 300px; height: 62px;" colspan="5">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" 
                                Width="300px" ToolTip="Informe o e-mail"></asp:TextBox>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 130px">
                            *
                            Login:
                        </td>
                        <td style="width: 300px" colspan="5">
                            <asp:TextBox ID="txtLogin" runat="server" CssClass="inputbox" MaxLength="20" 
                                ToolTip="Informe o login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtLogin" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 130px">
                            *
                            Senha:
                        </td>
                        <td style="width: 300px" colspan="3">
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="inputbox" MaxLength="100" 
                                Width="300px" TextMode="Password" ToolTip="Informe a senha" ></asp:TextBox>                              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtSenha" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                     <tr>
                        <td style="width: 130px">
                            *
                            Confirmar Senha:
                        </td>
                        <td style="width: 300px" colspan="3">
                            <asp:TextBox ID="txtConfirmarSenha" runat="server" CssClass="inputbox" 
                                MaxLength="100" Width="300px" TextMode="Password" 
                                ToolTip="Confirmar a senha"></asp:TextBox>                               
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtSenha" ControlToValidate="txtConfirmarSenha" 
                                
                                ErrorMessage="Os valores dos campo Senha e Confirmar Senha devem ser iguais" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:CompareValidator>
                        </td>
                    </tr>                     
                    <tr>                                           
                        <td style="width: 130px">
                            *
                            Data Início:
                        </td>
                        <td style="width: 300px" >
                            <asp:TextBox ID="txtDtInicio" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe a data de início"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDtInicio_CalendarExtender" runat="server" 
                                TargetControlID="txtDtInicio">
                            </asp:CalendarExtender>                         
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDtInicio" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>                   
                        <td style="width: 80px">
                            *
                            Data Fim:
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" Width="110px" 
                                ToolTip="Informe da data de fim"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtDtFim" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                            <asp:CalendarExtender ID="txtDtFim_CalendarExtender" runat="server" 
                                TargetControlID="txtDtFim">
                            </asp:CalendarExtender>                            
                        </td>
                    </tr>                      
                                      
                </table>
                <table>
                    <tr>   
                        <td style="width: 130px"> </td>    
                        <td style="width: 300px">                            
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
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">            
        </div>
    </div>   
</asp:Content>
