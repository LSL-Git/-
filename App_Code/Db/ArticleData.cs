using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

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

    // 根据文章id获取文章的内容
    private const string GET_ARTICLEINFO_BY_ARTICLEID = " SELECT * FROM [MyPostInfo] WHERE [ArticleID] = {0} ";

    // 根据文章id和用户id更新文章信息
    private const string UPDATE_ARTICLEINFO_BY_ARTICLEID = " UPDATE [Article] SET [Title] = '{0}', [Content] = '{1}', [Type] = '{2}'," +
        " [Tag] = '{3}', [Pub_Time] = '{4}', [Jurisdiction] = '{5}', [State] = '{6}' WHERE [ID] = {7} AND [UserID] = {8} ";
    
    // 根据文章id更新文章state
    private const string UPDATE_STATTE_BY_ARTICLEID = " UPDATE [Article] SET [State] = '{0}' WHERE [ID] = {1} ";

    // 根据文章id删除文章信息
    private const string DELETE_ARTICLE_BY_ARTICLEID = " DELETE * FROM [Article] WHERE [ID] = {0} ";

    /// <summary>
    /// 根据文章id删除文章信息
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool DeleteArticleByArticleId(int articleId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(DELETE_ARTICLE_BY_ARTICLEID, articleId);
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
    /// 根据文章id更新文章state
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="state"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateArticleStateByArticleId(int articleId, OleDbConnection conn)
    {
        string state = "禁评论";
        try
        {
            string sql1 = String.Format(GET_ARTICLEINFO_BY_ARTICLEID, articleId);
            OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                state = reader["State"] + "";
            }

            switch (state)
            {
                case "禁评论":
                    state = "可评论";
                    break;

                case "可评论":
                    state = "禁评论";
                    break;
            }

            string sql = String.Format(UPDATE_STATTE_BY_ARTICLEID, state, articleId);
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
    /// 根据文章id和用户id更新文章信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="articleId"></param>
    /// <param name="article"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateArticleByUserIDArticleID(int userId, int articleId, Article article, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(UPDATE_ARTICLEINFO_BY_ARTICLEID, article.Title, article.Content.Replace("'","‘"),
                article.Type, article.Tag, article.Pub_time, article.Juri, article.State, articleId, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            return row > 0;
        }
        catch (Exception)
        {
            //string s = ex.Message;
            return false;
        }
    }

    /// <summary>
    /// 根据文章id获取文章的内容
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DataSet GetArticleInfoByArticleID(int articleId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_ARTICLEINFO_BY_ARTICLEID, articleId);
            OleDbDataAdapter ole = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ole.Fill(ds, "ArticleTable");

            return ds;
        }
        catch (Exception)
        {
            return null;
        }
    }

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