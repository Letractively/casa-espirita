<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadChamada.aspx.cs" Inherits="Admin.cadChamada" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Registro de Frequências</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">
                            * Evento:
                        </td>
                        <td style="width: 400px" colspan="3">                            
                            <asp:TextBox ID="txtEvento" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesEvento" runat="server" Text="..."  CssClass="btn" onclick="btnPesEvento_Click" 
                                />
                            <asp:Label ID="lblDesEvento" runat="server"></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEvento" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            * Turma:
                        </td>
                        <td style="width: 400px" colspan="3">                            
                            <asp:TextBox ID="txtTurma" runat="server" CssClass="inputbox"></asp:TextBox>
                            <asp:Button ID="btnPesTurma" runat="server" Text="..."  CssClass="btn" onclick="btnPesTurma_Click" 
                                />
                            <asp:Label ID="lblDesTurma" runat="server"></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtTurma" ErrorMessage="*Preenchimento Obrigatório" 
                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px"> </td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server"  Text="Voltar" CssClass="btn" 
                                onclick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnPesquisar" runat="server"  Text="Pesquisar" CssClass="btn" onclick="btnPesquisar_Click" 
                                 />  
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnInserir" runat="server"  Text="Inserir" CssClass="btn" 
                                onclick="btnInserir_Click" />  
                        </td>
                    </tr>
                    <tr>                        
                        <td colspan="2">
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
                                        <td><asp:CheckBox ID="chkPresenca" runat="server" Text="Consultar" Checked='<% #DataBinder.Eval(Container, "DataItem.PRESENCA") %>' /></td>
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
                </table>                
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdEvento" runat="server" />
            <asp:HiddenField ID="hfIdTurma" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
