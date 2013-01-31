<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadPessoa.aspx.cs" Inherits="Admin.cadPessoa" %>

<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container">
            <div class="conthead">
                <h2>
                    Cadastro de Pessoas</h2>
            </div>
            <div class="contentbox">
                <table>
                    <tr>
                        <td>
                            <asp:TabContainer ID="tcPessoa" runat="server" ActiveTabIndex="2">
                                <asp:TabPanel runat="server" HeaderText="Geral" ID="tpGeral">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 200px">
                                                    Código:
                                                </td>
                                                <td style="width: 400px" colspan="3">
                                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputbox" ></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Preenchimento Obrigatório"
                                                        ControlToValidate="txtCodigo" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Nome:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNome" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Preenchimento Obrigatório"
                                                        ControlToValidate="txtNome" ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 200px">
                                                    Data Cadastro:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtDtCadastro" runat="server" CssClass="inputbox" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Nome Fantasia:
                                                </td>
                                                <td style="width: 400px" colspan="3">
                                                    <asp:TextBox ID="txtNomeFantasia" runat="server" CssClass="inputbox" MaxLength="70"
                                                        Width="334px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Categoria:
                                                </td>
                                                <td style="width: 400px" colspan="3">
                                                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesCategoria" runat="server" Text="..." CssClass="btn" OnClick="btnPesCategoria_Click" />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesCategoria" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                                runat="server" ControlToValidate="txtCategoria" ErrorMessage="*Preenchimento Obrigatório"
                                                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    CPF/CNPJ:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="inputbox" MaxLength="14"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCpfCnpj" ErrorMessage="*Preenchimento Obrigatório"
                                                        ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 200px">
                                                    RG:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtRg" runat="server" CssClass="inputbox" MaxLength="14"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Data de Nascimento:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="inputbox"></asp:TextBox><asp:CalendarExtender
                                                        ID="txtDataNascimento_CalendarExtender" runat="server" TargetControlID="txtDataNascimento"
                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td style="width: 200px">
                                                    Estado Civil:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:DropDownList ID="ddlEstadoCivil" runat="server">
                                                        <asp:ListItem>Solteiro</asp:ListItem>
                                                        <asp:ListItem>Casado</asp:ListItem>
                                                        <asp:ListItem>Separado</asp:ListItem>
                                                        <asp:ListItem>Divorciado</asp:ListItem>
                                                        <asp:ListItem Value="Viuvo">Viúvo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    E-mail:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" Width="335px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Nome da Mãe:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNomeMae" runat="server" CssClass="inputbox" MaxLength="70" 
                                                        Width="335px"></asp:TextBox>
                                                </td>                                            
                                                <td style="width: 200px">
                                                    Nome do Pai:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNomePai" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Naturalidade:
                                                </td>
                                                <td style="width: 400px" colspan="3">
                                                    <asp:TextBox ID="txtNaturalidade" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesNaturalidade" runat="server" CssClass="btn" Text="..." OnClick="btnPesNaturalidade_Click" />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesNaturalidade" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpEndereco" runat="server" HeaderText="Endereço">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cidade:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtCidade" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesCidade" runat="server" CssClass="btn" Text="..." OnClick="btnPesCidade_Click" />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesCidade" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                runat="server" ControlToValidate="txtCidade" ErrorMessage="*Preenchimento Obrigatório"
                                                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    CEP:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCep" runat="server" CssClass="inputbox" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCep" ErrorMessage="*Preenchimento Obrigatório"
                                                        ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Bairro:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtBairro" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesBairro" runat="server" CssClass="btn" Text="..." OnClick="btnPesBairro_Click" />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesBairro" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                                runat="server" ControlToValidate="txtBairro" ErrorMessage="*Preenchimento Obrigatório"
                                                                ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Endereço:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEndereco" ErrorMessage="*Preenchimento Obrigatório"
                                                        ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Número:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNumero" ErrorMessage="*Preenchimento Obrigatório"
                                                        ForeColor="#CC0000" ValidationGroup="salvar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Complemento:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtComplemento" runat="server" CssClass="inputbox" MaxLength="40"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpTelefone" runat="server" HeaderText="Telefones">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                                    Tipo:
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                                        <asp:ListItem>Celular</asp:ListItem>
                                                        <asp:ListItem>Comercial</asp:ListItem>
                                                        <asp:ListItem>Residencial</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px">
                                                    Telefone:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="inputbox" MaxLength="13"></asp:TextBox>&nbsp;&nbsp;
                                                    <asp:Button ID="btnInserirTelefone" runat="server" CssClass="btn" Text="Inserir"
                                                        OnClick="btnInserirTelefone_Click" ValidationGroup="salvarTelefone" /><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefone" ErrorMessage="*Preenchimento Obrigatório"
                                                            ForeColor="#CC0000" ValidationGroup="salvarTelefone"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="dtgTelefones" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CODIGO"
                                                        OnSelectedIndexChanged="dtgTelefones_SelectedIndexChanged" OnRowDeleting="dtgTelefones_RowDeleting">
                                                        <Columns>
                                                            <asp:CommandField ShowSelectButton="True">
                                                                <HeaderStyle CssClass="grd_cmd_header" />
                                                                <ItemStyle CssClass="grd_edit" />
                                                            </asp:CommandField>
                                                            <asp:CommandField ShowDeleteButton="True">
                                                                <HeaderStyle CssClass="grd_cmd_header" />
                                                                <ItemStyle CssClass="grd_delete" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                                            <asp:BoundField DataField="CODIGO" HeaderText="Codigo" Visible="False" />
                                                            <asp:BoundField DataField="DESCRICAO" HeaderText="Tipo" />
                                                            <asp:BoundField DataField="NUMERO" HeaderText="Número" />
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpProfissional" runat="server" HeaderText="Profissional">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 140px">
                                                    Empresa:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtEmpresa" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <strong><em>Endereço Profissional</em></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    CEP:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCepProf" runat="server" CssClass="inputbox" MaxLength="10"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cidade:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCidadeProf" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesCidProf" runat="server" CssClass="btn" Text="..." OnClick="btnPesCidProf_Click" />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesCidProf" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Bairro:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtBairroProf" runat="server" CssClass="inputbox"></asp:TextBox><asp:Button
                                                        ID="btnPesBairroProf" runat="server" CssClass="btn" Text="..." />&nbsp;&nbsp;<asp:Label
                                                            ID="lblDesBairroProf" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Endereço:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtEnderecoProf" runat="server" CssClass="inputbox" MaxLength="70"
                                                        Width="335px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Número:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNumeroProf" runat="server" CssClass="inputbox" MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Complemento:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtComplementoProf" runat="server" CssClass="inputbox" MaxLength="40"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpObs" HeaderText="Observação" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 540px; height: 54px;">
                                                    <strong><em>Observação:</em></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 540px; height: 54px;">
                                                    <asp:TextBox ID="txtObservacao" runat="server" CssClass="text-input textarea" Rows="10"
                                                        Columns="75" TextMode="MultiLine" Width="440px" MaxLength="500"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click" />
                            &nbsp;&nbsp;&nbsp
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                ValidationGroup="salvar" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:HiddenField ID="hfIdCategoria" runat="server" />
            <asp:HiddenField ID="hfIdBairro" runat="server" />
            <asp:HiddenField ID="hfIdCidade" runat="server" />
            <asp:HiddenField ID="hfIdNaturalidade" runat="server" />
            <asp:HiddenField ID="hfIdCidProf" runat="server" />
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdBairroProf" runat="server" />
            <asp:HiddenField ID="hfCodTel" runat="server" />
            <asp:HiddenField ID="hfCodTelAlt" runat="server" />
            <asp:HiddenField ID="hfIdTelefone" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
