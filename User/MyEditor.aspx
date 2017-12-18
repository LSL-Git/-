<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyEditor.aspx.cs" Inherits="User_MyEditor" ValidateRequest="false" %>

<%@ Register Src="~/Views/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<%-- kindeditor version 4.1.11 --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>编辑器</title>    
    <link href="../kindeditor/plugins/code/prettify.css" rel="stylesheet" />
    <script type="text/javascript" src="../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript" src="../kindeditor/kindeditor-all.js"></script>
    <script type="text/javascript" src="../kindeditor/lang/zh-CN.js"></script>
    <script type="text/javascript" src="../kindeditor/kindeditor-all-min.js"></script>
    <link href="../Styles/Editor.css" rel="stylesheet" />
    <link href="../Styles/UserMaster.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/mykindeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server" name="example">
        <div class="header">
            <div class="header_box clearfix">
                <div class="logo"></div>
                <div class="left_head">
                    <ul>
                        <li>
                            <asp:HyperLink ID="link_home" runat="server" CssClass="hyperlink" 
                                NavigateUrl="~/User/MainPage.aspx">首页</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="link_addT" runat="server" CssClass="hyperlink">发帖+</asp:HyperLink></li>
                    </ul>
                </div>
                <div class="right_head">
                    <h1>
                        <asp:Label ID="title" runat="server" Text="写新帖"></asp:Label>
                    </h1>
                </div>
            </div>        
        </div>

        <div class="editor_box">
            <div class="box_top">
                <span>标&nbsp;题:</span><asp:TextBox ID="txtTitle" runat="server" CssClass="title_box"></asp:TextBox>
                <asp:Label ID="Title_msg" runat="server" Text="（标题最多30个字）" Font-Size="17px"></asp:Label>
                <asp:DropDownList ID="ArticleTypeList" runat="server" CssClass="article_type" Font-Size="17px">
                    <asp:ListItem Selected="True">原创</asp:ListItem>
                    <asp:ListItem>转载</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            </div>
            <hr />

            <div class="box_main">
                <asp:TextBox ID="content" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="box_bottom">
                <asp:Button ID="butPublish" runat="server" Text="发表" OnClick="butPublish_Click" CssClass="but_publish" />
                &nbsp;&nbsp;<asp:Button ID="butSaveDraft" runat="server" Text="存为草稿~" BackColor="White" BorderStyle="None" Font-Size="17px" ForeColor="#999999" OnClick="butSaveDraft_Click" style="height: 23px" />
                &nbsp;&nbsp;<asp:Label ID="Err_Msg" runat="server" ForeColor="#FF9900"></asp:Label>
                &nbsp;&nbsp;<asp:HyperLink ID="link_login" runat="server" Font-Underline="False" NavigateUrl="~/User/Login.aspx" ForeColor="#00CC00" Target="_blank" Visible="False">前往登录</asp:HyperLink>
                <div class="article_type type">
                    <asp:Label ID="Article_Tag" runat="server" Text="选择标签：" Font-Size="17px"></asp:Label>
                    <asp:DropDownList ID="ArticleTagList" runat="server" Font-Size="17px" CssClass="select_type">
                    </asp:DropDownList>
                </div>
            </div>
        </div>      

        <div class="footer">
            <uc1:Footer runat="server" ID="Footer" />
        </div>
    </form>
</body>
</html>
