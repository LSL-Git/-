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
        string type = Request["type"];
        SetTitle(type);
        string userName = "";

        if (Request.Cookies["USERINFO"] != null)
        {
            userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            if (userName != null && userName != "")
            {
                LAdmin.Text = "管理员：" + userName;
                User user = UserHelper.GetUserInfoByUserName(userName);
                if (user.Admin != "admin")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "", "alert('请先请登录管理员账号！');window.location.href='/User/MainPage.aspx'", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "", "alert('请先登录！');window.location.href='/User/MainPage.aspx'", true);
            }
        }


    }

    /// <summary>
    ///  设置标题
    /// </summary>
    /// <param name="type"></param>
    public void SetTitle(string type)
    {
        switch (type)
        {
            case "0":
                ltitle.Text = "文章审核";
                break;

            case "1":
                ltitle.Text = "修改密码";
                break;

            case "2":
                ltitle.Text = "我的草稿";
                break;

            case "3":
                ltitle.Text = "我的帖子";
                break;

            case "4":
                ltitle.Text = "我的回复";
                break;

            case "5":
                ltitle.Text = "我的消息";
                break;

            case "6":
                ltitle.Text = "我的收藏";
                break;

            default:
                break;
        }
    }
}
