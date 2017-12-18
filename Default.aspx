<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../kindeditor/plugins/code/prettify.css" rel="stylesheet" />
    <script src="../kindeditor/plugins/code/prettify.js"></script>
    <script src="../kindeditor/kindeditor-all.js"></script>
    <script src="../kindeditor/lang/zh-CN.js"></script>
    <script src="../kindeditor/kindeditor-all-min.js"></script>
    <script src="Scripts/mykindeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            密码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="加密" />
            <br />
            加密后：<asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
            对比密码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="对比" />
            <br />
            对比结果：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:TextBox ID="content" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
