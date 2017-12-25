<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserInfoPage.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="User_UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/UserInfo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="user_info_box">
        <asp:Image ID="userIcon" runat="server" CssClass="img" Height="100px" Width="100px" ImageUrl="~/Image/userIcon/userIcon.jpeg" />
        <span>用户头像~</span>
        <ul>
            <li>用户名：<asp:TextBox ID="txtUserName" runat="server" Enabled="False"
                CssClass="textbox"></asp:TextBox>
            </li>
            <li>积&nbsp;分：&nbsp;&nbsp;<asp:TextBox ID="UserExp" runat="server" Enabled="False"
                CssClass="textbox" ForeColor="#FF9900"></asp:TextBox>
            </li>
            <li>手机号：<asp:TextBox ID="txtUserTel" runat="server" Enabled="False"
                CssClass="textbox"></asp:TextBox>
            </li>
            <li>邮&nbsp;箱：&nbsp;&nbsp;<asp:TextBox ID="txtUserEmail" runat="server" Enabled="False"
                CssClass="textbox"></asp:TextBox>
            </li>
            <li>性&nbsp;别：&nbsp;&nbsp;<asp:DropDownList ID="Sex" runat="server" Font-Size="17px"
                Enabled="False">
                <asp:ListItem Selected="True"></asp:ListItem>
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
            </li>
            <li>学&nbsp;历：&nbsp;&nbsp;<asp:DropDownList ID="edu" runat="server"
                Font-Size="17px" Enabled="False">
                <asp:ListItem Selected="True"></asp:ListItem>
                <asp:ListItem>博士后</asp:ListItem>
                <asp:ListItem>博士</asp:ListItem>
                <asp:ListItem>硕士</asp:ListItem>
                <asp:ListItem>大学</asp:ListItem>
                <asp:ListItem>高中</asp:ListItem>
                <asp:ListItem>初中</asp:ListItem>
                <asp:ListItem>小学</asp:ListItem>
                <asp:ListItem>幼儿园</asp:ListItem>
            </asp:DropDownList>
            </li>
            <li style="position: relative">出生日期：
                <div class="calendar1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtUserBirth" runat="server" Enabled="False"
                                CssClass="textbox"></asp:TextBox>
                            <div id="calendar" class="calendar" visible="false" runat="server">
                                <asp:Calendar ID="Calendar1" runat="server"
                                    OnSelectionChanged="Calendar1_SelectionChanged" Font-Size="11px"></asp:Calendar>
                            </div>
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_but"
                                ImageUrl="~/Image/calendar.jpg" OnClick="ImageButton1_Click" Visible="False" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </li>
            <li>个人简述：<asp:TextBox ID="txtUserSketch" runat="server" Enabled="False"
                CssClass="textbox" Width="400px"></asp:TextBox>
            </li>
        </ul>

        <div>
            <asp:Button ID="butUpdate" runat="server" Text="修改" CssClass="but_update"
                OnClick="butUpdate_Click" />
            <asp:Button ID="butCancel" runat="server" CssClass="but_update"
                OnClick="butCancel_Click" Text="取消" Visible="False" />

            <asp:Button ID="butAdmin" runat="server" CssClass="but_update" Text="管理员" Visible="False" OnClick="butAdmin_Click" />
        </div>
    </div>
</asp:Content>
