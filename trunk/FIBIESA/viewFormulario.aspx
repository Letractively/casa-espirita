<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="viewFormulario.aspx.cs" Inherits="Admin.viewFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>Formulário</h2>
            </div>
            <div class="contentbox">
                <asp:TextBox ID="txtBusca" runat="server" CssClass="inputbox"></asp:TextBox>
                <asp:Button ID="Busca" runat="server" Text="Buscar" CssClass="btn" OnClick="Busca_Click" />
                <!-- grid modelo começa aqui -->
                <div class="contentbox">
                    <table width="100%">
                        <thead>
                            <tr>
                                <th>
                                    Título
                                </th>
                                <th>
                                    Sub-título
                                </th>
                                <th>
                                    Ação
                                </th>
                                <th>
                                    <input name="" type="checkbox" value="" id="checkboxall" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Conteúdo
                                </td>
                                <td>
                                    O no nono nononono nono nonononono.
                                </td>
                                <td>
                                    <a href="cadFormulario.aspx" title=""><img src="images/icons/icon_edit.png" alt="Edit" /></a>
                                    <a href="#" title=""><img src="images/icons/icon_approve.png" alt="Approve" /></a>
                                    <a href="#" title=""><img src="images/icons/icon_unapprove.png" alt="Unapprove" /></a>
                                    <a href="#" title=""><img src="images/icons/icon_delete.png" alt="Delete" /></a>
                                </td>
                                <td>
                                    <input type="checkbox" value="" name="checkall" />
                                </td>
                            </tr>
                            <tr class="alt">
                                <td>
                                    Conteúdo
                                </td>
                                <td>
                                    O no nono nononono nono nonononono.
                                </td>
                                <td>
                                    <a href="#" title="">
                                        <img src="images/icons/icon_edit.png" alt="Edit" /></a> <a href="#" title="">
                                            <img src="images/icons/icon_approve.png" alt="Approve" /></a> <a href="#" title="">
                                                <img src="images/icons/icon_unapprove.png" alt="Unapprove" /></a> <a href="#" title="">
                                                    <img src="images/icons/icon_delete.png" alt="Delete" /></a>
                                </td>
                                <td>
                                    <input type="checkbox" value="" name="checkall" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Conteúdo
                                </td>
                                <td>
                                    O no nono nononono nono nonononono.
                                </td>
                                <td>
                                    <a href="#" title="">
                                        <img src="images/icons/icon_edit.png" alt="Edit" /></a> <a href="#" title="">
                                            <img src="images/icons/icon_approve.png" alt="Approve" /></a> <a href="#" title="">
                                                <img src="images/icons/icon_unapprove.png" alt="Unapprove" /></a> <a href="#" title="">
                                                    <img src="images/icons/icon_delete.png" alt="Delete" /></a>
                                </td>
                                <td>
                                    <input type="checkbox" value="" name="checkall" />
                                </td>
                            </tr>
                            <tr class="alt">
                                <td>
                                    Conteúdo
                                </td>
                                <td>
                                    O no nono nononono nono nonononono.
                                </td>
                                <td>
                                    <a href="#" title="">
                                        <img src="images/icons/icon_edit.png" alt="Edit" /></a> <a href="#" title="">
                                            <img src="images/icons/icon_approve.png" alt="Approve" /></a> <a href="#" title="">
                                                <img src="images/icons/icon_unapprove.png" alt="Unapprove" /></a> <a href="#" title="">
                                                    <img src="images/icons/icon_delete.png" alt="Delete" /></a>
                                </td>
                                <td>
                                    <input type="checkbox" value="" name="checkall" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="extrabottom">
                        <ul class="pagination">
                            <li class="text">Anterior</li>
                            <li class="page"><a href="#" title="">1</a></li>
                            <li><a href="#" title="">2</a></li>
                            <li><a href="#" title="">3</a></li>
                            <li><a href="#" title="">4</a></li>
                            <li class="text"><a href="#" title="">Próximo</a></li>
                        </ul>
                    </div>
                </div>
                <!-- grid modelo finaliza aqui -->
                <br />
                <br />
                <asp:GridView ID="GridProduto" runat="server">
                </asp:GridView>
                <br />
                <br />
                <br />
            </div>
        </div>
        <div class="status">
        </div>
    </div>    
</asp:Content>
