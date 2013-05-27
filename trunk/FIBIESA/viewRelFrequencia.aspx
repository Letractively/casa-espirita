<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewRelFrequencia.aspx.cs" Inherits="FIBIESA.viewRelFrequencia" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlPesquisa" runat="server" UpdateMode="Always">
        <ContentTemplate>        
            <div id="content">
                <div class="container">
                    <div class="conthead">
                        <h2>Relatório de Frequência</h2>
                    </div>
                    <div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">
                                    Evento:
                                </td>
                                <td style="width: 530px" colspan="3">
                                    <asp:DropDownList ID="ddlEvento" runat="server" CssClass="dropdownlist" 
                                        ToolTip="Selecione o instrutor" AppendDataBoundItems="true" AutoPostBack="true"
                                        onselectedindexchanged="ddlEvento_SelectedIndexChanged" >                                        
                                    </asp:DropDownList>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlEvento" InitialValue="Selecione" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Turma:
                                </td>
                                <td style="width: 530px" colspan="3">
                                    <asp:DropDownList ID="ddlTurma" runat="server" CssClass="dropdownlist" 
                                        ToolTip="Selecione a turma" AppendDataBoundItems="false" AutoPostBack="true"
                                        onselectedindexchanged="ddlTurma_SelectedIndexChanged">                                        
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlTurma"  InitialValue="0" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Instrutor:
                                </td>
                                <td style="width: 530px" colspan="3">
                                    <asp:Label ID="lblInstrutor" runat="server"/>                                                                            
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Participante:
                                </td>
                                <td style="width: 530px" colspan="3">
                                    <asp:DropDownList ID="ddlParticipante" runat="server" CssClass="dropdownlist" 
                                        ToolTip="Selecione o participante" AppendDataBoundItems="false">                                        
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlParticipante"  InitialValue="Todos" Display="Dynamic" validationgroup="grupo" ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Mês:
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlMes" runat="server" AppendDataBoundItems="True" 
                                        CssClass="dropdownlist" ToolTip="Selecione o mês">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>                                            
                                        <asp:ListItem Text="Janeiro" Value="1" ></asp:ListItem>                                            
                                        <asp:ListItem Text="Fevereiro" Value="2" ></asp:ListItem>                                            
                                        <asp:ListItem Text="Março" Value="3" ></asp:ListItem>
                                        <asp:ListItem Text="Abril" Value="4" ></asp:ListItem>
                                        <asp:ListItem Text="Maio" Value="5" ></asp:ListItem>
                                        <asp:ListItem Text="Junho" Value="6" ></asp:ListItem>
                                        <asp:ListItem Text="Julho" Value="7" ></asp:ListItem>
                                        <asp:ListItem Text="Agosto" Value="8" ></asp:ListItem>
                                        <asp:ListItem Text="Setembro" Value="9" ></asp:ListItem>
                                        <asp:ListItem Text="Outubro" Value="10" ></asp:ListItem>
                                        <asp:ListItem Text="Novembro" Value="11" ></asp:ListItem>
                                        <asp:ListItem Text="Dezembro" Value="12" ></asp:ListItem>                                            
                                    </asp:DropDownList>
                                </td>                                    
                                <td style="width: 140px">
                                    Ano:
                                </td>
                                <td style="width: 240px">
                                    <asp:DropDownList ID="ddlAno" runat="server" AppendDataBoundItems="True" 
                                        CssClass="dropdownlist" ToolTip="Selecione o ano">
                                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>                                                                                                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="4" style="text-align:center;">
                                    <center>
                                        <asp:RadioButton ID="rbComPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" value="1" Text="Com Preenchimento">                                                                                    
                                        </asp:RadioButton>
                                        <asp:RadioButton ID="rbSemPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" value="0" Text="Sem Preenchimento">
                                        </asp:RadioButton>
                                    </center>
                                </td>                                                                      
                            </tr>
                            <tr>
                                <td colspan="4" valign="middle" style="text-align:center;">
                                    <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                    onclick="btnVoltar_Click" ToolTip="Volta para página principal" />
                                            &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnRelatorio" runat="server" CssClass="btn" Text="Relatório" 
                                        onclick="btnRelatorio_Click" validationgroup="grupo"/>
                                </td>                                    
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="status">
                </div>                
                <asp:HiddenField ID="hfIdEvento" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdTurma" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdInstrutor" runat="server" Value="0" />
                <asp:HiddenField ID="hfIdParticipante" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
