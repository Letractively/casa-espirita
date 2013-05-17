<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cadJuroMulta.aspx.cs" Inherits="Admin.cadJuroMulta" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
<div id="content">
        		<div class="container half left">
                	<div class="conthead">
                    	<h2>Cadastro de Juros&nbsp; e Multas</h2>
                    </div>
                	<div class="contentbox">
                        <table>
                            <tr>
                                <td style="width: 140px">* Mês / Ano:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtMesAno" runat="server" CssClass="inputbox" Width="110px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtMesAno" ErrorMessage="*Preenchimento Obrigatório" 
                                        ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                    <asp:CalendarExtender
                                        ID="txtMesAno_CalendarExtender" runat="server" TargetControlID="txtMesAno"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">% Juro Dia:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtJuroDia" runat="server" CssClass="inputboxRight" Width="110px" 
                                        MaxLength="12" ></asp:TextBox>
                                </td>   
                             </tr>
                            <tr>                       
                                <td style="width: 140px">% Juro Mês:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtJuroMes" runat="server" CssClass="inputboxRight" Width="110px" 
                                        MaxLength="12"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px">Valor Multa Dia:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtMultaDia" runat="server" CssClass="inputboxValor" Width="110px" 
                                        MaxLength="12"></asp:TextBox>
                                </td> 
                            </tr>
                            <tr>                          
                                <td style="width: 140px">Valor Multa Mês:</td>
                                <td style="width: 400px">
                                    <asp:TextBox ID="txtMultaMes" runat="server" CssClass="inputboxValor" Width="110px" 
                                        MaxLength="12"></asp:TextBox>
                                </td>
                            </tr>

                            </table>
                        <table>
                           <tr>
                                <td style="width: 140px"></td>
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
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                        EnableScriptLocalization="true">
                    </asp:ScriptManager>
                </div>
                <div class="status"></div>  
        	</div>   
</asp:Content>
