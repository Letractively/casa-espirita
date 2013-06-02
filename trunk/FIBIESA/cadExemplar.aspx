<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadExemplar.aspx.cs" Inherits="Admin.cadExemplar" %>
    <%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Exemplares</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 130px">
                            * Obra:
                        </td>
                        <td style="width: 300px">                      
                            <asp:TextBox ID="txtObra" runat="server" CssClass="inputbox" Width="75px" 
                                ontextchanged="txtObra_TextChanged" AutoPostBack="True" 
                                ToolTip="Informe a obra - Lista de valores disponível"></asp:TextBox>
                            <asp:Button ID="btnPesObra" runat="server" Text="..." CssClass="btn" 
                                onclick="btnPesObra_Click"/>
                            <asp:Label ID="lblDesObra" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtObra" CssClass="validacao" 
                                ErrorMessage="*" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>    
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Tombo:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTombo" runat="server" CssClass="inputbox" 
                                AutoPostBack="True" ontextchanged="txtTombo_TextChanged" 
                                ToolTip="Informe o tombo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valTombo" runat="server" 
                                ControlToValidate="txtTombo" ErrorMessage="*" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblInformacao" runat="server" CssClass="validacao"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Status:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o status">
                                <asp:ListItem Value="A">Ativo</asp:ListItem>
                                <asp:ListItem Value="I">Inativo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            Origem:
                        </td>
                        <td style="width: 120px">
                            <asp:DropDownList ID="ddlOrigem" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a origem">
                            </asp:DropDownList>
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
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdObra" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
