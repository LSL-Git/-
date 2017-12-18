using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ArticleHelper 的摘要说明
/// </summary>
public class ArticleHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 根据用户ID获取该用户的最新的文章信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static Article GetTheNewArticleByUserId(int userId)
    {
        Article article = null;
        lock (mLockObj)
        {
            mdb.Connect();
            article = ArticleData.GetTheNewArticleByUserId(userId, mdb.GetConn);
            mdb.Disconnect();
        }
        return article;
    }

    /// <summary>
    /// 新建文章
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    public static bool InsertNewArticle(Article article)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = ArticleData.InsertArticle(article, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
}