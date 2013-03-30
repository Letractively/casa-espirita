<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadChamada.aspx.cs" Inherits="Admin.cadChamada" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Registro de Frequências</h2>
            </div>
            <div class="contentbox">
                <table>                                  
                    <tr>                         
                        <td style="width: 150px"> * Evento: </td> 
                        <td style="width: 150px"> * Turma: </td> 
                        <td style="width: 130px" colspan="2"> * Data: </td>                         
                    </tr>
                    <tr>                           
                        <td style="width: 280px">                                                         
                            <asp:DropDownList ID="ddlEvento" runat="server" CssClass="dropdownlist" 
                                AutoPostBack="True" onselectedindexchanged="ddlEvento_SelectedIndexChanged">
                            </asp:DropDownList>       
                        </td>                        
                        <td style="width: 280px"> 
                            <asp:DropDownList ID="ddlTurmas" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>                                                                               
                        </td>
                        <td style="width: 130px"> 
                        <asp:TextBox ID="txtSelData" CssClass="inputbox" runat="server" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtSelData_CalendarExtender" runat="server" TargetControlID="txtSelData"
                            Enabled="True">
                        </asp:CalendarExtender>                           
                        </td>  
                        <td>                           
                            <asp:Button ID="btnPesquisar" runat="server"  Text="Pesquisar" CssClass="btn" 
                              onclick="btnPesquisar_Click"/>  
                        </td>
                    </tr>    
                    <tr>                        
                         <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlEvento" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator></td>
                          <td colspan="2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlTurmas" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator></td>
                          <td></td>
                    </tr>               
                    <tr>                        
                        <td colspan="4">
                             <asp:Repeater ID="repPermissao" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <thead>
                                    <tr>                                        
                                        <th></th><th></th><th>Código</th><th>Nome</th><th>Status</th><th>Data</th> 
                                    </tr>
                                    </thead>
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                    <tr>  
                                        <td><asp:TextBox ID="txtId" runat="server" Visible="false" Text='<% #DataBinder.Eval(Container, "DataItem.ID") %>'></asp:TextBox></td>
                                        <td><asp:TextBox ID="txtTurmaParticipanteId" runat="server" Visible="false" Text='<% #DataBinder.Eval(Container, "DataItem.TURMAPARTICIPANTEID") %>'></asp:TextBox></td>                                                        
                                        <td><asp:Label ID="lblCodParticipante" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.CODPARTICIPANTE") %>'></asp:Label></td> 
                                        <td><asp:Label ID="lblDescParticipante" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.DESCPARTICIPANTE") %>'></asp:Label></td> 
                                        <td><asp:CheckBox ID="chkPresenca" runat="server" Text="Presente" Checked='<% #DataBinder.Eval(Container, "DataItem.PRESENCA") %>' /></td>
                                        <td><asp:Label ID="lblData" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.DATA") %>' /></td>                                     
                                    </tr>  
                                    </tbody>  
                                </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                            </asp:Repeater>        
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100px"> </td>
                        <td colspan="3">
                            <asp:Button ID="btnVoltar" runat="server"  Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" />                           
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnInserir" runat="server"  Text="Salvar" CssClass="btn" 
                                onclick="btnInserir_Click" />  
                        </td>
                    </tr>
                </table>                
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
