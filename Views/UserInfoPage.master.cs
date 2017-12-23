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
                ltitle.Text = "基本信息";
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
