﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Comment 的摘要说明
/// </summary>
public class Comment
{
    public int ID;
    public int ArticleID;
    public int Comm_userID;
    public string Comm_Content;
    public string Comm_Time;
    public int Floor; // 楼层
}