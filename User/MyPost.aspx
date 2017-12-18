<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserInfoPage.master" AutoEventWireup="true" CodeFile="MyPost.aspx.cs" Inherits="User_MyPost" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Styles/RepeaterTable.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="width: 95%; margin: 10px auto;">
        类型：<asp:DropDownList ID="TypeDDList" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True">全部</asp:ListItem>
                <asp:ListItem>原创</asp:ListItem>
                <asp:ListItem>转载</asp:ListItem>
                <asp:ListItem>其他</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;标签：<asp:DropDownList ID="TagDDList" runat="server" 
            AutoPostBack="True">
            </asp:DropDownList>
        &nbsp;&nbsp;<asp:Label ID="Total" runat="server" Font-Size="14px" 
            ForeColor="#999999"></asp:Label>
    </div>

    <asp:Repeater ID="Repeater_Post" runat="server" 
        onitemcommand="Repeater_Post_ItemCommand">
        <HeaderTemplate>
            <table class="repeater_table">
                <thead>
                    <tr class="repeater_table_thead_tr">
                        <th style="width:38%; text-align: left; padding-left: 15px;">标题</th>
                        <th>状态</th>
                        <th>阅读</th>
                        <th>评论</th>
                        <th>评论权限</th>
                        <th>发表时间</th>
                        <th>操作</th>
                    </tr>
                </thead>           
        </HeaderTemplate>

        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">                
                    <tr class="repeater_table_tbody_tr">
                        <td style="padding-left: 15px;text-align: left;border-bottom: 1px solid #c5c5c5;">
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" ForeColor="#0D6CE9"
                                CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ArticleID")%>'>
                                <%#DataBinder.Eval(Container.DataItem, "Title")%></asp:LinkButton>
                        </td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Jurisdiction")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Browse_Num")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Comment_Num")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "State")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"Pub_Time")%></td>
                        <td>
                            <asp:LinkButton ID="lbtEdit" runat="server" Font-Underline="false" ForeColor="#009933"
                                CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ArticleID")%>'>编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbtClassify" runat="server" Font-Underline="false" ForeColor="#009933"
                                CommandName="Classify" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ArticleID")%>'>分类</asp:LinkButton>
                            <asp:LinkButton ID="lbtDelete" runat="server" Font-Underline="false" ForeColor="#ff0000"
                                CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ArticleID")%>'>删除</asp:LinkButton>
                        </td>
                    </tr>              
            </asp:Panel>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <div style="width: 95%; margin: 10px auto;">
        <webdiyer:AspNetPager ID="AspNetPager" runat="server" Width="100%" UrlPaging="true"
         LayoutType="Div" PagingButtonLayoutType="Span" PagingButtonSpacing="0"
          PageSize="12" onpagechanged="AspNetPager_PageChanged" CssClass="pagination"
            CurrentPageButtonClass="active">
        </webdiyer:AspNetPager>
    </div>
</asp:Content>

