<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelItensEstoque.aspx.cs" Inherits="FIBIESA.viewRelItensEstoque" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updPrincipal" runat="server" UpdateMode="Always">
        <ContentTemplate>        
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>Relatório de Itens em Estoque</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Item:
                                </td>
                                <td style="width: 530px" colspan="2">
                                    <asp:TextBox ID="txtItem" runat="server" CssClass="inputbox" Width="110px" 
                                        AutoPostBack="true" ontextchanged="txtItem_TextChanged" ToolTip="Digite o código do Item."></asp:TextBox>                                                                                   
                                    <asp:Button ID="btnPesItem" runat="server" CssClass="btn" Text="..." 
                                        onclick="btnPesItem_Click"  />
                                    &nbsp;
                                    <asp:Label ID="lblDesItem" runat="server" Text="Todos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 530px" colspan="2" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbControlaEstoque" GroupName="Estoque" runat="server" CssClass="input" value="1" Text="   Controla Estoque">                                                                                                                                
                                        </asp:RadioButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="rbNaoControlaEstoque" GroupName="Estoque" runat="server" CssClass="input" value="0" Text="   Não Controla Estoque">
                                        </asp:RadioButton>
                                    </center>
                                </td>                                                                      
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Status:
                                </td>
                                <td style="width: 530px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Ativos" Value="1" ></asp:ListItem>                                            
                                        <asp:ListItem Text="Inativos" Value="0" ></asp:ListItem>                                            
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="middle" style="text-align:center;">
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        onclick="btnRelatorio_Click" />
                                </td>                                    
                            </tr>                                        
                        </table>
                    </div>
                </div>                
                <asp:HiddenField ID="hfIdItem" runat="server" Value="0" />
                <div class="status">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
