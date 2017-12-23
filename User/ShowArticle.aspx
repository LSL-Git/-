<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ArticleInfo.master" AutoEventWireup="true" CodeFile="ShowArticle.aspx.cs" Inherits="User_ShowArticle"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../kindeditor/plugins/code/prettify.css" rel="stylesheet" />
    <script type="text/javascript" src="../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript" src="../kindeditor/kindeditor-all.js"></script>
    <script type="text/javascript" src="../kindeditor/lang/zh-CN.js"></script>
    <script type="text/javascript" src="../kindeditor/kindeditor-all-min.js"></script>
    <link href="../Styles/ShowArticle.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/mykindeditor2.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="user_win">
        <span>个人资料</span>
        <div class="user_icon">
            <asp:ImageButton ID="ib_userIcon" runat="server" ImageUrl="~/Image/userIcon/userIcon.jpeg"
                PostBackUrl="~/User/UserInfo.aspx" Visible="false" />
        </div>
        <asp:LinkButton ID="lbt_userName" runat="server" PostBackUrl="~/User/UserInfo.aspx"></asp:LinkButton>

        <asp:Button ID="bnt_Concern" runat="server" Text="+关注" CssClass="bnt" Visible="false" />

        <hr />

        <ul>
            <li>原创:33</li>
            <li>转载:22</li>
            <li>粉丝:32</li>
            <li>喜欢:14</li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main_box">
        <div class="box_header clearfix">
            <h2>
                <asp:Label ID="ArticleTitle" runat="server" Text="Error"></asp:Label>
            </h2>
            <ul>
                <li>
                    <asp:Label ID="ArticleType" runat="server" Text="原创" CssClass="type_cls"></asp:Label></li>
                <li>标签：<asp:Label ID="ArticleTag" runat="server" Text="" CssClass="label"></asp:Label></li>
                <li>浏览：<asp:Label ID="Browse_Num" runat="server" Text="" CssClass="label"></asp:Label></li>
                <li>评论：<asp:Label ID="Comment_Num" runat="server" Text="" CssClass="label"></asp:Label></li>
                <li>发表时间：<asp:Label ID="Pub_Time" runat="server" Text="" CssClass="label"></asp:Label></li>
            </ul>

            <span class="span1">楼主</span>
        </div>
        <hr />
        <div class="article_content">
            <asp:Label ID="ArticleContent" runat="server" Text="没有该文~！" CssClass="article_content"></asp:Label>
        </div>
    </div>


    <asp:Repeater ID="Repeater_Comment" runat="server">
        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                <div class="comment_box">
                    <div style="width: 100%; height: 10px; background: #f3f3f3; /*border-top: 1px solid #ccc; */"></div>
                    <div class="comment_main">
                        <div class="comment_user">
                            <asp:Image ID="Comm_Icon" runat="server" ImageUrl="~/Image/userIcon/userIcon.jpeg" CssClass="comm_icon" />
                            <asp:LinkButton ID="Link_UserName" runat="server" CssClass="comm_name">LinkButton</asp:LinkButton>
                            <asp:Label ID="L_Floor" runat="server" Text="1楼" CssClass="label1"></asp:Label>
                        </div>
                        <div class="comm_content">
                            <asp:Label ID="Comm_Content" runat="server" Text="Label"></asp:Label>
                        </div>

                        <div class="comm_other">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="Link_Report" runat="server">举报</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Link_Del" runat="server">删除</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:Label ID="LComm_Time" runat="server" Text="回复时间"></asp:Label>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Link_Comm" runat="server">回复</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>


    <div class="comment_box">
        <div style="width: 100%; height: 10px; background: #f3f3f3; /*border-top: 1px solid #ccc; */"></div>
        <div class="comment_main">
            <div class="comment_user">
                <%--    <div style="width:100%; height: 30px; background: #fff;">
    </div>--%>

                <asp:Label ID="Label1" runat="server" Text="发表评论" CssClass="comm_name"></asp:Label>
                <span class="span2">回复：<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">楼主</asp:ListItem>
                    <asp:ListItem>1楼</asp:ListItem>
                </asp:DropDownList></span>
            </div>
            <div class="comm_content2">
                <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
                <asp:TextBox ID="content" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="comm_other2">
                <%--<ul>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server">举报</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton3" runat="server">删除</asp:LinkButton>
                    </li>
                    <li>
                        <asp:Label ID="Label3" runat="server" Text="回复时间"></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server">回复</asp:LinkButton>
                    </li>
                </ul>--%>

                <asp:Button ID="Bnt_Comm" runat="server" Text="发表" CssClass="but_comm" OnClick="Bnt_Comm_Click" />
                &nbsp;&nbsp;
                <asp:Label ID="LMsg" runat="server" Text="" ForeColor="#ff0000"></asp:Label>

                <div class="comm_userLogin">
                    <asp:Label ID="LUserName" runat="server" Text="用户名：" Visible="false"></asp:Label>
                    <asp:TextBox ID="userName" runat="server"  Visible="false"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="LPassword" runat="server" Text="密码：" Visible="false"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Bnt_Login" runat="server" Text="登录" CssClass="but_comm"  Visible="false"/>
                </div>
            </div>            
        </div>
    </div>

    <%--    <div style="width:100%; height: 30px; background: #fff;">
    </div>--%>

    <div style="width: 100%; height: 30px; background: #f3f3f3;">
    </div>
</asp:Content>

