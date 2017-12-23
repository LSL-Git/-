using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = "";

        if (Request.Cookies["USERINFO"] != null)
        {
            userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            User user = UserHelper.GetUserInfoByUserName(userName); // 获取用户信息

            UserIcon.ImageUrl = user.Img; // 获取用户头像
            UserIcon.Visible = true; // 显示用户头像

            if (userName.Length > 6)
            {
                userName = userName.Substring(0, 6) + "...";
            }
            link_login.Text = userName;
            link_login.NavigateUrl = "~/User/UserInfo.aspx";
            link_register.Text = "注销";
        }
    }

    protected void link_register_Click(object sender, EventArgs e)
    {
        link_login.Text = "登录";
        link_login.NavigateUrl = "~/User/Login.aspx";
        UserIcon.Visible = false;
        if (link_register.Text.Equals("注销"))
        {
            Response.Cookies["USERINFO"].Expires = DateTime.Now.AddDays(-1);
        }
        link_register.PostBackUrl = "~/User/Register.aspx";
        link_register.Text = "注册";
    }
}
