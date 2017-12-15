using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// ArticleTypeDate 的摘要说明
/// </summary>
public class ArticleTagDate
{
    private const string GET_ALL_ARTICLE_TAG = " SELECT * FROM ArticleTag ";

    /// <summary>
    /// 获取文章所有类型
    /// </summary>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static OleDbDataAdapter GetAllArticleTag(OleDbConnection conn)
    {
        OleDbDataAdapter typeData = new OleDbDataAdapter(GET_ALL_ARTICLE_TAG, conn);
        return typeData;
    }
}