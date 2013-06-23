<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadConta.aspx.cs" Inherits="Admin.cadConta" %>
 <%@ MasterType VirtualPath="~/home.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container half left">
            <div class="conthead">
                <h2>Cadastro de Contas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td style="width: 140px">Banco:</td>
                        <td style="width: 250px" colspan="3">
                             <asp:DropDownList ID="ddlBanco" runat="server" CssClass="dropdownlist" 
                                 AutoPostBack="True" onselectedindexchanged="ddlBanco_SelectedIndexChanged" 
                                 ToolTip="Selecione o banco">
                             </asp:DropDownList>                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 179px">* Agência:</td>
                        <td style="width: 350px">      
                            <asp:DropDownList ID="ddlAgencia" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione a agência">
                             </asp:DropDownList>   
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlAgencia" ErrorMessage="*Informe a agência" 
                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>                    
                        <td style="width: 100px">* Dígito:</td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtDigito" runat="server" CssClass="inputbox" MaxLength="2" 
                                Width="50px" ToolTip="Informe o dígito verificador"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtDigito" ErrorMessage="*Informe o dígito verificador" 
                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 179px">* Código:</td>
                        <td style="width: 250px" colspan="3">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputboxRight" 
                                Width="100px" ToolTip="Informe o código da conta" MaxLength="8" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtCodigo" ErrorMessage="*Informe o código da conta" 
                                CssClass="validacao" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td style="width: 179px">* Descrição:</td>
                        <td style="width: 250px" colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="inputbox" 
                                MaxLength="100" Width="335px" ToolTip="Informe a descrição da agência"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescricao" ErrorMessage="*Informe a descrição da agência" 
                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 179px">* Titular:</td>
                        <td style="width: 250px" colspan="3">
                            <asp:TextBox ID="txtTitular" runat="server" CssClass="inputbox"  
                                Width="335px" ToolTip="Informe o nome do titular" MaxLength="70"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtTitular" ErrorMessage="*Informe o nome do titular" 
                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>           
                </table>
                <table>
                    <tr>
                        <td style="width: 140px">
                           
                        </td>
                        <td style="width: 250px">
                           <asp:Button ID="btnVoltar" runat="server" CssClass="btn" Text="Voltar" 
                                onclick="btnVoltar_Click" ToolTip="Volta para a página de consulta" /> 
                           &nbsp;&nbsp;&nbsp;
                           <asp:Button ID="btnSalvar" runat="server" CssClass="btn" Text="Salvar" 
                                onclick="btnSalvar_Click" ValidationGroup="salvar" 
                                ToolTip="Salva as informações da conta" />                             
                        </td>
                    </tr>
                </table>
            </div>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                CssClass="validacao" ValidationGroup="salvar" />
             <asp:HiddenField ID="hfId" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
