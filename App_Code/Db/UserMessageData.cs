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

    //private const string GET_MY_ALL_MASSAGE_BY_USERID = " SELECT [userName], MSG.* FROM [User], [SELECT  *  FROM  UserMessage " +
    //    " WHERE  UserMessage.UserID = {0}]. AS MSG  WHERE  MSG.CommentUserID = User.userID {1} ORDER BY Comment_Time DESC ";

    private const string GET_MY_ALL_MASSAGE_BY_USERID = " SELECT TOP {0} [userName], MSG.* FROM [User], [SELECT TOP {1} *  FROM  UserMessage" +
        "  WHERE  UserMessage.UserID = {2} {3}]. AS MSG  WHERE  MSG.CommentUserID = User.userID  ORDER BY Comment_Time DESC";

    private const string GET_MSG_NUM = "SELECT COUNT(*) FROM  [UserMessage]  WHERE  [UserID] = {0} {1} ";

    /// <summary>
    /// 获取用户的消息数量
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="state"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static int GetMsgNum(int userID, string state, OleDbConnection conn)
    {
        try
        {
            string STATE = "";
            if (!state.Equals("全部"))
            {
                STATE = " AND State= '" + state + "' "; // 添加查询条件
            }

            string sql = String.Format(GET_MSG_NUM, userID, STATE);
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            return (int)cmd.ExecuteScalar();
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// 根据用户id获取用户‘全部’/‘未读’的消息，
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="state"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static OleDbDataReader GetMyMsgByUserID(int userID, int startIndex, int endIndex, string state, OleDbConnection conn)
    {
        try
        {
            string STATE = "";
            if (!state.Equals("全部"))
            {
                STATE = " AND State= '" + state + "' "; // 添加查询条件
            }

            string sql = String.Format(GET_MY_ALL_MASSAGE_BY_USERID, startIndex, endIndex, userID, STATE);
            OleDbCommand cmd = new OleDbCommand(sql, conn);           
            
            return cmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            string ms = ex.Message;
            return null;
        }
    }

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