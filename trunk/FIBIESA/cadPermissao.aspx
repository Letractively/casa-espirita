<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadPermissao.aspx.cs" Inherits="Admin.cadPermicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Cadastro de Permissões</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                    <td  style="width: 80px" >
                           <strong>Categoria:</strong>     
                        </td>
                        <td>
                            <asp:Label ID="lblDesCategoria" runat="server"></asp:Label>
                        </td>
                   </tr>
                    <tr>                        
                        <td  style="width: 80px" >
                           <strong>Módulo:</strong>     
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModulo" runat="server" CssClass="dropdownlist" 
                                ToolTip="Selecione o Módulo">
                                <asp:ListItem Value="F">Financeiro</asp:ListItem>
                                <asp:ListItem Value="B">Biblioteca</asp:ListItem>
                                <asp:ListItem Value="E">Estoque</asp:ListItem>
                                <asp:ListItem Value="V">Eventos</asp:ListItem>
                                <asp:ListItem Value="G">Geral</asp:ListItem>
                                <asp:ListItem Value="C">Configuração</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn" Text="Buscar" 
                                onclick="btnBuscar_Click" 
                                ToolTip="Pesquisar páginas do módulo selecionado" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                        
                            <asp:Repeater ID="repPermissao" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <thead>
                                    <tr>                                        
                                        <th></th><th></th><th></th><th>Código</th><th>Página</th><th>Tipo</th><th colspan="4">Tipos de permissões</th>   
                                    </tr>
                                    </thead>
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                    <tr>              
                                        <td><asp:TextBox ID="txtId" runat="server" Visible="false" Text='<% #DataBinder.Eval(Container, "DataItem.ID") %>'></asp:TextBox></td> 
                                        <td><asp:TextBox ID="txtFormularioId" runat="server" Visible="false" Text='<% #DataBinder.Eval(Container, "DataItem.FORMULARIOID") %>'></asp:TextBox></td>  
                                        <td><asp:TextBox ID="txtCategoriaId" runat="server" Visible="false" Text='<% #DataBinder.Eval(Container, "DataItem.CATEGORIAID") %>'></asp:TextBox></td>                        
                                        <td><asp:Label ID="lblCodFormulario" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.CODFORMULARIO") %>'></asp:Label></td> 
                                        <td><asp:Label ID="lblDescFormulario" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.DESCFORMULARIO") %>'></asp:Label></td> 
                                        <td><asp:Label ID="lblTipo" runat="server" Text='<% #DataBinder.Eval(Container, "DataItem.TIPO") %>'></asp:Label></td> 
                                        <td><asp:CheckBox  ID="chkConsultar" runat="server" Text="Consultar" Checked='<% #DataBinder.Eval(Container, "DataItem.CONSULTAR") %>' /></td>
                                        <td><asp:CheckBox  ID="chkEditar" runat="server" Text="Editar" Checked='<% #DataBinder.Eval(Container, "DataItem.EDITAR") %>' /></td>
                                        <td><asp:CheckBox  ID="chkInserir" runat="server" Text="Inserir" Checked='<% #DataBinder.Eval(Container, "DataItem.INSERIR") %>' /></td>
                                        <td><asp:CheckBox  ID="chkExcluir" runat="server" Text="Excluir" Checked='<% #DataBinder.Eval(Container, "DataItem.EXCLUIR") %>' /></td>  
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
                <table>
                    <tr>
                        <td style="width: 140px">
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" Text="Voltar" CssClass="btn" runat="server" 
                                onclick="btnVoltar_Click" ToolTip="Volta para página principal" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" Text="Salvar" CssClass="btn" runat="server" 
                                onclick="btnSalvar_Click" ToolTip="Valida e salva as informações" />                           
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="status">
        </div>
    </div>   
</asp:Content>
