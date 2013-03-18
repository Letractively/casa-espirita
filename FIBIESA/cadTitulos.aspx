<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTitulos.aspx.cs" Inherits="Admin.cadTitulos" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Cadastro de Títulos</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            *
                            Numero:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumero"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            *
                            Parcela:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtParcela" runat="server" CssClass="inputbox" MaxLength="70"
                                Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtParcela"
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Valor:</td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputbox" MaxLength="70"
                                Width="335px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValor" 
                                ErrorMessage="*Preenchimento Obrigatório" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Pessoa:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtPessoa" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesPessoa" runat="server" CssClass="btn" Text="..." OnClick="btnPesPessoa_Click" />&nbsp;&nbsp;
                            <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                        </td>
                    </tr>                   
                    <tr>
                        <td style="width: 140px">
                            Portador:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtPortador" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesPortador" runat="server" CssClass="btn" Text="..." OnClick="btnPesPortador_Click" />
                            &nbsp;&nbsp;<asp:Label ID="lblDesPortador" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data do Vencimento:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDataVencimento" runat="server" CssClass="inputbox" MaxLength="70"
                                Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 140px">
                            Data da Emissão:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDataEmissao" runat="server" CssClass="inputbox" MaxLength="70"
                                Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo do Documento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTipoDocumento" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesTipoDocumento" runat="server" CssClass="btn" Text="..." OnClick="btnPesPortador_Click" />
                            &nbsp;&nbsp;<asp:Label ID="lblDesTipoDocumento" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTipo" runat="server" CssClass="inputbox" MaxLength="40"
                                Width="147px"></asp:TextBox>
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
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdPortador" runat="server" />
            <asp:HiddenField ID="hfIdTipoDocumento" runat="server" />
        </div>
        <div class="status">            
        </div>
    </div>
</asp:Content>
