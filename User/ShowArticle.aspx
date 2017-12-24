<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ArticleInfo.master" AutoEventWireup="true" CodeFile="ShowArticle.aspx.cs" Inherits="User_ShowArticle" ValidateRequest="false" %>

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
    <div style="width: 100%; height: 40px; background: #fff; text-align: center;">
        <asp:Label ID="LMsg2" runat="server" Text="该帖子还没有评论！期待你的神评~" Visible="false"></asp:Label>
    </div>

    <asp:Repeater ID="Repeater_Comment" runat="server">
        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                <div class="comment_box">
                    <div style="width: 100%; height: 10px; background: #f3f3f3; /*border-top: 1px solid #ccc; */"></div>
                    <div class="comment_main">
                        <div class="comment_user">
                            <asp:Image ID="Comm_Icon" runat="server"
                                ImageUrl='<%#DataBinder.Eval(Container.DataItem, "img")%>' CssClass="comm_icon" />

                            <asp:LinkButton ID="Link_UserName" runat="server" CommandName="LookUser" ToolTip='<%#DataBinder.Eval(Container.DataItem, "userName")%>'
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Comment_UserID")%>'
                                CssClass="comm_name"><%#DataBinder.Eval(Container.DataItem, "userName")%></asp:LinkButton>

                            <asp:Label ID="L_Floor" runat="server" CssClass="label1"><%#DataBinder.Eval(Container.DataItem, "Floor")%>楼</asp:Label>
                        </div>
                        <div class="comm_content">
                            <asp:Label ID="Comm_Content" runat="server"
                                Text='<%#DataBinder.Eval(Container.DataItem, "Comment_Content")%>'></asp:Label>
                        </div>

                        <div class="comm_other">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="Link_Report" runat="server" CommandName="Report" Font-Underline="false" ToolTip="举报"
                                        ForeColor="#8b8b8b" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Comment_UserID")%>'>举报</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Link_Del" runat="server" CommandName="DelComm" ToolTip="删除评论" Font-Underline="false"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID")%>' ForeColor="#8b8b8b">删除</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:Label ID="LComm_Time" runat="server" ToolTip="评论时间" Font-Underline="false" ForeColor="#8b8b8b">
                                        评论于：<%#DataBinder.Eval(Container.DataItem, "Comment_Time")%></asp:Label>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Link_Comm" runat="server" CommandName="Reply" ToolTip="回复" Font-Underline="false"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Comment_UserID")%>'>回复</asp:LinkButton>
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
                <span class="span2">回复：<asp:DropDownList ID="FloorList" runat="server">
                    <asp:ListItem Selected="True" Value="0">楼主</asp:ListItem>
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
                    <asp:TextBox ID="txtUserName" runat="server" Visible="false"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="LPassword" runat="server" Text="密码：" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Bnt_Login" runat="server" Text="登录" CssClass="but_comm" Visible="false" />
                </div>
            </div>
        </div>
    </div>

    <%--    <div style="width:100%; height: 30px; background: #fff;">
    </div>--%>

    <div style="width: 100%; height: 30px; background: #f3f3f3;">
    </div>
</asp:Content>

