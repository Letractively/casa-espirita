<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacaoLogin.aspx.cs" Inherits="FIBIESA.recuperacaoLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  
    <link href="styles/login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 300px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="logincontainer">
        <h1>            
            <br/><span>Problemas com login?</span>
        </h1>  
        <div id="loginbox"> 
               <p> Um novo login será enviado para o e-mail cadastrado. 
                Digite seu e-mail:  </p><br />
               
                <div class="inputcontainer">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Height="16px" 
                        Width="251px" ></asp:TextBox>                   
                </div>                  
                <asp:Button ID="btnEnviar" Text="Enviar" CssClass="loginsubmit" 
                    runat="server" ValidationGroup="salvar" onclick="btnEnviar_Click" />            
                <p><asp:Label ID="lblMensagem" runat="server" ForeColor="#CC0000"></asp:Label> </p>                
        </div>
       </div>
    </form>
</body>
</html>
