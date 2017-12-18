using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
///MyPostInfo 
/// </summary>
public class MyPostUtils
{
    // 连接文章表和文章信息表获取‘我的帖子’所需信息
    private const string GET_POST_INFO_BY_USERID = "SELECT [ArticleID], [Title], [Type], [Tag], [Jurisdiction], [State], [Browse_Num], " +
      "[Comment_Num], [Pub_Time] FROM Article LEFT JOIN ArticleInfo ON ArticleInfo.ArticleID=Article.ID WHERE UserID = {0} ";

    // 获取MyPostInfo表内指定连续范围的列
    private const string GET_POST_INFO_BY_ORDERS = "SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM [MyPostInfo] ORDER BY " +
        " [ArticleID] ASC) ORDER BY [ArticleID] DESC) WHERE [UserID] = {2} ORDER BY [ArticleID] ASC ";

    // 根据用户ID获取用户的所有文章数量
    private const string GET_USER_ARTICLE_COUNT_BY_USERID = " SELECT COUNT(*) AS N FROM [Article] WHERE [UserID] = {0} ";

    // 获取用户已有文章的所有标签
    private const string GET_USER_ARTICLE_TAG_BY_USERID = "SELECT DISTINCT [Tag] FROM [Article] WHERE [UserID] = {0} ";

    /// <summary>
    /// 获取用户已有文章的所有标签
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DataTable GetArticleTagByUserId(int userID, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_USER_ARTICLE_TAG_BY_USERID, userID);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            DataTable TagTable = null;
            if (reader.Read())
            {
                TagTable = new DataTable();
                TagTable.Load(reader);
            }
            return TagTable;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 根据用户ID获取用户的所有文章数量
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static int GetUserArticleCountByUserId(int userId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_USER_ARTICLE_COUNT_BY_USERID, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int count = 0;
            if (reader.Read())
            {
                count = (int)reader["N"];
            }
            return count;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// 获取MyPostInfo表内指定连续范围的列
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static OleDbDataReader GetMyPostByOders(int startIndex, int endIndex, int userId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_POST_INFO_BY_ORDERS, startIndex, endIndex, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteReader();
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 连接文章表和文章信息表获取‘我的帖子’所需信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DataTable GetMyPostInfoByUserID(int userId, OleDbConnection conn)
    {
        try
        {
            DataTable MyPostTable = new DataTable();
            string sql = String.Format(GET_POST_INFO_BY_USERID, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            MyPostTable.Load(reader);
            reader.Close();
            return MyPostTable;
        }
        catch (Exception)
        {
            return null;
        }
    }
}