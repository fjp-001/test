﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testBuyTicket.aspx.cs" Inherits="testBuyTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />    
    测试更改
    测试合并
    </div>
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Height="489px" TextMode="MultiLine" Width="1052px"></asp:TextBox>
    
    </div>
        <div>
    <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="测试" />
    
    </div>
    </form>
</body>
</html>
