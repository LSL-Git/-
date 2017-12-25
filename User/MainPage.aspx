<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="User_MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/MainPage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="menu hyperlink">全部</asp:HyperLink>
    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="menu hyperlink">热门</asp:HyperLink>
    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="menu hyperlink">精品</asp:HyperLink>
    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="menu hyperlink">原创</asp:HyperLink>
    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="menu hyperlink">排行</asp:HyperLink>
    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="menu hyperlink">其他</asp:HyperLink>--%>

    <asp:Menu ID="Menu1" runat="server" CssClass="left_menu" OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="全部" Value="全部"></asp:MenuItem>
            <asp:MenuItem Text="热帖" Value="热帖"></asp:MenuItem>
            <asp:MenuItem Text="精华" Value="精华"></asp:MenuItem>
            <asp:MenuItem Text="原创" Value="原创"></asp:MenuItem>
            <asp:MenuItem Text="排行" Value="排行"></asp:MenuItem>
            <%--            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>--%>
        </Items>
        <StaticSelectedStyle BackColor="#FF3399" />
    </asp:Menu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="rigth_content_top">
        <%--<asp:Label ID="Label1" runat="server" Text="标签"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="AccessDataSource1" DataTextField="tag" DataValueField="tag">
        </asp:DropDownList>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/BBSdb.accdb" SelectCommand="SELECT [tag] FROM [ArticleTag]"></asp:AccessDataSource>--%>
    </div>

    <asp:Repeater ID="Repeater_Article" runat="server">
        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                <div class="main_box clearfix">
                    <div class="box_top">
                        <div class="box_top_left">
                            <asp:Label ID="Level" runat="server">
                                <%#       DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() == "热帖" ?
                                          "<span class='span3'>" + DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() + "</span>"
                                        : DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() == "精华" ?
                                          "<span class='span4'>" + DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() + "</span>"
                                        : DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() == "置顶" ?
                                           DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString()
                                        : DataBinder.Eval(Container.DataItem, "Jurisdiction").ToString() != "通过" ?
                                           ""
                                        : DataBinder.Eval(Container.DataItem, "Type").ToString() == "原创" ?
                                        "<span class='span2'>" + DataBinder.Eval(Container.DataItem, "Type").ToString() + "</span>"
                                        :"<span class='span5'>" + DataBinder.Eval(Container.DataItem, "Type").ToString() + "</span>"%>
                                        
                            </asp:Label>

                            <asp:HyperLink ID="link_title" runat="server" Target="_blank"
                                NavigateUrl='<%#"~/User/ShowArticle.aspx?ArticleId=" + DataBinder.Eval(Container.DataItem, "ArticleID")%>'>
                                <%#DataBinder.Eval(Container.DataItem, "Title")%></asp:HyperLink>
                        </div>
                        <div class="box_top_right">
                            <asp:Label ID="LnewCommUser" runat="server">
                                标签：<span class="span1"><%#DataBinder.Eval(Container.DataItem, "Tag")%></span></asp:Label>
                        </div>
                    </div>

                    <div class="box_bottom">
                        <div class="box_bottom_left">
                            <asp:LinkButton ID="lbtuserName" runat="server"><%#DataBinder.Eval(Container.DataItem, "userName")%></asp:LinkButton>
                            <asp:Label ID="LPubTime" runat="server" Text="">发表时间：<%#DataBinder.Eval(Container.DataItem, "Pub_Time")%></asp:Label>
                        </div>
                        <div class="box_bottom_right">
                            <asp:Label ID="LBrowse" runat="server" Text="">浏览：<%#DataBinder.Eval(Container.DataItem, "Browse_Num")%></asp:Label>
                            <asp:Label ID="LComment" runat="server" Text="">评论：<%#DataBinder.Eval(Container.DataItem, "Comment_Num")%></asp:Label>
                            <asp:Label ID="LnewCommTime" runat="server" Text="">赞：<%#DataBinder.Eval(Container.DataItem, "Favour_Num")%></asp:Label>
                        </div>
                        <hr />
                    </div>
                </div>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>

    <div class="footer_box clearfix">
        <%--<div class="box_top">
            <div class="box_top_left">
                <asp:Label ID="Label2" runat="server" Text="置顶"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/User/ShowArticle.aspx">标题</asp:HyperLink>
            </div>
            <div class="box_top_right">
                <asp:Label ID="Label3" runat="server" Text="浏览"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="评论"></asp:Label>
            </div>
        </div>

        <div class="box_bottom">
            <div class="box_bottom_left">
                <asp:LinkButton ID="LinkButton1" runat="server">用户名</asp:LinkButton>
                <asp:Label ID="Label7" runat="server" Text="发表时间"></asp:Label>
            </div>
            <div class="box_bottom_right">
                <asp:Label ID="Label5" runat="server" Text="最新评论用户名"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="最新评论时间"></asp:Label>
            </div>
            <hr />
        </div>--%>
    </div>
</asp:Content>

