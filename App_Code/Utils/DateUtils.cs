using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DateUtils 时间工具类
/// </summary>
public class DateUtils
{
    /// <summary>
    /// 根据当前时间产生一个序列号
    /// </summary>    
    public static long GetNumberByTime()
    {
        DateTime dateTime = new DateTime();
        string number = dateTime.ToString("yyyyMMddHHmmss") + dateTime.Millisecond.ToString("D3");
        return long.Parse(number);
    }

    /// <summary>
    /// 获取当前系统时间
    /// </summary>
    /// <returns></returns>
    public static string GetNowTime()
    {
        return System.DateTime.Now.ToString();
    }
}