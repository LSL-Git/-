using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ArticleInfo 文章概况信息
/// </summary>
public class ArticleInfo
{
    public int ID;
    public int Article_id; 
    public int Browse_num; // 文章浏览数
    public int Comment_num; // 文章评论数
    public int Favour_num; // 文章点赞数
    public string Comment_time; // 文章最新评论时间
}