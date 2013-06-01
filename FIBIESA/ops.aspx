<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="ops.aspx.cs" Inherits="FIBIESA.ops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>Opss....</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnVoltar" Text="Voltar" runat="server" CssClass="btn" 
                                onclick="btnVoltar_Click" />
                        </td>
                    </tr>
                </table>                                               
            </div>            
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
