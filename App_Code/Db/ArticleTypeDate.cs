using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// ArticleTypeDate 的摘要说明
/// </summary>
public class ArticleTypeDate
{
    private const string GET_ALL_ARTICLE_TYPE = " SELECT * FROM ArticleType ";

    /// <summary>
    /// 获取文章所有类型
    /// </summary>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static OleDbDataAdapter GetAllArticleType(OleDbConnection conn)
    {
        OleDbDataAdapter typeData = new OleDbDataAdapter(GET_ALL_ARTICLE_TYPE, conn);
        return typeData;
    }
}