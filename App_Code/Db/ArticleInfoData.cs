using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// 对ArticleInfo表的操作
/// </summary>
public class ArticleInfoData
{
    // 新建文章信息
    private const string INSERT_NEW_ARTICLEINFO = " INSERT INTO [ArticleInfo] ([ArticleID], [Browse_Num], [Comment_Num]," + 
        " [Favour_Num], [Comment_Time]) VALUES ({0}, {1}, {2}, {3}, '{4}') ";
    
    // 根据文章ID获取文章相关信息
    private const string GET_ARTICLEINFO_BY_ARTICLEID = " SELECT * FROM [ArticleInfo] WHERE [ArtilceID] = {0} ";
   
    // 根据文章ID更新文章信息
    private const string UPDATE_ARTICLEINFO_BY_ARTICLEID = " UPDATE [ArticleInfo] SET [Browse_Num] = {0}, [Comment_Num] = {1}," +
            " [Favour_Num] = {3}, [Comment_Time] = '{4}' WHERE [ArtilceID] = {5} ";

    /// <summary>
    /// 更具文章ID更新文章相关信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="articleInfo"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateArticleInfoById(int articleId, ArticleInfo articleInfo, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(UPDATE_ARTICLEINFO_BY_ARTICLEID, articleInfo.Browse_num, articleInfo.Comment_num,
                articleInfo.Favour_num, articleInfo.Comment_time, articleId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            return row > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// 根据文章ID获取文章信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static ArticleInfo GetArticleInfoByArticleId(int articleId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_ARTICLEINFO_BY_ARTICLEID, articleId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            ArticleInfo articleInfo = null;
            if (reader.Read())
            {
                articleInfo = new ArticleInfo();
                articleInfo.ID = (int)reader["ID"];
                articleInfo.Article_id = (int)reader["ArtilceID"];
                articleInfo.Browse_num = (int)reader["Browse_Num"];
                articleInfo.Comment_num = (int)reader["Comment_Num"];
                articleInfo.Favour_num = (int)reader["Favour_Num"];
                articleInfo.Comment_time = reader["Comment_Time"] + "";
            }
            return articleInfo;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 根据文章ID新建文章相关信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="articleInfo"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool InsertArticleInfo(int articleId, ArticleInfo articleInfo, OleDbConnection conn)
    {
        try
        {
            int row = 0;
            if (GetArticleInfoByArticleId(articleId, conn) == null)
            {
                string sql = String.Format(INSERT_NEW_ARTICLEINFO, articleId, articleInfo.Browse_num, articleInfo.Comment_num,
                articleInfo.Favour_num, articleInfo.Comment_time);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                row = cmd.ExecuteNonQuery();
            }
            return row > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}