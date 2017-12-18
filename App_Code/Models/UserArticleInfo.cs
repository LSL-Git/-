using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///UserArticleInfo 用户发贴总概信息model
/// </summary>
public class UserArticleInfo
{
    public int ID;
    public int User_id;
    public int Article_num; // 文章数
    public int Del_Article_num; // 删除文章数
    public int MComment_num; // 被评论数
    public int Comment_num; // 我的评论数
    public int Favour_num; // 获得点赞数
    public int Browse_num; // 个人总浏览数
}