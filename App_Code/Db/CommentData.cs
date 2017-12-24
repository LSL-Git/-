using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// CommentData 的摘要说明
/// </summary>
public class CommentData
{
    // 给文章添加新评论
    private const string INSERT_NEW_COMMMENT = " INSERT INTO [ArticleComment] ([ArticleID], [Comment_UserID], [Comment_Content], " +
        "[Comment_Time], [Floor]) VALUES ({0}, {1}, '{2}', '{3}', {4}) ";

    // 根据文章id获取该文章的所有评论
    private const string GET_ALL_COMMENT_BY_ARTICLEID = " SELECT ArticleComment.*, User.userName, User.img FROM ArticleComment, [User] " +
        "WHERE User.userID = ArticleComment.Comment_UserID AND ArticleID = {0} "; // ORDER BY [Comment_Time] DESC ";

    private const string GET_FLOOR_NUM = " SELECT COUNT(*) FROM [ArticleComment] WHERE [ArticleID] = {0} ";

    /// <summary>
    /// 根据文章id获取该文章的所有评论
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="conn"></param>
    public static OleDbDataReader GetAllCommentByArticleID(int articleId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_ALL_COMMENT_BY_ARTICLEID, articleId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteReader();
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 获取当前文章评论楼层数
    /// </summary>
    /// <param name="articleID"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static int GetFloorByArticleId(int articleID, OleDbConnection conn)
    {
        try
        {
            string sql2 = String.Format(GET_FLOOR_NUM, articleID);
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
            return (int)cmd2.ExecuteScalar();
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// 给文章添加新评论
    /// </summary>
    /// <param name="comment"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool InsertNewCommentForArticle(Comment comment, OleDbConnection conn)
    {
        try
        {            
            int newFloor = GetFloorByArticleId(comment.ArticleID, conn) + 1;

            string sql = String.Format(INSERT_NEW_COMMMENT, comment.ArticleID, comment.Comm_userID, 
                            comment.Comm_Content, comment.Comm_Time, newFloor);
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