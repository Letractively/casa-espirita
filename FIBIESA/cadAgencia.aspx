<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadAgencia.aspx.cs" Inherits="Admin.cadAgencia" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Cadastro de Agências</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            *
                            Código:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            *
                            Descrição:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" MaxLength="70"
                                Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescricao"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Banco:</td>
                        <td style="width: 400px" colspan="3">
                            <asp:DropDownList ID="ddlBanco" runat="server" CssClass="dropdownlist">
                             </asp:DropDownList>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlBanco" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            CEP:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCep" runat="server" CssClass="inputbox" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>                   
                    <tr>
                        <td style="width: 140px">
                            * UF:
                        </td>
                        <td style="width: 500px">
                            <asp:DropDownList ID="ddlUF" runat="server" CssClass="dropdownlist" 
                                onselectedindexchanged="ddlUF_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Cidade:
                        </td>
                        <td style="width: 500px">
                            <asp:DropDownList ID="ddlCidades" runat="server" CssClass="dropdownlist" 
                                onselectedindexchanged="ddlCidades_SelectedIndexChanged" 
                                AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                        runat="server" ControlToValidate="ddlCidades" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" 
                                CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                                            
                    <tr>
                        <td style="width: 140px">
                            * Bairro:
                        </td>
                        <td style="width: 500px">
                            <asp:DropDownList ID="ddlBairro" runat="server" CssClass="dropdownlist" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                        runat="server" ControlToValidate="ddlBairro" 
                                ErrorMessage="*Preenchimento Obrigatório" ValidationGroup="salvar" 
                                CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 140px">
                            Endereço:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtEndereco" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Complemento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="inputbox" MaxLength="40"
                                Width="147px"></asp:TextBox>
                        </td>
                        <td style="width: 140px">
                            Ranking:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtRanking" runat="server" CssClass="inputbox" Width="55px"></asp:TextBox>
                        </td>
                    </tr>                              
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text ="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" /> 
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text ="Salvar" CssClass="btn" 
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
