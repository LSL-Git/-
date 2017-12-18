using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
///ArticleData 的摘要说明
/// </summary>
public class ArticleData
{
	// 插入文章信息
    private const string INSERT_NEW_ARTICLE = " INSERT INTO [Article] ([UserID], [Title], [Content], [Type], " + 
        "[Tag], [Pub_Time], [Jurisdiction], [State]) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";

    // 根据用户ID，查询最新提条文章信息
    private const string GET_THE_NEW_ARTICLE = " SELECT TOP 1 * FROM [Article] WHERE [UserID] = {0} ORDER BY [Pub_Time] DESC ";

    /// <summary>
    /// 根据用户ID，查询最新提条文章信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static Article GetTheNewArticleByUserId(int userId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_THE_NEW_ARTICLE, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Article article = null;
            if (reader.Read())
            {
                article = new Article();
                article.ID = (int)reader["ID"];
                article.User_id = (int)reader["UserID"];
                article.Title = reader["Title"] + "";
                article.Content = reader["Content"] + "";
                article.Type = reader["Type"] + "";
                article.Tag = reader["Tag"] + "";
                article.Pub_time = reader["Pub_Time"] + "";
                article.Juri = reader["Jurisdiction"] + "";
                article.State = reader["State"] + "";
            }
            reader.Close();
            return article;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 插入文章信息
    /// </summary>
    /// <param name="article"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool InsertArticle(Article article, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(INSERT_NEW_ARTICLE, article.User_id, article.Title,
                article.Content.Replace("'", "‘"), article.Type, article.Tag, article.Pub_time, article.Juri, article.State);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            return row > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

}