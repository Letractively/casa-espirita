<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadFormulario.aspx.cs" Inherits="Admin.cadFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Formulário</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">* Código:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtCodigo" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Descrição:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="70" Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Tipo:</td>
                        <td><asp:DropDownList ID="ddlTipo" runat="server" CssClass="dropdownlist" >
                            <asp:ListItem Value="V">Consulta</asp:ListItem>
                            <asp:ListItem Value="C">Edição</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="ddlTipo" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Nome:</td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="inputbox" MaxLength="70" 
                                Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtNome" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Modulo:</td>
                        <td><asp:DropDownList ID="ddlModulo" runat="server" CssClass="dropdownlist" >
                            <asp:ListItem Value="F">Financeiro</asp:ListItem>
                            <asp:ListItem Value="B">Biblioteca</asp:ListItem>
                            <asp:ListItem Value="E">Estoque</asp:ListItem>
                            <asp:ListItem Value="V">Eventos</asp:ListItem>
                            <asp:ListItem Value="G">Geral</asp:ListItem>
                            <asp:ListItem Value="C">Configuração</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="ddlModulo" ErrorMessage="*Preenchimento Obrigatório" 
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
                                ValidationGroup="salvar" onclick="btnSalvar_Click" />                           
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
