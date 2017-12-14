<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="Views_Register" %>

<link href="../Styles/Register.css" rel="stylesheet" type="text/css" />

<table align="center">
    <thead>
        <tr>
            <td></td>
            <td align="center">
                <h2>用户注册</h2>
            </td>
            <td></td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td align="right">
                <span>用户名:</span>
            </td>
            <td>
                <asp:TextBox ID="newUser" runat="server" CssClass="i-input"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="newUser" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td align="right">
                <span>密码:</span>
            </td>
            <td>
                <asp:TextBox ID="newPsw" runat="server" TextMode="Password" CssClass="i-input"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="newPsw" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span>确认密码:</span>
            </td>
            <td>
                <asp:TextBox ID="newRpsw" runat="server" TextMode="Password" CssClass="i-input"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="newRpsw" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span>手机号:</span>
            </td>
            <td>
                <asp:TextBox ID="newTel" runat="server" CssClass="i-input"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="newTel" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <td></td>
            <td align="center">
                <asp:Button ID="butRegister" runat="server" Text="立即注册" Height="40px" BackColor="#038bcb" 
                BorderStyle="None" Font-Names="微软雅黑" Font-Size="17px" ForeColor="White" 
                OnClick="Button1_Click" Width="257px"/>
            </td>
            <td>
                <asp:Label ID="registerMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="center">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/User/Login.aspx" style="text-decoration: none;">我已注册，登录</asp:HyperLink>
            </td>
            <td></td>
        </tr>
    </tfoot>
</table>