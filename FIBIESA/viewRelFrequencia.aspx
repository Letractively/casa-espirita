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
                <div class="container half left">
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
                                        ToolTip="Selecione o evento" AppendDataBoundItems="true" AutoPostBack="true"
                                        onselectedindexchanged="ddlEvento_SelectedIndexChanged">                                                                                                                            
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Selecione" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlEvento" validationgroup="grupo" ForeColor="Red"></asp:RequiredFieldValidator>                                   
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Selecione" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlTurma" validationgroup="grupo" ForeColor="Red"></asp:RequiredFieldValidator>                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Facilitador:
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
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">
                                    Mês:
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlMes" runat="server" AppendDataBoundItems="True" 
                                        CssClass="dropdownlist" ToolTip="Selecione o mês">
                                        <asp:ListItem Text="Janeiro" Value="01" ></asp:ListItem>                                            
                                        <asp:ListItem Text="Fevereiro" Value="02" ></asp:ListItem>                                            
                                        <asp:ListItem Text="Março" Value="03" ></asp:ListItem>
                                        <asp:ListItem Text="Abril" Value="04" ></asp:ListItem>
                                        <asp:ListItem Text="Maio" Value="05" ></asp:ListItem>
                                        <asp:ListItem Text="Junho" Value="06" ></asp:ListItem>
                                        <asp:ListItem Text="Julho" Value="07" ></asp:ListItem>
                                        <asp:ListItem Text="Agosto" Value="08" ></asp:ListItem>
                                        <asp:ListItem Text="Setembro" Value="09" ></asp:ListItem>
                                        <asp:ListItem Text="Outubro" Value="10" ></asp:ListItem>
                                        <asp:ListItem Text="Novembro" Value="11" ></asp:ListItem>
                                        <asp:ListItem Text="Dezembro" Value="12" ></asp:ListItem>                                            
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Todos" ErrorMessage="*" ToolTip="Obrigatório" SetFocusOnError="true"
        ControlToValidate="ddlMes" validationgroup="grupo" ForeColor="Red"></asp:RequiredFieldValidator>                                   
                                </td>                                    
                                <td style="width: 140px">
                                    Ano:
                                </td>
                                <td style="width: 240px">
                                    <asp:DropDownList ID="ddlAno" runat="server" AppendDataBoundItems="True" 
                                        CssClass="dropdownlist" ToolTip="Selecione o ano">                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td  colspan="3">                                   
                                        <asp:RadioButton ID="rbSemPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" Text="Sem Preenchimento">
                                        </asp:RadioButton>
                                        <asp:RadioButton ID="rbComPreenchimento" GroupName="Preenchimento" runat="server" CssClass="input" Text="Com Preenchimento">                                                                                    
                                        </asp:RadioButton>  
                                </td>                                                                      
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="3">
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
