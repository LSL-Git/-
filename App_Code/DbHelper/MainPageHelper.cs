using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// MainPageHelper 的摘要说明
/// </summary>
public class MainPageHelper
{
    private const string GET_ALL_ARTICLE = " SELECT User.userName, A.* FROM [User], [SELECT Article.*, ArticleInfo.* FROM Article, " +
        "ArticleInfo WHERE Article.ID = ArticleInfo.ArticleID ]. AS A WHERE A.UserID = User.userID  " +
        "AND [Jurisdiction] NOT IN ('待审核','未通过') ";
    // "ORDER BY Article.Jurisdiction = '热帖', Pub_Time DESC";//, Browse_Num DESC ";

    public static OleDbDataReader GetAllArticle(string type, OleDbConnection conn)
    {
        try
        {
            string sql = "";
            string jur = "Jurisdiction";

            if (type == "全部") type = "置顶";
            if (type == "原创") jur = "Type";

            sql = GET_ALL_ARTICLE + " ORDER BY Article." + jur + " = '" + type + "', Pub_Time DESC ";

            if (type == "排行")
            {
                sql = GET_ALL_ARTICLE + " ORDER BY Browse_Num desc, Pub_Time DESC ";
            }

            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            string s = e.Message;
            return null;
        }
    }
}