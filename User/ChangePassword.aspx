<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserInfoPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="User_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Styles/UserInfo.css" rel="stylesheet" type="text/css" />

    <div class="user_info_box">
        <ul>
            <li>原&nbsp;密&nbsp;码&nbsp;：<asp:TextBox ID="txtOriginPsw" runat="server" TextMode="Password"></asp:TextBox>
            </li>
            <li>新&nbsp;密&nbsp;码&nbsp;：<asp:TextBox ID="txtNewPsw" runat="server" TextMode="Password"></asp:TextBox>
            </li>
            <li>确认密码：<asp:TextBox ID="txtNewRPsw" runat="server" TextMode="Password"></asp:TextBox>
            </li>
        </ul>

        <div>
            <asp:Button ID="butChange" runat="server" Text="修改" CssClass="but_update" 
                onclick="butChange_Click"/>            
        </div>
        
    </div>
</asp:Content>

