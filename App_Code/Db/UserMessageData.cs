using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// UserMessageData 的摘要说明
/// </summary>
public class UserMessageData
{
    // 新建用户消息
    private const string INSERT_NEW_MESSAGE = " INSERT INTO [UserMessage] ([UserID], [ArticleID], [BComment_Content], [Comment_Content], " +
        " [CommentUserID], [Comment_Time], [State]) VALUES ({0}, {1}, '{2}', '{3}', {4}, '{5}', '{6}') ";

    /// <summary>
    /// 新建用户消息
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool InsertNewMessage(UserMessage msg, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(INSERT_NEW_MESSAGE, msg.UserID, msg.ArticleID, msg.bComm_Content, 
                msg.Comm_Content, msg.Comm_UserID, msg.Comm_Time, msg.State);
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