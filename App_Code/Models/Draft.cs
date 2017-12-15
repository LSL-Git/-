using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Draft 草稿表 models
/// </summary>
public class Draft
{
    public int ID;
    public int userId;
    public string Title;
    public string Content;
    public string Type;
    public string Tag;
    public string create_time;
}