<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadReserva.aspx.cs" Inherits="Admin.cadReserva" %>
<%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>
                    [Reserva</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Pessoa:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtPessoa" runat="server" CssClass="inputbox" Width="75px"></asp:TextBox>
                            <asp:Button ID="btnPesPessoa" runat="server" Text="..." CssClass="btn" 
                                onclick="btnPesPessoa_Click"  />
                            <asp:Label ID="lblDesPessoa" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtPessoa" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Exemplar:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtExemplar" runat="server" CssClass="inputbox" Width="75px"></asp:TextBox>
                            <asp:Button ID="btnExemplar" runat="server" Text="..." CssClass="btn" 
                                onclick="btnExemplar_Click" />
                            <asp:Label ID="lblDesExemplar" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtExemplar" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data empréstimo: 
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtdataInicio" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtdataInicio" ErrorMessage="*Preenchimento Obrigatório" 
                                ValidationGroup="salvar" CssClass="validacao"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Prevista Devolução:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtdataPrevisao" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtdataPrevisao" ErrorMessage="*Preenchimento Obrigatório" 
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
                                onclick="btnSalvar_Click" ValidationGroup="salvar"/> 
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:HiddenField ID="hfIdExemplar" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
