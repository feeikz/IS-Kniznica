<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="WEB.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    

    <nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">WebSiteName</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="#">Home</a></li>
      <li><a href="Pozicky.aspx">Pôžičky</a></li>
    </ul>
        <form id="form1" runat="server">
         <div style="height: 38px; margin-left:80%;">
            <asp:Label ID="txtuser" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnlogout" runat="server" OnClick="Button1_Click" Text="Log out" Height="24px" Width="56px" />
        </div>
       </form>
    
  </div>    
</nav>

      


 

</body>
</html>
