using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserMessage 的摘要说明
/// </summary>
public class UserMessage
{
    public int ID;
    public int UserID;
    public int ArticleID;
    public string bComm_Content;
    public int Comm_UserID;
    public string Comm_Content;
    public string Comm_Time;
    public string State; // 未读|已读
}