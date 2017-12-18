using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyEditor : System.Web.UI.Page
{
    string article_title = "";
    string article_content = "";
    string article_type = "";
    string article_tag = "";
    string userName = "";
    string draftId = "";

    /// <summary>
    /// 获取页面写入信息
    /// </summary>
    private void GetArticleInfo()
    {
        article_title = txtTitle.Text.Trim();
        article_content = content.Text.ToString();
        article_type = ArticleTypeList.SelectedValue;
        article_tag = ArticleTagList.SelectedValue;
    }

    /// <summary>
    /// 填充分类下拉列表的值
    /// </summary>
    private void FillAritcleTypeList()
    {
        // 获取数据库连接对象
        DBHelper mdb = new DBHelper();
        mdb.Connect();//链接数据库
        DataSet data = new DataSet();
        // 从数据库读取文章的所有类型
        OleDbDataAdapter article_type = ArticleTagDate.GetAllArticleTag(mdb.GetConn);
        article_type.Fill(data, "TagTable");
        mdb.Disconnect();// 断开数据库连接

        // 将数据绑定到控件上
        ArticleTagList.DataSource = data.Tables["TagTable"].DefaultView;
        ArticleTagList.DataTextField = "tag";
        ArticleTagList.DataValueField = "tag";
        ArticleTagList.DataBind();
        // 设置第一项为空项
        //ArticleTagList.Items.Insert(0, new ListItem("", ""));
        data.Dispose(); // 释放data中的资源
        article_type.Dispose(); // 释放article_type中的资源
    }

    /// <summary>
    /// 检测用户是否登录
    /// </summary>
    private bool UserInfo()
    {
        if (Request.Cookies["USERINFO"] != null)
        {
            userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
        }

        if (userName == "")
        {
            Err_Msg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
            Err_Msg.Text = "检测到你尚未登录！建议您先登录~";
            link_login.Visible = true;
            return false;
        }
        else
        {
            link_login.Visible = false;
            Err_Msg.Text = "";
            return true;
        }
    }

    /// <summary>
    /// 从数据库加载草稿
    /// </summary>
    /// <param name="draftId"></param>
    private void LoadDraft(int draftId)
    {
        if (UserInfo())
        {
            User user = UserHelper.GetUserInfoByUserName(userName);

            Draft draft = DraftHelper.GetDraftById(draftId, user.userID);
            if (draft != null)
            {
                txtTitle.Text = draft.Title;
                content.Text = draft.Content;
                ArticleTypeList.Text = draft.Type;
                ArticleTagList.Text = draft.Tag;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo();
        // 获取草稿id
        draftId = Request["draftId"];        

        if (!IsPostBack)
        {
            FillAritcleTypeList();

            if (draftId != null && draftId != "" && Regex.IsMatch(draftId, @"^\d+$"))
            {
                // 加载草稿
                LoadDraft(int.Parse(draftId));
            }
        }

        
    }
    
    protected void butPublish_Click(object sender, EventArgs e)
    {
        if (UserInfo())
        {
            GetArticleInfo(); // 获取输入信息

            userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
            User user = UserHelper.GetUserInfoByUserName(userName); // 获取用户信息

            Article articleInfo = new Article();
            articleInfo.User_id = user.userID;
            articleInfo.Title = article_title;
            articleInfo.Content = article_content;
            articleInfo.Type = article_type;
            articleInfo.Tag = article_tag;
            articleInfo.Pub_time = DateUtils.GetNowTime();
            articleInfo.Juri = "待审核"; // 默认'待审核'->'已审核'
            articleInfo.State = "正常";

            if (ArticleHelper.InsertNewArticle(articleInfo)) // 判断发表结果
            {
                // 获取刚保存的文章的相关信息
                Article article = ArticleHelper.GetTheNewArticleByUserId(articleInfo.User_id);
                if (article != null)
                {
                    // 创建新的文章其他信息表，并保存
                    ArticleInfo articleIn = new ArticleInfo();
                    articleIn.Comment_time = DateUtils.GetNowTime();
                    ArticleInfoHelper.InsertArticleInfoByarticleId(article.ID, articleIn);
                }

                //if (UserArticleInfoHelper.GetArticleInfoByUserId(articleInfo.User_id) == null)
                //{}
                
                UserArticleInfoHelper.SetNumByUserId(articleInfo.User_id, 1);                

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发表成功！')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发表失败！')", true);
            }
        }
    }

    protected void butSaveDraft_Click(object sender, EventArgs e)
    {
        GetArticleInfo();
        Draft draft = new Draft();
        if (article_title.Equals("") || article_content.Equals(""))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('标题跟内容不能为空！')", true);
        }
        else
        {
            if (article_title.Length > 30)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('标题长度已超过30！')", true);
            }
            else
            {
                if (UserInfo())
                {
                    userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
                    User user = UserHelper.GetUserInfoByUserName(userName); // 获取用户信息

                    draft.userId = user.userID;
                    draft.Title = article_title;
                    draft.Content = article_content;
                    draft.Type = article_type;
                    draft.Tag = article_tag;
                    draft.create_time = DateUtils.GetNowTime();

                    if (draftId != null && draftId != "" && Regex.IsMatch(draftId, @"^\d+$"))
                    {
                        // 更新草稿
                        if (DraftHelper.UpdateDraft(draft, user.userID, int.Parse(draftId)))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('草稿保存成功！')", true);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('草稿保存失败！')", true);
                        }
                    }
                    else if (DraftHelper.InsertNewDraft(draft))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('草稿保存成功！')", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('草稿保存失败！')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先登录！')", true);
                }              
            }
        }
    }
}