using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// DraftHelper 没错。这个类就是多此一举
/// </summary>
public class DraftHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 更新草稿
    /// </summary>
    /// <param name="draft"></param>
    /// <param name="userId"></param>
    /// <param name="draftId"></param>
    /// <returns></returns>
    public static bool UpdateDraft(Draft draft, int userId, int draftId)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = DraftData.UpdateDraftById(draft, userId, draftId, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    /// 保存新建草稿
    /// </summary>
    /// <param name="draft"></param>
    /// <returns></returns>
    public static bool InsertNewDraft(Draft draft)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = DraftData.AddNewDraft(draft, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    ///  根据用户id获取用户所有草稿
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static DataTable GetAllDraftByUserId(int userId)
    {
        DataTable draft = new DataTable();
        lock (mLockObj)
        {
            mdb.Connect();
            draft = DraftData.GetDraftByUserId(userId, mdb.GetConn);
            mdb.Disconnect();
        }
        return draft;
    }

    /// <summary>
    /// 根据id删除草稿信息
    /// </summary>
    /// <param name="draftId"></param>
    /// <returns></returns>
    public static bool DeleteDraftById(int draftId)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = DraftData.DeleteDraftById(draftId, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    /// 根据草稿id和用户id获取草稿信息
    /// </summary>
    /// <param name="draftId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static Draft GetDraftById(int draftId, int userId)
    {
        Draft draft = new Draft();
        lock (mLockObj)
        {
            mdb.Connect();
            draft = DraftData.GetDraftById(draftId, userId, mdb.GetConn);
            mdb.Disconnect();
        }
        return draft;
    }
}