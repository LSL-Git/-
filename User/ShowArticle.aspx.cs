using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ShowArticle : System.Web.UI.Page
{
    string articleId = "";
    private string userID = "";
    string Article_Title = "";

    /// <summary>
    /// 控制显示和隐藏登陆控件
    /// </summary>
    /// <param name="f"></param>
    private void UserLoginClt(bool f)
    {
        LUserName.Visible = f;
        LPassword.Visible = f;
        txtUserName.Visible = f;
        txtPassword.Visible = f;
        Bnt_Login.Visible = f;
    }

    /// <summary>
    ///  检测用户是否登录，并获取登录用户信息
    /// </summary>
    /// <returns></returns>
    private User IsLogin()
    {
        User user = null;
        if (Request.Cookies["USERINFO"] != null)
        {
            LMsg.Text = "";
            UserLoginClt(false); // 隐藏登录控件

            string userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            user = UserHelper.GetUserInfoByUserName(userName);
        }
        else
        {
            LMsg.Text = "你尚未登录！";
            UserLoginClt(true); // 显示登录控件
        }
        return user;
    }

    /// <summary>
    /// 根据用户id加载作者信息
    /// </summary>
    /// <param name="userID"></param>
    private void LoadUserInfo(int userID)
    {
        User userInfo = UserHelper.GetUserInfoByUserID(userID);

        if (userInfo != null)
        {
            ib_userIcon.ImageUrl = userInfo.Img;
            string name = userInfo.userName;
            lbt_userName.ToolTip = name;
            if (name.Length > 6)
            {
                name = name.Substring(0, 6) + "...";
            }
            lbt_userName.Text = name;
        }

        if (Request.Cookies["USERINFO"] != null)
        {
            LMsg.Text = "";
            UserLoginClt(false); // 隐藏登录控件

            string userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            if (userName != userInfo.userName)
            {
                bnt_Concern.Visible = true;
            }
            else
            {
                bnt_Concern.Visible = false;
            }
        }
        else
        {
            bnt_Concern.Visible = true;
            LMsg.Text = "你尚未登录！";
            UserLoginClt(true); // 显示登录控件
        }
    }

    /// <summary>
    /// 判断该帖是否可以评论
    /// </summary>
    /// <param name="state"></param>
    private void IsComment(string state)
    {
        switch (state)
        {
            case "可评论":
                FloorList.Enabled = true;
                Bnt_Comm.Enabled = true;
                content.Enabled = true;
                LMsg2.Visible = false;
                break;

            case "禁评论":
                FloorList.Enabled = false;
                Bnt_Comm.Enabled = false;
                content.Enabled = false;
                LMsg2.Text = "该帖禁止评论！";
                LMsg2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8b900");
                LMsg2.Visible = true;
                break;
        }
    }

    /// <summary>
    /// 加载文章信息
    /// </summary>
    /// <param name="articleID"></param>
    private void LoadArticle(int articleID)
    {      
        DBHelper mdb = new DBHelper();
        mdb.Connect();
        DataSet articleInfo = ArticleData.GetArticleInfoByArticleID(articleID, mdb.GetConn); // 读取数据库，获取文章信息
        mdb.Disconnect();
        
        foreach (DataRow row in articleInfo.Tables["ArticleTable"].Rows)
        {
            Article_Title = row["Title"].ToString();
            ArticleTitle.Text = Article_Title;
            ArticleType.Text = row["Type"].ToString();
            ArticleTag.Text = row["Tag"].ToString();
            Browse_Num.Text = row["Browse_Num"].ToString();
            Comment_Num.Text = row["Comment_Num"].ToString();
            ArticleContent.Text = row["Content"].ToString();
            Pub_Time.Text = row["Pub_Time"].ToString();
            userID = row["UserID"].ToString();
            // 判断该帖是否可以评论
            IsComment(row["State"].ToString());
        }

        if (userID != null && userID != "")
        {
            // 加载作者信息
            LoadUserInfo(int.Parse(userID));
        }
    }

    /// <summary>
    /// 加载可回复的楼层
    /// </summary>
    /// <param name="floor"></param>
    private void LoadFloorList(int floor)
    {
        for (int i = 1; i <= floor; i++)
        {   ListItem floorItemt = new ListItem();
            floorItemt.Text = i + "楼";
            floorItemt.Value = i + "";
            FloorList.Items.Add(floorItemt);
        }        
    }

    /// <summary>
    /// 加载文章 的所有评论，并绑定到Repeater_Comment控件上
    /// </summary>
    /// <param name="articleID"></param>
    private void LoadComment(int articleID)
    {
        DBHelper mdb = new DBHelper();
        mdb.Connect();
        Repeater_Comment.DataSource = CommentData.GetAllCommentByArticleID(articleID, mdb.GetConn);
        Repeater_Comment.DataBind();
        int Floor = CommentData.GetFloorByArticleId(articleID, mdb.GetConn);
        if (Floor > 0 && !IsPostBack)
        {
            LoadFloorList(Floor); // 加载可回复的楼层
            LMsg2.Visible = false;
        }
        else
        {
            LMsg2.Visible = true;
        }
        mdb.Disconnect();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        articleId = Request["ArticleId"]; // 接收文章id

        // 判断文章id是否有效
        if (articleId != null && articleId != "" && Regex.IsMatch(articleId, @"^\d+$"))
        {
            int ArticleID = int.Parse(articleId);
            // 加载文章信息
            LoadArticle(ArticleID);
            LoadComment(ArticleID);
        }


    }

    protected void Bnt_Comm_Click(object sender, EventArgs e)
    {
        string floor = FloorList.SelectedValue; // 被评论楼层        
        string Comm_Content = content.Text.ToString().Replace("'", "‘"); // 评论内容
        int ArticleID = int.Parse(articleId); // 文章id
        string Comm_time = DateUtils.GetNowTime(); // 系统时间

        int BUserId = int.Parse(userID); // 被评论者id

        if (Comm_Content.Length < 15)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('评论内容长度至少15字！')", true);
        }
        else
        {
            User user = IsLogin();
            if (user != null)
            {
                int UserId = user.userID; // 评论者id

                Comment comment = new Comment();
                comment.ArticleID = ArticleID;
                comment.Comm_Content = Comm_Content;
                comment.Comm_Time = Comm_time;
                comment.Comm_userID = UserId;

                UserMessage msg = new UserMessage();
                msg.ArticleID = ArticleID;
                msg.Comm_Content = Comm_Content;
                msg.Comm_Time = Comm_time;
                msg.Comm_UserID = UserId;
                msg.UserID = BUserId;
                msg.State = "未读";
                msg.bComm_Content = Article_Title;

                if (MsgAndCommHelper.CommitComment(comment, msg)) // 将评论信息保存数据库
                {
                    UserArticleInfoHelper.SetNumByUserId(BUserId, 4); // 被评论用户被评论数 +1
                    UserArticleInfoHelper.SetNumByUserId(UserId, 3); // 评论用户的评论数 +1
                    Response.Redirect("ShowArticle.aspx?ArticleId=" + ArticleID);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发表成功！')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发表失败！')", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先登录！')", true);
            }
        }
    }
}