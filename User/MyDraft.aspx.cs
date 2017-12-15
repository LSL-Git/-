using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyDraft : System.Web.UI.Page
{
    /// <summary>
    /// 根据当前登录用户Id获取用户草稿信息
    /// 并将数据绑定到 Repeater_Draft控件上
    /// </summary>
    private void DataBindToDraftRepeater()
    {
        User user = null;
        DataTable draftTable = null;

        if (Request.Cookies["USERINFO"] != null)
        {
            user = UserHelper.GetUserInfoByUserName(
                HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]));
        }
        if (user != null)
        {
            draftTable = DraftHelper.GetAllDraftByUserId(user.userID);
        }
        
        if (draftTable != null)
        {
            Repeater_Draft.DataSource = draftTable;
            Repeater_Draft.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBindToDraftRepeater();
        }
    }
        
    protected void Repeater_Draft_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("MyEditor.aspx?draftId=" + e.CommandArgument);
        }
        else if (e.CommandName == "Delete")
        {
            if (DraftHelper.DeleteDraftById(int.Parse(e.CommandArgument.ToString())))
            {
                this.DataBindToDraftRepeater();
            }
        }
    }

    protected void Repeater_Draft_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}