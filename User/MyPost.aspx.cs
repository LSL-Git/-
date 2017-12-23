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
    private const string TOTAL = "全部";
    int ArticleCount = 0;

    /// <summary>
    /// 根据当前登录用户Id获取用户草稿信息
    /// 并将数据绑定到 Repeater_Draft控件上
    /// </summary>
    private void DataBindToPostRepeater(string type, string tag)
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
            // 根据用户id获取用户文章指定范围的文章信息
            Repeater_Post.DataSource = MyPostUtils.GetMyPostByOders(startIndex, endIndex, user.userID, type, tag, mdb.GetConn);
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
    private void LoadTotalOrders(string type, string tag)
    {
        User user = GetUserInfo();
        if (user != null)
        {
             // 加载文章数量
            mdb.Connect();
            ArticleCount = MyPostUtils.GetUserArticleCountByUserId(user.userID, type, mdb.GetConn);
            AspNetPager.RecordCount = ArticleCount;
            mdb.Disconnect();
        }
        
         
        Total.Text = "( " + type + "：" + ArticleCount + " 贴 )";

        DataBindToPostRepeater(type, tag);
    }

    /// <summary>
    /// 加载标签
    /// </summary>
    /// <param name="tag"></param>
    private void LoadTag(string type, string tag)
    {
        // 加载标签
        mdb.Connect();
        DataSet data = new DataSet();
        OleDbDataAdapter tagTable = MyPostUtils.GetArticleTagByUserId(GetUserInfo().userID, type, mdb.GetConn);
        tagTable.Fill(data, "TagTable");
        mdb.Disconnect();

        if (data != null)
        {
            // 绑定数据到 TagDDList 控件上
            TagDDList.DataSource = data.Tables["TagTable"].DefaultView;
            TagDDList.DataTextField = "Tag";
            TagDDList.DataValueField = "Tag";
            TagDDList.DataBind();
            TagDDList.Items.Insert(0, new ListItem(tag, tag));
            // 释放资源
            data.Dispose();
            tagTable.Dispose();
        }

        LoadTotalOrders(type, tag);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTotalOrders(TypeDDList.SelectedValue, TagDDList.SelectedValue);
        //LoadTotalOrders(TypeDDList.SelectedValue, TagDDList.SelectedValue);
    }


    protected void Repeater_Post_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Look") // 查看
        {
            //int ArticleId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("ShowArticle.aspx?ArticleId=" + e.CommandArgument);
        }
        else if (e.CommandName == "Edit") // 编辑
        {
            Response.Redirect("MyEditor.aspx?ArticleId=" + e.CommandArgument);
        }
        else if (e.CommandName == "State") // 分类
        {
            string articleId = e.CommandArgument.ToString();

            DBHelper mdb = new DBHelper();
            mdb.Connect();
            // 更新评论权限
            bool result = ArticleData.UpdateArticleStateByArticleId(int.Parse(articleId), mdb.GetConn);
            mdb.Disconnect();
            if (result)
            {
                Response.Redirect("MyPost.aspx?type=3");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！')", true);
            }
        }
        else if (e.CommandName == "Delete") // 删除
        {
            string articleId = e.CommandArgument.ToString();

            DBHelper mdb = new DBHelper();
            mdb.Connect();
            // 更新评论权限
            bool result = ArticleData.DeleteArticleByArticleId(int.Parse(articleId), mdb.GetConn);
            mdb.Disconnect();
            if (result)
            {
                Response.Redirect("MyPost.aspx?type=3");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！')", true);
            }
        }
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        LoadTotalOrders(TypeDDList.SelectedValue, TagDDList.SelectedValue);
    }
}