<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        .formclass
        {
            padding:10px;
            margin-top:0px auto;
            background:#fff;
            width:200px;
        }
        .input 
        {
            padding:10px;
            width:100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="formclass">

            <asp:TextBox ID="txtuser" class="input" placeholder="User Name" runat="server"></asp:TextBox> <br/> <br />

            <asp:TextBox ID="txtpass"  class="input" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox> <br/> <br />
            <asp:Button ID="Button1"  class="input" runat="server" Text="Login" OnClick="Button1_Click" />

        </div>
    </form>
</body> 
</html>
