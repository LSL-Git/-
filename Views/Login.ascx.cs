using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["USERINFO"] != null)
            {   
                userName.Text = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
                userPassword.Attributes.Add("value", Request.Cookies["USERINFO"]["PSW"]);
                userPassword.TextMode = TextBoxMode.Password;
            }
            else
            {
                userName.Focus();
                userName.Attributes.Add("value", "请输入用户名");
                userPassword.Attributes.Add("value", "请输入密码");
            }
        }
    }

    /// <summary>
    /// cookie存储用户信息
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPsw"></param>
    private void SetCookie(string userName, string userPsw)
    {
        
        Response.Cookies["USERINFO"]["NAME"] = HttpUtility.UrlEncode(userName);
        Response.Cookies["USERINFO"]["PSW"] = userPsw;
        Response.Cookies["USERINFO"].Expires = DateTime.Now.AddDays(1);
    }

    protected void butLogin_Click(object sender, EventArgs e)
    {
        string username = userName.Text.Trim();
        string userpsw = userPassword.Text.Trim();
        userName.Text = "";
        userPassword.Text = "";
        userName.Attributes.Clear();
        userPassword.Attributes.Clear();
        // 执行登录业务
        User user = UserHelper.Login(username, userpsw); // 先取原值比较，如果登录失败再取加密指登录
        if (user == null)
        {
            user = UserHelper.Login(username, MD5Encryption.EnCondingMD5(userpsw)); // 加密值登陆
        }
        

        if (user != null) // 登录成功
        {
            if (check.Checked)
            {
                // 保存cookie
                SetCookie(user.userName, user.userPsw);
            }
            Response.Redirect("MainPage.aspx");
        }
        else
        {
            LoginMsg.Text = "用户名或密码错误！";
        }
    }

    protected void butRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}