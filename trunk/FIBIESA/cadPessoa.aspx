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
                            <asp:TabContainer ID="tcPessoa" runat="server" ActiveTabIndex="0">
                                <asp:TabPanel runat="server" HeaderText="Geral" ID="tpGeral">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 200px">
                                                   * Código:
                                                </td>
                                                <td style="width: 150px" >
                                                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>   
                                                </td> 
                                                <td style="width: 150px">
                                                   * Data Cadastro:
                                                </td>
                                                <td style="width: 150px" colspan="3">
                                                    <asp:TextBox ID="txtDtCadastro" runat="server" CssClass="inputbox" 
                                                        ReadOnly="True" Width="110px"></asp:TextBox>                                                    
                                                </td>                                               
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    <asp:Label ID="lblDesNome" runat="server"></asp:Label>
                                                </td>                                                   
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtNome" runat="server" CssClass="inputbox" MaxLength="70" ToolTip="Informe o nome"
                                                        Width="280px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Infome o Nome/Razão social"
                                                        ControlToValidate="txtNome" ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>                                                                   
                                                <td colspan="2">
                                                    <asp:RadioButtonList ID = "rbTipoAssoc" runat="server" RepeatColumns="2">
                                                        <asp:ListItem Selected="True" Value="A">Associado</asp:ListItem>
                                                        <asp:ListItem Value="E">Efetivo</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>                                                                           
                                            </tr>                                            
                                            <tr>
                                                <td style="width: 200px">
                                                   * CPF/CNPJ:
                                                </td>
                                                <td style="width: 150px">
                                                    <asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="inputbox" MaxLength="14" 
                                                        ToolTip="Informe o CPF/CNPJ" AutoPostBack="True" 
                                                        ontextchanged="txtCpfCnpj_TextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCpfCnpj" ErrorMessage="Informe o CPF/CNPJ"
                                                        ForeColor="#CC0000" ValidationGroup="salvar" >*</asp:RequiredFieldValidator>   
                                                    <asp:Label ID="lblCpfCnpjInvalido" runat="server" CssClass="validacao" 
                                                        Font-Size="Smaller"></asp:Label>                                                 
                                                </td>  
                                                <td style="width: 150px">
                                                   * Categoria:
                                                </td>
                                                <td style="width: 200px" colspan="2">                                                   
                                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdownlist" ToolTip="Selecione a categoria">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                                runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Informe a Categoria"
                                                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>  
                                            </tr>
                                            <tr>
                                            <td style="width: 200px" >
                                                    RG:
                                                </td>
                                                <td style="width: 150px">
                                                    <asp:TextBox ID="txtRg" runat="server" CssClass="inputbox" MaxLength="14" ToolTip="Informe o RG"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px">
                                                    Sexo:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="dropdownlist" ToolTip="Selecione o sexo">
                                                        <asp:ListItem>Selecione</asp:ListItem>
                                                        <asp:ListItem Value="F">Feminino</asp:ListItem>
                                                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Data de Nascimento:
                                                </td>
                                                <td style="width: 180px" >
                                                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="inputbox" ToolTip="Informe a data de nascimento"
                                                        Width="110px"></asp:TextBox><asp:CalendarExtender
                                                        ID="txtDataNascimento_CalendarExtender" runat="server" TargetControlID="txtDataNascimento"
                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                        ErrorMessage="*Data com formato errado" ToolTip="Data com formato errado" SetFocusOnError="True" 
