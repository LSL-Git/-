<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Views_Login" %>
<link href="../Styles/Login.css" rel="stylesheet" />

<div class="box">
    <h2 class="box-input">用户登录</h2>
    <div class="box-input">
        <asp:TextBox 
            ID="userName" 
            runat="server" 
            Rows="1" 
            Wrap="False" 
            CssClass="i-input" 
            BackColor="White" 
            Font-Names="微软雅黑" 
            Font-Size="17px" 
            Text="请输入用户名"
            OnFocus="javascript:if(this.value=='请输入用户名') {this.value='';this.style.color='blue'}"
            OnBlur="javascript:if(this.value==''){this.value='请输入用户名';this.style.color='red'}" 
            ForeColor="Gray" ></asp:TextBox>
    </div>
    <div class="box-input">
        <asp:TextBox 
            ID="userPassword" 
            runat="server"
            Rows="1" 
            Wrap="False" 
            CssClass="i-input" 
            BackColor="White" 
            Font-Names="微软雅黑" 
            Font-Size="17px" 
            Text="请输入密码"
            OnFocus="javascript:if(this.value=='请输入密码' || this.value != '') {this.value='';this.style.color='blue'; this.type='password'}"
            OnBlur="javascript:if(this.value==''){this.value='请输入密码';this.style.color='red';this.type='text'}" 
            ForeColor="Gray" ></asp:TextBox>
    </div>
    <div class="box-input">
        <div class="box2">
            <asp:CheckBox ID="check" runat="server" Text="记住密码" CssClass="fleft" Checked="true" />
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="fright">忘记密码？</asp:HyperLink>
        </div>        
    </div>
    <div class="box-input">
        <div class="box2 box3">
            <asp:Button ID="butLogin" runat="server" Text="登录" CssClass="fleft" BackColor="#FF9900" BorderStyle="None" Font-Names="微软雅黑" Font-Size="17px" ForeColor="White" Height="40px" Width="115px" OnClick="butLogin_Click" />

            <asp:Button ID="butRegister" runat="server" Text="注册" CssClass="fright" 
                BackColor="#00CC00" BorderStyle="None" Font-Names="微软雅黑" Font-Size="17px" 
                ForeColor="White" Height="40px" Width="115px" onclick="butRegister_Click" />
        </div>
    </div>  
    
    <div class="box-input box3">
        <asp:Label ID="LoginMsg" runat="server" ForeColor="Red" Width="300px" CssClass="box3"></asp:Label>
    </div>
</div>
