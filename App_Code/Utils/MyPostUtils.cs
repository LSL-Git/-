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
    private const string GET_POST_INFO_BY_ORDERS = "SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM [MyPostInfo] " +
        " WHERE [UserID] = {2} {3} ORDER BY [ArticleID] DESC) {4} ORDER BY [ArticleID] ASC) ORDER BY [ArticleID] DESC ";

    // 根据用户ID获取用户的所有文章数量
    private const string GET_USER_ARTICLE_COUNT_BY_USERID = " SELECT COUNT(*) AS N FROM [Article] WHERE [UserID] = {0} ";

    // 获取用户已有文章的所有标签
    private const string GET_USER_ARTICLE_TAG_BY_USERID = " SELECT DISTINCT [Tag] FROM [Article] WHERE [UserID] = {0} ";

    private const string ADD_TYPE = " AND [Type] = '{0}' ";
    private const string ADD_TAG = " WHERE [Tag] = '{0}' ";

    private static string TOTAL = "全部";

    /// <summary>
    /// 根据用户id和制定文章类型
    /// 获取用户已有文章的所有标签
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static OleDbDataAdapter GetArticleTagByUserId(int userID, string type, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_USER_ARTICLE_TAG_BY_USERID, userID);
            if (type != TOTAL) // 如果不是原创则添加过滤条件
            {
                sql += String.Format(ADD_TYPE, type);
            }
            OleDbDataAdapter tagData = new OleDbDataAdapter(sql, conn);
            return tagData;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 根据用户ID和指定类型[Type]获取用户的所有文章数量
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static int GetUserArticleCountByUserId(int userId, string type, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_USER_ARTICLE_COUNT_BY_USERID, userId);

            if (type != TOTAL) // 如果不是原创则添加过滤条件
            {
                sql += String.Format(ADD_TYPE, type);
            }
            
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
    public static OleDbDataReader GetMyPostByOders(int startIndex, int endIndex, int userId, 
        string type, string tag, OleDbConnection conn)
    {
        try
        {
            string typeStr = "";
            string tagStr = "";
            // 添加过滤条件
            if (type != TOTAL) typeStr = String.Format(ADD_TYPE, type);
            if (tag != TOTAL && tag != "") tagStr = String.Format(ADD_TAG, tag);

            string sql = String.Format(GET_POST_INFO_BY_ORDERS, startIndex, endIndex, userId , typeStr, tagStr);
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