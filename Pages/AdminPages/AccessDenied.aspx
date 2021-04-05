<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="BsolutionWebApp.Pages.AdminPages.AccessDenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <span class="auto-style1"><strong>You are Not Allowed To Access this Page&nbsp; , To Go Page Home&nbsp; Press </strong>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        </span></div>
    </form>
</body>
</html>
