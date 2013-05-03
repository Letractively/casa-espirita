<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTitulo.aspx.cs" Inherits="Admin.cadTitulo" %>
<%@ MasterType VirtualPath="~/home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>Título</h2>
            </div>
            <div class="contentbox" style="height: 1000px">
                <table>
                    <tr>
                        <td style="width: 140px">
                            Pessoa:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlPessoa" runat="server" CssClass="dropdownlist"></asp:DropDownList> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Portador:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlPortador" runat="server" CssClass="dropdownlist"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo de Documento:
                        </td>
                        <td style="width: 400px">
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="dropdownlist"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Número:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Parcela:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtParcela" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Valor:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Vencimento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataVencimento" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Emissão:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataEmissao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Tipo:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtTipo" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Data Pagamento:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtDataPagamento" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Valor Pago:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtValorPago" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            Obs:
                        </td>
                        <td style="width: 400px">
                            <asp:TextBox ID="txtObs" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnSalvar" runat="server" Text ="Salvar" CssClass="btn" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" />
                        &nbsp;</td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
        </div>
        <div class="status"></div>
    </div>   
</asp:Content>
