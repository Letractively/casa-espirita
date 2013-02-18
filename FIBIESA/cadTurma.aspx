﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadTurma.aspx.cs" Inherits="Admin.cadTurma" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half2 left">
            <div class="conthead">
                <h2>
                    Cadastro de Turmas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            *
                            Código:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtCodigo" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            *
                            Descrição:
                        </td>
                        <td style="width: 400px" colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="40" Width="335px" ontextchanged="txtDescricao_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 140px">
                            * Evento:
                        </td>
                        <td style="width: 400px" colspan="3">                            
                            <asp:TextBox ID="txtEvento" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesEvento" runat="server" Text="..."  CssClass="btn"/>
                            <asp:Label ID="lblDesEvento" runat="server"></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEvento" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Instrutor:
                        </td>
                        <td style="width: 400px" colspan="3">                            
                            <asp:TextBox ID="txtInstrutor" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesInstrutor" runat="server" Text="..."  CssClass="btn"/>
                            <asp:Label ID="lblDesInstrutor" runat="server"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Dt. Início:</td>
                        <td>
                            <asp:TextBox ID="txtDtInicio" runat="server" CssClass="inputbox" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtInicio_CalendarExtender" runat="server" TargetControlID="txtDtInicio"
                                    Enabled="True">
                            </asp:CalendarExtender>
                        </td>
                        <td style="width: 140px">* Dt. Fim:</td>
                        <td>
                            <asp:TextBox ID="txtDtFim" runat="server" CssClass="inputbox" ></asp:TextBox>
                            <asp:CalendarExtender
                             ID="txtDtFim_CalendarExtender" runat="server" TargetControlID="txtDtFim"
                                        Enabled="True">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Hora Início:</td>
                        <td>
                            <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="inputbox" ></asp:TextBox>                          
                        </td>
                        <td style="width: 140px">Hora Fim:</td>
                        <td>
                            <asp:TextBox ID="txtHoraFim" runat="server" CssClass="inputbox" ></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">Sala:</td>
                        <td>
                            <asp:TextBox ID="txtSala" runat="server" CssClass="inputbox" ></asp:TextBox>                          
                        </td>
                        <td style="width: 140px">Dias da Semana:</td>
                        <td>
                            <asp:TextBox ID="txtDiaSemana" runat="server" CssClass="inputbox" ></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">* Nro. Máximo:</td>
                        <td style="width: 400px" colspan="3"> 
                            <asp:TextBox ID="txtNroMax" runat="server" CssClass="inputbox"></asp:TextBox>
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
                                onclick="btnSalvar_Click" ValidationGroup="salvar" />   
                        </td>
                    </tr>
                </table>                
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdEvento" runat="server" />
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
        
    </div>
</asp:Content>
