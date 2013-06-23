<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true"
    CodeBehind="cadInstituicao.aspx.cs" Inherits="FIBIESA.cadInstituicao" %>
<%@ MasterType VirtualPath="~/home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div class="container half3 left">
            <div class="conthead">
                <h2>
                    Cadastro de Instituições</h2>
            </div>
            <div class="contentbox">
               <table>
                    <tr>
                        <td>
                            <asp:TabContainer ID="tcInstituicao" runat="server" ActiveTabIndex="0">
                                <asp:TabPanel ID="tpGeral" runat="server" HeaderText="Geral" >
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 140px">
                                                    * Código:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputboxRight" 
                                                        ToolTip="Informe o código da instituição" 
                                                        ontextchanged="txtCodigo_TextChanged" AutoPostBack="True" Width="100px" 
                                                        MaxLength="6"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo"
                                                        ErrorMessage="*Informe o código - Aba geral" ForeColor="#CC0000" 
                                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblInformacao" runat="server" CssClass="validacao" 
                                                        Font-Size="Smaller"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    * Razão Social:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtRazao" runat="server" CssClass="inputbox" MaxLength="70" 
                                                        Width="335px" ToolTip="Informe a razão social"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazao"
                                                        ErrorMessage="*Informe a razão social - Aba geral" ForeColor="#CC0000" 
                                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    * Nome Fantasia:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtNomeFantasia" runat="server" CssClass="inputbox" MaxLength="70" 
                                                        Width="335px" ToolTip="Informe o nome fantasia"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNomeFantasia"
                                                        ErrorMessage="*Informe o nome fantasia" ForeColor="#CC0000" 
                                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    * CNPJ:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCnpj" runat="server" CssClass="inputbox" MaxLength="14" 
                                                        ToolTip="Informe o CNPJ"></asp:TextBox>
                                                    <asp:Label ID="lblCnpj" runat="server" CssClass="validacao" 
                                                        Font-Size="Smaller" ></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCnpj"
                                                        ErrorMessage="*Informe o CNPJ - Aba geral" ForeColor="#CC0000" 
                                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                        ErrorMessage="*CNPJ com formato errado" ToolTip="Não Válida" SetFocusOnError="True"
ControlToValidate="txtCnpj" ValidationExpression="^\d{2}.?\d{3}.?\d{3}/?\d{4}.?\d{2}$" Display="Dynamic" validationgroup="salvar" 
                                                        ForeColor="Red"  CssClass="labelValignMiddle">*</asp:RegularExpressionValidator>
                                                    <asp:MaskedEditExtender runat="server" ID="mke" TargetControlID="txtCnpj" 
                                                        Mask="99,999,999/9999-99" ClearMaskOnLostFocus="False" 
                                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" 
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    * E-mail:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" 
                                                        Width="335px" ToolTip="Informe o e-mail"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                                        ErrorMessage="*Informe o e-mail - Aba geral" ForeColor="#CC0000" 
                                                        ValidationGroup="salvar">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*E-mail com formato errado"
                                                        ToolTip="Não Válido" SetFocusOnError="True" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        Display="Dynamic" ValidationGroup="salvar" CssClass="validacao">*</asp:RegularExpressionValidator>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Ranking:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtRanking" runat="server" CssClass="inputbox" MaxLength="40" ToolTip="Informe o ranking"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="True"
ControlToValidate="txtRanking" ValidationExpression="^\d+$" Display="Dynamic" validationgroup="salvar" ForeColor="Red"  
                                                        CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 80px">
                                                    Telefone:
                                                </td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txttelefone" runat="server" CssClass="inputbox" MaxLength="20" 
                                                        Width="100px" ToolTip="Informe o telefone"></asp:TextBox>  
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
                                                   CEP:
                                                </td>
                                                <td style="width: 400px">
                                                    <asp:TextBox ID="txtCep" runat="server" CssClass="inputbox" MaxLength="9" ToolTip="Informe o CEP" 
                                                        Width="110px"></asp:TextBox>                                                    
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        ErrorMessage="*" ToolTip="Não Válida" SetFocusOnError="True"
ControlToValidate="txtCep" ValidationExpression="^\d{5}-?\d{3}$" Display="Dynamic" validationgroup="salvar" 
                                                        ForeColor="Red"  CssClass="labelValignMiddle"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 140px">
                                                    UF:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlUF" runat="server" CssClass="dropdownlist" ToolTip="Selecione a UF"
                                                        onselectedindexchanged="ddlUF_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Cidade:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlCidades" runat="server" CssClass="dropdownlist"  ToolTip="Selecione a cidade"
                                                        onselectedindexchanged="ddlCidades_SelectedIndexChanged" 
                                                        AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td style="width: 140px">
                                                    Bairro:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:DropDownList ID="ddlBairro" runat="server" CssClass="dropdownlist" ToolTip="Informe o bairro"></asp:DropDownList>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Endereço:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="inputbox" MaxLength="70" Width="335px" ToolTip="Informe o endereço"></asp:TextBox>                                       
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 140px">
                                                    Número:
                                                </td>
                                                <td style="width: 500px">
                                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="inputbox" MaxLength="20" ToolTip="Informe o número"></asp:TextBox>                                                 
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
                                <asp:TabPanel ID="tpLogo" runat="server" HeaderText="Logo">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 540px; height: 54px;">
                                                    <strong><em>Imagem do Logotipo:</em></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/sem_images.jpg"  />   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:FileUpload ID="fupImgLogo" runat="server" />    
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
                        <td style="width: 140px">
                            
                        </td>
                        <td style="width: 400px">
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn" 
                                OnClick="btnVoltar_Click" ToolTip="Volta para página de consulta" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"
                                ValidationGroup="salvar" ToolTip="Valida e salva as informações" />
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    CssClass="validacao" ValidationGroup="salvar" />
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:HiddenField ID="hfIdInstLogo" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div class="status">
        </div>
    </div>
</asp:Content>
