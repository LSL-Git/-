using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// DraftData 的摘要说明
/// </summary>
public class DraftData
{
    // 插入草稿信息
    private const string INSERT_DRAFT = " INSERT INTO [Draft] ([userID], [Title], [Content], [Type], " +
        "[Tag], [create_time]) VALUES ({0}, '{1}', \'{2}\', '{3}', '{4}', '{5}') ";

    // 根据用户id获取用户的所有草稿信息 根据create_time降序
    private const string GET_ALL_DRAFT_BY_USERID = " SELECT * FROM [Draft] WHERE [userID] = {0} " +
        "ORDER BY [create_time] DESC";

    // 根据id删除对应数据
    private const string DELETE_DRAFT_BY_ID = " DELETE * FROM [Draft] WHERE [ID] = {0} ";

    // 根据草稿id和用户id获取草稿信息
    private const string GET_DRAFT_BY_USERID_AND_ID = " SELECT * FROM [Draft] WHERE [ID] = {0} AND [userID] = {1} ";

    // 更新草稿
    private const string UPDATE_DRAFT_BY_USERID_DRAFTID = " UPDATE [Draft] SET [Title] = '{0}', [Content] = '{1}', " +
        " [Type] = '{2}', [Tag] = '{3}', [create_time] = '{4}' WHERE [ID] = {5} AND [userID] = {6} ";

    /// <summary>
    /// 根据用户ID和草稿ID更新草稿内容
    /// </summary>
    /// <param name="draft"></param>
    /// <param name="userId"></param>
    /// <param name="draftId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateDraftById(Draft draft, int userId, int draftId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(UPDATE_DRAFT_BY_USERID_DRAFTID, draft.Title, draft.Content.Replace("'", "‘"),
                draft.Type, draft.Tag, draft.create_time, draftId, userId );
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
    /// 根据草稿id和用户id获取草稿信息
    /// </summary>
    /// <param name="draftId"></param>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static Draft GetDraftById(int draftId, int userId, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(GET_DRAFT_BY_USERID_AND_ID, draftId, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Draft draft = new Draft();
            if (reader.Read())
            {
                draft.ID = (int)reader["ID"];
                draft.userId = (int)reader["userID"];
                draft.Title = reader["Title"] + "";
                draft.Content = reader["Content"] + "";
                draft.Type = reader["Type"] + "";
                draft.Tag = reader["Tag"] + "";
                draft.create_time = reader["create_time"] + "";
            }
            reader.Close();
            return draft;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 根据id删除草稿信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool DeleteDraftById(int id, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(DELETE_DRAFT_BY_ID, id);
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
    /// 保存新建草稿
    /// </summary>
    /// <param name="darft"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool AddNewDraft(Draft darft, OleDbConnection conn)
    {
        try
        {
            string sql = String.Format(INSERT_DRAFT, darft.userId, darft.Title,
                        darft.Content.Replace("'","‘"), darft.Type, darft.Tag, darft.create_time);
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
    /// 根据用户id获取该用户的所有草稿信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DataTable GetDraftByUserId(int userId, OleDbConnection conn)
    {   
        try
        {
            DataTable draftTable = new DataTable();
            string sql = String.Format(GET_ALL_DRAFT_BY_USERID, userId);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            draftTable.Load(reader);
            reader.Close();
            return draftTable;
        }
        catch (Exception)
        {
            return null;
        }
        
    }
}