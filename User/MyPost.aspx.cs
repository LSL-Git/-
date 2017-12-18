using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class User_MyPost : System.Web.UI.Page
{
    DBHelper mdb = new DBHelper();
    
    
    /// <summary>
    /// 根据当前登录用户Id获取用户草稿信息
    /// 并将数据绑定到 Repeater_Draft控件上
    /// </summary>
    private void DataBindToPostRepeater()
    {
        User user = GetUserInfo();
        if (user != null)
        {
            int startI = AspNetPager.StartRecordIndex; // 表的起始位置
            int endI = AspNetPager.EndRecordIndex; // 表的结束位置

            if (endI <= 0) endI++;

            int startIndex = (endI - startI + 1);
            int endIndex = endI;

            mdb.Connect();
            Repeater_Post.DataSource = MyPostUtils.GetMyPostByOders(startIndex, endIndex, user.userID, mdb.GetConn);
            Repeater_Post.DataBind();
            mdb.Disconnect();
        }
    }
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    private User GetUserInfo()
    {
        User user = null;
        if (Request.Cookies["USERINFO"] != null)
        {
            user = UserHelper.GetUserInfoByUserName(
                HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]));
        }
        return user;
    }

    /// <summary>
    /// 加载页面数据
    /// </summary>
    private void LoadTotalOrders()
    {
        // 加载文章数量
        mdb.Connect();
        int ArticleCount = MyPostUtils.GetUserArticleCountByUserId(GetUserInfo().userID, mdb.GetConn);
        AspNetPager.RecordCount = ArticleCount;
        mdb.Disconnect();
         
        Total.Text = "( 总：" + ArticleCount + " 贴 )";

        // 加载标签
        mdb.Connect();
        DataTable tagTable = MyPostUtils.GetArticleTagByUserId(GetUserInfo().userID, mdb.GetConn);
        if (tagTable != null)
        {
            TagDDList.DataSource = tagTable.DefaultView;
            TagDDList.DataTextField = tagTable.Columns[0].ColumnName;
            TagDDList.DataValueField = tagTable.Columns[0].ColumnName; ;
            TagDDList.DataBind();
            TagDDList.Items.Insert(0, new ListItem("全部", "全部"));
            tagTable.Clear();
        }
        mdb.Disconnect();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            LoadTotalOrders();
        }

        string type = TypeDDList.SelectedValue;
        string tag = TagDDList.SelectedValue;
    }


    protected void Repeater_Post_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "Edit")
        //{
        //    Response.Redirect("MyEditor.aspx?draftId=" + e.CommandArgument);
        //}
        //else if (e.CommandName == "Delete")
        //{
        //    if (DraftHelper.DeleteDraftById(int.Parse(e.CommandArgument.ToString())))
        //    {
        //        this.DataBindToPostRepeater();
        //    }
        //}
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        this.DataBindToPostRepeater();
    }
}