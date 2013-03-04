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
                        <td style="width: 130px"> * Data: </td>  
                        <td style="width: 150px"> * Evento: </td> 
                        <td style="width: 150px" colspan="2"> * Turma: </td>                         
                    </tr>
                    <tr>    
                        <td style="width: 130px"> 
                        <asp:TextBox ID="txtSelData" CssClass="inputbox" runat="server" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtSelData_CalendarExtender" runat="server" TargetControlID="txtSelData"
                            Enabled="True">
                        </asp:CalendarExtender>                           
                        </td>  
                        <td style="width: 280px">                                                         
                            <asp:TextBox ID="txtEvento" runat="server" CssClass="inputbox" Width="75px"></asp:TextBox>
                            <asp:Button ID="btnPesEvento" runat="server" Text="..."  CssClass="btn" onclick="btnPesEvento_Click" 
                                />
                            <asp:Label ID="lblDesEvento" runat="server"></asp:Label>
                                                      
                        </td>                        
                        <td style="width: 280px">  
                            <asp:TextBox ID="txtTurma" runat="server" CssClass="inputbox" Width="75px"></asp:TextBox>
                            <asp:Button ID="btnPesTurma" runat="server" Text="..."  CssClass="btn" onclick="btnPesTurma_Click" 
                                />
                            <asp:Label ID="lblDesTurma" runat="server"></asp:Label>
                                                   
                        </td>
                        <td>                           
                            <asp:Button ID="btnPesquisar" runat="server"  Text="Pesquisar" CssClass="btn" 
                              onclick="btnPesquisar_Click"/>  
                        </td>
                    </tr>    
                    <tr>
                        <td></td>
                         <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEvento" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator></td>
                          <td colspan="2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtTurma" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator></td>
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
            <asp:HiddenField ID="hfIdEvento" runat="server" />
            <asp:HiddenField ID="hfIdTurma" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
