<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadBancosInstrucoes.aspx.cs" Inherits="FIBIESA.cadBancosInstrucoes" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Cadastro de Instruções Bancárias</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">* Banco:</td>
                        <td style="width: 400px" colspan="3">
                            <asp:DropDownList ID="ddlBanco" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o Banco">
                             </asp:DropDownList>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="ddlBanco" ErrorMessage="* Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Código:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputboxRight" ToolTip="Informe o código da instrução"
                                Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCodigo"
                                CssClass="validacao" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Descrição:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" Width="335px" MaxLength="70"
                                ToolTip="Informe a descrição da instrução"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescricao"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Obrigar Dias:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlObrigDias" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione se é obrigatório informar o número de dias">
                                <asp:ListItem Value="true">Sim</asp:ListItem>
                                <asp:ListItem Value="false">Não</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlObrigDias"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click"
                                ToolTip="Volta para a página de consulta" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                ValidationGroup="salvar" ToolTip="Salva as informações do banco" />
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
