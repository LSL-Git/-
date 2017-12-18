using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///UserArticleInfoHelper 的摘要说明
/// </summary>
public class UserArticleInfoHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 设置制定字段值
    /// </summary>
    /// <param name="type"></param>
    /// <param name="articleInfo"></param>
    /// <returns></returns>
    private static UserArticleInfo SetNum(int type, UserArticleInfo articleInfo)
    {
        switch (type)
        {
            case 1:
                articleInfo.Article_num = articleInfo.Article_num + 1;
                break;
            case 2:
                articleInfo.Del_Article_num = articleInfo.Del_Article_num + 1;
                break;
            case 3:
                articleInfo.Comment_num = articleInfo.Comment_num + 1;
                break;
            case 4:
                articleInfo.MComment_num = articleInfo.MComment_num + 1;
                break;
            case 5:
                articleInfo.Favour_num = articleInfo.Favour_num + 1;
                break;
            case 6:
                articleInfo.Browse_num = articleInfo.Browse_num + 1;
                break;
            case 7:
                articleInfo.Favour_num = articleInfo.Favour_num - 1;
                break;
        }

        return articleInfo;
    }

    /// <summary>
    /// 根据用户ID更新用户概况表的各个值
    /// type = 1 => 总文章数 + 1 
    /// type = 2 => 删除文章总数 + 1 
    /// type = 3 => 评论数 + 1 
    /// type = 4 => 被评论数 + 1 
    /// type = 5 => 点赞数 + 1 
    /// type = 6 => 总浏览数 + 1 
    /// type = 7 => 点赞数 - 1
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="type"></param>
    public static void SetNumByUserId(int userId, int type)
    {
        if (GetArticleInfoByUserId(userId) == null) // 是看是否存在记录,不存在则新建
        {
            UserArticleInfo articleInfo = new UserArticleInfo();
            if (InsertNewArticleInfo(userId, articleInfo)) // 新建用户发文概况信息
            {
                UserArticleInfo userAInfo = GetArticleInfoByUserId(userId);
                UpdateArticleInfoByUserId(SetNum(type, userAInfo), userId);
            }
        }
        else
        {
            UserArticleInfo userAInfo = GetArticleInfoByUserId(userId);
            UpdateArticleInfoByUserId(SetNum(type, userAInfo), userId); // 更新信息
        }  
    }

    /// <summary>
    /// 根据用户ID获取用户发文信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static UserArticleInfo GetArticleInfoByUserId(int userId)
    {
        UserArticleInfo articleInfo = null;
        lock (mLockObj)
        {
            mdb.Connect();
            articleInfo = UserArticleInfoData.GetArticleInfoByUserId(userId, mdb.GetConn);
            mdb.Disconnect();
        }
        return articleInfo;
    }

    /// <summary>
    /// 插入用户发文概况信息
    /// </summary>
    /// <param name="articleInfo"></param>
    /// <returns></returns>
    public static bool InsertNewArticleInfo(int userId, UserArticleInfo articleInfo)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = UserArticleInfoData.InsertUserArticleInfo(userId, articleInfo, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    /// 根据用户ID更新用户发文概况表信息
    /// </summary>
    /// <param name="articleInfo"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool UpdateArticleInfoByUserId(UserArticleInfo articleInfo, int userId)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = UserArticleInfoData.UpdateInfoByUserId(userId, articleInfo, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
}