ControlToValidate="txtDataNascimento" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            Display="Dynamic" validationgroup="salvar" CssClass="validacao"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 150px">
                                                    Estado Civil:
                                                </td>
                                                <td style="width: 150px" colspan="3">
                                                    <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="dropdownlist" ToolTip="Selecione o estado civil" >
                                                        <asp:ListItem>Selecione</asp:ListItem>
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
                                                <td style="width: 150px" colspan="3">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" ToolTip="Informe o e-mail"
                                                        Width="280px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                                        ErrorMessage="*Formato do e-mail errado" ToolTip="Não Válido" SetFocusOnError="True"
ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" 
                                                        validationgroup="salvar"  CssClass="validacao">*</asp:RegularExpressionValidator>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Nome da Mãe:
                                                </td>
                                                <td style="width: 150px" colspan="3">
                                                    <asp:TextBox ID="txtNomeMae" runat="server" CssClass="inputbox" MaxLength="70" ToolTip="Informe o nome da mãe" 
                                                        Width="280px"></asp:TextBox>
                                                </td>     
                                            </tr>
                                            <tr>                                       
                                                <td style="width: 150px">
                                                    Nome do Pai:
                                                </td>
                                                <td style="width: 150px" colspan="3">
                                                    <asp:TextBox ID="txtNomePai" runat="server" CssClass="inputbox" MaxLength="70" ToolTip="Informe o nome do pai"
                                                        Width="280px"></asp:TextBox>
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
                                                  * CEP:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCep" runat="server" CssClass="inputbox" MaxLength="9" ToolTip="Informe o CEP"
                                                        Width="110px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCep" ErrorMessage="Informe o CEP - Aba Endereço"
                                                        ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="True"
ControlToValidate="txtCep" ValidationExpression="^\d{5}-?\d{3}$" Display="Dynamic" validationgroup="salvar" 
                                                        ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 140px">
                                                   * UF:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlUF" runat="server" CssClass="dropdownlist" ToolTip="Informe a UF"
                                                        onselectedindexchanged="ddlUF_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                   * Cidade:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlCidades" runat="server" CssClass="dropdownlist" ToolTip="Selecione a cidade"
                                                        onselectedindexchanged="ddlCidades_SelectedIndexChanged" 
                                                        AutoPostBack="True"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                runat="server" ControlToValidate="ddlCidades" ErrorMessage="Informe a Cidade - Aba Endereço"
                                                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td style="width: 140px">
                                                   * Bairro:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlBairro" runat="server" CssClass="dropdownlist" ToolTip="Selecione o bairro" ></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                                runat="server" ControlToValidate="ddlBairro" ErrorMessage="Informe o Bairro - Aba Endereço"
                                                                ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                   * Endereço:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="inputbox" MaxLength="70" Width="335px" ToolTip="Informe o endereço"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtEndereco" ErrorMessage="Informe o Endereço - Aba Endereço"
                                                        ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                   * Número:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox" MaxLength="20" ToolTip="Informe o número"
                                                        Width="110px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNumero" ErrorMessage="Informe o Número - Aba Endereço"
                                                        ForeColor="#CC0000" ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Complemento:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtComplemento" runat="server" CssClass="inputbox" MaxLength="40" ToolTip="Informe o complemento"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpTelefone" runat="server" HeaderText="Referência/Telefones">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <strong>Referências:</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Referência Nome:
                                                </td>
                                                <td colspan = "4">
                                                    <asp:TextBox ID="txtRefNome" runat="server" MaxLength="70" Width="335px" CssClass="inputbox"
                                                    ToolTip="Informe o nome da referência" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Referência Telefone:
                                                </td>
                                                <td colspan ="4">
                                                    <asp:TextBox ID="txtRefTelefone" runat="server" MaxLength="13" CssClass="inputbox"
                                                    ToolTip="Informe o telefone da referência"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Telefones: </strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 70px">
                                                    Tipo:
                                                </td>
                                                <td style="width: 150px">
                                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="dropdownlist" ToolTip="Selecione o tipo de telefone">
                                                        <asp:ListItem>Celular</asp:ListItem>
                                                        <asp:ListItem>Comercial</asp:ListItem>
                                                        <asp:ListItem>Residencial</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px">
                                                    Telefone:
                                                </td>
                                                <td style="width: 300px">
                                                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="inputbox" MaxLength="13" ToolTip="Informe o telefone"></asp:TextBox>&nbsp;&nbsp;
                                                    <asp:Button ID="btnInserirTelefone" runat="server" CssClass="btn" Text="Inserir"
                                                        OnClick="btnInserirTelefone_Click" ValidationGroup="salvarTelefone" /><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefone" ErrorMessage="*Preenchimento Obrigatório"
                                                            ForeColor="#CC0000" ValidationGroup="salvarTelefone"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="dtgTelefones" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="IDORDEM,ID" 
                                                        OnRowDeleting="dtgTelefones_RowDeleting" GridLines="None" 
                                                        onrowdatabound="dtgTelefones_RowDataBound">
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True">
                                                                <HeaderStyle CssClass="grd_cmd_header" />
                                                                <ItemStyle CssClass="grd_delete" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
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
                                                    <asp:TextBox ID="txtEmpresa" runat="server" CssClass="inputbox" MaxLength="70" Width="335px"
                                                    ToolTip="Informe a empresa"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtCepProf" runat="server" CssClass="inputbox" MaxLength="9" 
                                                        Width="110px" ToolTip="Informe o CEP profissional"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                        ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="True"
