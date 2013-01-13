<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadCurso.aspx.cs" Inherits="Admin.cadCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Curso</h2>
            </div>
            <div class="contentbox">
                <table>
                    
                    <tr>
                        <td style="width: 140px">Código:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_codigo" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Descrição:</td>
                        <td style="width: 400px">
                            <asp:TextBox ID="_descricao" runat="server" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <input type="submit" value="Enviar" class="btn_Salvar" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>
    </form>
</asp:Content>
