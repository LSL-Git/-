using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MsgAndCommHelper 的摘要说明
/// </summary>
public class MsgAndCommHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 执行提交评论业务，将评论信息存入数据库
    /// </summary>
    /// <param name="comment"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static bool CommitComment(Comment comment, UserMessage msg)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = CommentData.InsertNewCommentForArticle(comment, mdb.GetConn);
            result = UserMessageData.InsertNewMessage(msg, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
}