ControlToValidate="txtCepProf" ValidationExpression="^\d{5}-?\d{3}$" Display="Dynamic" validationgroup="salvar" 
                                                        ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                   * UF:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlUfProf" runat="server" CssClass="dropdownlist" 
                                                        AutoPostBack="True" ToolTip="Selecione a UF profissional"
                                                        onselectedindexchanged="ddlUfProf_SelectedIndexChanged" ></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cidade:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:DropDownList ID="ddlCidadeProf" runat="server" CssClass="dropdownlist" 
                                                            AutoPostBack="True"  ToolTip="Selecione a cidade profissional"
                                                        onselectedindexchanged="ddlCidadeProf_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Bairro:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:DropDownList ID="ddlBairroProf" runat="server" CssClass="dropdownlist" 
                                                            AutoPostBack="True" ToolTip="Selecione o bairro profissional"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Endereço:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtEnderecoProf" runat="server" CssClass="inputbox" MaxLength="70"
                                                        Width="335px" ToolTip="Informe o endereço profissional"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Número:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNumeroProf" runat="server" CssClass="inputbox" 
                                                        MaxLength="20" Width="110px" ToolTip="Informe o número"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Complemento:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtComplementoProf" runat="server" CssClass="inputbox" MaxLength="40"
                                                    ToolTip="Informe o complemento"></asp:TextBox>
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
                                                        Columns="75" TextMode="MultiLine" Width="440px" MaxLength="500" ToolTip="Informe a observação"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>

                                <asp:TabPanel ID="tpFoto" HeaderText="Foto" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 540px; height: 700px;">
                                                    <div id='errorLocation' style="font-size: small;color: Gray;"></div>

                                                    <div id="silverlightControlHost">
		                                                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
			                                                <param name="source" value="ClientBin/WebCamTeste.xap"/>
			                                                <param name="onerror" value="onSilverlightError" />
			                                                <param name="background" value="white" />
			                                                <param name="minRuntimeVersion" value="4.0.41108.0" />
			                                                <param name="autoUpgrade" value="true" />
			                                                <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.41108.0" style="text-decoration: none;">
     			                                                <img src="http://go.microsoft.com/fwlink/?LinkID=161376" alt="Get Microsoft Silverlight" style="border-style: none"/>
			                                                </a>
		                                                </object>
                                                        <!--iframe id='imagemFoto' style='visibility:hidden;height:0;width:0;border:0px'></iframe-->
                                                    </div>
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
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" OnClick="btnVoltar_Click" 
                            ToolTip="Volta para página principal"/>
                            &nbsp;&nbsp;&nbsp
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                ValidationGroup="salvar"  ToolTip="Valida e salva as informações"/>
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                CssClass="validacao" ValidationGroup="salvar" />
            </div>
            
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdTelefone" runat="server" />
            <asp:HiddenField ID="hfOrdemFone" runat="server" />
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
