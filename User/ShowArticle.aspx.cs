using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ShowArticle : System.Web.UI.Page
{
    string articleId = "";

    /// <summary>
    /// 根据用户id加载用户信息
    /// </summary>
    /// <param name="userID"></param>
    private void LoadUserInfo(int userID)
    {
        User userInfo = UserHelper.GetUserInfoByUserID(userID);
        if (userInfo != null)
        {
            ib_userIcon.ImageUrl = userInfo.Img;
            string name = userInfo.userName;
            if (name.Length > 6)
            {
                name = name.Substring(0, 6) + "...";
            }
            lbt_userName.Text = name;
        }

        if (Request.Cookies["USERINFO"] != null)
        {
            string userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            if (userName == userInfo.userName)
            {
                bnt_Concern.Visible = false;
            }
            else
            {
                bnt_Concern.Visible = true;
            }
        }
    }

    /// <summary>
    /// 加载文章信息
    /// </summary>
    /// <param name="articleID"></param>
    private void LoadArticle(int articleID)
    {
        string userID = "";

        DBHelper mdb = new DBHelper();
        mdb.Connect();
        DataSet articleInfo = ArticleData.GetArticleInfoByArticleID(articleID, mdb.GetConn); // 读取数据库，获取文章信息
        mdb.Disconnect();
        
        foreach (DataRow row in articleInfo.Tables["ArticleTable"].Rows)
        {
            ArticleTitle.Text = row["Title"].ToString();
            ArticleType.Text = row["Type"].ToString();
            ArticleTag.Text = row["Tag"].ToString();
            Browse_Num.Text = row["Browse_Num"].ToString();
            Comment_Num.Text = row["Comment_Num"].ToString();
            ArticleContent.Text = row["Content"].ToString();
            Pub_Time.Text = row["Pub_Time"].ToString();
            userID = row["UserID"].ToString();
        }

        if (userID != null && userID != "")
        {
            // 加载作者信息
            LoadUserInfo(int.Parse(userID));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        articleId = Request["ArticleId"]; // 接收文章id
        // 判断文章id是否有效
        if (articleId != null && articleId != "" && Regex.IsMatch(articleId, @"^\d+$"))
        {
            // 加载文章信息
            LoadArticle(int.Parse(articleId));
        }

    }

    protected void Bnt_Comm_Click(object sender, EventArgs e)
    {
        string Comm_Content = content.Text.ToString().Replace("'","‘");
    }
}