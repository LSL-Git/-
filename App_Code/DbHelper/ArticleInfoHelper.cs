using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ArticleInfoHelper 的摘要说明
/// </summary>
public class ArticleInfoHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 根据文章ID获取文章信息表信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <returns></returns>
    public static ArticleInfo GetArticleInfoById(int articleId)
    {
        ArticleInfo article = null;
        lock (mLockObj)
        {
            mdb.Connect();
            article = ArticleInfoData.GetArticleInfoByArticleId(articleId, mdb.GetConn);
            mdb.Disconnect();
        }
        return article;
    }

    /// <summary>
    /// 根据文章ID新建文章其他信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="articleInfo"></param>
    /// <returns></returns>
    public static bool InsertArticleInfoByarticleId(int articleId, ArticleInfo articleInfo)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = ArticleInfoData.InsertArticleInfo(articleId, articleInfo, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    /// 根据用户ID更新文章信息表信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="articleInfo"></param>
    /// <returns></returns>
    public static bool UpdateArticleInfoById(int articleId, ArticleInfo articleInfo)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = ArticleInfoData.UpdateArticleInfoById(articleId, articleInfo, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
}