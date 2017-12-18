using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Article 的摘要说明
/// </summary>
public class Article
{
    public int ID;
    public int User_id;
    public string Title;
    public string Content;
    public string Type;
    public string Tag;
    public string Pub_time; // 发布时间
    public string Juri; // 权限(置顶|精华|热帖|图贴|待审核|已审核|未通过)
    public string State; // 状态(正常|禁评|已删)
}