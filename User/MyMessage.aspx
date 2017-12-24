<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserInfoPage.master" AutoEventWireup="true" CodeFile="MyMessage.aspx.cs" Inherits="User_MyMessage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/RepeaterTable.css" rel="stylesheet" />
    <style type="text/css">
        .but_Del {
            display: block;
            float: right;
            margin-right: 10px;
        }

        .bn {
            margin-right: 15px;
            color: antiquewhite;
        }

        .but_Cont {
            text-decoration: none;
            font-size: 14px;
        }

        .span1 {
            color: #747474;
            font-size: 13px;
        }

        .msg_box {
            width: 95%;
            height: auto;
            margin: 0 auto;
        }

            .msg_box:hover {
                background: #f6f6f4;
            }

        .bntDelAll {
            float: right;
            margin: 0 15px;
            border: none;
            cursor: pointer;
            padding: 3px;
            background: #dfdfdf;
            box-shadow: 3px 1px 1px #ccc;
        }

            .bntDelAll:hover {
                background: #f6f6f4;
            }

        .msglist {
            padding: 3px;
        }

        .main_content {
            height: auto !important;
            overflow: hidden;
            padding-bottom: 40px;
        }

            .main_content .right_content {
                padding-bottom: 40px;
                height: auto !important;
                min-height: 888px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="width: 95%; height: 30px; margin: 15px auto; border-bottom: 1px solid #808080;">
        我的消息：<asp:DropDownList ID="MsgStateList" runat="server" AutoPostBack="True" CssClass="msglist">
            <asp:ListItem Selected="True">全部</asp:ListItem>
            <asp:ListItem>已读</asp:ListItem>
            <asp:ListItem>未读</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="bntDelAll" runat="server" Text="全部删除" CssClass="bntDelAll" />
        <asp:Button ID="bntReadAll" runat="server" Text="全部标记已读" CssClass="bntDelAll" />
    </div>

    <asp:Repeater ID="Repeater_MyMsg" runat="server">
        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                <div class="msg_box">
                    <div style="font-size: 14px; margin-left: 5px;">
                        <asp:LinkButton ID="lbtuserName" runat="server" Font-Underline="false" Font-Bold="true"
                            ForeColor="#038bcb"><%#DataBinder.Eval(Container.DataItem, "userName").ToString().Length > 6 ? 
                                                                DataBinder.Eval(Container.DataItem, "userName").ToString().Substring(0, 6) + "...":
                                                                DataBinder.Eval(Container.DataItem, "userName")%></asp:LinkButton>
                        <span class="username">,回复了我：</span>

                        <asp:LinkButton ID="lbtContent" runat="server" CssClass="but_Cont">
                                    <%#DataBinder.Eval(Container.DataItem, "Comment_Content").ToString()
                                            .Replace("<p>", "").Replace("</p>", "").Replace("</br>", "")
                                            .Replace("style","")%></asp:LinkButton>

                        <asp:LinkButton ID="lbt_Del" runat="server" CssClass="but_Del bn" ForeColor="#999999"
                            Font-Underline="false">删除</asp:LinkButton>
                    </div>
                    <div style="margin: 5px; font-size: 14px;">
                        <span style="color: #747474; font-size: 13px;">回复我的帖子/评论：</span>

                        <span style="color: #747474; font-size: 19px;">“</span>

                        <asp:LinkButton ID="lbtBcontent" runat="server" ForeColor="Black">
                                    <%#DataBinder.Eval(Container.DataItem, "BComment_Content")%></asp:LinkButton>

                        <span style="color: #747474; font-size: 19px;">”</span>

                        <div style="margin-top: 5px;">
                            <asp:LinkButton ID="lbtReply" runat="server" Font-Underline="false">回复</asp:LinkButton>
                            &nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtRead" runat="server" Font-Underline="false">标记为已读</asp:LinkButton>
                            <asp:Label ID="Label2" runat="server" ForeColor="#df0000" CssClass="but_Del">
                                        <%#DataBinder.Eval(Container.DataItem, "State").ToString() != "已读" ? 
                                                "<span style='color:red;'>未读</span>" : 
                                                "<span style='color:green;'>已读</span>"%></asp:Label>

                            <asp:Label ID="Label1" runat="server" CssClass="but_Del span1"
                                Text='<%#DataBinder.Eval(Container.DataItem, "Comment_Time")%>'></asp:Label>
                        </div>
                    </div>
                    <hr />
                </div>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>

    <div style="width: 95%; margin: 10px auto;">
        <webdiyer:AspNetPager ID="AspNetPager" runat="server" Width="100%"
            LayoutType="Div" PagingButtonLayoutType="Span" PagingButtonSpacing="0"
            PageSize="8" OnPageChanged="AspNetPager_PageChanged" CssClass="pagination"
            CurrentPageButtonClass="active">
        </webdiyer:AspNetPager>
    </div>
</asp:Content>

