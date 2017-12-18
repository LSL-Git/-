using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
///UserArticleInfo 操作UserArticleInfo表
/// </summary>
public class UserArticleInfoData
{
    // 新建用户发文概括表
    private const string INSERT_USER_ARTICLE_INFO = " INSERT INTO [UserArticleInfo] ([UserID], [Article_Num], [Del_Article_Num]," +
        " [MComment_Num], [Comment_Num], [Favour_Num], [Browse_Num]) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})";

    // 根据用户ID更新信息
    private const string UPDATE_ARTICLE_INFO_BY_USERID = " UPDATE [UserArticleInfo] SET [Article_Num] = {0}, [Del_Article_Num] = {1}," +
        " [MComment_Num] = {2}, [Comment_Num] = {3}, [Favour_Num] = {4}, [Browse_Num] = {5} WHERE [UserID] = {6} ";

    // 根据用户ID获取文章概况信息
    private const string GET_TOTAL_ARTICLEINFO_BY_USERID = " SELECT * FROM [UserArticleInfo] WHERE [UserID] = {0} ";

    /// <summary>
    /// 根据用户id 获取用户文章概况信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static UserArticleInfo GetArticleInfoByUserId(int userId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_TOTAL_ARTICLEINFO_BY_USERID, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            UserArticleInfo articleInfo = null;
            if (reader.Read())
            {                
                articleInfo = new UserArticleInfo();
                articleInfo.ID = (int)reader["ID"];
                articleInfo.User_id = (int)reader["UserID"];
                articleInfo.Article_num = (int)reader["Article_Num"];
                articleInfo.Del_Article_num = (int)reader["Del_Article_Num"];
                articleInfo.MComment_num = (int)reader["MComment_Num"];
                articleInfo.Comment_num = (int)reader["Comment_Num"];
                articleInfo.Favour_num = (int)reader["Favour_Num"];
                articleInfo.Browse_num = (int)reader["Browse_Num"];
            }
            reader.Close();
            return articleInfo;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 根据用户ID更新信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="articleInfo"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateInfoByUserId(int userId, UserArticleInfo articleInfo, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(UPDATE_ARTICLE_INFO_BY_USERID, articleInfo.Article_num, articleInfo.Del_Article_num, articleInfo.MComment_num,
                articleInfo.Comment_num, articleInfo.Favour_num, articleInfo.Browse_num, userId);
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
    /// 新建用户发文信息
    /// </summary>
    /// <param name="articleInfo"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool InsertUserArticleInfo(int userId, UserArticleInfo articleInfo, OleDbConnection conn)
    {
        try
        {
            int row = 0;
            if (GetArticleInfoByUserId(userId, conn) == null) // 判断是否存在记录
            {
                string sql = String.Format(INSERT_USER_ARTICLE_INFO, userId, articleInfo.Article_num, articleInfo.Del_Article_num,
                articleInfo.MComment_num, articleInfo.Comment_num, articleInfo.Favour_num, articleInfo.Browse_num);
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