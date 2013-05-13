<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadCategoria.aspx.cs" Inherits="Admin.cadCategoria" %>
    <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    Cadastro de Categorias</h2>
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
                            *
                            Descrição:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="70" Width="335px" ToolTip="Informe a descrição da categoria"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
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
                            <asp:button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                ToolTip="Valida e salva as informações" />                            
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
