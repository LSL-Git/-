using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyMessage : System.Web.UI.Page
{
    string userName = "";
    /// <summary>
    /// 获取正在登录用户信息
    /// </summary>
    /// <returns></returns>
    private User GetUser()
    {
        User user = null;
        if (Request.Cookies["USERINFO"] != null)
        {
            user = UserHelper.GetUserInfoByUserName(
                HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先登录！')", true);
        }
        return user;
    }

    /// <summary>
    /// 加载消息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="state"></param>
    private void LoadMsg(int userId, string state)
    {
        int startIndex = AspNetPager.StartRecordIndex; // 表的起始位置
        int endIndex = AspNetPager.EndRecordIndex; // 表的结束位置

        DBHelper mdb = new DBHelper();
        mdb.Connect();
        // 加载用户消息并绑定到Repeater
        Repeater_MyMsg.DataSource = UserMessageData.GetMyMsgByUserID(userId, endIndex - startIndex + 1, endIndex, state, mdb.GetConn);
        Repeater_MyMsg.DataBind();
        mdb.Disconnect();
    }

    /// <summary>
    /// 加载消息条数
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="state"></param>
    private void LoadTotalOrders(int userId, string state)
    {
        DBHelper mdb = new DBHelper();
        mdb.Connect();
        int msgCount = UserMessageData.GetMsgNum(userId, state, mdb.GetConn);
        AspNetPager.RecordCount = msgCount;
        mdb.Disconnect();

        LoadMsg(userId, state); // 加载用户消息

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string state = MsgStateList.SelectedValue;
        User user = GetUser();
        if (user != null)
        {
            LoadTotalOrders(user.userID, state);
        }
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        User user = GetUser();
        if (user != null)
        {
            LoadTotalOrders(user.userID, MsgStateList.SelectedValue);
        }
    }
}